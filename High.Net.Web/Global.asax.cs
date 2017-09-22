using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using High.Net.Web.App_Start;
using High.Net.Web.Business.Rendering;

namespace High.Net.Web
{
    public class EPiServerApplication : EPiServer.Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Tip: Want to call the EPiServer API on startup? Add an initialization module instead (Add -> New Item.. -> EPiServer -> Initialization Module)

            // register route for AdminTool
            RouteTable.Routes.MapRoute("LogDisplayPlugin", "LogDisplayPlugin/{action}",
                new { controller = "LogDisplayPlugin", action = "Index" });
        }

        private static volatile bool _isFirstRequest;
        private static readonly object _lockObj = new object();
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (_isFirstRequest)
            {
                return;
            }

            lock (_lockObj)
            {
                if (!_isFirstRequest)
                {
                    _isFirstRequest = true;
                    ViewEngines.Engines.Insert(0, new MultipleSiteViewEngine());
                }
            }
        }
    }
}
