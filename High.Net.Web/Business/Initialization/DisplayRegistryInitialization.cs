using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using High.Net.Core;
using System.Collections.Generic;
using System.Web.Mvc;

namespace High.Net.Web.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class DisplayRegistryInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            if (context.HostType == HostType.WebApplication)
            {
                // Register Display Options
                var options = ServiceLocator.Current.GetInstance<DisplayOptions>();
                options
                    .Add("full", "/displayoptions/full", Global.ContentAreaTags.FullWidth, "", "epi-icon__layout--full")
                    .Add("three-fourth", "/displayoptions/three-fourth", Global.ContentAreaTags.ThreeFourthWidth, "", "epi-icon__layout--three-fourth")
                    .Add("wide", "/displayoptions/wide", Global.ContentAreaTags.TwoThirdsWidth, "", "epi-icon__layout--two-thirds")
                    .Add("half", "/displayoptions/half", Global.ContentAreaTags.HalfWidth, "", "epi-icon__layout--half")
                    .Add("narrow", "/displayoptions/narrow", Global.ContentAreaTags.OneThirdWidth, "", "epi-icon__layout--one-third")
                    .Add("one-quarter", "/displayoptions/quarter", Global.ContentAreaTags.OneFourthWidth,"", "epi-icon__layout--one-quarter")
                    .Add("small", "/displayoptions/small", Global.ContentAreaTags.OneFifthWidth, "", "epi-icon__layout--small")
                    .Add("extra-small", "/displayoptions/extra-small", Global.ContentAreaTags.OneTwelfthWidth, "", "epi-icon__layout--extra-small");

                AreaRegistration.RegisterAllAreas();

            }
        }

        public void Preload(string[] parameters){}

        public void Uninitialize(InitializationEngine context){}
    }
}
