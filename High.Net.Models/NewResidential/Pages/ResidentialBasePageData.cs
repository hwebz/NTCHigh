using EPiServer.Core;
using High.Net.Core;
using ImageVault.EPiServer;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using High.Net.Models.Validation;

namespace High.Net.Models.NewResidential.Pages
{
    public abstract class ResidentialBasePageData :BasePageData, INewResidential
    {
        [Display(
         Description = "Banner Image",
         GroupName = Global.Tabs.Images,
         Order = 10)]
        public virtual MediaReference BannerImage { get; set; }

        [Display(
         Description = "Banner Logo Image",
         GroupName = Global.Tabs.Images,
         Order = 20)]
        public virtual MediaReference BannerLogoImage { get; set; }

        [Display(
        Description = "Hero Logo Width(pixel)",
        GroupName = Global.Tabs.Images,
        Order = 100)]
                [Range(100, int.MaxValue)]
        public virtual int HeroLogoWidth { get; set; }

        [Display(
           Description = "Title",
           GroupName = Global.Tabs.Content,
           Order = 30)]
        public virtual string Title { get; set; }

        [Display(
         Description = "Description",
         GroupName = Global.Tabs.Content,
         Order = 40)]
        public virtual XhtmlString  Description { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.HeroLogoWidth = RangeRules.DefaultHeroIconWidth;
        }


    }
}