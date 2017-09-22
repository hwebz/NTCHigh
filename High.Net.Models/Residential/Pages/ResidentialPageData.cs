using EPiServer.Core;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Residential.Pages
{
    public abstract class ResidentialPageData : BasePageData
    {
        #region Image

        [Display(
          Description = "Banner Image (Width : 1400 , Height : 360)",
          GroupName = Global.Tabs.Images,
          Order = 110)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion

    }
}
