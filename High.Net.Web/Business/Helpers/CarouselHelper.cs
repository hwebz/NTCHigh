using System.Web.Mvc;
using EPiServer.AddOns.Helpers;
using EPiServer.Core;
using EPiServer.Web.Mvc.Html;
using High.Net.Models.HighNet.Blocks;
using High.Net.Models.HighNet.Pages;
using ImageVault.EPiServer;
using System.Collections.Generic;
using High.Net.Models.NewResidential.Blocks;
using System.Linq;
using High.Net.Core;

namespace High.Net.Web.Business.Helpers
{
    public static class CarouselHelper
    {
        public static CarouselItemModel GetCarouselItemModel(CarouselItemBlock caroulseItem, UrlHelper urlHelper)
        {
            if (caroulseItem == null)
            {
                return null;
            }
            var model = new CarouselItemModel();
            var image = caroulseItem.Image;
            var altText = !string.IsNullOrWhiteSpace(caroulseItem.AltText) ? caroulseItem.AltText : string.Empty;
            var text = caroulseItem.HtmlText;

            if (image == null || string.IsNullOrWhiteSpace(text?.ToString()))
            {
                if (caroulseItem.Link != null)
                {
                    var contentRef = caroulseItem.Link.GetContentReference();
                    var page = contentRef.GetContent<HighNetPageData>();
                    image = image == null && page?.CarouselImage != null ? page.CarouselImage : image;
                    text = string.IsNullOrWhiteSpace(text?.ToString()) && page?.CarouselText != null
                        ? page.CarouselText : text;

                }
            }
            model.Text = text;
            model.Image = image;
            model.Url = urlHelper.ContentUrl(caroulseItem.Link);
            model.AltText = altText;
            return model;
        }

        public static List<List<ImageTextBlock>> GetPhotosGridGallerySliders(PhotosGridGalleryBlock block)
        {
            var result = new List<List<ImageTextBlock>>();

            if (block == null || block.PhotoItems.IsNullOrEmpty())
            {
                return result;
            }

            List<ImageTextBlock> allItems = new List<ImageTextBlock>();
            foreach (var item in block.PhotoItems.FilteredItems)
            {
                var contentItem = item.ContentLink.GetContent<ImageTextBlock>();
                if (contentItem != null) { allItems.Add(contentItem); }
            }

            if (allItems.IsNullOrEmpty()) { return result; }

            var totalItemPerSlide = 3 * (block.NumberOfColums > 0 ? block.NumberOfColums : 3);
            var totalSlides = allItems.Count();

            var idx = 0;
            while (idx < totalSlides)
            {
                if (idx + totalItemPerSlide <= totalSlides)
                {
                    result.Add(allItems.GetRange(idx, totalItemPerSlide));
                    idx += totalItemPerSlide;
                }
                else
                {
                    result.Add(allItems.GetRange(idx, totalSlides-idx));
                    idx = totalSlides;
                }
            }
            return result;
        }

    }

    public class CarouselItemModel
    {
        public MediaReference Image { get; set; }
        public string AltText { get; set; }
        public XhtmlString Text { get; set; }
        public string Url { get; set; }
    }
}