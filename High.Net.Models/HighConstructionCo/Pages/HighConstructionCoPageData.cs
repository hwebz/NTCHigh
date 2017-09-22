using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using High.Net.Core;
using ImageVault.EPiServer;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Models.HighConstructionCo.Pages
{
    public abstract class HighConstructionCoPageData : BasePageData
    {
        #region Images

        [Display(
           Name = "Banner Image (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "Banner Image for specific pages",
           Order = 100)]
        public virtual MediaReference PageBannerImage { get; set; }

        #endregion
    }
}
