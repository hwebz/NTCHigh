<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageVaultUpdateLinkPage.aspx.cs" Inherits="High.Net.Web.Plugins.ImageVaultUpdateLink.ImageVaultUpdateLinkPage" %>

<%@ Register TagPrefix="EPiServerUI" Namespace="EPiServer.UI.WebControls" Assembly="EPiServer.UI" %>
<%@ Register TagPrefix="EPiServer" Namespace="EPiServer.Web.WebControls" Assembly="EPiServer.Web.WebControls" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.ClientScript.WebControls" Assembly="EPiServer" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.UI.ClientScript.WebControls" Assembly="EPiServer.UI" %>

<asp:content contentplaceholderid="MainRegion" runat="server">    
    <div class="epi-paddingHorizontal" runat="server">
        <div>
            <asp:Label ID ="lblMessage"  runat="server" />
        </div>
        <div>
            <asp:Label AssociatedControlID="PageRoot" Text="Select website" runat="server" />
            <EPiServer:InputPageReference ID="PageRoot" DisableCurrentPageOption="true" runat="server" Style="display: inline; margin: 0;" />
            <div>
                <span>Data file(json): </span>
                <asp:FileUpload ID="dataFile" runat="server" />
            </div>                 
        </div>
        <div class="epi-buttonContainer">
            <EPiServerUI:ToolButton id="UpdateButton" OnClick="UpdateButton_Click" runat="server" text="Update"  tooltip="Update link"  />            
        </div>
        <div class="epi-buttonContainer">
            <textarea runat="server" id="txtMessage" cols="15" rows="5"></textarea>
        </div>
    </div>
</asp:content>
