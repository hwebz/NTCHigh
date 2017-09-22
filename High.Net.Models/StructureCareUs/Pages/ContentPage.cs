using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.StructureCareUs.Blocks;
using High.Net.Core.ContentTypes.Blocks;

namespace High.Net.Models.StructureCareUs.Pages
{
    [SiteContentType(GroupName = SiteGroups.SCU, Order = 9020, DisplayName = "Content Page", GUID = "dcd1f89e-c593-48ea-8168-1e3621dbd092", Description = "")]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage)})]    
    public class ContentPage : StructureCareUsPageData
    {
        [Display(
        Description = "Page Content Area",
        GroupName = Global.Tabs.Content,
        Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock) , typeof(ImageTextBlock),typeof(ContactPersonBlock) )]
        public virtual ContentArea PageContentArea { get; set; }
    }
}