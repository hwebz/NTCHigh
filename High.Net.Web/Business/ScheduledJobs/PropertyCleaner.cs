using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using System.Text;
using System.IO;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer;
using System.Collections.Generic;
using High.Net.Models.Shared.Pages;
using ImageVault.Client.Query;
using EPiServer.Web.Routing;
using CsvHelper;
using System.Web;
using High.Net.Core;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Property Pages Cleaner", SortIndex = 800)]
    public class PropertyCleaner : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;
        //private static readonly ILogger Logger = LogManager.GetLogger(typeof(PropertyCleaner));
        public PropertyCleaner()
        {
            IsStoppable = true;
        }

        #region Schedule Methods

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
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                string msg = RunMigration();

                if (_stopSignaled)
                {
                    return msg;
                }

                return msg;
            }
            else
            {
                return "You do not have the permission";
            }
        }

        #endregion

        #region Cleaning Properties

        public string RunMigration()
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            var _client = ImageVault.Client.ClientFactory.GetSdkClient();
            var resolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var _newProperties = new List<string>();
            var _allProperties = _contentLocator.GetAll<PropertyPage>(PageReference.RootPage);
            int counter = 0;

            var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"App_Data\import\All Properties.csv"));
            //Logger.Error(string.Format("\t Property Name \t Bussiness Key \t Corporate Center \t Status"));
            using (StreamReader textReader = new StreamReader(filePath, Encoding.Default, true))
            {
                using (var csvReader = new CsvReader(textReader))
                {
                    OnStatusChanged(String.Format("Reading File"));
                    while (csvReader.Read())
                    {
                        string BusinessKey = csvReader.GetField<String>("Business Key");

                        _newProperties.Add(BusinessKey);
                    }
                }
            }

            int allPages = _allProperties.Count();
            int cleanerCounter = 0;
            foreach (var item in _allProperties)
            {
                try
                {
                    OnStatusChanged(String.Format("Cleaning: Pages {0} out of {1}", counter, allPages));
                    int propertyCount = _newProperties.Where(x => x.Trim() == item.BusinessKey.Trim()).Count();

                    if (propertyCount > 0)
                    {
                        //Logger.Error(string.Format("\t {0} \t {1} \t {2} \t {3}",
                        //    item.PropertyName, item.BusinessKey, item.CorporateCenter, "Not_Deleted"));
                    }
                    else
                    {
                        _contentRepo.Delete(item.ContentLink, true, EPiServer.Security.AccessLevel.NoAccess);
                        cleanerCounter++;
                        //Logger.Error(string.Format("\t {0} \t {1} \t {2} \t {3}",
                        //    item.PropertyName, item.BusinessKey, item.CorporateCenter, "Deleted"));
                    }
                    counter++;
                }
                catch (Exception ex)
                {
                    //Logger.Error(string.Format("\t {0} \t {1} \t {2} \t {3}",
                    //item.PropertyName, item.BusinessKey, item.CorporateCenter, ex.StackTrace));
                }
            }
            return string.Format("clean successfully, {0} pages deleted.", cleanerCounter);
        }

        #endregion

    }
}
