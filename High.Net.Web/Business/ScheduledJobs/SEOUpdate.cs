using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer.Scheduler;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using System.Text;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using EPiServer;
using CsvHelper;
using EPiServer.DataAccess;
using High.Net.Core;
using EPiServer.Security;
using EPiServer.Logging;
using High.Net.Models.RootPage;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - SEO Update", SortIndex = 600)]
    public class SEOUpdate : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(SEOUpdate));

        public SEOUpdate()
            : base()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
            base.Stop();
        }

        /// <summary>
        /// Called when a scheduled job executes
        /// </summary>
        /// <returns>A status message to be stored in the database log and visible from admin mode</returns>
        public override string Execute()
        {
            SysRoot _sysRoot = _contentRepo.Get<SysRoot>(PageReference.RootPage);
            bool JobAccess = _sysRoot.ExecuteScheduleJobs;
            if (JobAccess)
            {
                string siteName = string.Empty;

                try
                {
                    var contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();

                    siteName = contentRepo.Get<PageData>(EPiServer.Web.SiteDefinition.Current.StartPage).Name;
                    var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"App_Data\SEO\{0}.csv", siteName));

                    string fName = filePath.Split(new char[] { '\\' }).LastOrDefault();

                    //Status Changed
                    OnStatusChanged(String.Format("Updating Site {0}", siteName));

                    List<SEORecord> records = new List<SEORecord>();

                    using (StreamReader textReader = new StreamReader(filePath, Encoding.Default))
                    {
                        using (var csvReader = new CsvReader(textReader))
                        {
                            records = csvReader.GetRecords<SEORecord>().ToList();
                            for (int r = 0; r < records.Count; r++)
                            {

                                try
                                {
                                    //Status Changed
                                    OnStatusChanged(String.Format("Updating file {0}: Pages {1} of {2}", fName, r + 1, records.Count));

                                    if (!string.IsNullOrEmpty(records[r].NewUrl) && records[r].Status != "Updated")
                                    {
                                        string pageUrl = records[r].NewUrl;

                                        if (!records[r].NewUrl.StartsWith("http://"))
                                            pageUrl = "http://" + pageUrl;

                                        var contentReference = UrlResolver.Current.Route(new UrlBuilder(pageUrl));

                                        if (contentReference != null)
                                        {
                                            var pageData = contentRepo.Get<BasePageData>(contentReference.ContentLink);
                                            var writablepageData = pageData.CreateWritableClone();

                                            writablepageData["MetaTitle"] = records[r].Title;
                                            writablepageData["MetaKeywords"] = records[r].Keyword;
                                            writablepageData["MetaDescription"] = records[r].Description;

                                            contentRepo.Save((IContent)writablepageData, SaveAction.Publish | SaveAction.ForceCurrentVersion, AccessLevel.NoAccess);

                                            records[r].Status = "Updated";
                                        }
                                        else
                                        {
                                            records[r].Status = "Skipped";
                                        }
                                    }
                                    else
                                    {
                                        records[r].Status = "Skipped";
                                    }

                                    Logger.Error(string.Format("Site: {0}, Row: {1}, New Url: {2}, Status: {3}", siteName, r + 1, records[r].NewUrl, records[r].Status));

                                    //If Stopped
                                    if (_stopSignaled)
                                    {
                                        return string.Format("Site: {0}, Status: {1}", siteName, "Job Stopped");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    records[r].Status = "Skipped";
                                    Logger.Error(string.Format("Site: {0}, Row: {1}, New Url: {2}, Status: {3}", siteName, r + 1, records[r].NewUrl, ex.StackTrace));
                                }
                            }
                        }
                    }

                    //write file
                    using (StreamWriter textWriter = new StreamWriter(filePath, false, Encoding.Default))
                    {
                        using (var csvWriter = new CsvWriter(textWriter))
                        {
                            csvWriter.WriteRecords(records);
                        }
                    }

                    return string.Format("Site: {0}, Status: {1}", siteName, "OK");
                }
                catch (Exception ex)
                {
                    return string.Format("Site: {0}, <br/> Status: {2}", siteName, ex.StackTrace);
                }
            }
            else
            {
                return "You do not have the permission";
            }
        }

        public class SEORecord
        {
            public string OldUrl { get; set; }
            public string NewUrl { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Keyword { get; set; }
            public string Status { get; set; }
        }
    }
}
