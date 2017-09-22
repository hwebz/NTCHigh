using EPiServer.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace High.Net.Core
{

    public class Global
    {
        /// <summary>
        /// Group names for content types and properties
        /// </summary>
        [GroupDefinitions()]
        public static class Tabs
        {
            [Display(Name = "Global", Order = 1)]
            public const string Global = "Global";

            [Display(Name = "Information", Order = 10)]
            public const string Content = "Information";

            [Display(Name = "Images", Order = 20)]
            public const string Images = "Images";

            [Display(Name = "Sliders", Order = 30)]
            public const string Sliders = "Sliders";

            [Display(Name = "Social", Order = 40)]
            public const string Social = "Social";

            [Display(Name = "SEO", Order = 50)]
            public const string SEO = "SEO";

            [Display(Name = "Rollover", Order = 60)]
            public const string Rollover = "Rollover";

            [Display(Name = "Commerce", Order = 70)]
            public const string Commerce = "Commerceg";

            [Display(Name = "Email Setting", Order = 80)]
            public const string EmailSetting = "Email Setting";

            [Display(Name = "App Settings", Order = 90)]
            public const string AppSettings = "App Settings";

            [Display(Name = "Carousel Settings", Order = 100)]
            public const string CarouselSettings = "Carousel Settings";

            [Display(Name = "Footer Settings", Order = 110)]
            public const string FooterSettings = "Footer Settings";

            [Display(Name = "Template Settings", Order = 120)]
            public const string TemplateSettings = "Template Settings";

            [Display(Name = "Block Settings", Order = 130)]
            public const string BlockSettings = "Block Settings";

            [Display(Name = "Should Be Removed", Order = 130)]
            public const string ShouldBeRemoved = "Should Be Removed";

            [Display(Name = "Contact Settings", Order = 140)]
            public const string ContactSettings = "Contact Settings";

        }

        /// <summary>
        /// Tags to use for the main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaTags
        {
            public const string FullWidth = "full";
            public const string ThreeFourthWidth = "three-fourth";
            public const string TwoThirdsWidth = "wide";
            public const string HalfWidth = "half";
            public const string OneThirdWidth = "narrow";
            public const string OneFourthWidth = "one-quarter";
            public const string OneFifthWidth = "small";
            public const string OneTwelfthWidth = "extra-small";
            public const string NoRenderer = "norenderer";
            public const string Custom = "custom";

            public const string ResidentialHomePage = "Residential Home Page Element";
            public const string ResidentialAdvanceGallery = "Residential Advance Gallery";
            public const string ResidentialContentPage = "Residential Content Element";

            public const string LeadershipContentPage = "Leadership Content Element";
            public const string FamilyContentPage = "Family Content Element";

        }

        /// <summary>
        /// Main widths used in the Bootstrap HTML framework
        /// </summary>
        public static class ContentAreaWidths
        {
            public const int FullWidth = 12;
            public const int ThreeFourthWidth = 10;
            public const int TwoThirdsWidth = 8;
            public const int HalfWidth = 6;
            public const int OneThirdWidth = 4;
            public const int OneFourthWidth = 3;
            public const int OneFifthWidth = 2;
            public const int OneTwelfthWidth = 1;
        }

        public static Dictionary<string, int> ContentAreaTagWidths = new Dictionary<string, int>
            {
                { ContentAreaTags.FullWidth, ContentAreaWidths.FullWidth },
                { ContentAreaTags.ThreeFourthWidth, ContentAreaWidths.ThreeFourthWidth},
                { ContentAreaTags.TwoThirdsWidth, ContentAreaWidths.TwoThirdsWidth },
                { ContentAreaTags.HalfWidth, ContentAreaWidths.HalfWidth },
                { ContentAreaTags.OneThirdWidth, ContentAreaWidths.OneThirdWidth },
                { ContentAreaTags.OneFourthWidth, ContentAreaWidths.OneFourthWidth },
                { ContentAreaTags.OneFifthWidth, ContentAreaWidths.OneFifthWidth },
                { ContentAreaTags.OneTwelfthWidth, ContentAreaWidths.OneTwelfthWidth }
            };

        /// <summary>
        /// Names used for UIHint attributes to map specific rendering controls to page properties
        /// </summary>
        public static class SiteUIHints
        {
            public const string Contact = "contact";
            public const string Strings = "StringList";
        }

        /// <summary>
        /// Virtual path to folder with static graphics, such as "~/Static/global/gfx/"
        /// </summary>
        public const string StaticGraphicsFolderPath = "~/Static/global/gfx/";
    }
}

