using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace High.Net.Models.HighHotels.Pages
{
    public abstract class HighHotelsPageData : BasePageData
    {
        #region Images

        [Display(
            Name = "Page Banner Image (Width : 1400 , Height : 360)",
            GroupName = Global.Tabs.Images,
            Description = "Page Image",
            Order = 100)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion
    }
}