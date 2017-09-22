using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;

namespace High.Net.Models.StructureCareUs.Blocks
{
    [ContentType(GroupName = SiteGroups.SCU, Order = 9030, DisplayName = "Contact Person Block", GUID = "d255dc70-5b18-4d3a-b9ba-13c549df068c", Description = "")]
    [SiteImageUrl]
    public class ContactPersonBlock : StructureCareUsBlockData
    {
        #region Images

        [Display(Name = "Person Image (Width : 214 , Height : 163)",
        GroupName = Global.Tabs.Images,
        Description = "Person's Image",
        Order = 1100)]
        public virtual MediaReference PersonImage { get; set; }

        #endregion 

        #region Content

        [Display(Name = "Text",
        GroupName = Global.Tabs.Content,
        Description = "Text",
        Order = 2100)]
        public virtual XhtmlString Text { get; set; }

        #endregion
    }
}