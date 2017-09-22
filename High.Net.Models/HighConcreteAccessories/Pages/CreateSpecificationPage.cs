using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;

namespace High.Net.Models.HighConcreteAccessories.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HCA,
        DisplayName = "CreateSpecificationPage",
        GUID = "6282d15f-6931-4609-86c8-90d76d0abfaf",
        Description = "",
        Order=15060)]    
    public class CreateSpecificationPage : HighConcreteAccessoriesPageData , IHighConcreteAccessories
    {
        #region Content

        [Display(
           Name = "To Email IDs",
           GroupName = Global.Tabs.Content,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 1300)]
        [UIHint(UIHint.LongString)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "E-mail Subject",
           GroupName = Global.Tabs.Content,
           Description = "Subject Of Mail",
           Order = 1400)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "E-Mail Body",
           GroupName = Global.Tabs.Content,
           Description = "To End User",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "Message after submit",
           GroupName = Global.Tabs.Content,
           Description = "Message display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion

    }
}