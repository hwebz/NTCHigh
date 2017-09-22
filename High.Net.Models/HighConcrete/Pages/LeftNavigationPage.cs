using Castle.DynamicProxy;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAbstraction.RuntimeModel;
using EPiServer.Framework;
using EPiServer.Logging.Compatibility;
using EPiServer.ServiceLocation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace High.Net.Models.HighConcrete.Pages
{
    public class LeftNavigationPage : HighConcretePageData
    {
        #region Content

        [Display(
            Name = "Display In Left Navigation",
            GroupName = High.Net.Core.Global.Tabs.Content,
            Description = "By clicking on checkbox this page will display in left navigation",
            Order = 300)]
        public virtual bool DisplayInLeftNavigation { get; set; }

        #endregion

        //Sets the default property values

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            DisplayInLeftNavigation = true;
        }
    }

    
}
