using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Industries.Pages
{
    public abstract class IndustriesPageData: BasePageData
    {
        #region Image

        [Display(
             Name = "Banner Image (Width : 1400 , Height : 360)",
             GroupName = Global.Tabs.Images,
             Description = "Banner Image for every page",
             Order = 100)]
        public virtual MediaReference PageBannerImage { get; set; }

        #endregion
    }
}
