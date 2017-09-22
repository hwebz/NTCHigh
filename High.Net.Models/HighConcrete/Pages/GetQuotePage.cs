using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Get Quote Page",
        GUID = "fb5de23b-f8c5-4420-9882-9917f3eb29be",
        Description = "",
        Order = 13080)]
    public class GetQuotePage : HighConcretePageData
    {
        #region Content

        [Display(
           Name = "To Email ID",
           GroupName = Global.Tabs.Content,
           Description = "To End User",
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
           Description = "Mail Body",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "Mail Body for User",
           GroupName = Global.Tabs.Content,
           Description = "This mail will send to the user who fill this form.",
           Order = 1500)]
        public virtual XhtmlString MailBodyForUser { get; set; }

        [Display(
           Name = "Thank you Message",
           GroupName = Global.Tabs.Content,
           Description = "display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion

    }
}