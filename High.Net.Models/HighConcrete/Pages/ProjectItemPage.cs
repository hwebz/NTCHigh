using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using ImageVault.EPiServer;
using EPiServer.Web;

namespace High.Net.Models.HighConcrete.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HC,
        DisplayName = "Project Item Page",
        GUID = "79622930-0d0e-4a06-a09c-0843e71c9d6e",
        Description = "",
        Order=13070)]    
    public class ProjectItemPage : HighConcretePageData
    {
        #region Images

        [Display(
           Name = "Project Images (Width : 277 , Height : 322)",
           Description = "",
           GroupName = Global.Tabs.Images,
           Order = 1100)]
        [BackingType(typeof(PropertyMediaList))]
        public virtual MediaReferenceList<MediaReference> Images { get; set; }

        #endregion

        #region Content

        [Display(
         Name = "Intro Text",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1100)]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }


        [Display(
         Name = "Description",
         GroupName = Global.Tabs.Content,
         Description = "",
         Order = 1200)]
        public virtual XhtmlString Description { get; set; }

        #endregion 


    }
}