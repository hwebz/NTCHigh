using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.HighSteelStructure.Blocks;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [SiteContentType(
        DisplayName = "NEXT Beam Budget Price Page",
        GroupName = SiteGroups.HSS,
        GUID = "85400051-B65D-4B0B-8BF3-9F902EE04C28",
        Description = "NEXT Beam Budget Price Page",
        Order = 18130)]    
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage) })]
    public class NEXTBeamBudgetPricePage : HighSteelStructurePageData
    {
        #region Content

        [Display(
           Name = "To Email ID",
           GroupName = Global.Tabs.Content,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 1300)]
        [UIHint(UIHint.LongString)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Subject",
           GroupName = Global.Tabs.Content,
           Description = "Subject Of Mail",
           Order = 1400)]
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