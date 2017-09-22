using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;
using High.Net.Models.HighConcrete.Pages;
using High.Net.Core;
using High.Net.Models.HighConcrete.ViewModels;
using EPiServer.ServiceLocation;
using High.Net.Web.Business;
using High.Net.Models.HighConcrete.Blocks;

namespace High.Net.Web.Controllers.HighConcrete
{
    public class ColorSelectorListingPageController : HighConcreteController<ColorSelectorListingPage>
    {
        public ActionResult Index(ColorSelectorListingPage currentPage, string color ,string texture , string pattern, int page = 1)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();

            ColorSelectorForm _ColorSelectorForm = new ColorSelectorForm();
            _ColorSelectorForm.color = color;
            _ColorSelectorForm.texture = texture;
            _ColorSelectorForm.pattern = pattern;

            var model = new ColorSelectorModel(currentPage){
                  colorSelectorForm = _ColorSelectorForm
            };

             if (model.colorSelectorForm != null)
            {
                dataLocator.SearchColorSelectorCriteria(model, this, page);
            }

            return View("~/Views/HighConcrete/Pages/ColorSelectorListingPage/Index.cshtml", model);
        }

        [HttpPost]
        public ActionResult Index(ColorSelectorListingPage currentPage, ColorSelectorForm colorSelectorForm, int page = 1)
        {
            var dataLocator = ServiceLocator.Current.GetInstance<DataLocator>();
            var model = new ColorSelectorModel(currentPage)
                        {
                            colorSelectorForm = colorSelectorForm
                        };
            if (colorSelectorForm != null)
            {
                dataLocator.SearchColorSelectorCriteria(model, this, page);
            }

            return View("~/Views/HighConcrete/Pages/ColorSelectorListingPage/Index.cshtml", model);
        }


        public JsonResult GetTextureAndPattern(string color)
        {
            var textures = new List<string>();
            var patterns = new List<string>();
            var contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var colorSelectingPage = contentLocator.GetAll<ColorSelectorListingPage>(PageReference.StartPage).FirstOrDefault();

            foreach (var item in colorSelectingPage.mainContentArea.Items)
            {
                var _colorFinishItem = _contentRepository.Get<ColorFinishesBlock>(item.ContentLink);
                if (_colorFinishItem.Color.Contains(color))
                {
                    if (!textures.Contains(_colorFinishItem.Texture) && ! _colorFinishItem.Texture.Contains("--"))
                    {
                        textures.Add(_colorFinishItem.Texture);
                    }

                    if (!patterns.Contains(_colorFinishItem.CastPattern) && ! _colorFinishItem.CastPattern.Contains("--"))
                    {
                        patterns.Add(_colorFinishItem.CastPattern);
                    }
                }

            }
            return Json( new { textures = textures , patterns = patterns  }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetColor(string value)
        {
            var colors = new List<string>();
            var contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var colorSelectingPage = contentLocator.GetAll<ColorSelectorListingPage>(PageReference.StartPage).FirstOrDefault();

            foreach (var item in colorSelectingPage.mainContentArea.Items)
            {
                var _colorFinishItem = _contentRepository.Get<ColorFinishesBlock>(item.ContentLink);
                if (_colorFinishItem.Texture.Contains(value))
                {
                    if (!colors.Contains(_colorFinishItem.Color))
                    {
                        colors.Add(_colorFinishItem.Color);
                    }
                }
                if (_colorFinishItem.CastPattern.Contains(value))
                {
                    if (!colors.Contains(_colorFinishItem.Color))
                    {
                        colors.Add(_colorFinishItem.Color);
                    }
                }

            }
            return Json(colors, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ResetAllProperties()
        {
            var contentLoader = ServiceLocator.Current.GetInstance<EPiServer.IContentLoader>();
            var contentLocator = ServiceLocator.Current.GetInstance<ContentLocator>();
          
            var Colors = contentLocator.GetCategories("Colors").Categories.Select(x=> x.Name.ToString()).ToList();
            var Textures = contentLocator.GetCategories("Textures").Categories.Select(x => x.Name.ToString()).ToList();
            var CastPattern = contentLocator.GetCategories("Cast Pattern").Categories.Select(x => x.Name.ToString()).ToList();
            return Json(new { color = Colors, texture = Textures, pattern = CastPattern }, JsonRequestBehavior.AllowGet);
        }

    }
}