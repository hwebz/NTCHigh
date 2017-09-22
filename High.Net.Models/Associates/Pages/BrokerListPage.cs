using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Associates.Blocks;
using ImageVault.EPiServer;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(GroupName = SiteGroups.HA,
        DisplayName = "Brokers List Page",
        GUID = "57e65d67-4f89-41dc-8377-dad62f7059b3",
        Description = "Brokers List Page",
        Order = 7010)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(BrokerPage) })]    
    public class BrokerListPage : AssociatesPageData, IAssociates
    {
        #region Content

        [Display(
          Name = "Contact Area",
          Description = "Contact Area",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}