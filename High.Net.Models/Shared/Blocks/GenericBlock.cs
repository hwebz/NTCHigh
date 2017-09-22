using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Models.Constants;

namespace High.Net.Models.Shared.Blocks
{
    [ContentType(GroupName = SiteGroups.Global, 
        DisplayName = "Generic Block", 
        GUID = "99f69bf3-1e19-42f4-b28b-0533c3a005ea", 
        Description = "", Order = 40)]
    public class GenericBlock : BaseBlockData
    {
        #region Content

        [Display(
           Name = "Text Area",
           Description = "Text Area",
           GroupName = Global.Tabs.Content,
           Order = 100)]
        public virtual XhtmlString TextArea { get; set; }

        #endregion
    }
}