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
<%@ Control Language="C#" Inherits="ViewUserControl<TextareaElementBlock>" %>

<%  var formElement = Model.FormElement; 
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
    <% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Textarea form-group contact" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="textarea" })) { %>
        <textarea name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" class="FormTextbox__Input form-control"
            placeholder="<%: Model.PlaceHolder %>" data-f-label="<%: labelText %>" data-f-datainput
            <%= Model.AttributesString %> ><%: Model.GetDefaultValue() %></textarea>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } else { %>
    <% using(Html.BeginElement(Model, new { @class="FormTextbox FormTextbox--Textarea" + Model.GetValidationCssClasses(), data_f_type="textbox", data_f_modifier="textarea" })) { %>
        <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
        <textarea name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" class="FormTextbox__Input"
            placeholder="<%: Model.PlaceHolder %>" data-f-label="<%: labelText %>" data-f-datainput
            <%= Model.AttributesString %> ><%: Model.GetDefaultValue() %></textarea>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>

<% } %>
