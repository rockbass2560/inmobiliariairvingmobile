<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" MasterPageFile="~/Index.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript" src="js/Default.js"></script>
</asp:Content>

<%--Contenido HTML de la pagina --%>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
Búsqueda:
    <div id="divFiltro" class="centrarDiv">
        <asp:DropDownList runat="server" ID="selectComprar">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="selectTipoInmueble" >
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="selectCiudad">
        </asp:DropDownList>
        <asp:DropDownList runat="server" ID="selectColonia">
        </asp:DropDownList>
        <div data-role="fieldcontain">
            <label for="precioMenor">Precio Menor:</label>
            <asp:TextBox style="width:100px;" runat="server" id="precioMenor" min="" max="" step="" Text="" data-highlight="true" />
            <br /><br />
            <label for="precioMayor">Precio Mayor:</label>
            <asp:TextBox style="width:100px;" runat="server" id="precioMayor" min="" max="" step="" Text="" data-highlight="true" />
        </div>
        <asp:Button runat="server" data-icon="search" Text="Buscar" 
            ID="buttonBusqueda" onclick="buttonBusqueda_Click" />
    </div>
</asp:Content>