using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.HighNet.Blocks;
using EPiServer.Web;
using High.Net.Models.Constants;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Pages
{
    [SiteContentType(GroupName = SiteGroups.HN,DisplayName = "Sustainability Download Page",
        GUID = "2a089840-dc71-4474-8973-5e6bb1c8d588", Description = "",
        Order=10060)]
    public class SustainabilityDownloadPage : HighNetPageData
    {
        #region Content

        [Display(
           Name = "Thank you message",
           GroupName = Global.Tabs.Content,
           Description = "This message is display after submit.",
           Order = 1700)]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        [Display(
            Name = "Solve360 Sign up Mail Message",
            GroupName = Global.Tabs.Content,
            Description = "This message is displayed on solve360 in followup message for sign up request",
            Order = 1800)]
        [UIHint(UIHint.LongString)]
        public virtual string Solve360SignupMailMessage { get; set; }

        [Display(
            Name = "Solve360 Unsubscribe Mail Message",
            GroupName = Global.Tabs.Content,
            Description = "This message is displayed on solve360 in followup message for unsubscribing",
            Order = 1900)]
        [UIHint(UIHint.LongString)]
        public virtual string Solve360UnsubscribeMailMessage { get; set; }

        [Display(Name = "Top Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2110)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea TopContentArea { get; set; }

        [Display(Name = "Bottom Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2120)]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea BottomContentArea { get; set; }

        #endregion
    }
}