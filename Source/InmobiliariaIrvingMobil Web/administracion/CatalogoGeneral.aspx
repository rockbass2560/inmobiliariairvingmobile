<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogoGeneral.aspx.cs" Inherits="administracion_CatalogoGeneral" MasterPageFile="~/administracion/Administracion.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        function asignarValores(li) {
            li = $(li);
            
        }
    </script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="content">
    <asp:Repeater runat="server" ID="repeater">
        <HeaderTemplate>
            <ul id="listaCatalogo" data-autodividers="true" data-filter="true" data-role="listview">
        </HeaderTemplate>
        <ItemTemplate>
            <li>
                <%-- ID: <asp:Literal ID="ltrId" ClientIDMode="AutoID" runat="server" Text='<%# Bind("ID") %>'></asp:Literal><br /> --%>
                <asp:Literal ID="ltrDescripcion" ClientIDMode="AutoID" runat="server" Text='<%# Bind("Descripcion") %>'></asp:Literal>
                <a href="#modificarCatalogo" onclick="asignarValores(this.parentNode)" data-split-icon="edit" data-rel="dialog"></a>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="footer">
    <%-- Sera un dialog que carge los datos del catalogo --%>
    <div data-role="dialog" id="modificarCatalogo">
        <fieldset>
            <legend>Cambio de Datos</legend>
            <label for="textID">ID:</label>
            <input type="text" readonly="readonly" id="textID" />
            <label for="textDescripcion"></label>
            <input type="text" id="textDescripcion" />
            <input type="button" id="botonCambios" value="Dar de Alta" />
        </fieldset>
    </div>
</asp:Content>
