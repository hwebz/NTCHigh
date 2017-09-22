using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.StructureCareUs.Pages
{
    public abstract class StructureCareUsPageData : BasePageData
    {
        #region Image

        [Display(Name = "Page Banner",
          GroupName = Global.Tabs.Images,
          Description = "Page Banner for Inner pages",
          Order = 1110)]
        public virtual MediaReference BannerImage { get; set; }

        #endregion
    }
}
