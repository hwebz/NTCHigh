using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighConcrete.Pages
{
    public abstract class HighConcretePageData : BasePageData
    {
        #region Image

            [Display(
                Name = "Banner Image (Width : 1400 , Height : 360)",
                GroupName = Global.Tabs.Images,
                Description = "Banner image for child pages",
                Order = 100)]
            public virtual MediaReference BannerImage { get; set; }

            [Display(
                    Name = "Page Image",
                    GroupName = Global.Tabs.Images,
                    Description = "Image for Page",
                    Order = 100)]
            public virtual MediaReference PageImage { get; set; }

        #endregion
    }
}
