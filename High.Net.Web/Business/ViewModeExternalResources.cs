using EPiServer.Forms.Helpers.Internal;
using EPiServer.Configuration;
using EPiServer.Forms.Implementation;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;

namespace High.Net.Web.Business
{
    /// <summary>
    /// </summary>
    [ServiceConfiguration(ServiceType = typeof(IViewModeExternalResources))]
    public class ViewModeExternalResources : IViewModeExternalResources
    {
        public virtual IEnumerable<Tuple<string, string>> Resources
        {
            get
            {
                //var publicVirtualPath = ModuleHelper.GetPublicVirtualPath(Constants.ModuleName);
                var currentPageLanguage = FormsExtensions.GetCurrentPageLanguage();

                var arrRes = new List<Tuple<string, string>>();

                arrRes.Add(new Tuple<string, string>("script", "/ClientResources/ViewMode/EPiServerFormsExternal.js"));

                return arrRes;
            }
        }
    }
}