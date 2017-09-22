using EPiServer.DataAbstraction;
using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Rollover.Pages
{
    public abstract class RolloverPageData : BasePageData
    {
        #region Images

        [Display(Name = "Banner Image (Width : 1400 , Height : 360)",
            GroupName = Global.Tabs.Images,
            Description = "Banner Image for single page",
            Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

        #region Content

        [Display(Name = "Is page heading visible on banner?",
               GroupName = Global.Tabs.Content,
               Description = "Is page heading visible on banner?",
               Order = 2100)]
        public virtual bool IsHeadingVisible { get; set; }

        #endregion
    }
}
