<%@ Page AspCompat="true" Language="C#" AutoEventWireup="true" CodeFile="Panel.aspx.cs" Inherits="administracion_Panel" MasterPageFile="~/administracion/Administracion.master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript" src="js/Panel.js"></script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="content">
    <asp:ToolkitScriptManager ID="scriptMAnagerToolkit" runat="server" EnablePageMethods="true">
        </asp:ToolkitScriptManager>
    <div>
        <a href="Catalogo.aspx?action=insert" data-role="button" data-icon="plus" data-inline="true">Agregar</a>
    </div>
    <asp:GridView runat="server" ID="gridCasas"
        AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" />
            <asp:BoundField DataField="Calle" HeaderText="Calle" />
            <asp:BoundField DataField="Colonia" HeaderText="Colonia" />
            <asp:BoundField DataField="TipoTransaccion" HeaderText="Tipo de Venta" />
            <asp:TemplateField HeaderText="Editar">
                <ItemTemplate>
                    <asp:HyperLink ID="linkEdit" runat="server" NavigateUrl='<%# Bind("EditHRef") %>' data-icon="edit" data-role="button" data-mini="true" Text="Editar" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar">
                <ItemTemplate>
                    <asp:HyperLink ID="linkDelete" ClientIDMode="AutoID" runat="server" NavigateUrl='<%# Bind("DeleteHRef") %>' data-icon="delete" data-role="button" data-mini="true" Text='<%# Bind("Estado") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <RowStyle BackColor="White" />
        <AlternatingRowStyle BackColor="#DFDDDE" />
        <EmptyDataTemplate>
            No se han encontrado datos disponibles
        </EmptyDataTemplate>
    </asp:GridView>
</asp:Content>