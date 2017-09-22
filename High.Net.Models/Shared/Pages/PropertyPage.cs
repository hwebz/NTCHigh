using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.SpecializedProperties;
using High.Net.Core;
using High.Net.Models.Constants;
using High.Net.Models.Shared.Blocks;
using EPiServer.Shell.ObjectEditing;
using High.Net.Models.Business.SelectionFactory;
using EPiServer.Web;
using ImageVault.EPiServer;
namespace High.Net.Models.Shared.Pages
{
    [SiteContentType(
        GroupName = SiteGroups.Global,
        DisplayName = "Property Item",
        GUID = "c17fbe10-8e3c-4285-a74b-5ff59cbff561",
        Description = "Property Item Page",
        Order = 40)]
    [AvailableContentTypes(
       Availability.None)]
    public class PropertyPage : BasePageData
    {
        [Display(Name = "Property Name", Order = 1)]
        public virtual string PropertyName { get; set; }

        [Display(Name = "Created On", Order = 100)]
        public virtual DateTime CreatedOn { get; set; }

        [Display(Name = "Acres", Order = 200)]
        public virtual string Acres { get; set; }

        [Display(Name = "Address Line 1", Order = 300)]
        public virtual string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2", Order = 400)]
        public virtual string AddressLine2 { get; set; }

        [Display(Name = "Air Conditioning", Order = 500)]
        public virtual string AirConditioning { get; set; }

        [Display(Name = "Available Sq Ft", Order = 600)]
        public virtual string AvailableSqFt { get; set; }

        [Display(Name = "Business Key", Order = 700)]
        public virtual string BusinessKey { get; set; }

        [Display(Name = "CAM", Order = 800)]
        public virtual string CAM { get; set; }

        [Display(Name = "Ceiling Height", Order = 900)]
        public virtual string CeilingHeight { get; set; }

        [Display(Name = "City", Order = 1000)]
        public virtual string City { get; set; }

        [Display(Name = "Construction", Order = 1100)]
        public virtual string Construction { get; set; }

        [Display(Name = "Corporate Center", Order = 1200)]
        public virtual string CorporateCenter { get; set; }

        [Display(Name = "County", Order = 1300)]
        public virtual string County { get; set; }

        [Display(Name = "Created By", Order = 1400)]
        public virtual string PropertyCreatedBy { get; set; }

        [Display(Name = "Currency", Order = 1500)]
        [SelectOne(SelectionFactoryType = typeof(SelectCurrency))]
        public virtual string Currency { get; set; }

        [Display(Name = "Description", Order = 1600)]
        public virtual XhtmlString Description { get; set; }

        [Display(Name = "Dock Doors", Order = 1700)]
        public virtual string DockDoors { get; set; }

        [Display(Name = "Electric", Order = 1800)]
        public virtual string Electric { get; set; }

        [Display(Name = "Enabled", Order = 1900)]
        public virtual string Enabled { get; set; }

        [Display(Name = "Exchange Rate", Order = 2000)]
        public virtual double ExchangeRate { get; set; }

        [Display(Name = "Featured", Order = 2100)]
        public virtual string Featured { get; set; }

        [Display(Name = "Featured End Date", Order = 2200)]
        public virtual string FeaturedEndDate { get; set; }

        [Display(Name = "Heating", Order = 2300)]
        public virtual string Heating { get; set; }

        [Display(Name = "Keywords", Order = 2400)]
        [UIHint(UIHint.Textarea)]
        public virtual String Keywords { get; set; }

        //[Display(Name = "Latitude", Order = 2500)]
        [Ignore]
        public double Latitude { get; set; }

        [Display(Name = "Listing Type", Order = 2600)]
        [SelectOne(SelectionFactoryType = typeof(SelectListingType))]
        public virtual string ListingType { get; set; }

        [Display(Name = "Location", Order = 2700)]
        [SelectOne(SelectionFactoryType = typeof(SelectLocation))]
        public virtual string Location { get; set; }

        //[Display(Name = "Longitude", Order = 2800)]
        [Ignore]
        public double Longitude { get; set; }

        [Display(Name = "Modified By", Order = 2900)]
        public virtual string PropertyModifiedBy { get; set; }

        [Display(Name = "Modified On", Order = 3000)]
        public virtual DateTime ModifiedOn { get; set; }

        [Display(Name = "Municipality", Order = 3100)]
        public virtual string Municipality { get; set; }

        [Display(Name = "Office Sq Ft", Order = 3200)]
        public virtual string OfficeSqFt { get; set; }

        [Display(Name = "Overhead Doors", Order = 3300)]
        public virtual XhtmlString OverheadDoors { get; set; }

        [Display(Name = "Owner", Order = 3400)]
        public virtual string Owner { get; set; }

        [Display(Name = "Parking", Order = 3500)]
        public virtual XhtmlString Parking { get; set; }

        [Display(Name = "Price", Order = 3600)]
        public virtual string Price { get; set; }

        [Display(Name = "Price (Base)", Order = 3700)]
        public virtual string PriceBase { get; set; }

        [SelectOne(SelectionFactoryType = typeof(SelectPropertyType))]
        [Display(Name = "Property Type", Order = 3800)]
        public virtual string PropertyType { get; set; }

        [Display(Name = "Record Created On", Order = 3900)]
        public virtual string RecordCreatedOn { get; set; }

        [Display(Name = "Rent", Order = 4000)]
        public virtual double Rent { get; set; }

        [Display(Name = "Rent (Base)", Order = 4100)]
        public virtual double RentBase { get; set; }

        [Display(Name = "Responsible Broker", Order = 4200)]
        public virtual string ResponsibleBroker { get; set; }

        [Display(Name = "Sewer", Order = 4300)]
        public virtual string Sewer { get; set; }

        [Display(Name = "Size", Order = 4400)]
        public virtual double Size { get; set; }

        [Display(Name = "Sprinkler", Order = 4500)]
        public virtual XhtmlString Sprinkler { get; set; }

        [Display(Name = "State", Order = 4600)]
        public virtual string State { get; set; }

        [Display(Name = "Status", Order = 4700)]
        public virtual string WorkStatus { get; set; }

        [Display(Name = "Status Reason", Order = 4800)]
        public virtual string StatusReason { get; set; }

        [Display(Name = "Third Party", Order = 4900)]
        public virtual string ThirdParty { get; set; }

        [Display(Name = "Unit of Measure", Order = 5000)]
        public virtual string UnitofMeasure { get; set; }

        [Display(Name = "URL", Order = 5100)]
        public virtual EPiServer.Url URL { get; set; }

        [Display(Name = "Video URL", Order = 5200)]
        public virtual EPiServer.Url VideoURL { get; set; }

        [Display(Name = "Warehouse Mfg Sq Ft", Order = 5300)]
        public virtual double WarehouseMfgSqFt { get; set; }

        [Display(Name = "Water", Order = 5400)]
        public virtual string Water { get; set; }

        [Display(Name = "Website", Order = 5500)]
        public virtual EPiServer.Url Website { get; set; }

        [Display(Name = "Zip Code", Order = 5600)]
        public virtual int ZipCode { get; set; }

        [Display(Name = "Zoning", Order = 5700)]
        public virtual string Zoning { get; set; }

        [Display(Name = "Page Image", Order = 5900)]
        public virtual MediaReference PageImage { get; set; }

        [Display(Name = "Property PDF Document", Order = 6000)]
        public virtual MediaReference PDFDocument { get; set; }

        [Display(Name="Co-ordinates", Order=5800)]
        [ClientEditor(ClientEditingClass = "googlemapseditor/Editor")]
        public virtual CoordinatesBlock Coordinates { get; set; }


        [Display(
           Name = "Page Banner Image",
           GroupName = Global.Tabs.Images,
           Description = "Banner Image",
           Order = 7000)]
        public virtual MediaReference BannerImage { get; set; }

        public override void SetDefaultValues(ContentType contentType)
        {
            base.SetDefaultValues(contentType);

            Currency = "US Dollar";
        }

    }
}