<%@ Page Language="c#" CodeBehind="TypeSync.aspx.cs" AutoEventWireup="False" Inherits="Techease.TypeSynchronization.TypeSync" Title="Type Synchronization" %>

<%@ Register TagPrefix="EPiServerUI" Namespace="EPiServer.UI.WebControls" Assembly="EPiServer.UI" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.ClientScript.WebControls" Assembly="EPiServer" %>
<%@ Register TagPrefix="EPiServerScript" Namespace="EPiServer.UI.ClientScript.WebControls" Assembly="EPiServer.UI" %>

<asp:content contentplaceholderid="MainRegion" runat="server">
    <EPiServerUI:TabStrip  runat="server" id="actionTab" EnableViewState="true" GeneratesPostBack="False" targetid="tabView" supportedpluginarea="SystemSettings">
        <EPiServerUI:Tab Text="Properties" runat="server" ID="Tab1" />
        <EPiServerUI:Tab Text="Page Types"  runat="server" ID="Tab2" />
    </EPiServerUI:TabStrip>

    <asp:Panel runat="server" ID="tabView" CssClass="epi-padding">
        <div class="epi-formArea" ID="PropertyTypes" runat="server">
            <div class="epi-size25">
                    <p class="EP-systemInfo"><b>Page Types</b></p>
                    <asp:GridView
                    ID="PropertiesViewControl_Pages"
                    runat="server"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Type Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                              <%#Item.TypeName %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Property Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <%#Item.Name%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:CheckBox id="box" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false" visible="false">
                            <ItemTemplate>
                                <asp:Label id="typeid" Text="<%#Item.id %>" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="epi-buttonContainer">
                     <asp:Label id="noPagePropertiesMsg" runat="server" visible="false" class="floatleft"></asp:Label>
                    <EPiServerUI:ToolButton id="Save_PageProperties" DisablePageLeaveCheck="true" OnClick="Delete_PageProperties" runat="server" text="Delete" ToolTip="Delete" SkinID="Delete" />
                </div>
                   <br />
                <p class="EP-systemInfo"><b>Block Types</b></p>
                <asp:GridView  ID="PropertiesViewControl_Blocks"
                    runat="server"
                    AutoGenerateColumns="false">
                        <Columns>
                        <asp:TemplateField HeaderText="Type Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                              <%#Item.TypeName %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Property Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <%#Item.Name%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:CheckBox id="boxBlock" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false" visible="false">
                            <ItemTemplate>
                                <asp:Label id="typeidBlock" Text="<%#Item.id %>" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                 <div class="epi-buttonContainer">
                    <asp:Label id="noBlockPropertiesMsg" runat="server" visible="false" class="floatleft"></asp:Label>
                    <EPiServerUI:ToolButton id="Save_BlockProperties" DisablePageLeaveCheck="true" OnClick="Delete_BlockProperties" runat="server" text="Delete" ToolTip="Delete" SkinID="Delete" />
                </div>
                <br />
                <p class="EP-systemInfo"><b>Media Types</b></p>
                    <asp:GridView
                    ID="PropertiesViewControl_Media"
                    runat="server"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Type Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                              <%#Item.TypeName %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Property Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <%#Item.Name%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:CheckBox id="boxMedia" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false" visible="false">
                            <ItemTemplate>
                                <asp:Label id="typeIdMedia" Text="<%#Item.id %>" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="epi-buttonContainer">
                    <asp:Label id="noMediaPropertiesMsg" runat="server" visible="false" class="floatleft"></asp:Label>
                    <EPiServerUI:ToolButton id="Save_MediaProperties" DisablePageLeaveCheck="true" OnClick="Delete_MediaProperties" runat="server" text="Delete" ToolTip="Delete" SkinID="Delete" />
                </div>
            </div>
        </div>
        <div class="epi-formArea" id="PageTypes" runat="server">
              <div class="epi-size25">
                 <asp:GridView
                    ID="PageTypesGrid"
                    runat="server"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Type Name" ItemStyle-Wrap="false">
                            <ItemTemplate>
                              <%#Item.TypeName %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false">
                            <ItemTemplate>
                                <asp:CheckBox id="boxPageTypes" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" ItemStyle-Wrap="false" visible="false">
                            <ItemTemplate>
                                <asp:Label id="typeIdPageTypes" Text="<%#Item.id %>" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="epi-buttonContainer">
                     <asp:Label id="noPageTypesMsg" runat="server" visible="false" class="floatleft"></asp:Label>
                    <EPiServerUI:ToolButton id="Save_PageTypes" DisablePageLeaveCheck="true" OnClick="Delete_PageTypes" runat="server" text="Delete" ToolTip="Delete" SkinID="Delete" />
                </div>
             </div>
        </div>
    </asp:Panel>
</asp:content>