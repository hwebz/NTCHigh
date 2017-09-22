using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using High.Net.Core;
using High.Net.Core.ContentTypes.Blocks;
using High.Net.Models.Constants;
using High.Net.Models.Humanity.Blocks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace High.Net.Models.Humanity.Pages
{
    [SiteContentType(
       GroupName = SiteGroups.EOH,
       DisplayName = "Content Page",
       Order = 1020,
       GUID = "5E2B58B2-6BA9-4038-930B-3AA5D19A4A87",
       Description = "Content Page")]
    [SiteImageUrl]
    [AvailableContentTypes(
       Availability.Specific,
       Include = new[] { typeof(ContentPage) },
       IncludeOn= new[]{typeof(HomePage)})]    
    public class ContentPage : HumanityPageData, IHumanity
    {
        #region Content

        [Display(Name="Content Area",
            Description = "Content Area",
           GroupName = Global.Tabs.Content,
           Order = 2100)]
        [CultureSpecific]
        [AllowedTypes(typeof(TextBlock), typeof(PartnersBlock))]
        public virtual ContentArea ContentArea { get; set; }

        #endregion
    }
}
