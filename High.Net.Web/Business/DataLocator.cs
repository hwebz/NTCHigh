using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAccess;
using EPiServer.Find;
using EPiServer.Find.Cms;
using EPiServer.Find.Framework;
using EPiServer.Find.Framework.Statistics;
using EPiServer.Find.UnifiedSearch;
using EPiServer.Globalization;
using EPiServer.Logging;
using EPiServer.Security;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Routing;
using High.Net.Core;
using High.Net.Core.Caching;
using High.Net.Models.Constants;
using High.Net.Models.HighConcrete.Blocks;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Models.HighConcrete.ViewModels;
using High.Net.Models.Shared.Pages;
using High.Net.Models.Shared.ViewModels;
using High.Net.Web.Business.ViewModels;
using High.Net.Web.Controllers.HighConcrete;
using High.Net.Web.ViewModels;
using High.Net.Web.ViewModels.Shared;
using LinqToTwitter;

namespace High.Net.Web.Business
{
    public class DataLocator
    {
        private readonly ICache _cacheManager;
        private static readonly string SiteNameCacheKey = "site_name_cache_key";
        private static readonly ILogger Logger = LogManager.GetLogger(typeof(DataLocator));

        public DataLocator(ICache cache)
        {
            _cacheManager = cache;
        }

        public IEnumerable<PropertyPage> SearchProperty(PropertyPageModel model)
        {
            ITypeSearch<PropertyPage> query = SearchClient.Instance.Search<PropertyPage>().For(model.propertySearchForm.Keywords);

            var client = Client.CreateFromConfig();

            if (model.propertySearchForm.ListingType != null)
            {
                var ListingTypeFilter = client.BuildFilter<PropertyPage>();
                foreach (var item in model.propertySearchForm.ListingType)
                {
                    if (item != "-1")
                    {
                        ListingTypeFilter = ListingTypeFilter.Or(x => x.ListingType.Match(item));
                    }
                }
                query = query.Filter(ListingTypeFilter);
            }

            if (!string.IsNullOrEmpty(model.propertySearchForm.Location) && model.propertySearchForm.Location != "-1")
            {
                if (model.propertySearchForm.Location.ToLower() == "all pa")
                {
                    query = query.Filter(x => x.State.Match("PA"));
                }
                else if (model.propertySearchForm.Location.ToLower() == "all nc")
                {
                    query = query.Filter(x => x.State.Match("NC"));
                }
                else if (model.propertySearchForm.Location.ToLower() == "all fl")
                {
                    query = query.Filter(x => x.State.Match("FL"));
                }
                else
                {
                    query = query.Filter(x => x.Location.Match(model.propertySearchForm.Location));
                }
            }

            if (model.propertySearchForm.PropertyType != null)
            {
                var PropertyTypeFilter = client.BuildFilter<PropertyPage>();
                foreach (var item in model.propertySearchForm.PropertyType)
                {
                    if (item != "-1")
                    {
                        PropertyTypeFilter = PropertyTypeFilter.Or(x => x.PropertyType.Match(item));
                    }
                }
                query = query.Filter(PropertyTypeFilter);
            }

            if (model.propertySearchForm.Size != null)
            {
                if (model.propertySearchForm.Size.First() != 0.0 && model.propertySearchForm.Size.Last() != 0.0)
                {
                    query = query.Filter(x => x.Size.InRange(model.propertySearchForm.Size.First(), model.propertySearchForm.Size.Last()));
                }
                else if (model.propertySearchForm.Size.First() != 0.0)
                {
                    query = query.Filter(x => x.Size.Match(model.propertySearchForm.Size.First()) | x.Size.GreaterThan(model.propertySearchForm.Size.First()));
                }
                else if (model.propertySearchForm.Size.Last() != 0.0)
                {
                    query = query.Filter(x => x.Size.Match(model.propertySearchForm.Size.Last()) | x.Size.LessThan(model.propertySearchForm.Size.Last()));
                }
            }

            if (model.propertySearchForm.Rent != null)
            {
                if (model.propertySearchForm.Rent.First() != 0.0 && model.propertySearchForm.Rent.Last() != 0.0)
                {
                    query = query.Filter(x => x.Rent.InRange(model.propertySearchForm.Rent.First(), model.propertySearchForm.Rent.Last()));
                }
                else if (model.propertySearchForm.Rent.First() != 0.0)
                {
                    query = query.Filter(x => x.Rent.Match(model.propertySearchForm.Rent.First()) | x.Rent.GreaterThan(model.propertySearchForm.Rent.First()));
                }
                else if (model.propertySearchForm.Rent.Last() != 0.0)
                {
                    query = query.Filter(x => x.Rent.Match(model.propertySearchForm.Rent.Last()) | x.Rent.LessThan(model.propertySearchForm.Rent.Last()));
                }
            }

            if (model.propertySearchForm.RentBase != null)
            {
                if (model.propertySearchForm.RentBase.First() != 0.0 && model.propertySearchForm.RentBase.Last() != 0.0)
                {
                    query = query.Filter(x => x.RentBase.InRange(model.propertySearchForm.RentBase.First(), model.propertySearchForm.RentBase.Last()));
                }
                else if (model.propertySearchForm.RentBase.First() != 0.0)
                {
                    query = query.Filter(x => x.RentBase.Match(model.propertySearchForm.RentBase.First()) | x.RentBase.GreaterThan(model.propertySearchForm.RentBase.First()));
                }
                else if (model.propertySearchForm.RentBase.Last() != 0.0)
                {
                    query = query.Filter(x => x.RentBase.Match(model.propertySearchForm.RentBase.Last()) | x.RentBase.LessThan(model.propertySearchForm.RentBase.Last()));
                }
            }

            var results = query.Filter(x => x.Ancestors().Match(model.propertySearchForm.RootPage != null ? model.propertySearchForm.RootPage.ID.ToString() : PageReference.StartPage.ID.ToString())).Take(1000).GetPagesResult<PropertyPage>();

            return results.Where(x => !x.IsDeleted && !x.IsPendingPublish);
        }

        public ColorSelectorModel SearchColorSelectorCriteria(ColorSelectorModel _colorSelectorModel, ColorSelectorListingPageController colorSelectorListingPageController, int page)
        {
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var skipNumber = 0;
            int pageSize = 24;
            if (page > 0)
                skipNumber = (page - 1) * pageSize;

            var result = new List<ColorFinishesBlock>();
            if (_colorSelectorModel.CurrentPage.mainContentArea != null && _colorSelectorModel.CurrentPage.mainContentArea.Items.Any())
            {
                foreach (var item in _colorSelectorModel.CurrentPage.mainContentArea.Items)
                {
                    var _colorFinishItem = _contentRepository.Get<ColorFinishesBlock>(item.ContentLink);
                    result.Add(_colorFinishItem);
                }
            }

            //var query = SearchClient.Instance.Search<ColorFinishesBlock>();
            if (!String.IsNullOrWhiteSpace(_colorSelectorModel.colorSelectorForm.color))
            {
                //query = query.Filter(x => x.Color.Match(_colorSelectorModel.colorSelectorForm.color));
                result = result.Where(x => x.Color == _colorSelectorModel.colorSelectorForm.color).ToList();
            }
            if (!String.IsNullOrWhiteSpace(_colorSelectorModel.colorSelectorForm.texture))
            {
                result = result.Where(x => x.Texture == _colorSelectorModel.colorSelectorForm.texture).ToList();
                //query = query.Filter(x => x.Texture.Match(_colorSelectorModel.colorSelectorForm.texture));
            }
            if (!String.IsNullOrWhiteSpace(_colorSelectorModel.colorSelectorForm.pattern))
            {
                result = result.Where(x => x.CastPattern == _colorSelectorModel.colorSelectorForm.pattern).ToList();
                //query = query.Filter(x => x.CastPattern.Match(_colorSelectorModel.colorSelectorForm.pattern));
            }

            //_colorSelectorModel.TotalHits = query.Count();
            //_colorSelectorModel.Results = query.GetResult<ColorFinishesBlock>().Skip(skipNumber).Take(pageSize);

            _colorSelectorModel.TotalHits = result.Count();
            _colorSelectorModel.Results = result.Skip(skipNumber).Take(pageSize);

            if (_colorSelectorModel.TotalHits > 0)
            {
                int numberOfPages = (_colorSelectorModel.TotalHits / pageSize) + 1;

                if (numberOfPages > 1)
                {
                    for (int i = 1; i < numberOfPages + 1; i++)
                    {
                        var pagerLink = new ColorSelectorModel.CustomLink();
                        pagerLink.LinkText = (i).ToString();
                        if (page == i)
                        {
                            pagerLink.IsActivePage = true;
                        }

                        pagerLink.Route = colorSelectorListingPageController.Url.ContentRoute(_colorSelectorModel.CurrentPage.ContentLink, new { color = _colorSelectorModel.colorSelectorForm.color, texture = _colorSelectorModel.colorSelectorForm.texture, pattern = _colorSelectorModel.colorSelectorForm.pattern, page = i });
                        _colorSelectorModel.PagerLinks.Add(pagerLink);
                    }
                }
            }

            return _colorSelectorModel;
        }

        public IEnumerable<IContent> GetAncestors(ContentReference contentReference)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var items = contentRepository.GetAncestors(contentReference);
            return items.Reverse().Skip(1);
        }

        public Dictionary<String, List<ContentReference>> GetSiteName()
        {
            var fromCache = _cacheManager.Get<Dictionary<String, List<ContentReference>>>(SiteNameCacheKey);
            if (fromCache == null)
            {
                var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
                var B2B = contentRepository.GetChildren<Models.Commercial.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HA = contentRepository.GetChildren<Models.Associates.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var EOH = contentRepository.GetChildren<Models.Humanity.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var SSC = contentRepository.GetChildren<Models.SteelServiceCentre.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HN = contentRepository.GetChildren<Models.HighNet.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var SCU = contentRepository.GetChildren<Models.StructureCareUs.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HII = contentRepository.GetChildren<Models.Industries.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var REG = contentRepository.GetChildren<Models.RealEstateGroup.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var RO = contentRepository.GetChildren<Models.Rollover.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HAPP = contentRepository.GetChildren<Models.HighAppraisal.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HSS = contentRepository.GetChildren<Models.HighSteelStructure.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var GAL = contentRepository.GetChildren<Models.GreenfieldArchitects.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HCC = contentRepository.GetChildren<Models.HighConstructionCo.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HH = contentRepository.GetChildren<Models.HighHotels.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HC = contentRepository.GetChildren<Models.HighConcrete.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HCA = contentRepository.GetChildren<Models.HighConcreteAccessories.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var HT = contentRepository.GetChildren<Models.HighTransit.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var BR = contentRepository.GetChildren<Models.Residential.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();
                var PSS = contentRepository.GetChildren<Models.SelfStorage.Pages.HomePage>(PageReference.RootPage).Select(x => x.ContentLink).ToList();

                Dictionary<String, List<ContentReference>> siteGroup = new Dictionary<String, List<ContentReference>>();
                siteGroup.Add(SiteGroups.B2B, B2B);
                siteGroup.Add(SiteGroups.HA, HA);
                siteGroup.Add(SiteGroups.EOH, EOH);
                siteGroup.Add(SiteGroups.SSC, SSC);
                siteGroup.Add(SiteGroups.HN, HN);
                siteGroup.Add(SiteGroups.SCU, SCU);
                siteGroup.Add(SiteGroups.HII, HII);
                siteGroup.Add(SiteGroups.REG, REG);
                siteGroup.Add(SiteGroups.RO, RO);
                siteGroup.Add(SiteGroups.HAPP, HAPP);
                siteGroup.Add(SiteGroups.HSS, HSS);
                siteGroup.Add(SiteGroups.GAL, GAL);
                siteGroup.Add(SiteGroups.HH, HH);
                siteGroup.Add(SiteGroups.HCC, HCC);
                siteGroup.Add(SiteGroups.HC, HC);
                siteGroup.Add(SiteGroups.HCA, HCA);
                siteGroup.Add(SiteGroups.HT, HT);
                siteGroup.Add(SiteGroups.BR, BR);
                siteGroup.Add(SiteGroups.PSS, PSS);

                _cacheManager.Add(siteGroup, SiteNameCacheKey, TimeSpan.FromMinutes(3));
                return siteGroup;
            }

            return fromCache;
        }

        public YoutubeInfo GetYoutubeInfo(Url videoUrl)
        {
            var cacheKey = $"GetYoutubeInfo{videoUrl.ToString()}";
            if (string.IsNullOrEmpty(videoUrl?.ToString()))
                return null;

            if (_cacheManager.Exists(cacheKey))
                return _cacheManager.Get<YoutubeInfo>(cacheKey);

            var youtubeInfo = new YoutubeInfo()
            {
                Title = GetYouTubeVideoTitle(videoUrl),
                ImageThumbnailUrl = GetYouTubeThumbnail(videoUrl),
                ImageBigThumbnailUrl = GetYouTubeBigThumbnail(videoUrl),
                Url = videoUrl.ToString()
            };

            _cacheManager.Add(youtubeInfo,cacheKey, TimeSpan.FromDays(1));
            return youtubeInfo;
        }

        public string GetYouTubeVideoTitle(Url videoUrl)
        {
            if (string.IsNullOrEmpty(videoUrl?.ToString()))
                return string.Empty;

            var cacheKey = $"GetYouTubeVideoTitle_{videoUrl.ToString()}";
            if (_cacheManager.Exists(cacheKey))
                return _cacheManager.Get<string>(cacheKey);

            var cliptId = GetYoutubeClipId(videoUrl);
            if(string.IsNullOrEmpty(cliptId))
                return string.Empty;
           
            using (var httpClient = new HttpClient())
            {
                var getTask = httpClient.GetStringAsync("http://youtube.com/get_video_info?video_id=" + cliptId);
                getTask.Wait();
                var result = getTask.Result;
                var title = GetArgs(result, "title", '&') ?? string.Empty;

                _cacheManager.Add(title, cacheKey, TimeSpan.FromDays(1));
                return title;
            }
        }
    

        private string GetArgs(string args, string key, char query)
        {
            var iqs = args.IndexOf(query);

            if (iqs == -1) return string.Empty; // or throw an error
            var querystring = (iqs < args.Length - 1) ? args.Substring(iqs + 1) : string.Empty;
            var nvcArgs = HttpUtility.ParseQueryString(querystring);
            return nvcArgs[key];
        }

        public string GetYouTubeThumbnail(Url videoUrl)
        {
            var videoImageLink = ConfigurationManager.AppSettings["YouTubeImageLink"].ToString();
            var clipId = GetYoutubeClipId(videoUrl);
            return string.IsNullOrEmpty(clipId) ? string.Empty : string.Format(videoImageLink, clipId);
        }

        public string GetYouTubeBigThumbnail(Url videoUrl)
        {

            ///var videoImageLink = ConfigurationManager.AppSettings["YouTubeBigImageLink"].ToString();
            //if (string.IsNullOrEmpty(videoImageLink))
            //{
            //    videoImageLink = "https://img.youtube.com/vi/{0}/maxresdefault.jpg";
            //}
            var videoImageLink = "https://img.youtube.com/vi/{0}/maxresdefault.jpg";
            var clipId = GetYoutubeClipId(videoUrl);
            return string.IsNullOrEmpty(clipId) ? string.Empty : string.Format(videoImageLink, clipId);
        }

        private string GetYoutubeClipId(Url url)
        {
            var videoUrl = url?.ToString() ?? string.Empty;
            if (videoUrl.Contains("/embed/"))
            {
                var mInd = videoUrl.IndexOf("/embed/", StringComparison.Ordinal);
                if (mInd == -1) return string.Empty;
                var strVideoCode = videoUrl.Substring(videoUrl.IndexOf("/embed/", StringComparison.Ordinal) + 7);
                var ind = strVideoCode.IndexOf("?", StringComparison.Ordinal);
                strVideoCode = strVideoCode.Substring(0, ind == -1 ? strVideoCode.Length : ind);
                return strVideoCode;
            }
            else
            {
                return url.QueryCollection.Get("v");
            }
        }

        public SearchContentModel Search(string q, ContentReference searchRoots, Controller searchController, int MaxResults, int page, SearchContentModel model)
        {
            var searchClient = ServiceLocator.Current.GetInstance<IClient>();
            var skipNumber = 0;
            int pageSize = 10;
            model.SearchQuery = q;

            if (page > 0)
                skipNumber = (page - 1) * pageSize;

            var hitSpecification = new HitSpecification { HighlightExcerpt = true, HighlightTitle = true };

            var queryFor = searchClient.UnifiedSearch(
               searchClient.Settings.Languages.GetSupportedLanguage(ContentLanguage.PreferredCulture) ?? EPiServer.Find.Language.None)
               .For(model.SearchQuery);

            var query = queryFor
                .UsingSynonyms()
                .UsingAutoBoost(TimeSpan.FromDays(30))
                //Include a facet whose value is used to show the total number of hits regardless of section.
                //The filter here is irrelevant but should match *everything*.
                .TermsFacetFor(x => x.SearchSection)
                .FilterFacet("AllSections", x => x.SearchSection.Exists())
                //Fetch the specific paging page.
                .Skip(skipNumber)
                .Take(pageSize)
                //Allow editors (from the Find/Optimizations view) to push specific hits to the top 
                //for certain search phrases.
                .ApplyBestBets();

            // obey DNT
            var doNotTrackHeader = HttpContext.Current.Request.Headers.Get("DNT");
            // Should not track when value equals 1
            if (doNotTrackHeader == null || doNotTrackHeader.Equals("0"))
            {
                query = query.Track();
            }

            model.Results = query.GetResult(hitSpecification);
            model.TotalHits = model.Results.TotalMatching;

            if (model.TotalHits > 0)
            {
                double numberOfPages = ((double)model.TotalHits / (double)pageSize);
                bool isInteger = (double)((int)numberOfPages) == numberOfPages;
                if (!isInteger)
                {
                    numberOfPages = (model.TotalHits / pageSize) + 1;
                }

                if (numberOfPages > 1)
                {
                    for (int i = 1; i < numberOfPages + 1; i++)
                    {
                        var pagerLink = new SearchContentModel.CustomLink();
                        pagerLink.LinkText = (i).ToString();
                        if (page == i)
                        {
                            pagerLink.IsActivePage = true;
                        }

                        pagerLink.Route = searchController.Url.ContentRoute(model.CurrentPage.ContentLink, new { q = q, page = i });
                        model.PagerLinks.Add(pagerLink);
                    }
                }
            }
            return model;
        }

        public string GetExternalAbsoluteFriendlyUrl(ContentReference reference, string language)
        {

            var urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();
            var friendlyUrl = urlResolver.GetUrl(reference, language);

            if (string.IsNullOrEmpty(friendlyUrl))
                return friendlyUrl;

            var uri = new Uri(friendlyUrl, UriKind.RelativeOrAbsolute);
            if (uri.IsAbsoluteUri)
                return friendlyUrl;

            if (HttpContext.Current != null)
                return new Uri(HttpContext.Current.Request.Url, uri).ToString();

            var siteDefinitionResolver =
                ServiceLocator.Current.GetInstance<ISiteDefinitionResolver>();
            var siteDefinition =
                siteDefinitionResolver.GetByContent(reference, true, true);

            return new Uri(siteDefinition.SiteUrl, friendlyUrl).ToString();
        }

        public bool sendMail(string subject, string body, string toAddresses, List<System.Net.Mail.Attachment> attachment = null,
            string sender = "", bool IsBodyHtml = true, string bccAddresses = null, string replyToAddresses = null, string displayHighName = null)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = IsBodyHtml;
                mailMessage.Body = body;
                var textInfo = new CultureInfo("en-US").TextInfo;

                foreach (string to in toAddresses.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mailMessage.To.Add(to.Trim());
                }

                if (!String.IsNullOrEmpty(replyToAddresses))
                {
                    foreach (string replyto in replyToAddresses.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        string email = GetEmailInText(replyto);
                        string displayName = string.Empty;
                        if (string.IsNullOrEmpty(displayHighName))
                        {
                            displayName = string.IsNullOrEmpty(Regex.Replace(replyto.Substring(0, replyto.IndexOf(email)), @"[^\w ]", "")) ? textInfo.ToTitleCase(replyto.Substring(0, (replyto.IndexOf("@"))).Replace(".", " ").Replace("_", " ")) : string.Empty;
                        }
                        else
                        {
                            displayName = textInfo.ToTitleCase(displayHighName);
                        }

                        MailAddress replytoAddress = new MailAddress(String.Format("{0} <{1}>", displayName, email));
                        mailMessage.ReplyToList.Add(replytoAddress);
                        mailMessage.From = new MailAddress(String.Format("{0}", replytoAddress));
                        
                    }
                }

                if (bccAddresses != null)
                {
                    foreach (string to in bccAddresses.Split(new string[] { ",", ";" }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        mailMessage.Bcc.Add(to.Trim());
                    }
                }
                if (attachment != null)
                {
                    if (attachment.Count() > 0)
                    {
                        foreach (var item in attachment)
                        {
                            mailMessage.Attachments.Add(item);
                        }
                    }
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Error("Cannot send email, error: " + ex.Message);
                return false;
            }
        }

        public ContentFolder GetOrCreateFolder(ContentReference parentFolder, string folderName)
        {
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var storedFolder = contentRepository.GetChildren<ContentFolder>(parentFolder)
             .FirstOrDefault(f => string.Compare(f.Name, folderName, StringComparison.OrdinalIgnoreCase) == 0);
            if (storedFolder != null)
            {
                return storedFolder;
            }

            var parent = contentRepository.Get<ContentFolder>(parentFolder);
            var folder = contentRepository.GetDefault<ContentFolder>(parent.ContentLink);
            folder.Name = folderName;

            var folderReference = contentRepository.Save(folder, SaveAction.Publish, AccessLevel.NoAccess);

            return contentRepository.Get<ContentFolder>(folderReference);
        }

        public List<NewsItemPage> GetNewsFeed(NewsListingPage currentListingPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<ContentLocator>();

            if (currentListingPage.NewsFeeds != null && currentListingPage.NewsFeeds.Count > 0)
            {
                var newsItems = new List<NewsItemPage>();
                foreach (var item in currentListingPage.NewsFeeds)
                {
                    // deprecated code
                    //string linkUrl = String.Empty;
                    //PermanentLinkMapStore.TryToMapped(item.Href, out linkUrl);
                    //var urlBuilder = new EPiServer.UrlBuilder(linkUrl);
                    //var page = urlResolver.Route(urlBuilder) as PageData;

                    var page = UrlResolver.Current.Route(new UrlBuilder(item.Href));
                    var news = contentLoader.GetAll<NewsItemPage>(page.ContentLink)
                        .Where(x => !x.HideOnParentSite && !x.IsDeleted)
                        .ToList();

                    newsItems.AddRange(news);
                }

                newsItems.AddRange(contentLoader.GetAll<NewsItemPage>(currentListingPage.ContentLink).ToList());

                return newsItems.Where(x => x.CheckPublishedStatus(PagePublishedStatus.Published))
                    .OrderByDescending(x => x.PostedDate).ToList();
            }
            else
            {
                return contentLoader.GetAll<NewsItemPage>(currentListingPage.ContentLink)
                    .Where(x => x.CheckPublishedStatus(PagePublishedStatus.Published))
                    .OrderByDescending(x => x.PostedDate).ToList();
            }
        }

        public NewsItemPage GetLatestFeaturedNews(NewsListingPage currentListingPage)
        {
            var contentLoader = ServiceLocator.Current.GetInstance<ContentLocator>();

            var newsItems = new List<NewsItemPage>();

            foreach (var item in contentLoader.GetAll<NewsItemPage>(currentListingPage.ContentLink))
            {
                newsItems.Add(item);
            }

            var newsItem = newsItems.Where(x => x.CheckPublishedStatus(PagePublishedStatus.Published) && x.FeaturedNews == true)
                                    .OrderByDescending(x => x.PostedDate).FirstOrDefault();

            if (newsItem != null)
            {
                return newsItem;
            }

            newsItem = newsItems.Where(x => x.CheckPublishedStatus(PagePublishedStatus.Published))
                                .OrderByDescending(x => x.PostedDate).FirstOrDefault();
            return newsItem;
        }

        #region Twitter Code
        private SingleUserAuthorizer _authorizer =
        new SingleUserAuthorizer
        {
            CredentialStore =
               new SingleUserInMemoryCredentialStore
               {
                   //ConsumerKey =
                   //    "972o8A95yoEZZ10ao34lrxxDA",
                   //ConsumerSecret =
                   //   "yN56OdQxSUMp56RqPjVkCqxnI5nug8qH35vdPeS1oXP2wLznYt",
                   //AccessToken =
                   //   "811119696552411136-SLUefc3Ndfi92S4Od0WEpdSnco3PUVp",
                   //AccessTokenSecret =
                   //   "1qSMDB4VxfZXYFKNBgJJo4HuBHvKlqkmynSZY6daJyNQu"


                   ConsumerKey =
                      "mxpMQudSAAvaugcBTgIGkoizG",
                   ConsumerSecret =
                      "vY9nFT0mlN6R6onVGZBlzzid5NGwoO9wUICeL5OOXPzZzegMV1",
                   AccessToken =
                      "1934928744-2NI0jN5HCvVeehKAJfuhTuvOxf913miyEVwuDNw",
                   AccessTokenSecret =
                      "wOlwVuP6Yc08JAcgPTqua4AGajRWvldfK5dDhJHn9UmSz"
               }
        };

        public string GetMostRecent200HomeTimeLine()
        {
            var cacheKey = "GetMostRecent200HomeTimeLine_CacheKey";
            if (_cacheManager.Exists(cacheKey))
            {
                return _cacheManager.Get<string>(cacheKey);
            }
            try
            {
                var twitterContext = new TwitterContext(_authorizer);
                var currentTweet = twitterContext.Status.FirstOrDefault(tweet => tweet.Type == StatusType.User &&
                                                                                 !tweet.Text.StartsWith("https") &&
                                                                                 tweet.Count == 1);
                if (currentTweet == null) return string.Empty;
                _cacheManager.Add(currentTweet.Text, cacheKey, TimeSpan.FromMinutes(10));
                return currentTweet.Text;
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        # endregion

        public bool CheckForProjectPages(ContentReference contentLink)
        {
            var contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            return contentLocator.GetAll<ProjectItemPage>(contentLink).Count() != 0 ? true : false;
        }

        public string GetEmailInText(string text)
        {
            string email = string.Empty;
            const string MatchEmailPattern =
                @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(MatchEmailPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Find matches.
            MatchCollection matches = rx.Matches(text);
            // Report the number of matches found.
            int noOfMatches = matches.Count;
            // Report on each match.
            foreach (Match match in matches)
            {
                email += match;
            }
            return email;
        }
    }

}