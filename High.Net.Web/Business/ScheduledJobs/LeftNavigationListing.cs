using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using EPiServer;
using High.Net.Core;
using High.Net.Models.HighConcrete.Pages;
using System.Linq;
using EPiServer.ServiceLocation;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High-Concrete LeftNavigationListing", SortIndex = 900)]
    public class LeftNavigationListing : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;
        

        public LeftNavigationListing()
        {
            IsStoppable = true;
        }

        /// <summary>
        /// Called when a user clicks on Stop for a manually started job, or when ASP.NET shuts down.
        /// </summary>
        public override void Stop()
        {
            _stopSignaled = true;
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
                var result = SetLeftnavigationProperty();
                
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

               
                if (_stopSignaled)
                {
                    return "Stop of job was called";
                }

                return result;
            }
            else
            {
                return "You do not have the permission";
            }
        }

        public string SetLeftnavigationProperty()
        {
            var _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
            var _contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();

            string result = string.Empty;

            result = SetPropertyForPages(_contentRepo, PageReference.StartPage);
           

            return "All specific Products and Projects pages set in left navigation";
        }

        private string SetPropertyForPages(IContentRepository _contentRepo, PageReference pageReference)
        {
            var DecendantsPages = _contentRepo.GetDescendents(pageReference).Where(x => _contentRepo.Get<IContent>(x) is LeftNavigationPage).Select(_contentRepo.Get<LeftNavigationPage>);

            foreach (var item in DecendantsPages)
            {
                var clone = (LeftNavigationPage)item.CreateWritableClone();
                clone.DisplayInLeftNavigation = true;
                _contentRepo.Save(clone, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            }

            return null;
        }

    }
}
