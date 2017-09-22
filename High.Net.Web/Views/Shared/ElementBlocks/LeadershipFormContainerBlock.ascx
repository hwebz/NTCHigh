<%@ Import Namespace="System.Web.Mvc" %>
<%@ Import Namespace="EPiServer.Web.Mvc.Html" %>
<%@ Import Namespace="EPiServer.Forms" %>
<%@ Import Namespace="EPiServer.Forms.Core" %>
<%@ Import Namespace="EPiServer.Forms.Core.Models" %>
<%@ Import Namespace="EPiServer.Forms.Helpers.Internal" %>
<%@ Import Namespace="EPiServer.Forms.EditView.Internal" %>
<%@ Import Namespace="EPiServer.Forms.Implementation.Elements" %>
<%@ Control Language="C#" Inherits="ViewUserControl<FormContainerBlock>" %>
<%@ Import Namespace="High.Net.Web.Business.Helpers" %>
<%  
    var _formConfig = EPiServer.ServiceLocation.ServiceLocator.Current.GetInstance<EPiServer.Forms.Configuration.IEPiServerFormsImplementationConfig>();
%>


<% if (EPiServer.Editor.PageEditing.PageIsInEditMode) { %>
    <link rel="stylesheet" type="text/css" data-f-resource="EPiServerForms.css" href='<%: ModuleHelper.ToClientResource(typeof(FormsModule), "ClientResources/ViewMode/EPiServerForms.css")%>' />
    <% if (Model.Form != null) { %>
        <div class="EPiServerForms">
            <h2 class="Form__Title"><%: Html.PropertyFor(m => m.Title) %></h2>
            <h4 class="Form__Description"><%: Html.PropertyFor(m => m.Description) %></h4>
            <div class="success-message"><p>Thanks for your interest. We'll be in touch should your experience and interests be a match.</p></div>
            <%: Html.PropertyFor(m => m.ElementsArea) %>
        </div>
    <% } else { %>
        <%--In case FormContainerBlock is used as a property, we cannot build Form model so we show a warning message to notify user--%>
        <div class="EPiServerForms">
            <span class="Form__Warning"><%: Html.Translate("/episerver/forms/editview/cannotbuildformmodel") %></span>
        </div>
    <% } %>
<% } else if (Model.Form != null) { %>

    <%-- 
    Using form tag (instead of div) for the sake of html elements' built-in features e.g. reset, file upload
    Using enctype="multipart/form-data" for post data and uploading files 
--%>
    <%
        
        var validationCssClass = ViewBag.ValidationFail ? "ValidationFail" : "ValidationSuccess";
    %>
    <%--Form will post to its own page Controller --%>

    <% if (ViewBag.RenderingFormUsingDivElement) { %>
    <div data-f-metadata="<%: Model.MetadataAttribute %>" class="EPiServerForms <%: validationCssClass %>" data-f-type="form" id="<%: Model.Form.FormGuid %>">
        <%}  else {%>

        <form method="post" 
              data-f-metadata="<%: Model.MetadataAttribute %>"
              enctype="multipart/form-data" class="EPiServerForms <%: validationCssClass %>" data-f-type="form" id="<%: Model.Form.FormGuid %>">

        <%} %>

        <%--Meta data, authoring data of this form is transfer to clientside here. We need to take form with language coresponse with current page's language --%>
        <script type="text/javascript" src="<%: _formConfig.CoreController %>/GetFormInitScript?formGuid=<%: Model.Form.FormGuid %>&formLanguage=<%: FormsExtensions.GetCurrentPageLanguage() %>"></script>

        <%--Meta data, send along as a SYSTEM information about this form, so this can work without JS --%>
        <input type="hidden" class="Form__Element Form__SystemElement FormHidden FormHideInSummarized" name="__FormGuid" value="<%: Model.Form.FormGuid %>" data-f-type="hidden" />
        <input type="hidden" class="Form__Element Form__SystemElement FormHidden FormHideInSummarized" name="__FormHostedPage" value="<%: FormsExtensions.GetCurrentPageLink().ToString() %>" data-f-type="hidden" />
        <input type="hidden" class="Form__Element Form__SystemElement FormHidden FormHideInSummarized" name="__FormLanguage" value="<%: FormsExtensions.GetCurrentPageLanguage() %>" data-f-type="hidden" />
        <input type="hidden" class="Form__Element Form__SystemElement FormHidden FormHideInSummarized" name="__FormCurrentStepIndex" value="<%: ViewBag.CurrentStepIndex ?? "" %>" data-f-type="hidden" />
        <input type="hidden" class="Form__Element Form__SystemElement FormHidden FormHideInSummarized" name="__FormSubmissionId" value="<%: ViewBag.FormSubmissionId %>" data-f-type="hidden" />

        
        <div class="success-message"  style="display:none"><p>Thanks for your interest. We'll be in touch should your experience and interests be a match.</p></div>
        <%  var statusDisplay = "hide";
            var message = ViewBag.Message;

            if (ViewBag.FormFinalized || ViewBag.IsProgressiveSubmit){
                statusDisplay = "Form__Success__Message";
            }
            else if (!ViewBag.Submittable && !string.IsNullOrEmpty(message)) {
                statusDisplay = "Form__Warning__Message";
            } 
        %>
        <%
        if (ViewBag.IsReadOnlyMode)
        {
        %>
            <div class="Form__Status">
                <span class="Form__Readonly__Message">
                    <%: Html.Translate("/episerver/forms/viewmode/readonlymode")%>
                </span>
            </div>
        <% 
       }
        %>

        <%-- area for showing Form's status or validation --%>
        <div class="Form__Status">
            <div class="Form__Status__Message <%: statusDisplay %>" data-f-form-statusmessage>
                <% if (ViewBag.FormFinalized) { %>
                    <%= message %>
                <% } else { %>
                    <%: message %>
                <% } %>
            </div>
        </div>

        <div class="Form__MainBody">
            <div class="row">
                <div class="col-xs-12 col-sm-12 col-md-6">
                    <div class="contact-form-popup__title">
                        <h1><%: Model.Title %></h1>
                    </div>
                </div>
            </div>
            <div class="row">
            <%  var i = 0;
                var currentStepIndex = ViewBag.CurrentStepIndex == null ? -1 : (int)ViewBag.CurrentStepIndex;
                string stepDisplaying;
                foreach (var step in Model.Form.Steps) { 
                    stepDisplaying = (currentStepIndex == i && !ViewBag.FormFinalized && (bool)ViewBag.IsStepValidToDisplay) ? "" : "hide"; %>
                <section id="<%: step.ElementName %>" data-f-type="step" data-f-element-name="<%: step.ElementName %>" class="Form__Element FormStep Form__Element--NonData <%: stepDisplaying %>" data-f-stepindex="<%: i %>" data-f-element-nondata>
                    <% 
                        var stepBlock = (step.SourceContent as ElementBlockBase);
                        if(stepBlock != null)
                        {
                            //Html.RenderContentData(step.SourceContent, false);
                        }
                    %>

                    <!-- Each FormStep groups the elements below it til the next FormStep -->
                   
                        <%
                            var buttons = step.Elements.Where(ele => (ele.SourceContent is SubmitButtonElementBlock));
                            var inputs = step.Elements.Where(ele => !(ele.SourceContent is SubmitButtonElementBlock));
                        %>
                    <div class="col-xs-12 col-sm-6 col-md-6">
                        <% Html.RenderFormElements(i, inputs, Model); %>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-6">
                        <aside class="Form__Description"><%: Model.Description %></aside>
                        <% Html.RenderFormElements(i, buttons, Model); %>
                        <p class="leadership-form-message"></p>
                    </div>
                    
                </section>

            <% i++; } // end foreach steps %>

            </div>
        </div>
        <%-- endof FormMainBody --%>
    
        <% if (ViewBag.RenderingFormUsingDivElement ) { %>
        </div>
        <%} else{  %>
            </form>
    <% } %>

<% } %>