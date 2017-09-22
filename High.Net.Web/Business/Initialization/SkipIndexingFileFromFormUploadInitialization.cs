using System.Collections.Generic;
using EPiServer.Core;
using EPiServer.Find.Api;
using EPiServer.Find.Cms;
using EPiServer.Find.Cms.Conventions;
using EPiServer.Forms.Implementation.Elements;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace High.Net.Web.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class SkipIndexingFileFromFormUploadInitialization : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ContentIndexer.Instance.Conventions.ForInstancesOf<MediaData>().ShouldIndex(ShouldIndexDocument);
        }

        bool ShouldIndexDocument(MediaData documentFileBase)
        {
            var contentAssetHelper = ServiceLocator.Current.GetInstance<ContentAssetHelper>();
            if (!(contentAssetHelper.GetAssetOwner(documentFileBase.ContentLink) is FileUploadElementBlock))
                return true;

            ContentIndexer.Instance.TryDelete(documentFileBase, out IEnumerable<DeleteResult> result);
            return false;
        }
        public void Uninitialize(InitializationEngine context)
        { 
        }
    }
}