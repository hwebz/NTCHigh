using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Residential.Blocks;
using EPiServer.Web;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(GroupName = SiteGroups.BR,
        DisplayName = "Standard Page",
        GUID = "de85da08-7f54-469a-b51e-e5c9ba491b48",
        Description = "Standard page for floor plans Accordian and Faqs",
        Order = 5030)]
    [AvailableContentTypes(
       Availability.None)]    
    public class StandardPage : ResidentialPageData, IResidential
    {
        #region Content

        [Display(
          Name = "Show Quick Navigation",
          Description = "Show Quick Navigation",
          GroupName = Global.Tabs.Content,
          Order = 2100)]
        public virtual bool ShowQuickNavigation { get; set; }

        [Display(
          Description = "Top Content Area",
          GroupName = Global.Tabs.Content,
          Order = 2200)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(TextBlock)})]
        public virtual ContentArea TopContentArea { get; set; }

        [Display(
          Description = "Accordion Content Area",
          GroupName = Global.Tabs.Content,
          Order = 2210)]
        [CultureSpecific]
        [AllowedTypes(new[] { typeof(TextBlock), typeof(PlanTypeBlock), typeof(FaqBlock), typeof(ProjectsBlock) ,typeof(ImageTextBlock) })]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}