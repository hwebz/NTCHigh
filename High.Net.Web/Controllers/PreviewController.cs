using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServer;
using High.Net.Core;
using EPiServer.DataAbstraction;
using High.Net.Models.NewResidential.Blocks;
using EPiServer.DataAbstraction.RuntimeModel.Internal;
using EPiServer.DataAbstraction.RuntimeModel;
using System;

namespace High.Net.Web.Controllers
{
    /* Note: as the content area rendering on Alloy is customized we create ContentArea instances 
     * which we render in the preview view in order to provide editors with a preview which is as 
     * realistic as possible. In other contexts we could simply have passed the block to the 
     * view and rendered it using Html.RenderContentData */
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = TemplateTypeCategories.MvcController, //Required as controllers for blocks are registered as MvcPartialController by default
        Tags = new[] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>
    {
        private readonly IContentLoader _contentLoader;
        private readonly TemplateResolver _templateResolver;
        private readonly DisplayOptions _displayOptions;
        private readonly EPiServer.DataAbstraction.ITemplateRepository _templateRepo;

        public PreviewController(IContentLoader contentLoader, TemplateResolver templateResolver, DisplayOptions displayOptions, ITemplateRepository templateRepo)
        {
            _contentLoader = contentLoader;
            _templateResolver = templateResolver;
            _displayOptions = displayOptions;
            _templateRepo = templateRepo;
        }

        public ActionResult Index(IContent currentContent)
        {
            //As the layout requires a page for title etc we "borrow" the start page
            var startPage = _contentLoader.Get<BasePageData>(SiteDefinition.Current.StartPage);

            var model = new PreviewModel(startPage, currentContent);

            if (currentContent is INewResidentialBlock)
            {
                var originalType = currentContent.GetOriginalType();
                var registedTemplateModels = _templateRepo.List(originalType);
                if (registedTemplateModels != null && registedTemplateModels.Any())
                {
                    var blockTemplateModels = registedTemplateModels.Where(x =>IsTemplateRegistered(x,originalType));
                    if (blockTemplateModels != null && blockTemplateModels.Any())
                    {
                        foreach(var blockTemplateModel in blockTemplateModels)
                        {
                            if (blockTemplateModel.Tags != null)
                            {
                                foreach (var tag in blockTemplateModel.Tags)
                                {                                   
                                    model.Areas.Add(CreatePreviewArea(currentContent, true, tag, tag));
                                }
                            }
                            else
                            {
                                model.Areas.Add(CreatePreviewArea(currentContent, true, string.Empty, string.Empty));
                            }
                            
                        }                        

                        return View(model);
                    }
                }
            }
            var supportedDisplayOptions = _displayOptions
                .Select(x => new { Tag = x.Tag, Name = x.Name, Supported = SupportsTag(currentContent, x.Tag) })
                .ToList();

            if (supportedDisplayOptions.Any(x => x.Supported))
            {
                foreach (var displayOption in supportedDisplayOptions)
                {
                    var contentArea = new ContentArea();
                    contentArea.Items.Add(new ContentAreaItem
                    {
                        ContentLink = currentContent.ContentLink
                    });
                    var areaModel = new PreviewModel.PreviewArea
                    {
                        Supported = displayOption.Supported,
                        AreaTag = displayOption.Tag,
                        AreaName = displayOption.Name,
                        ContentArea = contentArea
                    };
                    model.Areas.Add(areaModel);
                }
            }


            return View(model);
        }

        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = _templateResolver.Resolve(HttpContext,
                                      content.GetOriginalType(),
                                      content,
                                      TemplateTypeCategories.MvcPartial,
                                      tag);

            return templateModel != null;
        }

        private bool IsTemplateRegistered(TemplateModel model, Type originalType)
        {
            if (model.ModelType != null) return model.ModelType.Equals(originalType);
            return model.Name.Equals(originalType.Name);
        }
        
        private PreviewModel.PreviewArea CreatePreviewArea (IContent currentContent, bool isSupported, string tagName, string areaName)
        {
            var contentArea = new ContentArea();
            contentArea.Items.Add(new ContentAreaItem
            {
                ContentLink = currentContent.ContentLink
            });
            return  new PreviewModel.PreviewArea
            {
                Supported = isSupported,
                AreaTag = tagName,
                AreaName = areaName,
                ContentArea = contentArea
            };
        }
    }
}
