<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contactos.aspx.cs" Inherits="contacto" MasterPageFile="~/Index.master" %>

<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="divMensaje" runat="server" visible="false">
        <b>Su mensaje a sido enviado satisfactoriamente</b>
    </div>
    <div id="divElementos" runat="server">
        <h1>Contacto</h1><br />
        <fieldset>
            <label for="<%# textNombre.ClientID %>">Nombre:</label>
            <asp:TextBox runat="server" ID="textNombre" placeholder="Nombre" required></asp:TextBox>
            <label for="<%# textEmail.ClientID %>">Email:</label>
            <asp:TextBox runat="server" ID="textEmail" placeholder="Email" required pattern="^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,3})$"></asp:TextBox>
            <label for="<%# textTelefono.ClientID %>">Telefono:</label>
            <asp:TextBox runat="server" ID="textTelefono" placeholder="Telefono" required></asp:TextBox>
            Lada + Tel&eacute;fono donde contactarte<br /><br />
            <label for="<%# textMensaje.ClientID %>"><b>Mensaje:</b></label>
            <asp:TextBox style="height:12em;" runat="server" ID="textMensaje" required TextMode="MultiLine" placeholder="Mensaje"></asp:TextBox>
            <asp:Button data-icon="email" data-iconpos="top" runat="server" Text="Enviar" id="btnEnvio"
                onclick="Unnamed2_Click"/>
        </fieldset>
    </div>
</asp:Content>