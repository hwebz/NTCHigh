using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.SteelServiceCentre.Pages
{
    public abstract class SteelServiceCentrePageData: BasePageData
    {
        #region Images

        [Display(
           Name = "Banner Image (Width : 1400 , Height : 360)",
           GroupName = Global.Tabs.Images,
           Description = "",
           Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

    }
}
