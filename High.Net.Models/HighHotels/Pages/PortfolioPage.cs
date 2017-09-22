using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Business.SelectionFactory;
using EPiServer.Shell.ObjectEditing;

namespace High.Net.Models.HighHotels.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.HH,
        DisplayName = "Portfolio Page",
        GUID = "686c40df-f076-42ed-9a2f-42777e0f1540",
        Description = "",
        Order=12050)]
    public class PortfolioPage : HighHotelsPageData
    {
         [Display(Name = "Hotel Brand",
            GroupName = Global.Tabs.Content,
            Description = "Hotel Brand",
            Order = 2010)]
        [SelectOne(SelectionFactoryType = typeof(SelectHotelByBrand))]
        public virtual string Brand { get; set; }

         [Display(Name = "Hotel State",
            GroupName = Global.Tabs.Content,
            Description = "Hotel State",
            Order = 2010)]
        [SelectOne(SelectionFactoryType = typeof(SelectHotelByState))]
        public virtual string State { get; set; }

         [Display(Name = "Hotel Address & Contact Details",
             GroupName = Global.Tabs.Content,
             Description = "Hotel Address & Contact Details",
             Order = 2020)]
         public virtual XhtmlString Address { get; set; }
    }
}