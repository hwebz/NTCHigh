using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.BR,
        DisplayName = "Apply Now Page",
        GUID = "975e7548-08af-4d1c-9e77-840ac163b098",
        Description = "Apply Now Page",
        Order = 5110)]
    public class ApplyNowPage : ResidentialPageData
    {
        #region Content

        [Display(
            Name = "Document File",
            GroupName = Global.Tabs.Content,
            Description = "Document File",
            Order = 1100)]
        public virtual MediaReference DocumentFile { get; set; }

        [Display(
            Name = "Email Address",
            GroupName = Global.Tabs.Content,
            Description = "Email Address",
            Order = 1200)]
        public virtual String EmailAddress { get; set; }

        [Display(
            Name = "Content Body",
            GroupName = Global.Tabs.Content,
            Description = "Content Body",
            Order = 1300)]
        public virtual ContentArea ContentBody { get; set; }

        #endregion
    }
}