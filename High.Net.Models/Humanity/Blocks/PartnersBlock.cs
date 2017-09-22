using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Constants;

namespace High.Net.Models.Humanity.Blocks
{
    [ContentType(GroupName = SiteGroups.EOH, 
        DisplayName = "Partners Block",
         Order = 1020,
        GUID = "20628239-734b-46e8-b913-d7fa40324d0c", 
        Description = "Partners Block Area")]
    [SiteImageUrl]
    public class PartnersBlock : HumanityBlockData
    {

        #region Content

        [CultureSpecific]
        [Display(Name = "Title",
            Description = "Title of Partners Page",
            GroupName = Global.Tabs.Content,
            Order = 100)]
        public virtual String Title { get; set; }


        [CultureSpecific]
        [Display(Name = "Text",
            Description = "Text of Partners Page",
            GroupName = Global.Tabs.Content,
            Order = 200)]
        public virtual XhtmlString Text { get; set; }


        [Display(Name = "Partners Content Area",
         Description = "Partners Icons",
        GroupName = Global.Tabs.Content,
        Order = 300)]
        [CultureSpecific]
        [AllowedTypes(typeof(MediaLink))]
        public virtual ContentArea PartnersContentArea { get; set; }

             #endregion
    }
}