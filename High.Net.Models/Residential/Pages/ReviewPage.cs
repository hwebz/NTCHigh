using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Models.Constants;
using High.Net.Core;
using High.Net.Models.Humanity.Blocks;
using EPiServer.Web;

namespace High.Net.Models.Residential.Pages
{
    [SiteContentType(GroupName = SiteGroups.BR,
        DisplayName = "Review Page",
        GUID = "adc532fd-e596-4e16-ae18-dc70f5ed8b30",
        Description = "Page For Review",
        Order = 5040)]
    [AvailableContentTypes(
       Availability.None)]    
    public class ReviewPage : ResidentialPageData, IResidential
    {

        #region Content

        [Display(
          Name = "Heading",
          Description = "Heading",
          GroupName = Global.Tabs.Content,
          Order = 1100)]
        [CultureSpecific]
        public virtual String Heading { get; set; }

        [Display(
          Name = "Intro Text",
          Description = "Intro Text",
          GroupName = Global.Tabs.Content,
          Order = 1200)]
        [CultureSpecific]
        [UIHint(UIHint.LongString)]
        public virtual String IntroText { get; set; }

        [Display(
          Name = "Description",
          Description = "Description",
          GroupName = Global.Tabs.Content,
          Order = 1300)]
        [CultureSpecific]
        public virtual XhtmlString Description { get; set; }

        #endregion

    }
}