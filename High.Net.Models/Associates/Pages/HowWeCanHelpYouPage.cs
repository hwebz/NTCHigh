using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Models.Associates.Blocks;

namespace High.Net.Models.Associates.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HA,
        DisplayName = "How We Can Help You Page",
        GUID = "864bf9ac-28c9-45b0-9783-48f2700d2ec9",
        Description = "",
        Order=7080)]
    [AvailableContentTypes(
       Availability.None)]    
    public class HowWeCanHelpYouPage : AssociatesPageData, IAssociates
    {
        #region Email Settings

        [Display(
           Name = "Business Recipients Email",
           GroupName = Global.Tabs.EmailSetting,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 2100)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Business Email Subject",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Subject for business email",
           Order = 2200)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "Business Email Body",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Mail body for business email",
           Order = 2300)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "User Email Subject",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Subject for user email",
           Order = 2400)]
        public virtual String EmailConfirmationSubject { get; set; }

        [Display(
            Name = "User Email Body",
            GroupName = Global.Tabs.EmailSetting,
            Description = "Mail body for user email",
            Order = 2500)]
        public virtual XhtmlString EmailConfirmationMessage { get; set; }

        [Display(
          Name = "Thank you message",
          GroupName = Global.Tabs.EmailSetting,
          Description = "This message is displayed after submit.",
          Order = 2600)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion    
    }
}