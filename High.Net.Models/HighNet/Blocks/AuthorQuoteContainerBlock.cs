using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Blocks;
using System.ComponentModel.DataAnnotations;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Author Quote Container Block", GUID = "6999686C-6AAF-4A89-8602-C1E8C1D8C70E", Description = "", Order = 10580)]
    public class AuthorQuoteContainerBlock : HighNetBlockData, IHaveMultipleTemplates
    {
        [Display(
            Name = "Title",
            GroupName = SystemTabNames.Content,
            Order = 100)]
        public virtual string Title { get; set; }

        [Display(
            Name = "Author Quote Items",
            Description = "Author Quote Items",
            GroupName = SystemTabNames.Content,
            Order = 110)]
        [AllowedTypes(typeof(AuthorQuoteBlock))]
        public virtual ContentArea AuthorQuoteItems { get; set; }

        [Display(
           Name = "View Templates",
           GroupName = Global.Tabs.TemplateSettings,
           Order = 120)]
        [UIHint(HighUIHint.AuthorQuoteTemplatesSelection)]
        public virtual string ViewTemplate { get; set; }
    }
}