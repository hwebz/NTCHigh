using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace High.Net.Core
{
    /// <summary>
    /// Base class for all page types
    /// </summary>
    public abstract class BasePageData : PageData
    {
        #region SEO
        [Display(
           Description = "Meta Title",
           GroupName = Global.Tabs.SEO,
           Order = 10)]
        [CultureSpecific]
        public virtual string MetaTitle
        {
            get
            {
                var metaTitle = this.GetPropertyValue(p => p.MetaTitle);

                // Use explicitly set meta title, otherwise fall back to page name
                return !string.IsNullOrWhiteSpace(metaTitle)
                       ? metaTitle
                       : PageName;
            }
            set { this.SetPropertyValue(p => p.MetaTitle, value); }
        }

        [Display(
            Description = "Meta Keywords",
            GroupName = Global.Tabs.SEO,
            Order = 20)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string MetaKeywords { get; set; }

        [Display(
            Description = "Meta Description",
            GroupName = Global.Tabs.SEO,
            Order = 30)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual string MetaDescription { get; set; }

        [Display(
            Description = "Disable Indexing",
            GroupName = Global.Tabs.SEO,
            Order = 40)]
        [CultureSpecific]
        public virtual bool DisableIndexing { get; set; }
        #endregion
    }
}
