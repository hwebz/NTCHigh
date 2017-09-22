using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using ImageVault.EPiServer;
using High.Net.Models.Constants;

namespace High.Net.Models.HighNet.Blocks
{
    [ContentType(GroupName = SiteGroups.HN, DisplayName = "Homepage Animation", GUID = "57de8a70-dd38-4886-8a7a-56f77595b473", Description = "", Order = 10580)]
    public class AuthorQuoteBlock : HighNetBlockData
    {
        #region Image

       
        [Display(
            Name = "Author Image",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1100)]
        
        public virtual MediaReference AuthorImage { get; set; }


        
        [Display(
            Name = "Background Image",
            Description = "Name field's description",
            GroupName = SystemTabNames.Content,
            Order = 1200)]

        public virtual MediaReference BackgroundImage { get; set; }

        #endregion

        #region Content
        [Display(
          Name = "Quote",
          GroupName = Global.Tabs.Content,
          Description = "",
          Order = 2100)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String Quote { get; set; }


        [Display(
          Name = "Html Text",
          GroupName = Global.Tabs.Content,
          Description = "use to format text content",
          Order = 2300)]
        [CultureSpecific]
        public virtual String Author { get; set; }





        #endregion



    }
}