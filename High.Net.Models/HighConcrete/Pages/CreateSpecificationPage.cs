using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;
using EPiServer.Web;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Create a Specification Page",
        GUID = "B8EE77FF-DAA3-46A6-920F-BCCDFF05E4CE",
        Description = "Create a Specification Page",
        Order = 13080)]
    public class CreateSpecificationPage : HighConcretePageData
    {
        #region Content

        [Display(
           Name = "To Email Ids(comma separated)",
           GroupName = Global.Tabs.Content,
           Description = "List of To email address with comma separate.",
           Order = 1300)]
        public virtual String ToEmailIds { get; set; }

        [Display(
           Name = "E-Mail Subject",
           GroupName = Global.Tabs.Content,
           Description = "Subject for E-Mail",
           Order = 1400)]
        [UIHint(UIHint.LongString)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "E-Mail Body",
           GroupName = Global.Tabs.Content,
           Description = "E-Mail message body",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "Message after sumbit",
           GroupName = Global.Tabs.Content,
           Description = "Message will display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion
    }
}