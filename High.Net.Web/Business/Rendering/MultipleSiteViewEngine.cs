using EPiServer.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace High.Net.Web.Business.Rendering
{
    /// <summary>
    /// Extends the Razor view engine to set custom view locations.
    /// </summary>
    public class MultipleSiteViewEngine : RazorViewEngine
    {
        public MultipleSiteViewEngine()
        {
            string viewsFolder = SiteDefinition.Current.Name;

            ViewLocationFormats = new[]
			{
				string.Concat("~/Views/", viewsFolder, "/Pages/{1}/{0}.cshtml"),
				string.Concat("~/Views/", viewsFolder, "/Shared/{0}.cshtml"),
				"~/Views/Shared/{0}.cshtml"
			};
        }
    }
}