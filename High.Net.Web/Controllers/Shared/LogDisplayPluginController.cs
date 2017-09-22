using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using High.Net.Web.Business.Services;

namespace High.Net.Web.Controllers.Shared
{
    [GuiPlugIn(Area = PlugInArea.AdminMenu, Url = "/LogDisplayPlugin", DisplayName = "Log Retrieval")]
    [Authorize(Roles = "CmsAdmins")]
    public class LogDisplayPluginController:Controller
    {
        private readonly ILogFileService _logFileService;

        public LogDisplayPluginController()
        {
            _logFileService = ServiceLocator.Current.GetInstance<ILogFileService>();
        }

        public ActionResult Index()
        {
            var files = _logFileService
                .LogFiles()
                .OrderByDescending(f => f.Changed);

            return View("~/Views/Shared/AdminTool/Index.cshtml",files);
        }

        [HttpGet]
        public ActionResult LogFileStream(LogFileItem item)
        {
            if (IsBadItem(item))
            {
                throw new Exception("Something went wrong with your request.");
            }

            return new LogFileResult(item.Name, stream => WriteFrom(item, stream));
        }

        private bool IsBadItem(LogFileItem item)
        {
            return !item.Name.EndsWith(".log") ||
                   item.Name.Contains("/") ||
                   item.Name.Contains(@"\") ||
                   item.Name.Contains(":") ||
                   !System.IO.File.Exists(_logFileService.PhysicalPathTo(item));
        }

        private void WriteFrom(LogFileItem item, Stream stream)
        {
            var content = _logFileService.ReadFile(item);
            var bytes = Encoding.UTF8.GetBytes(content);
            stream.Write(bytes, 0, bytes.Length);
        }

        public class LogFileResult : FileResult
        {
            private readonly Action<Stream> content;

            public LogFileResult(string fileName, Action<Stream> content, string contentType = "text/plain")
                : base(contentType)
            {
                if (content == null) throw new ArgumentNullException("content");
                this.content = content;
                this.FileDownloadName = fileName;
            }

            protected override void WriteFile(HttpResponseBase response)
            {
                this.content(response.OutputStream);
            }
        }
    }
}