using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EPiServer.ServiceLocation;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "Project Listing Page",
        GUID = "6fc61620-48b6-41e7-bb46-cb78977e5405",
        Description = "",
        Order = 18020)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ProjectItemPage) })]
    public class ProjectListingPage : HighSteelStructurePageData
    {
        public ProjectListingPage()
        {
            var ContentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            var BridgeProjectType = ContentLocator.GetCategories(PropertyCategories.BridgeProjectType);
            ddProjectType = new List<SelectListItem>();
            foreach (var item in BridgeProjectType.Categories)
            {
                ddProjectType.Add(new SelectListItem() { Text = item.Name, Value = item.Name });
            }
        }

        #region Content

        [Display(
            Name = "Is Project Type Filter Enable?",
            GroupName = Global.Tabs.Content,
            Description = "Is Project Type Filter Enable?",
            Order = 1200)]
        public virtual bool IsProjectTypeFilter { get; set; }

        #endregion

        #region Images

        [Display(
            Name = "Project Category Image (Width : 545 , Height : 300)",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 1100)]
        public virtual MediaReference CategoryImage { get; set; }

        #endregion

        [Ignore]
        public List<SelectListItem> ddProjectType { get; set; }
    }
}