using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Models.HighConcreteAccessories.Blocks;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "Ask TheExpert Page",
        GUID = "c84ee450-4caf-4bdc-b137-9c82ec1e711a",
        Description = "",
        Order=15050)]
    public class AskTheExpertPage : HighConcreteAccessoriesPageData , IHighConcreteAccessories
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
           Name = "Thank You Message",
           GroupName = Global.Tabs.Content,
           Description = "display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion
    }
}