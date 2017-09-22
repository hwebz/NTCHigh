using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Find a Representative",
        GUID = "D98F66B1-D933-4C9B-AC73-B37FAB740C74",
        Description = "Find a Representative",
        Order=13060)]    
    public class FindRepresentativePage : HighConcretePageData
    {
        #region Content

        [Display(
           Name = "Main Content",
           GroupName = Global.Tabs.Content,
           Description = "",
           Order = 1100)]
        [AllowedTypes(typeof(TextBlock) , typeof(ImageGalleryBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}