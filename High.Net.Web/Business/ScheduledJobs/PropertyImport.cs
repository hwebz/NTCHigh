using System;
using EPiServer.Core;
using EPiServer.PlugIn;
using System.Text;
using System.IO;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer;
using System.Collections.Generic;
using System.Reflection;
using High.Net.Models.Shared.Pages;
using ImageVault.EPiServer;
using ImageVault.Client;
using ImageVault.Client.Query;
using ImageVault.Common.Data;
using EPiServer.Web.Routing;
using CsvHelper;
using System.Web;
using EPiServer.Logging;
using High.Net.Models.RootPage;
using EPiServer.Scheduler;

namespace High.Net.Web.Business.ScheduledJobs
{
    [ScheduledPlugIn(DisplayName = "High - Property Pages Import", SortIndex = 100)]
    public class PropertyImport : ScheduledJobBase
    {
        IContentRepository _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
        private bool _stopSignaled;
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(PropertyImport));
        public PropertyImport()
        {
            IsStoppable = true;
        }

        #region Schedule Methods

        public override void Stop()
        {
            _stopSignaled = true;
        }

        public override string Execute()
        {
            SysRoot _sysRoot = _contentRepo.Get<SysRoot>(PageReference.RootPage);
            bool JobAccess = _sysRoot.ExecuteScheduleJobs;
            if (JobAccess)
            {
                OnStatusChanged(String.Format("Starting execution of {0}", this.GetType()));

                string msg = RunMigration();

                if (_stopSignaled)
                {
                    return msg;
                }

                return msg;
            }
            else
            {
                return "You do not have the permission";
            }
        }

        #endregion

        #region Read Excel

        public string RunMigration()
        {
            try
            {
                var _contentRepo = ServiceLocator.Current.GetInstance<IContentRepository>();
                var _client = ImageVault.Client.ClientFactory.GetSdkClient();
                var resolver = ServiceLocator.Current.GetInstance<UrlResolver>();
                int counter = 0;
                XhtmlString declaration = new XhtmlString("Information furnished regarding property for sale or rent is from sources deemed reliable, but is not guaranteed. No warranty or representation is made as to accuracy thereof and is submitted subject to errors, omissions, change of price, or other conditions, prior sale or lease or withdrawal without notice. No liability of any kind is to be imposed on the broker herein. High Properties, the property owner, and High Associates Ltd., the broker, are indirect subsidiaries of High Real Estate Group LLC.");

                var catPropertySearch = _client.Query<Category>().Where(x => x.Name.Contains("Property Search")).FirstOrDefault();
                var catImages = catPropertySearch.Categories.Where(x => x.Name == "Images").FirstOrDefault() as Category;

                var catImagesDetail = catImages.Categories.Where(x => x.Name == "Detail").FirstOrDefault() as Category;
                var catImagesFeatured = catImages.Categories.Where(x => x.Name == "Featured").FirstOrDefault() as Category;
                var catImagesThumbnails = catImages.Categories.Where(x => x.Name == "Thumbnails").FirstOrDefault() as Category;

                var catPDF = catPropertySearch.Categories.Where(x => x.Name == "PDFs").FirstOrDefault() as Category;

                var StartPage = _contentRepo.Get<PageData>(EPiServer.Web.SiteDefinition.Current.StartPage);
                var propertyListing = new PropertyListingPage();//_contentRepo.GetDefault<PropertyListingPage>(StartPage.ContentLink);
                var propertyPages = new List<PropertyPage>();

                var propertyList = _contentRepo.GetDescendents(StartPage.ContentLink).Where(x => _contentRepo.Get<IContent>(x) is PropertyListingPage).Select(_contentRepo.Get<PropertyListingPage>);
                if (propertyList.Count() > 0)
                {
                    propertyListing = propertyList.FirstOrDefault();
                }
                else
                {
                    propertyListing = _contentRepo.GetDefault<PropertyListingPage>(StartPage.ContentLink);
                    propertyListing.Name = "Properties";
                    propertyListing.PropertyDeclaration = declaration;
                    propertyListing.VisibleInMenu = false;
                    _contentRepo.Save(propertyListing, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                }

                var filePath = Path.Combine(HttpRuntime.AppDomainAppPath, string.Format(@"App_Data\import\{0}.csv", StartPage.Name));
                using (StreamReader textReader = new StreamReader(filePath, Encoding.Default, true))
                {
                    using (var csvReader = new CsvReader(textReader))
                    {
                        OnStatusChanged(String.Format("Reading File"));
                        while (csvReader.Read())
                        {
                            PropertyPage propertyPage = BindProperties(_client, csvReader, catPropertySearch, catImagesDetail, catImagesFeatured, catImagesThumbnails, catPDF);
                            propertyPages.Add(propertyPage);
                        }
                    }
                }

                var grouppingPages = propertyPages.GroupBy(x => x.PropertyType).Distinct();

                foreach (var item in grouppingPages)
                {
                    var propertyTypePage = new PropertyTypePage();
                    var propertyTypeList = _contentRepo.GetChildren<PropertyTypePage>(propertyListing.ContentLink).Where(x => x.Name == item.Key);
                    if (propertyTypeList.Count() > 0)
                    {
                        propertyTypePage = _contentRepo.Get<PropertyTypePage>(propertyTypeList.FirstOrDefault().ContentLink);
                    }
                    else
                    {
                        propertyTypePage = _contentRepo.GetDefault<PropertyTypePage>(propertyListing.ContentLink);
                        propertyTypePage.Name = item.Key;
                        propertyTypePage.Image = item.First().PageImage;
                        _contentRepo.Save(propertyTypePage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                    }

                    foreach (var _propertyPage in propertyPages.Where(x => x.PropertyType == item.Key) as IEnumerable<PropertyPage>)
                    {
                        OnStatusChanged(String.Format("Updating file: Pages {0} of {1}", counter + 1, propertyPages.Count));
                        var propertyPageList = _contentRepo.GetChildren<PropertyPage>(propertyTypePage.ContentLink).Where(x => x.BusinessKey == _propertyPage.BusinessKey);
                        if (propertyPageList.Count() > 0)
                        {
                            var propertyPage = _contentRepo.Get<PropertyPage>(propertyPageList.FirstOrDefault().ContentLink);
                            var writablepageData = (PropertyPage)propertyPage.CreateWritableClone();

                            foreach (PropertyInfo prop in typeof(PropertyPage).GetProperties().Take(61))
                            {
                                if ("Latitude" != prop.Name && "Longitude" != prop.Name && "Coordinates" != prop.Name)
                                {
                                    writablepageData[prop.Name] = _propertyPage.GetType().GetProperty(prop.Name).GetValue(_propertyPage, null);
                                }
                                else if ("Coordinates" == prop.Name)
                                {
                                    var coordinates = _propertyPage.GetType().GetProperty(prop.Name).GetValue(_propertyPage, null) as High.Net.Models.Shared.Blocks.CoordinatesBlock;
                                    writablepageData.Coordinates.Latitude = coordinates.Latitude;
                                    writablepageData.Coordinates.Longitude = coordinates.Longitude;
                                }
                            }
                            _contentRepo.Save((IContent)writablepageData, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                        }
                        else
                        {
                            var propertyPage = _contentRepo.GetDefault<PropertyPage>(propertyTypePage.ContentLink);
                            propertyPage.Name = _propertyPage.PropertyName;

                            foreach (PropertyInfo prop in typeof(PropertyPage).GetProperties().Take(61))
                            {
                                if ("Latitude" != prop.Name && "Longitude" != prop.Name && "Coordinates" != prop.Name)
                                {
                                    propertyPage[prop.Name] = _propertyPage.GetType().GetProperty(prop.Name).GetValue(_propertyPage, null);
                                }
                                else if ("Coordinates" == prop.Name)
                                {
                                    var coordinates = _propertyPage.GetType().GetProperty(prop.Name).GetValue(_propertyPage, null) as High.Net.Models.Shared.Blocks.CoordinatesBlock;
                                    propertyPage.Coordinates.Latitude = coordinates.Latitude;
                                    propertyPage.Coordinates.Longitude = coordinates.Longitude;
                                }
                            }
                            _contentRepo.Save(propertyPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
                        }
                        counter++;
                    }
                }
                return string.Format("{0}, Property Pages Imported Successfully.", StartPage.Name);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static PropertyPage BindProperties(Client _client, CsvReader csvReader, Category catPropertySearch, Category catImagesDetail, Category catImagesFeatured, Category catImagesThumbnails, Category catPDF)
        {
            int intr = 0;
            double dobl = 0.0;
            PropertyPage propertyPage = new PropertyPage();
            propertyPage.PropertyName = csvReader.GetField<String>("Name");
            propertyPage.CreatedOn = DateTime.ParseExact(csvReader.GetField<String>("Created On"), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            propertyPage.Acres = csvReader.GetField<String>("Acres");
            propertyPage.AddressLine1 = csvReader.GetField<String>("Address Line 1");
            propertyPage.AddressLine2 = csvReader.GetField<String>("Address Line 2");
            propertyPage.AirConditioning = csvReader.GetField<String>("Air Conditioning");
            propertyPage.AvailableSqFt = csvReader.GetField<String>("Available Sq Ft");
            propertyPage.BusinessKey = csvReader.GetField<String>("Business Key");
            propertyPage.CAM = csvReader.GetField<String>("CAM");
            propertyPage.CeilingHeight = csvReader.GetField<String>("Ceiling Height");
            propertyPage.City = csvReader.GetField<String>("City");
            propertyPage.Construction = csvReader.GetField<String>("Construction");
            propertyPage.CorporateCenter = csvReader.GetField<String>("Corporate Center");
            propertyPage.County = csvReader.GetField<String>("County");
            propertyPage.PropertyCreatedBy = csvReader.GetField<String>("Created By");
            propertyPage.Currency = csvReader.GetField<String>("Currency");
            propertyPage.Description = new XhtmlString(csvReader.GetField<String>("Description"));
            propertyPage.DockDoors = csvReader.GetField<String>("Dock Doors");
            propertyPage.Electric = csvReader.GetField<String>("Electric");
            propertyPage.Enabled = csvReader.GetField<String>("Enabled");
            propertyPage.ExchangeRate = (double.TryParse(csvReader.GetField<String>("Exchange Rate"), out dobl)) ? dobl : 0.0;
            propertyPage.Featured = csvReader.GetField<String>("Featured");
            propertyPage.FeaturedEndDate = csvReader.GetField<String>("Featured End Date");
            propertyPage.Heating = csvReader.GetField<String>("Heating");
            propertyPage.Keywords = csvReader.GetField<String>("Keywords");
            propertyPage.Latitude = (double.TryParse(csvReader.GetField<String>("Latitude"), out dobl)) ? dobl : 0.0;
            propertyPage.ListingType = csvReader.GetField<String>("Listing Type");
            propertyPage.Location = csvReader.GetField<String>("Location");
            propertyPage.Longitude = (double.TryParse(csvReader.GetField<String>("Longitude"), out dobl)) ? dobl : 0.0;
            propertyPage.PropertyModifiedBy = csvReader.GetField<String>("Modified By");
            propertyPage.ModifiedOn = DateTime.ParseExact(csvReader.GetField<String>("Modified On"), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            propertyPage.Municipality = csvReader.GetField<String>("Municipality");
            propertyPage.OfficeSqFt = csvReader.GetField<String>("Office Sq Ft");
            propertyPage.OverheadDoors = new XhtmlString(csvReader.GetField<String>("Overhead Doors"));
            propertyPage.Owner = csvReader.GetField<String>("Owner");
            propertyPage.Parking = new XhtmlString(csvReader.GetField<String>("Parking"));
            propertyPage.Price = csvReader.GetField<String>("Price").Replace("?", string.Empty); // (int.TryParse(csvReader.GetField<String>("Price"), out intr)) ? intr : 0; ;
            propertyPage.PriceBase = csvReader.GetField<String>("Price (Base)").Replace("?", string.Empty); // (int.TryParse(csvReader.GetField<String>("Price (Base)"), out intr)) ? intr : 0;
            propertyPage.PropertyType = csvReader.GetField<String>("Property Type");
            propertyPage.RecordCreatedOn = csvReader.GetField<String>("Record Created On");
            propertyPage.Rent = (double.TryParse(csvReader.GetField<String>("Rent"), out dobl)) ? dobl : 0.0;
            propertyPage.RentBase = (double.TryParse(csvReader.GetField<String>("Rent (Base)"), out dobl)) ? dobl : 0.0;
            propertyPage.ResponsibleBroker = csvReader.GetField<String>("Responsible Broker");
            propertyPage.Sewer = csvReader.GetField<String>("Sewer");
            propertyPage.Size = (double.TryParse(csvReader.GetField<String>("Size"), out dobl)) ? dobl : 0.0;
            propertyPage.Sprinkler = new XhtmlString(csvReader.GetField<String>("Sprinkler"));
            propertyPage.State = csvReader.GetField<String>("State");
            propertyPage.WorkStatus = csvReader.GetField<String>("Status");
            propertyPage.StatusReason = csvReader.GetField<String>("Status Reason");
            propertyPage.ThirdParty = csvReader.GetField<String>("Third Party");
            propertyPage.UnitofMeasure = csvReader.GetField<String>("Unit of Measure");
            propertyPage.URL = new EPiServer.Url(csvReader.GetField<String>("URL"));
            propertyPage.VideoURL = new EPiServer.Url(csvReader.GetField<String>("Video URL"));
            propertyPage.WarehouseMfgSqFt = (double.TryParse(csvReader.GetField<String>("Warehouse Mfg Sq Ft"), out dobl)) ? dobl : 0.0;
            propertyPage.Water = csvReader.GetField<String>("Water");
            propertyPage.Website = new EPiServer.Url(csvReader.GetField<String>("Website"));
            propertyPage.ZipCode = (int.TryParse(csvReader.GetField<String>("Zip Code"), out intr)) ? intr : 0;
            propertyPage.Zoning = csvReader.GetField<String>("Zoning");
            propertyPage.Coordinates = new Models.Shared.Blocks.CoordinatesBlock { Latitude = propertyPage.Latitude, Longitude = propertyPage.Longitude };

            var result = _client.Query<MediaItem>().SearchFor(propertyPage.BusinessKey).Include(x => x.Categories).ToList();

            //var pageImage = result.Where(x => x.Categories != null && (x.Categories.Contains(catImagesDetail.Id)) && x.Name.Split('.')[0] == propertyPage.BusinessKey).ToList();
            var pageImage = (from item in result
                             where item.Name.Split('.')[0] == propertyPage.BusinessKey
                             where item.Categories != null
                             from itemCat in item.Categories
                             where itemCat.Categories.Contains(catImagesDetail.Id)
                             select item).ToList();

            var pdfDocument = result.Where(x => x.Categories != null && x.Categories.Contains(catPropertySearch.Id)).Where(x => x.Name.Contains(".pdf")).ToList();

            if (pageImage.Count == 0)
            {
                pageImage = (from item in result
                             where item.Name.Split('.')[0] == propertyPage.BusinessKey
                             where item.Categories != null
                             from itemCat in item.Categories
                             where itemCat.Categories.Contains(catImagesFeatured.Id)
                             select item).ToList();

                //pageImage = result.Where(x => x.Categories != null && x.Categories.Contains(catImagesFeatured.Id) && x.Name.Split('.')[0] == propertyPage.BusinessKey).ToList();
            }
            if (pageImage.Count == 0)
            {
                pageImage = (from item in result
                             where item.Name.Split('.')[0] == propertyPage.BusinessKey
                             where item.Categories != null
                             from itemCat in item.Categories
                             where itemCat.Categories.Contains(catImagesThumbnails.Id)
                             select item).ToList();

                //pageImage = result.Where(x => x.Categories != null && x.Categories.Contains(catImagesThumbnails.Id) && x.Name.Split('.')[0] == propertyPage.BusinessKey).ToList();
            }

            propertyPage.PageImage = new MediaReference { Id = pageImage.Count > 0 ? pageImage.FirstOrDefault().Id : 0 };
            propertyPage.PDFDocument = new MediaReference() { Id = pdfDocument.Count > 0 ? pdfDocument.FirstOrDefault().Id : 0 };

            return propertyPage;
        }

        #endregion

    }
}
