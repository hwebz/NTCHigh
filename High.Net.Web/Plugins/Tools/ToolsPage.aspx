<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToolsPage.aspx.cs" Inherits="High.Net.Web.Plugins.Tools.ToolsPage" %>

<%@ Register TagPrefix="EPiServerUI" Namespace="EPiServer.UI.WebControls" Assembly="EPiServer.UI" %>
<%@ Register TagPrefix="EPiServer" Namespace="EPiServer.Web.WebControls" Assembly="EPiServer.Web.WebControls" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.ClientScript.WebControls" Assembly="EPiServer" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.UI.ClientScript.WebControls" Assembly="EPiServer.UI" %>

<asp:Content contentplaceholderid="MainRegion" runat="server">    
    <div class="epi-paddingHorizontal" runat="server">
        <div class="epi-buttonContainer">
            <EPiServerUI:ToolButton OnClientClick="javascript:return confirm('Are you sure you want to re-organize global forms folder?');" id="btnReOrganizeForms" OnClick="btnReOrganizeForms_Click" runat="server" text="Re-Organize Global Block Forms Folder"  tooltip="Re-Organize Global Block Forms Folder"  />            
            <EPiServerUI:ToolButton id="btnMigrageMapBlock" OnClick="btnMigrageMapBlock_Click" runat="server" text="Migrate map block property"  tooltip="Migrate map block property"  />            
        </div>
    </div>
</asp:Content>

