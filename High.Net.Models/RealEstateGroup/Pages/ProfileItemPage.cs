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

namespace High.Net.Models.RealEstateGroup.Pages
{
    [ContentType(
        GroupName = SiteGroups.REG, 
        DisplayName = "Profile Item Page", 
        GUID = "8e5996ce-58c9-4a47-b7b3-14c7be0abbd3",
        Description = "",
        Order=8040)]
    public class ProfileItemPage : RealEstateGroupPageData
    {
        #region Image

        [Display(
        Name = "Profile Image (Width : 100 , Height : 125)",
        Description = "",
        GroupName = Global.Tabs.Images,
        Order = 1100)]
        public virtual MediaReference ProfileImage { get; set; }

        #endregion

        #region Content

        [Display(
        Name = "Title",
        Description = "Profile Title",
        GroupName = Global.Tabs.Content,
        Order = 2100)]
        public virtual string Title { get; set; }

        [Display(
        Name = "Location",
        Description = "",
        GroupName = Global.Tabs.Content,
        Order = 2200)]
        public virtual string Location { get; set; }

        [Display(
        Name = "Contact",
        Description = "",
        GroupName = Global.Tabs.Content,
        Order = 2300)]
        public virtual string Contact { get; set; }

        [Display(
        Name = "Email ID",
        Description = "",
        GroupName = Global.Tabs.Content,
        Order = 2400)]
        public virtual string EmailID { get; set; }

        [Display(
        Name = "Intro-Text",
        Description = "Short Text",
        GroupName = Global.Tabs.Content,
        Order = 2500)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
        Name = "Description",
        Description = "",
        GroupName = Global.Tabs.Content,
        Order = 2600)]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}