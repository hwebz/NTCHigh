using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.HighAppraisal.Blocks;


namespace High.Net.Models.HighAppraisal.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HAPP,
        DisplayName = "Content Page",
        GUID = "feace5f8-d6e1-49b1-a2bb-4c582d9bcf36",
        Description = "",
        Order=14020)]    
    public class ContentPage : HighAppraisalPageData , IHighAppraisal
    {
        #region Content

        [Display(
            Name = "Main Content",
            GroupName = Global.Tabs.Content,
            Description = "",
            Order = 1100)]
        [AllowedTypes(typeof(TextBlock), typeof(ImageTextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}