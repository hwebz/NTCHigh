using System;
using System.Linq;
using System.Web;
using EPiServer;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using System.IO;
using EPiServer.Core;
using EPiServer.Logging;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Fetch All Site Page URL", SortIndex = 700)]
    public class FetchSitePageURL : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(FetchSitePageURL));

        public FetchSitePageURL()
        {
            IsStoppable = true;
        }


        public override void Stop()
        {
            _stopSignaled = true;
        }

        public override string Execute()
        {
            SysRoot _sysRoot = _contentRepo.Get<SysRoot>(PageReference.RootPage);
            bool JobAccess = _sysRoot.ExecuteScheduleJobs;

            if (JobAccess)
            {
                string status = FetchPageURL();
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                if (_stopSignaled)
                {

                }

                return status;
            }
            else
            {
                return "You do not have the permission";
            }
        }


        #region Fetch Site Page URL

        public string FetchPageURL()
        {
            try
            {
                var contentRepository = ServiceLocator.Current.GetInstance<EPiServer.IContentRepository>();

                var list = contentRepository.GetDescendents(EPiServer.Core.ContentReference.RootPage)
                                            .Select(contentRepository.Get<EPiServer.Core.IContent>)
                                            .ToList();

                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Site_URL.txt");

                string url = string.Empty;
                FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);

                foreach (var page in list)
                {

                    string s = page.Name;
                    url = EPiServer.Web.Routing.UrlResolver.Current.GetUrl(page.ContentLink, null, new EPiServer.Web.Routing.VirtualPathArguments { ContextMode = EPiServer.Web.ContextMode.Default });
                    if (!string.IsNullOrEmpty(url))
                    {
                        sw.WriteLine(url);
                        sw.Flush();
                    }

                }
                sw.Close();

                return "Fetched All site page URL !";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        #endregion

    }
}