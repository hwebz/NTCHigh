using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using EPiServer.Web;
using ImageVault.EPiServer;
using High.Net.Models.Residential.Blocks;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.BR,
        DisplayName = "Sales Item Page",
        GUID = "a4edcb9a-ab7f-42d0-aa8c-669f938d8988",
        Description = "",
        Order=5100)]
    public class SalesItemPage : ResidentialPageData , IResidential
    {
        #region Images

        [Display(
          Name = "Image Slider",
          Description = "",
          GroupName = Global.Tabs.Sliders,
          Order = 1100)]
        [AllowedTypes(typeof(ImageTextBlock))]
        public virtual ContentArea SalesImageSlider { get; set; }


        #endregion

        #region Content

        [Display(
          Name = "Heading",
          Description = "Heading",
          GroupName = Global.Tabs.Content,
          Order = 2100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        [Display(
          Name = "Intro Text",
          Description = "Intro Text",
          GroupName = Global.Tabs.Content,
          Order = 2200)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
          Name = "Description",
          Description = "Description",
          GroupName = Global.Tabs.Content,
          Order = 2300)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        #endregion
    }
}