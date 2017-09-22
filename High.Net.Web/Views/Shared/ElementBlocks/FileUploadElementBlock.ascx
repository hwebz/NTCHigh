<%@ import namespace="System.Web.Mvc" %>
<%@ import namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ import namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.HighNet" %>
<%@ Import Namespace="High.Net.Models.NewResidential" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%@ control language="C#" inherits="ViewUserControl<FileUploadElementBlock>" %>

<%  var formElement = Model.FormElement; 
    var labelText = Model.Label;
    var allowMultiple = Model.AllowMultiple ? "multiple" : string.Empty;
%>

<% if(SiteDefinition.Current.StartPage.GetContent<BasePageData>() is IHighNet || SiteDefinition.Current.StartPage.GetContent<BasePageData>() is INewResidential) { %>
    <% using(Html.BeginElement(Model, new { @class="FormFileUpload contact" + Model.GetValidationCssClasses(), data_f_type="fileupload" })) { %>
        
        <input type="file" 
            name="<%: formElement.ElementName %>" 
            id="<%: formElement.Guid %>" 
            <%:allowMultiple%>
            <% if(!string.IsNullOrEmpty(Model.FileExtensions)) { %>
			    accept="<%=Model.FileExtensions%>"
    	    <%}%>    
            class="FormFileUpload__Input inputfile inputfile-6"
            <%= Model.AttributesString %> data-f-datainput />

        <label for="<%: formElement.Guid %>" class="Form__Element__Caption resume-file form-control contact">
            <span><%: labelText %></span> <strong>Browse for file</strong>
        </label>

        <div class="FormFileUpload__PostedFile" data-f-postedFile></div>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>

<% } else { %>
    <% using(Html.BeginElement(Model, new { @class="FormFileUpload" + Model.GetValidationCssClasses(), data_f_type="fileupload" })) { %>
        <label for="<%: formElement.Guid %>" class="Form__Element__Caption"><%: labelText %></label>
        <input name="<%: formElement.ElementName %>" id="<%: formElement.Guid %>" type="file" class="FormFileUpload__Input" <%:allowMultiple%>
            <% if(!string.IsNullOrEmpty(Model.FileExtensions)) { %>
			    accept="<%=Model.FileExtensions%>"
    	    <%}%>     
            <%= Model.AttributesString %> data-f-datainput />
        <div class="FormFileUpload__PostedFile" data-f-postedFile></div>
        <%= Html.ValidationMessageFor(Model) %>
    <% } %>
<% } %>
