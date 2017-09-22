using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using ImageVault.EPiServer;

namespace High.Net.Models.Shared.Pages
{
    /// <summary>
    /// Used to provide on-site search
    /// </summary>
    [SiteContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Search Page",
        GUID = "D589320B-6FA1-4F6E-AAEA-7F2B855244E6",
        Description = "Search Page",
        Order = 50)]
    [AvailableContentTypes(
       Availability.None)]
    public class SearchPage : BasePageData
    {
        #region Images

        [Display(
           Name = "Page Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Banner Image",
           Order = 1100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion
    }
}
