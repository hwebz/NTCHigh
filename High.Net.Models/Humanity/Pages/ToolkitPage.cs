using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Humanity.Blocks;
using High.Net.Models.Constants;

namespace High.Net.Models.Humanity.Pages
{
    [SiteContentType(DisplayName = "Toolkit Page",
        GroupName = SiteGroups.EOH,
        GUID = "684d4a6b-3226-44ad-bfec-d703cacb3a9e",
         Order = 1030,
        Description = "Page for Toolkit")]
    [SiteImageUrl]
    [AvailableContentTypes(
      Availability.None)]    
    public class ToolkitPage : HumanityPageData
    {
        #region Content

        [Display(Name="Toolkit Area",
            Description = "Content Area",
            GroupName = Global.Tabs.Content,
            Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock))]
        public virtual ContentArea ContentArea { get; set; }

        [Display(
           Description = "Username",
           GroupName = Global.Tabs.Content,
           Order = 2200)]
        [CultureSpecific]
        public virtual string Username { get; set; }


        [Display(
          Description = "Password",
          GroupName = Global.Tabs.Content,
          Order = 2300)]
        [CultureSpecific]
        public virtual string Password { get; set; }

        #endregion
    }
}