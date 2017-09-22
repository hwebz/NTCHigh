using EPiServer.Web;
using High.Net.Core;
using ImageVault.EPiServer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.HighAppraisal.Pages
{
    public abstract class HighAppraisalPageData : BasePageData
    {
        #region Image

        [Display(
          Name = "Page Image (Width : 120 , Height : 120)",
          Description = "Page Image thumnail",
          GroupName = Global.Tabs.Images,
          Order = 100)]
        public virtual MediaReference PageImage { get; set; }

        #endregion

        #region Content

        [Display(
          Name = "Page Intro Text",
          Description = "",
          GroupName = Global.Tabs.Content,
          Order = 200)]
        [UIHint(UIHint.LongString)]
        public virtual String PageIntroText { get; set; }

        #endregion
    }
}