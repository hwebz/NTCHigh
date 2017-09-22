using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcreteAccessories.Blocks;
using EPiServer.Web;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "News Letter Page",
        GUID = "c5438bfe-ced7-4b03-a4ce-7780da6e7136",
        Description = "",
        Order=15040)]

    public class NewsLetterPage : HighConcreteAccessoriesPageData
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
           Description = "To End User",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "Signature",
           GroupName = Global.Tabs.Content,
           Description = "To End User",
           Order = 1600)]
        public virtual XhtmlString Signature { get; set; }

        [Display(
           Name = "Thank you Message",
           GroupName = Global.Tabs.Content,
           Description = "This message is display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion
    }
}