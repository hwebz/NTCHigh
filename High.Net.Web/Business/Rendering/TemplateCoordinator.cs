using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using High.Net.Core;

using Humanity = High.Net.Models.Humanity;
using SelfStorage = High.Net.Models.SelfStorage;
using Commercial = High.Net.Models.Commercial;
using ResidentialNew = High.Net.Models.Residential;
using Industries = High.Net.Models.Industries;
using Associates = High.Net.Models.Associates;
using SteelServiceCentre = High.Net.Models.SteelServiceCentre;
using RealEstateGroup = High.Net.Models.RealEstateGroup;
using StructureCareUs = High.Net.Models.StructureCareUs;
using HighNet = High.Net.Models.HighNet;
using Rollover = High.Net.Models.Rollover;
using HighHotels = High.Net.Models.HighHotels;
using HighConcrete = High.Net.Models.HighConcrete;
using HighAppraisal = High.Net.Models.HighAppraisal;
using HighConcreteAccessories = High.Net.Models.HighConcreteAccessories;
using HighSteelStructure = High.Net.Models.HighSteelStructure;
using HighTransit = High.Net.Models.HighTransit;
using GreenfieldArchitects = High.Net.Models.GreenfieldArchitects;
using HighConstructionCo = High.Net.Models.HighConstructionCo;
using NewResidential = High.Net.Models.NewResidential;
using High.Net.Web.Controllers;
using System.Collections.Generic;
using System;

namespace High.Net.Web.Business.Rendering
{
    [ServiceConfiguration(typeof(IViewTemplateModelRegistrator))]
    public class TemplateCoordinator : IViewTemplateModelRegistrator
    {
        public const string SharedBlockFolder = "~/Views/Shared/Blocks/";
        public const string HumanityBlockFolder = "~/Views/Humanity/Blocks/";
        public const string SelfStorageBlockFolder = "~/Views/SelfStorage/Blocks/";
        public const string CommercialBlockFolder = "~/Views/Commercial/Blocks/";
        public const string ResidentialNewBlockFolder = "~/Views/Residential/Blocks/";
        public const string IndustriesBlockFolder = "~/Views/Industries/Blocks/";
        public const string AssociatesBlockFolder = "~/Views/Associates/Blocks/";
        public const string SteelServiceCentreBlockFolder = "~/Views/SteelServiceCentre/Blocks/";
        public const string RealEstateGroupBlockFolder = "~/Views/RealEstateGroup/Blocks/";
        public const string StructureCareUsBlockFolder = "~/Views/StructureCareUs/Blocks/";
        public const string HighNetBlockFolder = "~/Views/HighNet/Blocks/";
        public const string RolloverBlockFolder = "~/Views/Rollover/Blocks/";
        public const string HighHotelsBlockFolder = "~/Views/HighHotels/Blocks/";
        public const string HighConcreteBlockFolder = "~/Views/HighConcrete/Blocks/";
        public const string HighAppraisalBlockFolder = "~/Views/HighAppraisal/Blocks/";
        public const string HighConcreteAccessoriesBlockFolder = "~/Views/HighConcreteAccessories/Blocks/";
        public const string HighSteelStructureBlockFolder = "~/Views/HighSteelStructure/Blocks/";
        public const string HighTransitBlockFolder = "~/Views/HighTransit/Blocks/";
        public const string GreenfieldArchitectsBlockFolder = "~/Views/GreenfieldArchitects/Blocks/";
        public const string HighConstructionCoBlockFolder = "~/Views/HighConstructionCo/Blocks/";
        public const string NewResidentialBlockFolder = "~/Views/NewResidential/Blocks/";


        public static void OnTemplateResolved(object sender, TemplateResolverEventArgs args)
        {
            //Disable DefaultPageController for page types that shouldn't have any renderer as pages
            if (args.ItemToRender is IContainerPage && args.SelectedTemplate != null && args.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                args.SelectedTemplate = null;
            }
        }

        /// <summary>
        /// Registers renderers/templates which are not automatically discovered, 
        /// i.e. partial views whose names does not match a content type's name.
        /// </summary>
        /// <remarks>
        /// Using only partial views instead of controllers for blocks and page partials
        /// has performance benefits as they will only require calls to RenderPartial instead of
        /// RenderAction for controllers.
        /// Registering partial views as templates this way also enables specifying tags and 
        /// that a template supports all types inheriting from the content type/model type.
        /// </remarks>
        public void Register(TemplateModelCollection viewTemplateModelRegistrator)
        {
            #region Humanity

            viewTemplateModelRegistrator.Add(typeof(Humanity.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HumanityBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Humanity.Blocks.PartnersBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HumanityBlockPath("PartnersBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Humanity.Blocks.PlainTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HumanityBlockPath("PlainTextBlock.cshtml")
            });

            #endregion

            #region Self Storage

            viewTemplateModelRegistrator.Add(typeof(SelfStorage.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth,
                            Global.ContentAreaTags.OneFourthWidth,
                            Global.ContentAreaTags.OneFifthWidth,
                            Global.ContentAreaTags.OneTwelfthWidth,
                            Global.ContentAreaTags.NoRenderer,
                            Global.ContentAreaTags.Custom
                        },
                AvailableWithoutTag = false,
                Path = SelfStorageBlockPath("TextBlock.cshtml")
            });

            #endregion

            #region Greenfield Corporate Center

            viewTemplateModelRegistrator.Add(typeof(Commercial.Blocks.LinkItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = CommercialBlockPath("LinkItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Commercial.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = CommercialBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Commercial.Blocks.ImageGalleryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = CommercialBlockPath("ImageGalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Commercial.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = CommercialBlockPath("ImageTextBlock.cshtml")
            });

            #endregion

            #region Residential

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("ImageTextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.GalleryBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("GalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.FaqBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("FaqBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.PlanTypeBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("PlanTypeBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.FloorPlansBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.NoRenderer
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("FloorPlansBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.StaffBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("StaffBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(ResidentialNew.Blocks.ProjectsBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                },
                AvailableWithoutTag = false,
                Path = ResidentialNewBlockPath("ProjectsBlock.cshtml")
            });

            #endregion

            #region Industries

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.LLCBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.Custom
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("LLCBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.AboutBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("AboutBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.MembersBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("MembersBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.CEOBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("CEOBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.BusinessBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("BusinessBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Industries.Blocks.CarouselBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth
                    },
                AvailableWithoutTag = false,
                Path = IndustriesBlockPath("CarouselBlock.cshtml")
            });


            #endregion

            #region Associates

            viewTemplateModelRegistrator.Add(typeof(Associates.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = AssociatesNewBlockPath("TextBlock.cshtml")
            });

            #endregion

            #region Steel Service Centre


            viewTemplateModelRegistrator.Add(typeof(SteelServiceCentre.Blocks.ServicesBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = SteelServiceCentreBlockPath("ServicesBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(SteelServiceCentre.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = SteelServiceCentreBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(SteelServiceCentre.Blocks.ImageGalleryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = SteelServiceCentreBlockPath("ImageGalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(SteelServiceCentre.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = SteelServiceCentreBlockPath("ImageTextBlock.cshtml")
            });

            #endregion

            #region High Net

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TaskBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("TaskBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.VideoCarouselBlock), new TemplateModel
            {               
                AvailableWithoutTag = true,
                Path = HighNetBlockPath("VideoCarouselBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.AuthorQuoteContainerBlock), new TemplateModel
            {                
                AvailableWithoutTag = true,
                Path = HighNetBlockPath("AuthorQuoteContainerBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TilesContainerBlock), new TemplateModel
            {
                AvailableWithoutTag = true,
                Path = HighNetBlockPath("TilesContainerBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("ImageTextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.VideoBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.LeadershipContentPage
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("VideoBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.CEOBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("CEOBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.HistoryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("HistoryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.MembersBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("MembersBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.OtherTilesBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.ThreeFourthWidth
                    },
                AvailableWithoutTag = false,

                Path = HighNetBlockPath("OtherTileBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.OtherTileBlockWide), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.ThreeFourthWidth
                    },
                AvailableWithoutTag = false,

                Path = HighNetBlockPath("OtherTileBlockWide.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.NewsBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.ThreeFourthWidth
                    },
                AvailableWithoutTag = false,

                Path = HighNetBlockPath("NewsBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TweeterFeedBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.ThreeFourthWidth
                    },
                AvailableWithoutTag = false,

                Path = HighNetBlockPath("TweeterFeedBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.HeaderBannerBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("HeaderBannerBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.PhotoGalleryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("PhotoGalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.SingleColumnCalloutBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("SingleColumnCalloutBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TextTableBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("TextTableBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.LogoWallBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("LogoWallBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.LogoWallItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("LogoWallItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TextTableSubItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("TextTableSubItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TextTableItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("TextTableItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.NumberListContentBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("NumberListContentBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.StandardContentImageBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("StandardContentImageBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.NumberListContentItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("NumberListContentItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.FeaturePositionBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("FeaturePositionBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.FeaturePositionItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("FeaturePositionItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.FullWidthCalloutBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("FullWidthCalloutBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.ImageTable), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("ImageTable.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.ResizableBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = true,
                Path = HighNetBlockPath("ResizableBlock.cshtml")
            });
            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.CSSLayeredImageContentBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("CSSLayeredImageContentBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.ImageTableItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("ImageTableItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.GoogleMapBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("GoogleMapBlock.cshtml")
            });


            //viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.CarouselBlock), new TemplateModel
            //{
            //    Tags = new[] {
            //            Global.ContentAreaTags.FullWidth,
            //            Global.ContentAreaTags.ThreeFourthWidth,
            //            Global.ContentAreaTags.TwoThirdsWidth,
            //            Global.ContentAreaTags.HalfWidth,
            //            Global.ContentAreaTags.OneThirdWidth,
            //            Global.ContentAreaTags.OneFourthWidth,
            //            Global.ContentAreaTags.OneFifthWidth,
            //            Global.ContentAreaTags.OneTwelfthWidth
            //        },
            //    AvailableWithoutTag = false,
            //    Path = HighNetBlockPath("CarouselBlock.cshtml")
            //});

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.TestimonialConatinerBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = true,
                Path = HighNetBlockPath("TestimonialConatinerBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.CarouselItemBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("CarouselItemBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighNet.Blocks.StaticQuoteBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighNetBlockPath("StaticQuoteBlock.cshtml")
            });
            #endregion

            #region RealEstateGroup

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.AssetsBlock), new TemplateModel
            {
                Tags = new[] {
                         Global.ContentAreaTags.NoRenderer,
                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("AssetsBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.ServicesBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,

                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("ServicesBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.LocationBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("LocationBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.ProfileImageBlock), new TemplateModel
            {
                Tags = new[] {
                       Global.ContentAreaTags.NoRenderer,
                       Global.ContentAreaTags.TwoThirdsWidth,
                       Global.ContentAreaTags.HalfWidth,
                       Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("ProfileImageBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(RealEstateGroup.Blocks.MainBlock), new TemplateModel
            {
                Tags = new[] {
                         Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = RealEstateGroupBlockPath("MainBlock.cshtml")
            });

            #endregion

            #region StructureCareUs

            viewTemplateModelRegistrator.Add(typeof(StructureCareUs.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = StructureCareUsBlockPath("TextBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(StructureCareUs.Blocks.ContactPersonBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = StructureCareUsBlockPath("ContactPersonBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(StructureCareUs.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = StructureCareUsBlockPath("ImageTextBlock.cshtml")
            });

            #endregion

            #region Rollover

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("TextBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.MainBlock), new TemplateModel
            {
                Tags = new[] {
                         Global.ContentAreaTags.NoRenderer,
                         Global.ContentAreaTags.FullWidth,
                         Global.ContentAreaTags.TwoThirdsWidth,
                         Global.ContentAreaTags.HalfWidth,
                         Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("MainBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.Testimonials), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("Testimonials.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.CommercialMultiFamily), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("CommercialMultiFamily.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.ResidentialMultiFamily), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("ResidentialMultiFamily.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.PortfolioListingBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("PortfolioListingBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.ProfileBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("ProfileBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Rollover.Blocks.FindASpaceBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.NoRenderer,
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                    },
                AvailableWithoutTag = false,
                Path = RolloverBlockPath("FindASpaceBlock.cshtml")
            });

            #endregion

            #region HighHotels

            viewTemplateModelRegistrator.Add(typeof(HighHotels.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HighHotelsBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighHotels.Blocks.FeaturesBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth
                    },
                AvailableWithoutTag = false,
                Path = HighHotelsBlockPath("FeaturesBlock.cshtml")
            });

            #endregion

            #region High Concrete

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("ImageTextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                         Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.ImageGalleryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("ImageGalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.QuickLinkBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("QuickLinkBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.ExpandCollapseBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("ExpandCollapseBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.PopupBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("PopupBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcrete.Blocks.ProductBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth,
                        Global.ContentAreaTags.NoRenderer
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteBlockPath("ProductBlock.cshtml")
            });

            #endregion

            #region High Appraisal

            viewTemplateModelRegistrator.Add(typeof(HighAppraisal.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighAppraisalBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighAppraisal.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighAppraisalBlockPath("ImageTextBlock.cshtml")
            });

            #endregion

            #region High Concrete Accessories

            viewTemplateModelRegistrator.Add(typeof(HighConcreteAccessories.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteAccessoriesBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcreteAccessories.Blocks.FaqBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteAccessoriesBlockPath("FaqBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConcreteAccessories.Blocks.SpecificationsBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighConcreteAccessoriesBlockPath("SpecificationsBlock.cshtml")
            });
            #endregion

            #region High Steel Structure

            viewTemplateModelRegistrator.Add(typeof(HighSteelStructure.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighSteelStructureBlockPath("ImageTextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighSteelStructure.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighSteelStructureBlockPath("TextBlock.cshtml")

            });

            viewTemplateModelRegistrator.Add(typeof(HighSteelStructure.Blocks.ProductsBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighSteelStructureBlockPath("ProductsBlock.cshtml")

            });

            viewTemplateModelRegistrator.Add(typeof(HighSteelStructure.Blocks.FaqBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.ThreeFourthWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFourthWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.OneTwelfthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighSteelStructureBlockPath("FaqBlock.cshtml")

            });

            #endregion

            #region High Transit


            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.ProfileBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                    },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("ProfileBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth,
                        Global.ContentAreaTags.NoRenderer
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("TextBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.EquipmentBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("EquipmentBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.InnerEquipmentBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("InnerEquipmentBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.EquipmentDetailsBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("EquipmentDetailsBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("ImageTextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.ImageGalleryBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("ImageGalleryBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.MemberBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("MemberBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighTransit.Blocks.AwardsBlock), new TemplateModel
            {
                Tags = new[] {
                        Global.ContentAreaTags.FullWidth,
                        Global.ContentAreaTags.TwoThirdsWidth,
                        Global.ContentAreaTags.HalfWidth,
                        Global.ContentAreaTags.OneThirdWidth,
                        Global.ContentAreaTags.OneFifthWidth
                },
                AvailableWithoutTag = false,
                Path = HighTransitBlockPath("AwardsBlock.cshtml")
            });


            viewTemplateModelRegistrator.Add(typeof(High.Net.Models.NewResidential.Blocks.FaqBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.FullWidth,
                    Global.ContentAreaTags.TwoThirdsWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("FaqBlock.cshtml")
            });

            #endregion

            #region GreenfieldArchitects

            viewTemplateModelRegistrator.Add(typeof(GreenfieldArchitects.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = GreenfieldArchitectsBlockPath("TextBlock.cshtml")
            });

            #endregion

            #region High Construction Company

            viewTemplateModelRegistrator.Add(typeof(HighConstructionCo.Blocks.TextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = HighConstructionCoBlockPath("TextBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(HighConstructionCo.Blocks.ImageTextBlock), new TemplateModel
            {
                Tags = new[] {
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.TwoThirdsWidth,
                            Global.ContentAreaTags.HalfWidth,
                            Global.ContentAreaTags.OneThirdWidth
                        },
                AvailableWithoutTag = false,
                Path = HighConstructionCoBlockPath("ImageTextBlock.cshtml")
            });

            #endregion            
            #region NewResidential

            //viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.PhotosLinkedGalleryBlock), new TemplateModel
            //{
            //    Tags = new[] {
            //        Global.ContentAreaTags.ResidentialHomePage,
            //        Global.ContentAreaTags.ResidentialContentPage,
            //        Global.ContentAreaTags.FullWidth
            //    },
            //    AvailableWithoutTag = false,
            //    Path = NewResidentialBlockPath("PhotosLinkedGalleryBlock.cshtml")
            //});

            viewTemplateModelRegistrator.Add(typeof(Models.NewResidential.Blocks.GoogleMapSingleLocationBlock), new TemplateModel
            {
                Tags = new[] {
                           Global.ContentAreaTags.ResidentialHomePage,
                            Global.ContentAreaTags.FullWidth,
                            Global.ContentAreaTags.ResidentialContentPage
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("GoogleMapSingleLocationBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(Models.NewResidential.Blocks.ReadyToMoveBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.ResidentialContentPage,
                    Global.ContentAreaTags.FullWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("ReadyToMoveBlock.cshtml")
            });
            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.TextInformationGroupedBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialContentPage,
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("TextInformationGroupedBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.ApartmentsCarouselBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialContentPage,
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("ApartmentsCarouselBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.UtilityConnectionsBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.ResidentialContentPage,
                    Global.ContentAreaTags.FullWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("UtilityConnectionsBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.PhoneInfoBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.ResidentialContentPage,
                    Global.ContentAreaTags.FullWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("PhoneInfoBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.EventListBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.ResidentialContentPage,
                    Global.ContentAreaTags.FullWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("EventListBlock.cshtml")
            });

            viewTemplateModelRegistrator.Add(typeof(NewResidential.Blocks.EventItemBlock), new TemplateModel
            {
                Tags = new[] {
                    Global.ContentAreaTags.ResidentialHomePage,
                    Global.ContentAreaTags.ResidentialContentPage,
                    Global.ContentAreaTags.FullWidth
                },
                AvailableWithoutTag = false,
                Path = NewResidentialBlockPath("EventItemBlock.cshtml")
            });

            #endregion
        }

        private static string SharedBlockPath(string fileName)
        {
            return string.Format("{0}{1}", SharedBlockFolder, fileName);
        }

        private static string HumanityBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HumanityBlockFolder, fileName);
        }

        private static string SelfStorageBlockPath(string fileName)
        {
            return string.Format("{0}{1}", SelfStorageBlockFolder, fileName);
        }

        private static string CommercialBlockPath(string fileName)
        {
            return string.Format("{0}{1}", CommercialBlockFolder, fileName);
        }

        private static string ResidentialNewBlockPath(string fileName)
        {
            return string.Format("{0}{1}", ResidentialNewBlockFolder, fileName);
        }

        private static string IndustriesBlockPath(string fileName)
        {
            return string.Format("{0}{1}", IndustriesBlockFolder, fileName);
        }

        private static string AssociatesNewBlockPath(string fileName)
        {
            return string.Format("{0}{1}", AssociatesBlockFolder, fileName);
        }

        private static string SteelServiceCentreBlockPath(string fileName)
        {
            return string.Format("{0}{1}", SteelServiceCentreBlockFolder, fileName);
        }

        private static string RealEstateGroupBlockPath(string fileName)
        {
            return string.Format("{0}{1}", RealEstateGroupBlockFolder, fileName);
        }

        private static string StructureCareUsBlockPath(string fileName)
        {
            return string.Format("{0}{1}", StructureCareUsBlockFolder, fileName);
        }

        private static string HighNetBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighNetBlockFolder, fileName);
        }

        private static string RolloverBlockPath(string fileName)
        {
            return string.Format("{0}{1}", RolloverBlockFolder, fileName);
        }

        private static string HighHotelsBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighHotelsBlockFolder, fileName);
        }

        private static string HighConcreteBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighConcreteBlockFolder, fileName);
        }

        private string HighAppraisalBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighAppraisalBlockFolder, fileName);
        }

        private string HighConcreteAccessoriesBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighConcreteAccessoriesBlockFolder, fileName);
        }

        private string HighSteelStructureBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighSteelStructureBlockFolder, fileName);
        }

        private string HighTransitBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighTransitBlockFolder, fileName);
        }

        private string GreenfieldArchitectsBlockPath(string fileName)
        {
            return string.Format("{0}{1}", GreenfieldArchitectsBlockFolder, fileName);
        }

        private string HighConstructionCoBlockPath(string fileName)
        {
            return string.Format("{0}{1}", HighConstructionCoBlockFolder, fileName);
        }

        private string NewResidentialBlockPath(string fileName)
        {
            return string.Format("{0}{1}", NewResidentialBlockFolder, fileName);
        }
    }
}
