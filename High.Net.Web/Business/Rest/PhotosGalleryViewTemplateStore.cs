using System;
using System.Web.Http;
using EPiServer.Shell.Services.Rest;
using static High.Net.Models.Constants.EditorConstants;

namespace High.Net.Web.Business.Rest
{
    [RestStore("templatestore")]
    public class PhotosGalleryViewTemplateStore : RestControllerBase
    {
        [HttpGet]
        public RestResult Get(string templateId, string uiHint)
        {
            if (string.IsNullOrEmpty(uiHint) || HighUIHint.PhotosGalleryTemplateSelection.Equals(uiHint))
            {
                return Rest(RenderGridImageViewTemplateLayout(templateId));
            }

            if (uiHint.Equals(HighUIHint.NumbericBlockTemplatesSelection))
            {
                return Rest(RenderNumbericViewTemplateLayout(templateId));

            }
            if (uiHint.Equals(HighUIHint.ImageTextBlockTemplatesSelection))
            {
                return Rest(RenderImageTextViewTemplateLayout(templateId));
            }

            if (uiHint.Equals(HighUIHint.TestimonialSliderTemplateSelection))
            {
                return Rest(RenderTestimonialSliderTemplateLayout(templateId));
            }
            if (uiHint.Equals(HighUIHint.AuthorQuoteTemplatesSelection))
            {
                return Rest(RenderAuthorQuoteSliderTemplateLayout(templateId));
            }
            if (uiHint.Equals(HighUIHint.CarouselTemplatesSelection))
            {
                return Rest(RenderCarouselTemplateLayout(templateId));
            }

            return Rest(RenderGridImageViewTemplateLayout(templateId));

        }

        private string RenderCarouselTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case CarouselViewTemplate.HighNetCarousel:
                    return "<img src='/Static/editors/imgs/CarouselBlock/HighnetCarousel.jpg' />";
                case CarouselViewTemplate.LeadershipCarousel:
                    return "<img src='/Static/editors/imgs/CarouselBlock/LeadershipCarousel.jpg' />";
                case CarouselViewTemplate.FamilyCarouselLeftImage:
                    return "<img src='/Static/editors/imgs/CarouselBlock/FamilyCarousel-LeftImg.jpg' />";
                case CarouselViewTemplate.FamilyCarouselRightImage:
                    return "<img src='/Static/editors/imgs/CarouselBlock/FamilyCarousel-RightImg.jpg' />";
                default:
                    return "<img src='/Static/editors/imgs/CarouselBlock/HighnetCarousel.jpg' />";
            }
        }

        private string RenderAuthorQuoteSliderTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case AuthorQuoteSliderViewTemplate.HighNetAuthorQuote:
                    return "<img src='/Static/editors/imgs/AuthorQuote/high-net-author-quote.jpg' />";
                case AuthorQuoteSliderViewTemplate.FamilyAuthorQuote:
                    return "<img src='/Static/editors/imgs/AuthorQuote/family-author-quote.jpg' />";
                default:
                    return "<img src='/Static/editors/imgs/AuthorQuote/high-net-author-quote.jpg' />";
            }
        }

        private string RenderTestimonialSliderTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case TestimonialSliderViewTemplate.HighNetTestimonials:
                    return "<img src='/Static/editors/imgs/HighNetTestimonials.jpg' />";
                case TestimonialSliderViewTemplate.LeadershipTestimonials:
                    return "<img src='/Static/editors/imgs/LeadershipTestimonials.jpg' />";
                default:
                    return "<img src='/Static/editors/imgs/HighNetTestimonials.jpg' />";
            }
        }

        private string RenderImageTextViewTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case ImageTextViewTemplate.FullImage:
                    return "<img src='/Static/editors/imgs/ImageTextBlock/FullWidthImg.jpg' />";
                case ImageTextViewTemplate.ImageInLeft:
                    return "<img src='/Static/editors/imgs/ImageTextBlock/ImgInLeft.jpg' />";
                case ImageTextViewTemplate.ImageBelow:
                    return "<img src='/Static/editors/imgs/ImageTextBlock/ImgBelow.jpg' />";
                default:
                    return "<img src='/Static/editors/imgs/ImageTextBlock/ImgInLeft.jpg' />";
            }
        }

        public string RenderNumbericViewTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case NumbericContentViewTemplate.NumbericTextOnly:
                    return "<img src='/Static/editors/imgs/NumbericTextOnly.jpg' />";
                case NumbericContentViewTemplate.NumbericWithPhotosGallery:
                    return "<img src='/Static/editors/imgs/NumbericWithGallery.jpg' />";
                default:
                    return "<img src='/Static/editors/imgs/NumbericTextOnly.jpg' />";
            }
        }

        public string RenderGridImageViewTemplateLayout(string viewTemplate)
        {
            if (string.IsNullOrEmpty(viewTemplate))
            {
                return string.Empty;
            }
            switch (viewTemplate)
            {
                case PhotoGalleryViewTemplates.GridNoButton:
                    return "<img src='/Static/editors/imgs/GridNoButton.jpg' />";
                case PhotoGalleryViewTemplates.GridNoSpaceNoButton:
                    return "<img src='/Static/editors/imgs/GridNoButtonNoSpace.jpg' />";
                case PhotoGalleryViewTemplates.GridWithButton:
                    return "<img src='/Static/editors/imgs/GridWithButton.jpg' />";
                case PhotoGalleryViewTemplates.GridSliderNoButton:
                    return "<img src='/Static/editors/imgs/GridSliderNoButton.jpg' />";

                default:
                    return "<img src='/Static/editors/imgs/GridNoButton.jpg' />";
            }
        }
    }
}