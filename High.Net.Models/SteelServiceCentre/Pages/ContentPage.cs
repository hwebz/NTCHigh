using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.SteelServiceCentre.Blocks;
using High.Net.Core.ContentTypes.Blocks;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    [SiteContentType(GroupName = SiteGroups.SSC,
        DisplayName = "Content Page",
        GUID = "4fad0e20-5e3f-4901-b819-8e04fab602de",
        Description = "", Order = 6020)]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage) })]
    
    public class ContentPage : SteelServiceCentrePageData
    {

        [Display(
        Name = "Content Area",
        GroupName = Global.Tabs.Content,
        Description = "Content Area",
        Order = 2100)]
        [AllowedTypes(typeof(ServicesBlock), typeof(TextBlock), typeof(ImageGalleryBlock),typeof(ImageTextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
        Name = "Allow SideBar",
        GroupName = Global.Tabs.Content,
        Description = "Add Sidebar Content",
        Order = 2100)]
        public virtual bool IsSideBar { get; set; }

        [Display(
        Name = "Sidebar Content Area",
        GroupName = Global.Tabs.Content,
        Description = "Add Sidebar Content",
        Order = 2100)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea SidebarContentArea { get; set; }

    }
}