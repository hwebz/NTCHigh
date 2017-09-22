<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.Business.SelectionFactory" %>
<%@ Import Namespace="High.Net.Models.HighNet" %>
<%@ Import Namespace="High.Net.Models.HighNet.Pages" %>
<%@ Import Namespace="High.Net.Models.NewResidential" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>

<%@ Control Language="C#" Inherits="ViewUserControl<UrlElementBlock>" %>

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

<% if(!hasShowLabel) { %>
      <% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Url form-group contact" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="url" })) { %>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="url" class="FormTextbox__Input FormUrl__Input form-control contact"
               placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%: Html.Raw(Model.AttributesString) %>  data-f-datainput/>

        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } else { %>
    <% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Url" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="url" })) { %>
        <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="url" class="FormTextbox__Input FormUrl__Input"
               placeholder="<%: Model.PlaceHolder %>" value="<%: Model.GetDefaultValue() %>" <%: Html.Raw(Model.AttributesString) %>  data-f-datainput/>

        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } %>
