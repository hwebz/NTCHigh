using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using EPiServer.Web;
using High.Net.Core;

namespace High.Net.Models.HighConcrete.Pages
{
    [ContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Online Courses Form Page",
        GUID = "24c2e596-ee82-45fd-b721-db55b869168f",
        Description = "Online Courses Form Page",
        Order = 13180)]
    public class OnlineCoursesFormPage : HighConcretePageData
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
           Description = "To End User",
           Order = 1500)]
        public virtual XhtmlString MailBody { get; set; }

        [Display(
           Name = "Thank you message",
           GroupName = Global.Tabs.Content,
           Description = "display after submit",
           Order = 1700)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion 
    }
}