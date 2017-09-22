using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using EPiServer.ServiceLocation;
using High.Net.Core.Attributes;
using High.Net.Core.Caching;
using ImageVault.Client;
using ImageVault.Client.Query;
using ImageVault.Common.Data;
using ImageVault.EPiServer;
using ImageVault.EPiServer.Common;
using System.Collections.Generic;
using ImageVault.Common.Data.Effects;

namespace High.Net.Core.Helpers
{
    public static class MediaHelpers
    {
        private static readonly Client Client;
        private static readonly ICache EpiCache;

        static MediaHelpers()
        {
            Client = ClientFactory.GetSdkClient();
            EpiCache = ServiceLocator.Current.GetInstance<ICache>();
        }

        /// <summary>
        /// Renders the media.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="mediaReference">The media reference.</param>
        /// <param name="additionalViewData">Route data</param>
        /// <returns>Html string that represents the media</returns>
        public static MvcHtmlString RenderMedia(this HtmlHelper helper, MediaReference mediaReference, object additionalViewData)
        {
            var routeValueDictionary = new RouteValueDictionary(additionalViewData);
            var propertySettings = routeValueDictionary["propertySettings"] as PropertyMediaSettings;
            var cssClass = routeValueDictionary["cssClass"] as string ?? string.Empty;
            var altText = routeValueDictionary["alt"] as string ?? string.Empty;
            var dataImg = routeValueDictionary["dataImage"] as string ?? string.Empty;

            try
            {
                var media = GetWebMedia(mediaReference, propertySettings);
                if (media == null) return MvcHtmlString.Empty;

                var mediaMetaData = GetMediaMetadata(media.Id);

                if (mediaMetaData != null && string.IsNullOrEmpty(altText))
                {
                    altText = mediaMetaData.Caption;
                }

                if (string.IsNullOrEmpty(dataImg))
                {

                    return string.IsNullOrEmpty(cssClass)
                        ? new MvcHtmlString($"<img alt=\"{altText}\" src=\"{media.Url}\">")
                        : new MvcHtmlString($"<img alt=\"{altText}\" class=\"{cssClass}\" src=\"{media.Url}\">");
                }
                return string.IsNullOrEmpty(cssClass)
                    ? new MvcHtmlString($"<img alt=\"{altText}\" src=\"{media.Url}\" data-image=\"{dataImg}\">")
                    : new MvcHtmlString($"<img alt=\"{altText}\" class=\"{cssClass}\" src=\"{media.Url}\" data-image=\"{dataImg}\">");
            }
            catch
            {

                return MvcHtmlString.Empty;
            }
        }

        /// <summary>
        /// Get the url of an image from the reference
        /// </summary>
        /// <param name="mediaReference">Reference to the media</param>
        /// <param name="additionalViewData">Addition info e.g. width, height...</param>
        public static string GetImageUrl(MediaReference mediaReference, object additionalViewData = null)
        {
            if (mediaReference == null) return string.Empty;

            var routeValueDictionary = new RouteValueDictionary(additionalViewData);
            var propertySettings = routeValueDictionary["propertySettings"] as PropertyMediaSettings;

            try
            {
                var media = GetWebMedia(mediaReference, propertySettings);

                return media?.Url ?? string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        private static MediaMetaData GetMediaMetadata(int mediaId)
        {
            var key = $"{nameof(MediaMetaData)}_{mediaId}";
            if (EpiCache.Exists(key)) return EpiCache.Get<MediaMetaData>(key);

            // ReSharper disable once ReplaceWithSingleCallToFirstOrDefault
            var mediaMetaData = Client.Query<MediaMetaData>().Where(x => x.Id == mediaId).FirstOrDefault();
            if (mediaMetaData == null) return null;

            EpiCache.Add(mediaMetaData, key, TimeSpan.FromMinutes(5));
            return mediaMetaData;
        }

        private static WebMedia GetWebMedia(MediaReferenceBase mediaReference, PropertyMediaSettings propertySettings)
        {
            var width = propertySettings?.Width.ToString() ?? string.Empty;
            var height = propertySettings?.Height.ToString() ?? string.Empty;
            var resizeModel = propertySettings?.ResizeMode.ToString() ?? string.Empty;

            var key = GenerateCacheKeyForImg(mediaReference, propertySettings);

            //var key = $"{nameof(WebMedia)}_{mediaReference.Id}_{width}_{height}_{resizeModel}";

            if (EpiCache.Exists(key)) return EpiCache.Get<WebMedia>(key);

            // Start building the query for the specific media
            var query = Client.Load<WebMedia>(mediaReference.Id);

            // Apply editorial effects
            if (mediaReference.Effects.Count > 0)
            {
                query = query.ApplyEffects(mediaReference.Effects);
            }

            WebMedia media;
            //var mediaFormat = GetMediaFormat(mediaReference, propertySettings);
            
            if (propertySettings != null)
            {
                // Videos cannot be cropped so if settings.ResizeMode is ScaleToFill we'll get null
                // Execute the query
                media = query.Resize(propertySettings.Width, propertySettings.Height, propertySettings.ResizeMode).SingleOrDefault() ??
                        query.Resize(propertySettings.Width, propertySettings.Height).SingleOrDefault();
            }
            else
            {
                media = query.SingleOrDefault();
            }

            if (media == null) return null;
            EpiCache.Add(media, key, TimeSpan.FromMinutes(5));
            return media;
        }

        private static string GenerateCacheKeyForImg(MediaReferenceBase mediaReference, PropertyMediaSettings propertySettings)
        {
            var width = propertySettings?.Width.ToString() ?? string.Empty;
            var height = propertySettings?.Height.ToString() ?? string.Empty;
            var resizeModel = propertySettings?.ResizeMode.ToString() ?? string.Empty;

            var effectStr = string.Empty;
            foreach(var effect in mediaReference.Effects)
            {
                if(effect is ResizeEffect) {
                    var resizeEffect = effect as ResizeEffect;

                    effectStr += $"_{resizeEffect.Height}_{resizeEffect.Width}_{resizeEffect.ResizeMode}";
                }
                if(effect is CropEffect)
                {
                    var cropEffect = effect as CropEffect;
                    effectStr += $"_{cropEffect.Height}_{cropEffect.Width}_{cropEffect.X}_{cropEffect.Y}";
                }
            }

            return  $"{nameof(WebMedia)}_{mediaReference.Id}_{effectStr}_{width}_{height}_{resizeModel}"; 
        }

        private static List<MediaFormatBase> GetMediaFormat(MediaReferenceBase mediaReference, PropertyMediaSettings propertySettings)
        {
            var imageFormat = new ImageFormat();
            imageFormat.Effects.AddRange(mediaReference.Effects);

            // if no preference size in MediaReference.Effect, then get from settings.
            if (mediaReference.Effects == null || !mediaReference.Effects.Any())
            {
                var resizeEffect = new ResizeEffect();
                if (propertySettings != null)
                {
                    resizeEffect.Width = propertySettings.Width;
                    resizeEffect.Height = propertySettings.Height;
                    resizeEffect.ResizeMode = propertySettings.ResizeMode;
                }               
                imageFormat.Effects.Add(resizeEffect);
            }

            return mediaReference.Effects == null || !mediaReference.Effects.Any()? null: new List<MediaFormatBase>() { imageFormat };
        }
    }
}