<%@ import namespace="System.Web.Mvc" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.HighNet" %>
<%@ Import Namespace="High.Net.Models.NewResidential" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%@ control language="C#" inherits="ViewUserControl<SelectionElementBlock>" %>

<%
    var formElement = Model.FormElement; 
    var labelText = Model.Label;
    var placeholderText = Model.PlaceHolder;
    var defaultOptionItemText = !string.IsNullOrWhiteSpace(placeholderText) ? placeholderText : Html.Translate(string.Format("/episerver/forms/viewmode/selection/{0}", Model.AllowMultiSelect ? "selectoptions" : "selectanoption"));
    var defaultOptionSelected = Model.Items.Count(x => x.Checked.HasValue && x.Checked.Value) <= 0 ? "selected=\"selected\"" : "";
    var items = Model.GetItems();
%>

<% if(SiteDefinition.Current.StartPage.GetContent<BasePageData>() is IHighNet || SiteDefinition.Current.StartPage.GetContent<BasePageData>() is INewResidential) { %>
      <% using(Html.BeginElement(Model, new { @class="FormSelection form-group contact" + Model.GetValidationCssClasses(), data_f_type="selection" })) { %>
        <select class="makeMeFancy" name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" <%: Model.AllowMultiSelect ? "multiple" : "" %>  <%= Model.AttributesString %> >
            <option disabled="disabled" <%= defaultOptionSelected %> value=""><%: defaultOptionItemText %></option>
            <%
            foreach (var item in items)
            {
                var defaultSelectedString = Model.GetDefaultSelectedString(item);
                var selectedString = string.IsNullOrEmpty(defaultSelectedString) ? string.Empty : "selected";
            %>
            <option value="<%: item.Value %>" <%= selectedString %> <%= defaultSelectedString %>><%: item.Caption %></option>
            <% } %>
        </select>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } else { %>
    <% using(Html.BeginElement(Model, new { @class="FormSelection" + Model.GetValidationCssClasses(), data_f_type="selection" })) { %>
        <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
        <select name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" <%: Model.AllowMultiSelect ? "multiple" : "" %>  <%= Model.AttributesString %> >
            <option disabled="disabled" <%= defaultOptionSelected %> value=""><%: defaultOptionItemText %></option>
            <%
            foreach (var item in items)
            {
                var defaultSelectedString = Model.GetDefaultSelectedString(item);
                var selectedString = string.IsNullOrEmpty(defaultSelectedString) ? string.Empty : "selected";
            %>
            <option value="<%: item.Value %>" <%= selectedString %> <%= defaultSelectedString %>><%: item.Caption %></option>
            <% } %>
        </select>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } %>