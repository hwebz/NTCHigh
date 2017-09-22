<%@ import namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.Business.SelectionFactory" %>
<%@ Import Namespace="High.Net.Models.HighNet" %>
<%@ Import Namespace="High.Net.Models.HighNet.Pages" %>
<%@ Import Namespace="High.Net.Models.NewResidential" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%@ control language="C#" inherits="ViewUserControl<TextboxElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var labelText = Model.Label;
    var startPage = SiteDefinition.Current.StartPage.GetContent<BasePageData>();
    var hasShowLabel = true;
    if (startPage is IHighNet)
    {
        if ((startPage as HomePage).SiteViewTemplate == SelectHighSiteTemplate.HightNetTemplate)
        {
            hasShowLabel = false;
        }
    }
    else if(startPage is INewResidential)
    {
        hasShowLabel = false;
    }
%>
<% if(!hasShowLabel ) { %>
    <% using(Html.BeginElement(Model, new { @class="FormTextbox form-group contact" + Model.GetValidationCssClasses(), data_f_type="textbox" })) { %>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" class="FormTextbox__Input form-control contact"
            placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%: Html.Raw(Model.AttributesString) %> data-f-datainput />

        <%= Html.ValidationMessageFor(Model) %>
        <%= Model.RenderDataList() %>
    <% } %>
<% } else { %>
    <% using(Html.BeginElement(Model, new { @class="FormTextbox" + Model.GetValidationCssClasses(), data_f_type="textbox" })) { %>
        <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="text" class="FormTextbox__Input"
            placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%: Html.Raw(Model.AttributesString) %> data-f-datainput />

        <%= Html.ValidationMessageFor(Model) %>
        <%= Model.RenderDataList() %>
    <% } %>
<% } %>