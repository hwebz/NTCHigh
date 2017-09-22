using System;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Core.Html.StringParsing;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using EPiServer;

namespace High.Net.Core.Rendering
{
    /// <summary>
    /// Extends the default <see cref="ContentAreaRenderer"/> to apply custom CSS classes to each <see cref="ContentFragment"/>.
    /// </summary>
    public class BootstrapContentAreaRenderer : ContentAreaRenderer
    {
        protected override string GetContentAreaItemCssClass(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
        {
            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
            return string.Format("block {0} {1} {2} {3}", GetTypeSpecificCssClasses(contentAreaItem, ContentRepository), GetCssClassForTag(tag), tag, htmlHelper.ViewContext.ViewData["childrencssclass"] as string);
        }

        public string GetItemCssClass(HtmlHelper htmlHelper, ContentAreaItem contentAreaItem)
        {
            var tag = GetContentAreaItemTemplateTag(htmlHelper, contentAreaItem);
            var baseClasses = base.GetContentAreaItemCssClass(htmlHelper, contentAreaItem);
            return string.Format("block {0} {1} {2} {3}", GetTypeSpecificCssClasses(contentAreaItem, ContentRepository), GetCssClassForTag(tag), tag, baseClasses);
        }

        /// <summary>
        /// Gets a CSS class used for styling based on a tag name (ie a Bootstrap class name)
        /// </summary>
        /// <param name="tagName">Any tag name available, see <see cref="Global.ContentAreaTags"/></param>
        private static string GetCssClassForTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
            {
                return "";
            }
            switch (tagName.ToLower())
            {
                case "full":
                    return "col-md-12"; //"full";
                case "three-fourth":
                    return "col-md-9"; //"three-fourth";
                case "wide":
                    return "col-md-8"; //"wide";
                case "half":
                    return "col-sm-12 col-md-6"; //"half";
                case "narrow":
                    return "col-md-4"; //"narrow";
                case "one-quarter":
                    return "col-sm-6 col-md-3"; //"quarter";
                case "small":
                    return "col-md-2"; //"small";
                case "extra-small":
                    return "col-md-1"; //"extra-small";
                default:
                    return string.Empty;
            }
        }

        private static string GetTypeSpecificCssClasses(ContentAreaItem contentAreaItem, IContentRepository contentRepository)
        {
            //depreacted method GetContent
            //var content = contentAreaItem.GetContent(contentRepository);

            var content = contentRepository.Get<IContent>(contentAreaItem.ContentLink);
            var cssClass = content == null ? String.Empty : content.GetOriginalType().Name.ToLowerInvariant();

            var customClassContent = content as ICustomCssInContentArea;
            if (customClassContent != null && !string.IsNullOrWhiteSpace(customClassContent.ContentAreaCssClass))
            {
                cssClass += string.Format("{0}", customClassContent.ContentAreaCssClass);
            }

            return cssClass;
        }
    }
}
