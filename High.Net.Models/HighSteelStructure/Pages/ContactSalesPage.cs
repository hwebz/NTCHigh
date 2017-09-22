using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.HighSteelStructure.Blocks;
using EPiServer.Web;
using High.Net.Models.Constants;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(GroupName = SiteGroups.HSS, DisplayName = "Contact Sales Page", GUID = "ae707d1e-47d6-4756-a21e-423f35192ce8", Description = "", Order = 18300)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage) })]
    public class ContactSalesPage : HighSteelStructurePageData
    {
        #region Content

        [Display(
           Name = "Main Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
           Name = "To Email IDs(comma separated)",
           GroupName = Global.Tabs.EmailSetting,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 1300)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Subject",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Subject Of Mail",
           Order = 1400)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "Mail Body",
           GroupName = Global.Tabs.EmailSetting,
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