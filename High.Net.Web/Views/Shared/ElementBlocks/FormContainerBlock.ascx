<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.Business.SelectionFactory" %>
<%@ Import Namespace="High.Net.Models.HighNet.Pages" %>
<%@ Control Language="C#" Inherits="ViewUserControl<FormContainerBlock>" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%  
    var _formConfig = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Forms.Configuration.IEPiServerFormsImplementationConfig>();
%>
<%
    var startPage = SiteDefinition.Current.StartPage.GetContent<BasePageData>();
    if (startPage is HomePage)
    {
        var templateSite = (startPage as HomePage).SiteViewTemplate;
        if (templateSite == SelectHighSiteTemplate.LeadershipTemplate)
        {
            Html.RenderPartial("~/Views/Shared/ElementBlocks/LeadershipFormContainerBlock.ascx", Model);
        }
        else if (templateSite == SelectHighSiteTemplate.FamilyTemplate)
        {
            Html.RenderPartial("~/Views/Shared/ElementBlocks/FamilyFormContainerBlock.ascx", Model);
        }else
        {
            Html.RenderPartial("~/Views/Shared/ElementBlocks/CommonFormContainerBlock.ascx", Model);
        }
    }
    else
    {
        Html.RenderPartial("~/Views/Shared/ElementBlocks/CommonFormContainerBlock.ascx", Model);
    }
%>
