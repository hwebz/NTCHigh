using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Models.HighSteelStructure.Blocks;
using High.Net.Core;
using EPiServer.Web;

namespace High.Net.Models.HighSteelStructure.Pages
{
    [ContentType(
        GroupName = SiteGroups.HSS,
        DisplayName = "PlantTourPage",
        GUID = "730c1ed8-f3be-4b6d-a75e-9beaf7e4ed07",
        Description = "",
        Order = 18400)]
    public class PlantTourPage : HighSteelStructurePageData
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
           Name = "Thank you message",
           GroupName = Global.Tabs.Content,
           Description = "This message is display after submit.",
           Order = 1200)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion

        #region Email Setting

        [Display(
           Name = "To Email ID",
           GroupName = Global.Tabs.EmailSetting,
           Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
           Order = 2100)]
        public virtual String ToEmailID { get; set; }

        [Display(
           Name = "Subject",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Subject Of Mail",
           Order = 2200)]
        public virtual String Subject { get; set; }

        [Display(
           Name = "Mail Body",
           GroupName = Global.Tabs.EmailSetting,
           Description = "To End User",
           Order = 2300)]
        public virtual XhtmlString MailBody { get; set; }

        #endregion
    }
}