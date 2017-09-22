<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Import Namespace="EPiServer.Web" %>
<%@ Import Namespace="High.Net.Core" %>
<%@ Import Namespace="High.Net.Models.HighNet" %>
<%@ Import Namespace="High.Net.Models.NewResidential" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%@ Control Language="C#" Inherits="ViewUserControl<SubmitButtonElementBlock>" %>

<%
    var formElement = Model.FormElement;
    var buttonText = Model.Label;

    var buttonDisableState = Model.GetFormSubmittableStatus(ViewContext.Controller.ControllerContext.HttpContext);
%>

<% if(SiteDefinition.Current.StartPage.GetContent<BasePageData>() is IHighNet ) { %>
    <div class="send-applicatin-btn">
        <button id="<%: formElement.Guid %>" name="submit" type="submit" value="<%: formElement.Guid %>" data-f-is-finalized="<%: Model.FinalizeForm.ToString().ToLower() %>"
            data-f-is-progressive-submit="true" data-f-type="submitbutton"
            <%= Model.AttributesString %> <%: buttonDisableState %>
            <% if (Model.Image == null) 
            { %>
                class="Form__Element FormExcludeDataRebind FormSubmitButton get-in-touch-btn">
                <%: buttonText %>
            <% } else { %>
                class="Form__Element FormExcludeDataRebind FormSubmitButton FormImageSubmitButton">
                <img src="<%: Model.Image.Path %>" data-f-is-progressive-submit="true" data-f-is-finalized="<%: Model.FinalizeForm.ToString().ToLower() %>" />
            <% } %>
        </button>
    </div>

<% } else { %>
    <button id="<%: formElement.Guid %>" name="submit" type="submit" value="<%: formElement.Guid %>" data-f-is-finalized="<%: Model.FinalizeForm.ToString().ToLower() %>"
        data-f-is-progressive-submit="true" data-f-type="submitbutton"
        <%= Model.AttributesString %> <%: buttonDisableState %>
        <% if (Model.Image == null) 
        { %>
            class="Form__Element FormExcludeDataRebind FormSubmitButton">
            <%: buttonText %>
        <% } else { %>
            class="Form__Element FormExcludeDataRebind FormSubmitButton FormImageSubmitButton">
            <img src="<%: Model.Image.Path %>" data-f-is-progressive-submit="true" data-f-is-finalized="<%: Model.FinalizeForm.ToString().ToLower() %>" />
        <% } %>
    </button>

<% } %>
