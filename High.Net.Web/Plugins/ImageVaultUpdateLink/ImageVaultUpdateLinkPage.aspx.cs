using EPiServer;
using EPiServer.PlugIn;
using EPiServer.ServiceLocation;
using EPiServer.Shell.WebForms;
using EPiServer.UI;
using System.Linq;
using System;
using EPiServer.Core;
using High.Net.Models.HighNet.Pages;
using High.Net.Models.HighNet.Blocks;
using ImageVault.EPiServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using EPiServer.DataAccess;
using EPiServer.Security;
using High.Net.Core;
using System.Web;
using System.IO;
using System.Web.UI;
using High.Net.Web.Business;
using High.Net.Web.Business.Helpers;

namespace High.Net.Web.Plugins.ImageVaultUpdateLink
{
    [GuiPlugIn(DisplayName = "Image Vault Update Link", Description = "Image Vault Update Link", Area = PlugInArea.AdminMenu, Url = "~/Plugins/ImageVaultUpdateLink/ImageVaultUpdateLinkPage.aspx")]
    public partial class ImageVaultUpdateLinkPage : WebFormsBase
    {
        private List<ImageVaultData> ImageVaultDatas;
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageVaultDatas = new List<ImageVaultData>();
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.SystemMessageContainer.Heading = "Image Vault Update Link";
            this.SystemMessageContainer.Description = "This tool aim to update the old image vault reference with the new one when migrate its data from uat to prod env.";
        }
        private void DisplayAlert(string message)
        {
            var clientScriptName = "PopupScript";
            Type clientScriptType = this.GetType();

            // Get a ClientScriptManager reference from the Page class.
            ClientScriptManager cs = Page.ClientScript;

            // Check to see if the startup script is already registered.
            if (!cs.IsStartupScriptRegistered(clientScriptType, clientScriptName))
            {
                var msg = string.Format("alert('{0}');", message);
                cs.RegisterStartupScript(clientScriptType, clientScriptName, msg, true);
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            //check file was submitted
            if (dataFile.PostedFile == null || dataFile.PostedFile.ContentLength <= 0)
            {
                DisplayAlert("Please pick valid json data file.");
                return;
            }
            if (PageReference.IsNullOrEmpty(PageRoot.PageLink))
            {
                DisplayAlert("Please select website to update.");
                return;
            }
            var affectedContents = new List<string>();

            LoadJsonData(new StreamReader(dataFile.PostedFile.InputStream).ReadToEnd());
            var count = 0;
            var _contentRepository = ServiceLocator.Current.GetInstance<IContentRepository>();
            var websiteContentData = _contentRepository.GetDescendents(PageRoot.PageLink)
                .Select(_contentRepository.Get<ContentData>)
                .ToList();
            websiteContentData.Insert(0, _contentRepository.Get<ContentData>(PageRoot.PageLink));

            bool flag = false;
            bool contentPageFlag = false;
            foreach (var content in websiteContentData)
            {
                var imageVaultProps = content.GetOriginalType().GetProperties().Where(x => x.PropertyType == typeof(MediaReference));
                if (imageVaultProps != null && imageVaultProps.Any())
                {
                    var clone = (ContentData)content.CreateWritableClone();
                    foreach (var imageVaultProperty in imageVaultProps)
                    {
                        if (null == (MediaReference)imageVaultProperty.GetValue(content))
                            continue;
                        var uatId = ((MediaReference)imageVaultProperty.GetValue(content)).Id;
                        if (ImageVaultDatas.Any(x => x.UatId == uatId))
                        {
                            clone[imageVaultProperty.Name] = new PropertyMedia(new MediaReference() { Id = ImageVaultDatas.Single(x => x.UatId == uatId).ProdId }).ToRawProperty().Value;
                            _contentRepository.Save(clone as IContent, SaveAction.Publish, AccessLevel.NoAccess);
                            count += 1;
                            contentPageFlag = true;
                        }
                    }
                }
                if (contentPageFlag)
                {
                    affectedContents.Add(string.Format("Found image vault for content: {0} \n", ((IContent)content).Name));
                }
                var contentAreas = content.GetOriginalType().GetProperties().Where(x => x.PropertyType == typeof(ContentArea));
                var contentCount = 0;
                if (contentAreas != null && contentAreas.Any())
                {
                    foreach (var contentAreaProp in contentAreas)
                    {
                        var contentArea = contentAreaProp.GetValue(content) as ContentArea;
                        if (contentArea == null)
                            continue;

                        var messages = contentArea.UpdateMediaItemsOfBlock(ImageVaultDatas);
                        if (messages.Any())
                        {
                            contentCount += messages.Count;
                            affectedContents.AddRange(messages);
                            flag = true;
                        }
                    }
                }
                if (!contentPageFlag && flag)
                {
                    affectedContents.Add(string.Format("Found {0} image vault item(s) for content: {1} \n", contentCount, ((IContent)content).Name));
                }
            }

            txtMessage.InnerText = affectedContents.Any() ? affectedContents.Aggregate((b, n) => b + "<br/>" + n) : "Not found any content meet data which attached.";

            DisplayAlert(string.Format("Finished update image(s) vault link! Found {0} page(s) affected.", count));
        }

        private void LoadJsonData(string data)
        {
            var dumbData = JArray.Parse(data);
            foreach (var token in dumbData)
            {
                ImageVaultDatas.Add(new ImageVaultData
                {
                    UatId = Convert.ToInt16(token["UatId"]),
                    ProdId = Convert.ToInt16(token["ProdId"])
                });
            }
        }

    }
}