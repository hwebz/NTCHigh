using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High.Net.Core;
using EPiServer.DataAnnotations;
using EPiServer.DataAbstraction;
using High.Net.Models.Constants;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using High.Net.Models.Business.SelectionFactory;
using EPiServer.Shell.ObjectEditing;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.Shared.Pages
{
    [ContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Contact Us",
        GUID = "F659F597-8D74-4D54-8039-08115D8D169F",
        Description = "",
        Order = 80)]
    [AvailableContentTypes(Availability.All)]

    public class ContactUsPage : BasePageData
    {
        #region Images

        [Display(
           Name = "Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Size: 1400x430",
           Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [Display(
            Name = "Main Content Area",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display tasks",
            Order = 1100)]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
            Name = "Sub Content Area",
            GroupName = Global.Tabs.Content,
            Description = "Content Area to display Addtional Information",
            Order = 1200)]
        public virtual ContentArea SubContentArea { get; set; }

        #endregion

        #region Email Settings

        [Display(
            Name = "Business Recipients Email",
            GroupName = Global.Tabs.EmailSetting,
            Description = "If multiple email recipients please separate using comma(,) or semicolon(;)",
            Order = 2100)]
        public virtual String BusinessRecipientsEmail { get; set; }

        [Display(
            Name = "Business Email Subject",
            GroupName = Global.Tabs.EmailSetting,
            Description = "Subject for business email",
            Order = 2200)]
        public virtual String BusinessEmailSubject { get; set; }

        [Display(
           Name = "Business Email Body",
           GroupName = Global.Tabs.EmailSetting,
           Description = "Mail body for business email",
           Order = 2300)]
        public virtual XhtmlString BusinessEmailBody { get; set; }


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
            Name = "OnScreen - Thank You Message",
            GroupName = Global.Tabs.EmailSetting,
            Description = "This message is displayed after submit.",
            Order = 2600)]
        public virtual XhtmlString ThankYouMessage { get; set; }

        #endregion

    }
}