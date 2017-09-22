using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.Filters;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.WebForms;
using EPiServer.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Techease.TypeSynchronization
{
    [GuiPlugIn(Area = PlugInArea.AdminMenu, Description = "Type Synchronization", DisplayName = "Type Synchronization", UrlFromModuleFolder = "TypeSync.aspx")]
    public class TypeSync : WebFormsBase
    {
        private ContentTypeModelRepository _contentTypeModelRepository;
        private List<Result> _resultsPages = new List<Result>();
        private List<Result> _resultsBlocks = new List<Result>();
        private List<Result> _resultsMedia = new List<Result>();
        private List<Result> _resultsPageTypes = new List<Result>();
        private Injected<IAdministrationSettingsService> SettingsService;
        protected TabStrip actionTab;
        protected Tab Tab1;
        protected Tab Tab2;
        protected Panel tabView;
        protected HtmlGenericControl PropertyTypes;
        protected GridView PropertiesViewControl_Pages;
        protected Label noPagePropertiesMsg;
        protected ToolButton Save_PageProperties;
        protected GridView PropertiesViewControl_Blocks;
        protected Label noBlockPropertiesMsg;
        protected ToolButton Save_BlockProperties;
        protected GridView PropertiesViewControl_Media;
        protected Label noMediaPropertiesMsg;
        protected ToolButton Save_MediaProperties;
        protected HtmlGenericControl PageTypes;
        protected GridView PageTypesGrid;
        protected Label noPageTypesMsg;
        protected ToolButton Save_PageTypes;

        protected TypeSync.Result Item
        {
            get
            {
                return ((Control)this).Page.GetDataItem() as TypeSync.Result;
            }
        }

        public TypeSync() : base()
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.SystemMessageContainer.Heading = "Type Synchronization";
            this.SystemMessageContainer.Description = "Below property types and page types were defined in code but are no longer available. You can delete these from the database.";
        }

        protected override void OnLoad(EventArgs e)
        {            
            if (((Page)this).IsPostBack)
                return;
            this.Setup();
        }

        private void Setup()
        {
            this._contentTypeModelRepository = ServiceLocator.Current.GetInstance<ContentTypeModelRepository>();
            this.BindPropertyTypes();
            this.BindPageTypes();
        }

        private void BindPropertyTypes()
        {
            foreach (ContentType contentType in (IEnumerable<ContentType>)this.ContentTypeRepository.List().OrderBy<ContentType, int>((Func<ContentType, int>)(c => c.SortOrder)))
            {
                string lower = this.SettingsService.Service.GetAttribute(contentType).GroupName.ToLower();
                if (!(lower == "pagetypes"))
                {
                    if (!(lower == "blocktypes"))
                    {
                        if (lower == "mediatypes")
                        {
                            int num = 0;
                            foreach (PropertyDefinition propertyDefinition in contentType.PropertyDefinitions)
                            {
                                if (this.IsMissingModelProperty(propertyDefinition))
                                {
                                    ++num;
                                    this._resultsMedia.Add(new TypeSync.Result()
                                    {
                                        TypeName = num == 1 ? contentType.Name : string.Empty,
                                        Name = propertyDefinition.Name,
                                        id = propertyDefinition.ID
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        int num = 0;
                        foreach (PropertyDefinition propertyDefinition in contentType.PropertyDefinitions)
                        {
                            if (this.IsMissingModelProperty(propertyDefinition))
                            {
                                ++num;
                                this._resultsBlocks.Add(new TypeSync.Result()
                                {
                                    TypeName = num == 1 ? contentType.Name : string.Empty,
                                    Name = propertyDefinition.Name,
                                    id = propertyDefinition.ID
                                });
                            }
                        }
                    }
                }
                else
                {
                    int num = 0;
                    foreach (PropertyDefinition propertyDefinition in contentType.PropertyDefinitions)
                    {
                        if (this.IsMissingModelProperty(propertyDefinition))
                        {
                            ++num;
                            this._resultsPages.Add(new TypeSync.Result()
                            {
                                TypeName = num == 1 ? contentType.Name : string.Empty,
                                Name = propertyDefinition.Name,
                                id = propertyDefinition.ID
                            });
                        }
                    }
                }
            }
            if (this._resultsPages.Count > 0)
            {
                this.PropertiesViewControl_Pages.DataSource = (object)this._resultsPages;
                this.PropertiesViewControl_Pages.DataBind();
                this.PropertiesViewControl_Pages.Columns[0].HeaderStyle.Width = this.PropertiesViewControl_Pages.Columns[1].HeaderStyle.Width = (Unit)320;
            }
            else
            {
                this.noPagePropertiesMsg.Text = "No results found.";
                this.noPagePropertiesMsg.Visible = true;
                this.Save_PageProperties.Visible = false;
            }
            if (this._resultsBlocks.Count > 0)
            {
                this.PropertiesViewControl_Blocks.DataSource = (object)this._resultsBlocks;
                this.PropertiesViewControl_Blocks.DataBind();
                this.PropertiesViewControl_Blocks.Columns[0].HeaderStyle.Width = this.PropertiesViewControl_Blocks.Columns[1].HeaderStyle.Width = (Unit)320;
            }
            else
            {
                this.noBlockPropertiesMsg.Text = "No results found.";
                this.noBlockPropertiesMsg.Visible = true;
                this.Save_BlockProperties.Visible = false;
            }
            if (this._resultsMedia.Count > 0)
            {
                this.PropertiesViewControl_Media.DataSource = (object)this._resultsMedia;
                this.PropertiesViewControl_Media.DataBind();
                this.PropertiesViewControl_Media.Columns[0].HeaderStyle.Width = this.PropertiesViewControl_Blocks.Columns[1].HeaderStyle.Width = (Unit)320;
            }
            else
            {
                this.noMediaPropertiesMsg.Text = "No results found.";
                this.noMediaPropertiesMsg.Visible = true;
                this.Save_MediaProperties.Visible = false;
            }
        }

        private void BindPageTypes()
        {
            foreach (ContentType contentType in this.ContentTypeRepository.List().Where<ContentType>((Func<ContentType, bool>)(c =>
           {
               if (this.SettingsService.Service.GetAttribute(c).GroupName.ToLower().Equals("pagetypes"))
                   return this.IsMissingModel(c);
               return false;
           })))
                this._resultsPageTypes.Add(new TypeSync.Result()
                {
                    TypeName = contentType.Name,
                    id = contentType.ID
                });
            if (this._resultsPageTypes.Count > 0)
            {
                this.PageTypesGrid.DataSource = (object)this._resultsPageTypes;
                this.PageTypesGrid.DataBind();
                this.PageTypesGrid.Columns[0].HeaderStyle.Width = this.PropertiesViewControl_Pages.Columns[1].HeaderStyle.Width = (Unit)320;
            }
            else
            {
                this.noPageTypesMsg.Text = "No results found.";
                this.noPageTypesMsg.Visible = true;
                this.Save_PageTypes.Visible = false;
            }
        }

        private bool IsMissingModelProperty(PropertyDefinition propertyDefinition)
        {
            if (propertyDefinition != null && propertyDefinition.ExistsOnModel)
                return this._contentTypeModelRepository.GetPropertyModel(propertyDefinition.ContentTypeID, propertyDefinition) == null;
            return false;
        }

        private bool IsMissingModel(ContentType type)
        {
            if (type != (ContentType)null && type.ModelType == (Type)null)
                return !string.IsNullOrEmpty(type.ModelTypeString);
            return false;
        }

        protected void Delete_PageProperties(object sender, EventArgs e)
        {
            IPropertyDefinitionRepository instance = ServiceLocator.Current.GetInstance<IPropertyDefinitionRepository>();
            foreach (GridViewRow row in this.PropertiesViewControl_Pages.Rows)
            {
                string id1 = "box";
                bool flag = ((CheckBox)row.FindControl(id1)).Checked;
                string id2 = "typeid";
                string text = ((Label)row.FindControl(id2)).Text;
                if (flag)
                    instance.Delete(instance.Load(int.Parse(text)).CreateWritableClone());
            }
          ((Page)this).Response.Redirect(((Page)this).Request.RawUrl);
        }

        protected void Delete_BlockProperties(object sender, EventArgs e)
        {
            IPropertyDefinitionRepository instance = ServiceLocator.Current.GetInstance<IPropertyDefinitionRepository>();
            foreach (GridViewRow row in this.PropertiesViewControl_Blocks.Rows)
            {
                string id1 = "boxBlock";
                bool flag = ((CheckBox)row.FindControl(id1)).Checked;
                string id2 = "typeidBlock";
                string text = ((Label)row.FindControl(id2)).Text;
                if (flag)
                    instance.Delete(instance.Load(int.Parse(text)).CreateWritableClone());
            }
          ((Page)this).Response.Redirect(((Page)this).Request.RawUrl);
        }

        protected void Delete_MediaProperties(object sender, EventArgs e)
        {
            IPropertyDefinitionRepository instance = ServiceLocator.Current.GetInstance<IPropertyDefinitionRepository>();
            foreach (GridViewRow row in this.PropertiesViewControl_Media.Rows)
            {
                string id1 = "boxMedia";
                bool flag = ((CheckBox)row.FindControl(id1)).Checked;
                string id2 = "typeidMedia";
                string text = ((Label)row.FindControl(id2)).Text;
                if (flag)
                    instance.Delete(instance.Load(int.Parse(text)).CreateWritableClone());
            }
          ((Page)this).Response.Redirect(((Page)this).Request.RawUrl);
        }

        protected void Delete_PageTypes(object sender, EventArgs e)
        {
            IContentTypeRepository instance1 = ServiceLocator.Current.GetInstance<IContentTypeRepository>();
            IPageCriteriaQueryService instance2 = ServiceLocator.Current.GetInstance<IPageCriteriaQueryService>();
            foreach (GridViewRow row in this.PageTypesGrid.Rows)
            {
                string id1 = "boxPageTypes";
                bool flag = ((CheckBox)row.FindControl(id1)).Checked;
                string id2 = "typeIdPageTypes";
                string text = ((Label)row.FindControl(id2)).Text;
                if (flag)
                {
                    PageDataCollection pagesWithCriteria = instance2.FindPagesWithCriteria(ContentReference.RootPage, new PropertyCriteriaCollection()
          {
            new PropertyCriteria()
            {
              Condition = CompareCondition.Equal,
              Name = "PageTypeID",
              Type = PropertyDataType.PageType,
              Value = text
            }
          });
                    if (pagesWithCriteria != null && pagesWithCriteria.Count > 0)
                    {
                        IContentRepository instance3 = ServiceLocator.Current.GetInstance<IContentRepository>();
                        foreach (PageData pageData in pagesWithCriteria)
                            instance3.Delete(pageData.ContentLink, true);
                    }
                    instance1.Delete(instance1.Load(int.Parse(text)));
                }
            }
          ((Page)this).Response.Redirect(((Page)this).Request.RawUrl);
        }

        protected class Result
        {
            public string TypeName { get; set; }

            public string Name { get; set; }

            public int id { get; set; }

            public string PageLink { get; set; }

            public string PageName { get; set; }
        }
    }
}
