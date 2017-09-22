using EPiServer;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using Castle.Core.Resource;

namespace High.Net.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Clear();
            bundles.ResetAll();

            BundleTable.EnableOptimizations = true;
            bundles.UseCdn = true;

            //cdn
            /*jquery*/
            var jqueryCdnPath = "//code.jquery.com/jquery-1.11.3.min.js";
            var jqueryBundle = new ScriptBundle("~/bundles/jquery", jqueryCdnPath).Include("~/Static/lib/Jquery/jquery-1.11.3.js");
            jqueryBundle.CdnFallbackExpression = "window.jquery";
            bundles.Add(jqueryBundle);

            /*jquery-migrate*/
            var jquerymigrateCdnPath = "//code.jquery.com/jquery-migrate-1.0.0.js";
            var jquerymigrateBundle = new ScriptBundle("~/bundles/jquery-migrate", jquerymigrateCdnPath).Include("~/Static/lib/Jquery/jquery-migrate-1.0.0.js");
            jquerymigrateBundle.CdnFallbackExpression = "window.jquerymigrate";
            bundles.Add(jquerymigrateBundle);

            /*bootstrap*/
            var bootstrapCdnPath = "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/js/bootstrap.js";
            var bootstrapJsBundle = new ScriptBundle("~/bundles/bootstrap-js", bootstrapCdnPath).Include("~/Static/lib/bootstrap/js/*.js");
            //bootstrapJsBundle.CdnFallbackExpression = "$.fn.modal";
            bundles.Add(bootstrapJsBundle);

            var bootstrapCdnCssPath = "//cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.5/css/bootstrap.css";
            var bootstrapCssBundle = new StyleBundle("~/bundles/bootstrap-css", bootstrapCdnCssPath).Include("~/Static/lib/bootstrap/css/*.css");
            //bootstrapCssBundle.CdnFallbackExpression = "$.fn.modal";
            bundles.Add(bootstrapCssBundle);

            var bootstrapCdnCssPathOld = "//maxcdn.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.css";
            var bootstrapCssBundleOld = new StyleBundle("~/bundles/bootstrap-css-3.0.0", bootstrapCdnCssPathOld).Include("~/Static/lib/bootstrap/css/*.css");
            //bootstrapCssBundleOld.Transforms.Add(new CssMinify());
            //bootstrapCssBundleOld.CdnFallbackExpression = "$.fn.modal";
            bundles.Add(bootstrapCssBundleOld);

            /*mordenizr*/
            var modernizrCdnPath = "//cdnjs.cloudflare.com/ajax/libs/modernizr/2.8.3/modernizr.min.js";
            var modernizrJsBundle = new ScriptBundle("~/bundles/modernizr", modernizrCdnPath).Include("~/Static/lib/modernizr/modernizr.min.js");
            modernizrJsBundle.CdnFallbackExpression = "window.modernizr";
            bundles.Add(modernizrJsBundle);

            /*jquery.validate*/
            var jqueryValidationCdnPath = "//ajax.aspnetcdn.com/ajax/jquery.validate/1.14.0/jquery.validate.min.js";
            var jqueryValidationJsBundle = new ScriptBundle("~/bundles/jquery-validate", jqueryValidationCdnPath).Include("~/Static/lib/JqueryValidate/jquery.validate.min.js");
            jqueryValidationJsBundle.CdnFallbackExpression = "window.jqueryValidate";
            bundles.Add(jqueryValidationJsBundle);

            /*bootstrap-datetimepicker*/
            var bootstrapDateepickerCdnCssPath = "//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/css/bootstrap-datetimepicker.css";
            var bootstrapDateepickerCssBundle = new StyleBundle("~/bundles/bootstrap-datetimepicker-css", bootstrapDateepickerCdnCssPath).Include("~/Static/lib/bootstrap-datetimepicker/bootstrap-datetimepicker.min.css");
            bootstrapDateepickerCssBundle.CdnFallbackExpression = "window.jquery";
            bundles.Add(bootstrapDateepickerCssBundle);

            var bootstrapDateepickerCdnJsPath = "//cdnjs.cloudflare.com/ajax/libs/bootstrap-datetimepicker/4.17.37/js/bootstrap-datetimepicker.min.js";
            var bootstrapDateepickerCdnJsBundle = new ScriptBundle("~/bundles/bootstrap-datetimepicker-js", bootstrapDateepickerCdnJsPath).Include("~/Static/lib/bootstrap-datetimepicker/bootstrap-datetimepicker.min.js");
            bootstrapDateepickerCdnJsBundle.CdnFallbackExpression = "window.jquery";
            bundles.Add(bootstrapDateepickerCdnJsBundle);

            /*moment*/
            var momentCdnPath = "//cdnjs.cloudflare.com/ajax/libs/moment.js/2.10.6/moment.js";
            var momentJsBundle = new ScriptBundle("~/bundles/moment", momentCdnPath).Include("~/Static/lib/bootstrap-datetimepicker/moment.js");
            momentJsBundle.CdnFallbackExpression = "window.moment";
            bundles.Add(momentJsBundle);

            var fontawesomeCdnPath = "//cdnjs.cloudflare.com/ajax/libs/font-awesome/3.2.1/css/font-awesome.css";
            var fontawesomeCssBundle = new StyleBundle("~/bundles/fontawesome-css", fontawesomeCdnPath).Include("~/Static/global/font-awesome/css/font-awesome.css");
            //fontawesomeCssBundle.CdnFallbackExpression = "window.fontawesome";
            bundles.Add(fontawesomeCssBundle);

            //lib
            /*Jssor*/
            bundles.Add(new ScriptBundle("~/bundles/jssor")
                .Include("~/static/lib/jssor/*.js"));

            /*browserBlast*/
            bundles.Add(new ScriptBundle("~/bundles/browserBlast-js").Include(
                        "~/Static/lib/browserBlast/*.js"));
            bundles.Add(new StyleBundle("~/bundles/browserBlast-css").Include(
                       "~/Static/lib/browserBlast/*.css"));

            /*multiselect*/
            bundles.Add(new StyleBundle("~/bundles/bootstrap-multiselect-css").Include("~/Static/lib/bootstrap-multiselect/bootstrap-multiselect.css"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-multiselect-js").Include("~/Static/lib/bootstrap-multiselect/bootstrap-multiselect.js"));

            /*MvcFoolproofValidation*/
            bundles.Add(new ScriptBundle("~/bundles/MvcFoolproofValidation-js").Include("~/Static/lib/foolproof/MvcFoolproofValidation.min.js"));

            /*MapAreaResponsive*/
            bundles.Add(new ScriptBundle("~/bundles/MapAreaResponsive-js").Include("~/Static/global/js/MapAreaResponsive.js"));

            /*jcarousel*/
            bundles.Add(new ScriptBundle("~/bundles/jcarousel")
                .Include("~/static/lib/jcarousel/*.js"));

            /*bxslider*/
            bundles.Add(new ScriptBundle("~/bundles/bxslider")
                .Include("~/Static/lib/carousel/jquery.bxslider.js"));

            /*fitvids*/
            bundles.Add(new ScriptBundle("~/bundles/fitvids")
                .Include("~/Static/lib/carousel/plugins/jquery.fitvids.js"));

            /*easing*/
            bundles.Add(new ScriptBundle("~/bundles/easing").Include("~/Static/lib/carousel/plugins/jquery.easing.1.3.js"));

            /*responsiveslides*/
            bundles.Add(new ScriptBundle("~/bundles/responsiveslides-js").Include("~/Static/lib/responsiveslides/responsiveslides.min.js"));
            bundles.Add(new StyleBundle("~/bundles/responsiveslides-css").Include("~/Static/lib/responsiveslides/responsiveslides.css"));

            /*owl.carousel*/
            bundles.Add(new StyleBundle("~/bundles/owl-carousel").Include("~/Static/lib/carousel/owl.carousel.css",
                                                                          "~/Static/lib/carousel/owl.theme.css",
                                                                          "~/Static/lib/carousel/owl.transitions.css"));

            bundles.Add(new ScriptBundle("~/bundles/owl-carousel-js").Include("~/Static/lib/carousel/owl.carousel.js"));

            /*jquery.unobtrusive-ajax*/
            bundles.Add(new ScriptBundle("~/bundles/jquery.unobtrusive-ajax").Include("~/Static/lib/jquery.unobtrusive-ajax.min.js"));

            //Google Map
            var googleMapJsPath = "http://maps.google.com/maps/api/js?sensor=false";
            bundles.Add(new ScriptBundle("~/bundles/google-map-js", googleMapJsPath));

            bundles.Add(new ScriptBundle("~/bundles/jquery-csv-js").Include("~/Static/lib/location-js/jquery.csv.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/markerclusterer-js").Include("~/Static/lib/location-js/markerclusterer.js"));

            //global
            var globalCss = new Bundle("~/bundles/global-css").Include("~/static/global/css/global.css", "~/static/global/css/media.css", "~/static/global/css/editmode.css");
            globalCss.Transforms.Add(new CssMinify());
            bundles.Add(globalCss);

            var globalJs = new Bundle("~/bundles/global-js").Include("~/static/global/js/*.js");
            globalJs.Transforms.Add(new JsMinify());
            bundles.Add(globalJs);

            //Generic Page css
            var genericCss = new Bundle("~/bundles/generic-css").Include("~/Static/global/css/genericpage.css");
            genericCss.Transforms.Add(new CssMinify());
            bundles.Add(genericCss);

            //High Companies
            var highNetJs = new Bundle("~/bundles/highnet-js").Include("~/Static/highnet/js/*.js");
            highNetJs.Transforms.Add(new JsMinify());
            bundles.Add(highNetJs);

            var highNetCss = new Bundle("~/bundles/highnet-css").Include("~/Static/highnet/css/style.css", "~/Static/highnet/css/media.css");
            highNetCss.Transforms.Add(new CssMinify());
            bundles.Add(highNetCss);

            var highnetparallaxCss = new Bundle("~/bundles/highnetparallax-css").Include("~/Static/highnet/parallax/video.css");
            highnetparallaxCss.Transforms.Add(new CssMinify());
            bundles.Add(highnetparallaxCss);

            var highNetResuableCompJs = new Bundle("~/bundles/highnet-resuablecomponent-js").Include("~/Static/highnet/reusable-components/js/slick.js", "~/Static/highnet/reusable-components/js/site.js");
            highNetResuableCompJs.Transforms.Add(new JsMinify());
            bundles.Add(highNetResuableCompJs);

            var highNetResuableCompCss = new Bundle("~/bundles/highnet-resuablecomponent-css").Include("~/Static/highnet/reusable-components/css/slick.css", "~/Static/highnet/reusable-components/css/slick-theme.css", "~/Static/highnet/reusable-components/css/style.css", "~/Static/highnet/reusable-components/css/media.css");
            highNetResuableCompCss.Transforms.Add(new CssMinify());
            bundles.Add(highNetResuableCompCss);

            //Commercial
            var commercialJs = new Bundle("~/bundles/commercial-js").Include("~/Static/commercial/js/*.js");
            commercialJs.Transforms.Add(new JsMinify());
            bundles.Add(commercialJs);

            var commercialCss = new Bundle("~/bundles/commercial-css").Include("~/Static/commercial/css/style.css", "~/Static/commercial/css/media.css");
            commercialCss.Transforms.Add(new CssMinify());
            bundles.Add(commercialCss);

            //self-storage
            var selfstorageJs = new Bundle("~/bundles/self-storage-js").Include("~/Static/self-storage/js/site.js", "~/Static/self-storage/js/main.js");
            selfstorageJs.Transforms.Add(new JsMinify());
            bundles.Add(selfstorageJs);

            var selfstorageCss = new Bundle("~/bundles/self-storage-css").Include("~/Static/self-storage/css/style.css", "~/Static/self-storage/css/media.css");
            selfstorageCss.Transforms.Add(new CssMinify());
            bundles.Add(selfstorageCss);

            //Humanity

            var humanityCss = new Bundle("~/bundles/humanity-css").Include("~/Static/humanity/css/style.css", "~/Static/humanity/css/media.css");
            humanityCss.Transforms.Add(new CssMinify());
            bundles.Add(humanityCss);


            //Commercial-Rollover
            var commercialRolloverCss = new Bundle("~/bundles/commercial-rollover-css").Include("~/Static/commercial-rollover/css/style.css", "~/Static/commercial-rollover/css/media.css");
            commercialRolloverCss.Transforms.Add(new CssMinify());
            bundles.Add(commercialRolloverCss);

            var commercialRolloverJs = new Bundle("~/bundles/commercial-rollover-js").Include("~/Static/commercial-rollover/js/site.js");
            commercialRolloverJs.Transforms.Add(new JsMinify());
            bundles.Add(commercialRolloverJs);

            //Residential-Rollover
            var residentialRolloverCss = new Bundle("~/bundles/residential-rollover-css").Include("~/Static/residential-rollover/css/style.css", "~/Static/residential-rollover/css/media.css");
            residentialRolloverCss.Transforms.Add(new CssMinify());
            bundles.Add(residentialRolloverCss);

            var residentialRolloverJs = new Bundle("~/bundles/residential-rollover-js").Include("~/Static/residential-rollover/js/site.js");
            residentialRolloverJs.Transforms.Add(new JsMinify());
            bundles.Add(residentialRolloverJs);

            //regional-retail-Rollover
            var regionalRetailRolloverCss = new Bundle("~/bundles/regional-retail-rollover-css").Include("~/Static/regional retail/css/style.css", "~/Static/regional retail/css/media.css");
            regionalRetailRolloverCss.Transforms.Add(new CssMinify());
            bundles.Add(regionalRetailRolloverCss);

            var regionalRetailRolloverJs = new Bundle("~/bundles/regional-retail-rollover-js").Include("~/Static/regional retail/js/site.js");
            regionalRetailRolloverJs.Transforms.Add(new JsMinify());
            bundles.Add(regionalRetailRolloverJs);

            //regional-retail-OpportunityItemPage-Rollover
            var opportunityItemPageRolloverCss = new Bundle("~/bundles/opportunityItemPage-retail-rollover-css").Include("~/Static/regional retail/css/thumb.css");
            opportunityItemPageRolloverCss.Transforms.Add(new CssMinify());
            bundles.Add(opportunityItemPageRolloverCss);

            var opportunityItemPageRolloverJs = new Bundle("~/bundles/opportunityItemPage-retail-rollover-js").Include("~/Static/regional retail/js/thumb.js");
            opportunityItemPageRolloverJs.Transforms.Add(new JsMinify());
            bundles.Add(opportunityItemPageRolloverJs);

            //high hotels
            var hotelCss = new Bundle("~/bundles/hotels-css").Include("~/Static/high-hotels/css/style.css", "~/Static/high-hotels/css/media.css");
            hotelCss.Transforms.Add(new CssMinify());
            bundles.Add(hotelCss);

            var hotelJs = new Bundle("~/bundles/hotels-js").Include("~/Static/high-hotels/js/*.js");
            hotelJs.Transforms.Add(new JsMinify());
            bundles.Add(hotelJs);

            //Real Estate Group
            var realEstateCss = new Bundle("~/bundles/realEstateGroup-css").Include("~/Static/real-estate-group/css/thumb.css",
                "~/Static/real-estate-group/css/style.css", "~/Static/real-estate-group/css/media.css");
            realEstateCss.Transforms.Add(new CssMinify());
            bundles.Add(realEstateCss);

            var realEstateJs = new Bundle("~/bundles/realEstateGroup-js").Include("~/Static/real-estate-group/js/site.js");
            realEstateJs.Transforms.Add(new JsMinify());
            bundles.Add(realEstateJs);

            //High Associates
            var highAssociatesCss = new Bundle("~/bundles/highassociates-css").Include("~/Static/associates/css/main-slider.css",
                "~/Static/associates/css/style.css", "~/Static/associates/css/media.css");
            highAssociatesCss.Transforms.Add(new CssMinify());
            bundles.Add(highAssociatesCss);

            var highAssociatesJs = new Bundle("~/bundles/highassociates-js").Include("~/Static/associates/js/main-slider.js");
            highAssociatesJs.Transforms.Add(new JsMinify());
            bundles.Add(highAssociatesJs);

            //High Appraisals
            var highAppraisalCss = new Bundle("~/bundle/highappraisal-css").Include("~/Static/high-apprisal/css/style.css", "~/Static/high-apprisal/css/media.css");
            highAppraisalCss.Transforms.Add(new CssMinify());
            bundles.Add(highAppraisalCss);

            var highAppraisalJs = new Bundle("~/bundle/highappraisal-js").Include("~/Static/high-apprisal/js/*.js");
            highAppraisalJs.Transforms.Add(new JsMinify());
            bundles.Add(highAppraisalJs);

            //High Concrete Group LLC
            var highConcreteJs = new Bundle("~/bundles/highconcrete-js").Include("~/Static/highconcrete/js/site.js",
                                                                                 "~/Static/highconcrete/js/fxnewsletter.js");
            highConcreteJs.Transforms.Add(new JsMinify());
            bundles.Add(highConcreteJs);

            var highConcreteCss = new Bundle("~/bundles/highconcrete-css").Include("~/Static/highconcrete/css/style.css",
                "~/Static/highconcrete/css/media.css",
                "~/Static/highconcrete/css/thumb.css");
            highConcreteCss.Transforms.Add(new CssMinify());
            bundles.Add(highConcreteCss);

            var highConcreteProductBannerCss = new Bundle("~/bundles/highconcreteProductBanner-css").Include("~/Static/highconcrete/css/banner.css");
            highConcreteProductBannerCss.Transforms.Add(new CssMinify());
            bundles.Add(highConcreteProductBannerCss);

            var highConcreteProductBannerJs = new Bundle("~/bundles/highconcreteProductBanner-js").Include("~/Static/highconcrete/js/banner.js");
            highConcreteProductBannerJs.Transforms.Add(new JsMinify());
            bundles.Add(highConcreteProductBannerJs);

            var highConcretePrintCutSheetCss = new Bundle("~/bundles/highConcretePrintCutSheetCss").Include("~/Static/highconcrete/css/print.css");
            highConcretePrintCutSheetCss.Transforms.Add(new CssMinify());
            bundles.Add(highConcretePrintCutSheetCss);

            //Residential
            var residentialCss = new Bundle("~/bundles/residential-css").Include("~/Static/residential/css/style.css", "~/Static/residential/css/media.css");
            residentialCss.Transforms.Add(new CssMinify());
            bundles.Add(residentialCss);

            var residentialJs = new Bundle("~/bundles/residential-js").Include("~/Static/residential/js/site.js");
            residentialJs.Transforms.Add(new JsMinify());
            bundles.Add(residentialJs);

            //structurecareus
            var structurecareusCss = new Bundle("~/bundles/structurecareus-css").Include("~/Static/structurecareus/css/style.css", "~/Static/structurecareus/css/media.css");
            structurecareusCss.Transforms.Add(new CssMinify());
            bundles.Add(structurecareusCss);

            var structurecareusJs = new Bundle("~/bundles/structurecareus-js").Include("~/Static/structurecareus/js/site.js");
            structurecareusJs.Transforms.Add(new JsMinify());
            bundles.Add(structurecareusJs);

            //high concrete-assoccesories
            var highconcreteassoccesoriesCss = new Bundle("~/bundles/high-concrete-assoccesories-css").Include("~/Static/concrete-assoccesories/css/photos.css",
                                                                                                           "~/Static/concrete-assoccesories/css/style.css",
                                                                                                           "~/Static/concrete-assoccesories/css/media.css");
            highconcreteassoccesoriesCss.Transforms.Add(new CssMinify());
            bundles.Add(highconcreteassoccesoriesCss);

            var highconcreteassoccesoriesJs = new Bundle("~/bundles/high-concrete-assoccesories-js").Include("~/Static/concrete-assoccesories/js/photos.js");
            highconcreteassoccesoriesJs.Transforms.Add(new JsMinify());
            bundles.Add(highconcreteassoccesoriesJs);

            //Construction
            var constructionCss = new Bundle("~/bundles/construction-css").Include("~/Static/high-construction-co/css/style.css", "~/Static/high-construction-co/css/media.css");
            constructionCss.Transforms.Add(new CssMinify());
            bundles.Add(constructionCss);

            var constructionBannerCss = new Bundle("~/bundles/constructionBanner-css").Include("~/Static/high-construction-co/css/banner.css");
            constructionBannerCss.Transforms.Add(new CssMinify());
            bundles.Add(constructionBannerCss);

            var constructionJs = new Bundle("~/bundles/construction-js").Include("~/Static/high-construction-co/js/site.js");
            constructionJs.Transforms.Add(new JsMinify());
            bundles.Add(constructionJs);

            var constructionBannerJs = new Bundle("~/bundles/constructionBanner-js").Include("~/Static/high-construction-co/js/banner.js");
            constructionBannerJs.Transforms.Add(new JsMinify());
            bundles.Add(constructionBannerJs);

            //High Steel Service Center
            var highsteelservicecenterCss = new Bundle("~/bundles/highsteelservicecenter-css").Include("~/Static/steel-service-centre/css/style.css",
                                                                                                       "~/Static/steel-service-centre/css/team.css",
                                                                                                       "~/Static/steel-service-centre/css/media.css");
            highsteelservicecenterCss.Transforms.Add(new CssMinify());
            bundles.Add(highsteelservicecenterCss);

            var highsteelservicecenterJs = new Bundle("~/bundles/highsteelservicecenter-js").Include("~/Static/steel-service-centre/js/site.js");
            highsteelservicecenterJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelservicecenterJs);

            var highhighsteelservicecenterTeamJs = new Bundle("~/bundles/highsteelservicecenterTeam-js").Include("~/Static/steel-service-centre/js/team.js");
            highhighsteelservicecenterTeamJs.Transforms.Add(new JsMinify());
            bundles.Add(highhighsteelservicecenterTeamJs);

            //High Steel Service Center jcarousel.responsive
            var HsscjcarouselResponsiveCss = new Bundle("~/bundles/HsscjcarouselResponsive-css").Include("~/Static/steel-service-centre/css/jcarousel.responsive.css");
            HsscjcarouselResponsiveCss.Transforms.Add(new CssMinify());
            bundles.Add(HsscjcarouselResponsiveCss);

            var HsscjcarouselResponsiveJs = new Bundle("~/bundles/HsscjcarouselResponsive-Js").Include("~/Static/steel-service-centre/js/jcarousel.responsive.js");
            HsscjcarouselResponsiveJs.Transforms.Add(new JsMinify());
            bundles.Add(HsscjcarouselResponsiveJs);

            //High Steel Structure

            var highsteelCss = new Bundle("~/bundles/highsteel-css").Include(
                "~/Static/high-steel-structure/css/style.css",
                "~/Static/high-steel-structure/css/media.css");
            highsteelCss.Transforms.Add(new CssMinify());
            bundles.Add(highsteelCss);

            var highsteelflexsliderCss = new Bundle("~/bundles/highsteelflexslider-css").Include("~/Static/high-steel-structure/css/flexslider.css");
            highsteelflexsliderCss.Transforms.Add(new CssMinify());
            bundles.Add(highsteelflexsliderCss);

            var highsteelflexsliderJs = new Bundle("~/bundles/highsteelflexslider-js").Include("~/Static/high-steel-structure/js/jquery.flexslider.js");
            highsteelflexsliderJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelflexsliderJs);

            var highsteelthumbCss = new Bundle("~/bundles/highsteel-thumbcss").Include("~/Static/high-steel-structure/css/thumb.css");
            highsteelthumbCss.Transforms.Add(new CssMinify());
            bundles.Add(highsteelthumbCss);

            var highsteelthumbJs = new Bundle("~/bundles/highsteel-thumbjs").Include("~/Static/high-steel-structure/js/thumb.js");
            highsteelthumbJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelthumbJs);

            var highsteelJs = new Bundle("~/bundles/highsteel-js").Include("~/Static/high-steel-structure/js/jquery.flexslider.js",
                "~/Static/high-steel-structure/js/jquery.isotope.js",
                "~/Static/high-steel-structure/js/link-hover.js");
            highsteelJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelJs);

            var highsteelsiteJs = new Bundle("~/bundle/highsteelsite-js").Include("~/Static/high-steel-structure/js/site.js");
            highsteelsiteJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelsiteJs);

            var highsteelfancyboxJs = new Bundle("~/bundles/highsteelfancybox-js").Include("~/Static/high-steel-structure/assets/fancybox/source/jquery.fancybox.js");
            highsteelfancyboxJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelfancyboxJs);

            var highsteelrevulationJs = new Bundle("~/bundles/highsteelrevulation-js").Include("~/Static/high-steel-structure/js/revulation-slide.js");
            highsteelrevulationJs.Transforms.Add(new JsMinify());
            bundles.Add(highsteelrevulationJs);

            bundles.Add(new ScriptBundle("~/bundles/highsteelrevolutionslider-js").Include("~/Static/high-steel-structure/assets/revolution_slider/rs-plugin/js/jquery.themepunch.plugins.min.js",
                "~/Static/high-steel-structure/assets/revolution_slider/rs-plugin/js/jquery.themepunch.revolution.min.js"));

            //High Industries
            var industriesCss = new Bundle("~/bundles/industries-css").Include("~/Static/industries/css/thumb.css", "~/Static/industries/css/style.css", "~/Static/industries/css/media.css", "~/Static/industries/css/main-slider.css");
            industriesCss.Transforms.Add(new CssMinify());
            bundles.Add(industriesCss);

            var industriesJs = new Bundle("~/bundles/industries-Js").Include("~/Static/industries/js/main-slider.min.js", "~/Static/industries/js/site.js");
            industriesJs.Transforms.Add(new JsMinify());
            bundles.Add(industriesJs);

            var thumbJs = new Bundle("~/bundles/thumb-Js").Include("~/Static/industries/js/thumb.js");
            thumbJs.Transforms.Add(new JsMinify());
            bundles.Add(thumbJs);

            //High Transit LLC
            var hightransitCss = new Bundle("~/bundles/hightransit-css").Include("~/Static/high-transit/css/style.css", "~/Static/high-transit/css/media.css");
            hightransitCss.Transforms.Add(new CssMinify());
            bundles.Add(hightransitCss);

            var hightransitJs = new Bundle("~/bundles/hightransit-js").Include("~/Static/high-transit/js/site.js");
            hightransitJs.Transforms.Add(new JsMinify());
            bundles.Add(hightransitJs);

            //High Transit responsiveCarousel scroller
            var hightransitCarouselCss = new Bundle("~/bundles/hightransitCarousel-css").Include("~/Static/high-transit/assets/scroller/styles.css");
            hightransitCarouselCss.Transforms.Add(new CssMinify());
            bundles.Add(hightransitCarouselCss);

            var hightransitCarouselJs = new Bundle("~/bundles/hightransitCarousel-js").Include("~/Static/high-transit/assets/scroller/responsiveCarousel.min.js");
            hightransitCarouselJs.Transforms.Add(new JsMinify());
            bundles.Add(hightransitCarouselJs);
            //Green field archietect
            var GreenFieldArchietectCss = new Bundle("~/bundles/GreenFieldArchietect-css").Include("~/Static/greenfield-architects/css/style.css", "~/Static/greenfield-architects/css/media.css");
            GreenFieldArchietectCss.Transforms.Add(new CssMinify());
            bundles.Add(GreenFieldArchietectCss);

            var GreenFieldArchietectJs = new Bundle("~/bundles/GreenFieldArchietect-js").Include("~/Static/greenfield-architects/js/site.js");
            GreenFieldArchietectJs.Transforms.Add(new JsMinify());
            bundles.Add(GreenFieldArchietectJs);
        }
    }
}