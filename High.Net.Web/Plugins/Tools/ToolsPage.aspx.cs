using EPiServer;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.WebForms;
using System;
using EPiServer.Core;
using System.Linq;
using EPiServer.DataAbstraction;
using log4net;
using EPiServer.Forms.EditView;
using EPiServer.DataAccess;
using EPiServer.Security;
using EPiServer.Forms.Helpers.Internal;
using EPiServer.Forms.Implementation.Elements;
using High.Net.Models.NewResidential.Blocks;
using High.Net.Web.Business.Helpers;

namespace High.Net.Web.Plugins.Tools
{
    [GuiPlugIn(DisplayName = "Advanced Tools", Description = "Advanced tools set", Area = PlugInArea.AdminMenu, Url = "~/Plugins/Tools/ToolsPage.aspx")]
    public partial class ToolsPage : WebFormsBase
    {
        Injected<IContentRepository> _contentRepository;
        private static Injected<IEPiServerFormsUIConfig> _formConfig;
        private static readonly ILog log = LogManager.GetLogger(typeof(ToolsPage));
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.SystemMessageContainer.Heading = "Advanced tools for integration works.";
            this.SystemMessageContainer.Description = "Manage any hot fixes, advanced procedures to sites.";
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void MassRemoveContents(int contentId)
        {
            if (contentId > 0)
            {
                //First delete all contents in children             
                _contentRepository.Service.DeleteChildren(new ContentReference(contentId), true, AccessLevel.Delete);
                //Then delete main content.
                _contentRepository.Service.Delete(new EPiServer.Core.ContentReference(contentId), true);
            }
        }
    
        private void MoveFormsToGlobalFormsFolder()
        {
            var forms = _contentRepository.Service.GetDescendents(ContentReference.GlobalBlockFolder).Where(x => x.GetContent() is FormContainerBlock).Select(f => f.GetContent());
            foreach (FormContainerBlock form in forms)
            {
                //Assign them to global forms root folder.
                var cloneForm = form.CreateWritableClone() as IContent;
                cloneForm.ParentLink = _formConfig.Service.RootFolder;
                _contentRepository.Service.Save(cloneForm, SaveAction.Publish, AccessLevel.NoAccess);
            }
        }
        protected void btnReOrganizeForms_Click(object sender, EventArgs e)
        {
            //Load existing forms root folder.
            var existingFormFolder = _formConfig.Service.RootFolder;
            //Find existing episerver forms folder which created forms inside.
            var existingGlobalFormFolder = _contentRepository.Service.GetChildren<ContentFolder>(ContentReference.GlobalBlockFolder).FirstOrDefault(x => x.Name == _formConfig.Service.RootFolderName);
            if(null != existingGlobalFormFolder && existingGlobalFormFolder.ContentLink != ContentReference.EmptyReference)
            {
                //Change root folder to global forms folder.
                _formConfig.Service.RootFolder = existingGlobalFormFolder.ContentLink.ToReferenceWithoutVersion();
                MoveFormsToGlobalFormsFolder();
            }
            else
            {
                //Create global episerver forms folder.
                var globalFormFolder = _contentRepository.Service.GetDefault<ContentFolder>(ContentReference.GlobalBlockFolder);
                globalFormFolder.Name = _formConfig.Service.RootFolderName;
                _contentRepository.Service.Save(globalFormFolder, SaveAction.Publish, AccessLevel.NoAccess);
                //Change root folder to global forms folder.
                _formConfig.Service.RootFolder = globalFormFolder.ContentLink.ToReferenceWithoutVersion();

                //Get all forms(content) belong to root folder to assign to the new one then remove the exsting one.
                MoveFormsToGlobalFormsFolder();
                //Check existing any children of the old forms folder and remove site level form folder.
                if (null != existingFormFolder && existingFormFolder != ContentReference.EmptyReference)
                {
                    var doubleCheckExistingForms = _contentRepository.Service.GetDescendents(existingFormFolder);
                    if (!doubleCheckExistingForms.Any())
                    {
                        _contentRepository.Service.Delete(existingFormFolder, true);
                    }
                }
            }
            btnReOrganizeForms.Text = "Done!";
            btnReOrganizeForms.Enabled = false;
        }

        protected void btnMigrageMapBlock_Click(object sender, EventArgs e)
        {
            var contentTypeRepository = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            var contentModelUsage = ServiceLocator.Current.GetInstance<IContentModelUsage>();
            var contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            // loading a block type
            var contentType = contentTypeRepository.Load<GoogleMapSingleLocationBlock>();
            // getting the list of block type usages, each usage object has properties ContentLink, LanguageBranch and Name
            var usages = contentModelUsage.ListContentOfContentType(contentType);
            foreach (var usage in usages)
            {
                var mapBlock = usage.ContentLink.GetContent<GoogleMapSingleLocationBlock>();
                var clone = mapBlock.CreateWritableClone() as GoogleMapSingleLocationBlock;
                clone.ComplexCoordinates = clone.LatLng;
                contentRepository.Save((IContent)clone, SaveAction.Publish,
                    AccessLevel.NoAccess);
            }
        }
    }
}