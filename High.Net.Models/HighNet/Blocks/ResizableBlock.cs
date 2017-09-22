using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Pages;
using High.Net.Models.HighNet;
using High.Net.Core;
using EPiServer.Shell.ObjectEditing;
namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(
        GroupName = SiteGroups.HN,
        DisplayName = "Resizable Container",
        GUID = "CBA7B4E3-E1B1-4FDD-84CF-F7795714603D",
        Description = "",
        Order = 10900)]
    public class ResizableBlock : HighNetBlockData
    {
        #region Content

        [Display(
             Name = "Block Content",
             GroupName = Global.Tabs.Content,
             Description = "Content Area to display blocks",
             Order = 1100)]
//        [AllowedTypes(typeof(PhotoGalleryBlock), typeof(LogoWallBlock), typeof(TextTableBlock), typeof(ImageTable),
//            typeof(SingleColumnCalloutBlock), typeof(NumberListContentBlock), typeof(StandardContentImageBlock), typeof(FullWidthCalloutBlock),
//            typeof(CSSLayeredImageContentBlock),typeof(StaticQuoteBlock), typeof(TestimonialConatinerBlock))]
        public virtual ContentArea BlockContentArea { get; set; }

        [Display(
           Name = "Is Container?",
           Description = "If this values is true then width will be 1170px.",
           GroupName = SystemTabNames.Content,
           Order = 1110)]
        public virtual bool IsContainer { get; set; }

        #endregion
    }
}
