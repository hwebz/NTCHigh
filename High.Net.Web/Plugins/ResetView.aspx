<%@ Page Language="c#" CodeBehind="ResetView.aspx.cs" AutoEventWireup="False" Inherits="High.Net.Web.Plugins.ResetView" Title="ResetView" %>

<form runat="server">
    <asp:button runat="server" id="btnReset" onclick="btnReset_OnClick" text="Reset View" />
    <br />
    <asp:label runat="server" id="labelMessage"></asp:label>
</form>
