using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Associates.Blocks;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "Content Page",
        GUID = "91dbf4ce-c1d2-4b4f-ae8b-265982d5ea46",
        Description = "Content Page with content area",
        Order=7050)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage),typeof(BrokerPage)})]    
    public class ContentPage : AssociatesPageData, IAssociates
    {
        #region Content

        [Display(
          Description = "Contact Area",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}