using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Validation;
using static High.Net.Models.Constants.EditorConstants;
using EPiServer.Web;

namespace High.Net.Models.HighNet.Pages
{
    public abstract class HighNetPageData : BasePageData
    {
        #region Image

        [Display(
            Name = "Desktop Banner Image",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 100)]
        public virtual MediaReference ImageBanner { get; set; }

        [Display(
            Name = "Tablet Banner Image",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 110)]
        public virtual MediaReference ImageBannerTablet { get; set; }

        [Display(
            Name = "Mobile Banner Image",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 120)]
        public virtual MediaReference ImageBannerMobile { get; set; }

        [Display(
            Name = "Banner Image Logo",
            GroupName = Global.Tabs.Images,
            Description = "",
            Order = 110)]
        public virtual MediaReference ImageBannerLogo { get; set; }

        #endregion

        [Display(
           Name = "Page Title",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 100)]
        [UIHint(UIHint.LongString)]
        public virtual string Title { get; set; }

        [Display(
           Name = "Description",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 120)]
        public virtual XhtmlString Description { get; set; }

        [Display(
            Name = "Carousel Image",
            GroupName = Global.Tabs.CarouselSettings,
            Description = "",
            Order = 200)]
        public virtual MediaReference CarouselImage { get; set; }

        [Display(
            Name = "Carousel Text",
            GroupName = Global.Tabs.CarouselSettings,
            Order = 300)]
        [CultureSpecific]
        [UIHint(HighUIHint.HighNetTinyMce)]
        public virtual XhtmlString CarouselText { get; set; }
    }
}