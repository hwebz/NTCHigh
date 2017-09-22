using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using EPiServer.ServiceLocation;

namespace High.Net.Web.Business.Services
{
    [ServiceConfiguration(typeof(ILogFileService))]
    public class LogFileService : ILogFileService
    {
        public IEnumerable<LogFileItem> LogFiles()
        {
            var filenames = Directory.GetFiles(PhysicalPathTo());

            foreach (var filename in filenames)
            {
                var fileInfo = new FileInfo(filename);
                yield return new LogFileItem
                {
                    Server = Environment.MachineName,
                    Name = fileInfo.Name,
                    Size = fileInfo.Length,
                    Changed = fileInfo.LastWriteTime,
                    Created = fileInfo.CreationTime
                };
            }
        }

        public string ReadFile(LogFileItem item)
        {
            var physicalPath = PhysicalPathTo(item);
            if (!File.Exists(physicalPath))
            {
                throw new FileNotFoundException("Unable to locate file.");
            }

            return File.ReadAllText(physicalPath);
        }

        public string PhysicalPathTo(LogFileItem item = null)
        {
            var file = item != null ? item.Name : string.Empty;
            var logDir = ConfigurationManager.AppSettings["LogDirectoryName"] ?? "App_Data";
            return Path.Combine(HttpContext.Current.Server.MapPath("~"), logDir, file);
        }
    }
    public class LogFileItem
    {
        public string Server { get; set; }
        public string Name { get; set; }
        public double Size { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }

    }
}