using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.NewResidential.Blocks;
using System.ComponentModel.DataAnnotations;
using EPiServer.Forms.Implementation.Elements;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.Shared.Blocks;
using EPiServer.DataAbstraction;

namespace High.Net.Models.NewResidential.Pages
{
     [SiteContentType(GroupName = SiteGroups.NewResidential,
        DisplayName = "Content Page",
        GUID = "AC2900C0-5682-4267-A74C-ACCAA1B14496",
        Description = "Content Page of the website",
        Order = 5001)]
    public class ContentPage : ResidentialBasePageData
    {
        [Display(
           Description = "Content",
           GroupName = Global.Tabs.Content,
           Order = 30)]
        [AllowedTypes(typeof(INewResidentialBlock), typeof(LogoWallBlock), typeof(GenericBlock), typeof(FormContainerBlock))]
        public virtual ContentArea Content { get; set; }
        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.HeroLogoWidth = 300;
        }
    }
}

