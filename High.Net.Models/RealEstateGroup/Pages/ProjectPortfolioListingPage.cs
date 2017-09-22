using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.RealEstateGroup.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.Shared.Pages
{
    [ContentType(
        GroupName = SiteGroups.REG,
        DisplayName = "Project Portfolio Listing Page",
        GUID = "0F95303D-DDA9-4F25-B8A8-E3D6BFD178EA",
        Description = "Portfolio Project Listing Page",
        Order=8050)]
    [AvailableContentTypes(Availability.None)]
    public class ProjectPortfolioListingPage : BasePageData
    {
        #region Images

        [Display(
           Name = "Banner Image (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "Size: 1400x430",
           Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Portfolio Content Area",
            GroupName = Global.Tabs.Content,
            Description = "Content Area contains Portfolio Block",
            Order = 1200)]
        [AllowedTypes(typeof(ProjectPortfolioBlock))]
        public virtual ContentArea PortfolioContentArea { get; set; }

        [Display(
            Name = "Location Content Area",
            GroupName = Global.Tabs.Content,
            Description = "Content Area contains Location Block",
            Order = 1100)]
        [AllowedTypes(typeof(LocationBlock))]
        public virtual ContentArea LocationContentArea { get; set; }

        #endregion
    }
}