using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(GroupName = SiteGroups.HSS, DisplayName = "Building Project Page", GUID = "10dc5cad-0f56-41d2-b599-cb305db09db6", Order = 18120, Description = "")]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage) })]
    public class BuildingProjectPage : HighSteelStructurePageData
    {
        #region Content

        [Display(
           Name = "To Email IDs(comma separated)",
           GroupName = Global.Tabs.Content,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 1300)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Subject",
           GroupName = Global.Tabs.Content,
           Description = "Subject Of Mail",
           Order = 1400)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "Mail Body",
           GroupName = Global.Tabs.Content,
           Description = "To End User",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }
        
        [Display(
           Name = "Thank you message",
           GroupName = Global.Tabs.Content,
           Description = "This message is display after submit.",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion
    }
}