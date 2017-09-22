using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.BR,
        DisplayName = "Schedule Tour Page",
        GUID = "213F7393-2FAE-4408-87C6-6C00B8567310",
        Description = "Schedule Tour Page",
        Order = 5100)]
    [AvailableContentTypes(Availability.None)]
    public class ScheduleTourPage : ResidentialPageData, IResidential
    {
        #region Content

        [Display(
           Name = "To Email Id",
           GroupName = Global.Tabs.Content,
           Description = "To comma separated Email Addesses",
           Order = 1100)]
        [UIHint(UIHint.LongString)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Subject",
           GroupName = Global.Tabs.Content,
           Description = "Subject Of Mail",
           Order = 1200)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "E-Mail Body",
           GroupName = Global.Tabs.Content,
           Description = "E-Mail Body",
           Order = 1300)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
            Name = "Thank you message",
            GroupName = Global.Tabs.Content,
            Description = "This message is displayed after submit.",
            Order = 1400)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            VisibleInMenu = false;
        }
    }
}