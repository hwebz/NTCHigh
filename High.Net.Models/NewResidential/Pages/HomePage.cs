using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.NewResidential.Blocks;
using High.Net.Models.Shared.ListPropertyModel;
using ImageVault.EPiServer;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.NewResidential.Pages
{
    [SiteContentType(GroupName = SiteGroups.NewResidential,
        DisplayName = "Home Page",
        GUID = "A439CAAE-92FE-43AD-A767-F800AEFCCF3F",
        Description = "Home page of the website",
        Order = 5001)]
    [AvailableContentTypes(Availability.Specific, Include = new[] { typeof(ContentPage), typeof(ContactPage) })]
    public class HomePage : ResidentialBasePageData, IHome, ICommonHome
    {
        [ScaffoldColumn(false)]
        public new virtual XhtmlString Description { get; set; }

        [Display(
        Description = "Hero Image",
        GroupName = Global.Tabs.Images,
        Order = 10)]
        [Required]
        public new virtual MediaReference BannerImage { get; set; }

        [Display(
         Description = "Hero Logo Image",
         GroupName = Global.Tabs.Images,
         Order = 20)]
        public new virtual MediaReference BannerLogoImage { get; set; }

        [Display(
            Name = "Hero Text",
             Description = "Hero Text",
             GroupName = Global.Tabs.Images,
             Order = 30)]
        [UIHint(UIHint.LongString)]
        public virtual string HeroText { get; set; }

        [Display(
            Name = "Image Collection",
           Description = "Image Collection",
           GroupName = Global.Tabs.Content,
           Order = 40)]
        [AllowedTypes(typeof(PhotosGridGalleryBlock))]
        public virtual ContentArea ImageCollections { get; set; }

        [Display(
            Name = "Plantation Title",
          Description = "Plantation Title",
          GroupName = Global.Tabs.Content,
          Order = 50)]
        [UIHint(UIHint.LongString)]
        public virtual string PlantationTitle { get; set; }

        [Display(
            Name = "Plantation Description",
           Description = "Plantation Description",
           GroupName = Global.Tabs.Content,
           Order = 60)]
        [UIHint(UIHint.LongString)]
        public virtual string PlantationDescription { get; set; }

        [Display(
           Description = "Content",
           GroupName = Global.Tabs.Content,
           Order = 70)]
        [AllowedTypes(typeof(GoogleMapSingleLocationBlock), typeof(PhotosGridGalleryBlock), typeof(ReadyToMoveBlock))]
        public virtual ContentArea Content { get; set; }

        [Display(
           Description = "Footer",
           GroupName = Global.Tabs.FooterSettings,
           Order = 80)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<TextInformationModel>))]
        public virtual IList<TextInformationModel> Footer { get; set; }

        [Display(
            Name = "Bottom Bar Left Icon Links",
          Description = "Bottom Bar Left Icon Links",
          GroupName = Global.Tabs.FooterSettings,
          Order = 90)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<IconLinkModel>))]
        public virtual IList<IconLinkModel> BottomBarLeft { get; set; }

        [Display(
            Name = "Bottom Bar Title",
           Description = "Bottom Bar Title",
           GroupName = Global.Tabs.FooterSettings,
           Order = 100)]
        public virtual string BottomBarTitle { get; set; }

        [Display(
            Name = "Bottom Bar Right Icon Links",
           Description = "Bottom Bar Right Icon Links",
           GroupName = Global.Tabs.FooterSettings,
           Order = 110)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<IconLinkModel>))]
        public virtual IList<IconLinkModel> BottomBarRight { get; set; }

        [Display(
            Description = "Site Logo",
            GroupName = Global.Tabs.TemplateSettings,
            Order = 20)]
        public virtual MediaReference SiteLogo { get; set; }

        public string NameInEmail => string.Empty;

        public string BusinessContactNumber => string.Empty;

        [Display(
           Name = "Google Analytics Code",
           Description = "Google Analytics",
           GroupName = Global.Tabs.Content,
           Order = 4100)]
        public virtual string GoogleAnalytics { get; set; }

        [Display(
        Description = "Site Color",
        GroupName = Global.Tabs.TemplateSettings,
        Order = 10)]
        [ClientEditor(ClientEditingClass = "highnet/editors/ColorPicker")]
        public virtual string SiteColor { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);
            this.SiteColor = "#c77629";
        }
    }
}