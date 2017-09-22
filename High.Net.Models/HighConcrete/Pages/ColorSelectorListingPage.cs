using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;
using High.Net.Models.HighConcrete.Blocks;
using EPiServer.Web;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Color Selector Listing Page",
        GUID = "037eed0d-c6ec-4123-ad88-9267ee935f59",
        Description = "",
        Order=13160)]    
    [AvailableContentTypes(Availability.None)]
    public class ColorSelectorListingPage : HighConcretePageData , IHighConcrete
    {
        #region Content

        [Display(
            Name = "Color/Finish Selector Data",
            GroupName = Global.Tabs.Content,
            Description = "Color/Finish Selector Data",
            Order = 1100)]
        public virtual MediaReference ColorFinisherData { get; set; }


        [Display(
            Name = "Main Content Area",
            GroupName = Global.Tabs.Content,
            Description = "Main Content Area contains ColorFinishes Block",
            Order = 1200)]
        [AllowedTypes(typeof(ColorFinishesBlock))]
        public virtual ContentArea mainContentArea { get; set; }

        [Display(
            Name = "No Combination Message",
            GroupName = Global.Tabs.Content,
            Description = "No Combination Message",
            Order = 1300)]
        [UIHint(UIHint.LongString)]
        public virtual String NoCombinationMessage { get; set; }

        #endregion
    }
}