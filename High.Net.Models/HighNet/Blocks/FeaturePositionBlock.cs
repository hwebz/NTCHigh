using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using Global = High.Net.Core.Global;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Feature Positions Table", GUID = "956b5bdd-5c73-4357-b942-8f24190bc430", Description = "", Order = 10760)]
    public class FeaturePositionBlock : HighNetBlockData
    {
        #region Image

        [Display(
           Name = "Background Image",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        public virtual MediaReference BackgroundImage { get; set; }

        #endregion

        #region Content

        [CultureSpecific]
        [Display(
            Name = "Title",
            Description = "Title",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [Display(
           Name = "See All Position Link",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 200)]
        public virtual Url SeeAllPositionLink { get; set; }

        [Display(
            Name = "Feature Position Items",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display feature position items",
            Order = 200)]
        [AllowedTypes(typeof(FeaturePositionItemBlock))]
        public virtual ContentArea FeaturePositionItems { get; set; }

        #endregion       

    }
}