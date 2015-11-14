<%@ Page Title="" Language="C#" MasterPageFile="~/administracion/Administracion.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="administracion_Login" %>

<asp:Content ID="head" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="content" ContentPlaceHolderID="content" Runat="Server">
    <asp:Login runat="server" ID="login"
        TitleText="Acceso a Administracion Inmobiliaria Irving" 
         RenderOuterTable="false" DisplayRememberMe="true" RememberMeSet="true" RememberMeText="Recordar Usuario" DestinationPageUrl="~/administracion/Panel.aspx"
        onauthenticate="login_Authenticate" onloggedin="login_LoggedIn" FailureText="Error al iniciar sesion, intente de nuevo porfavor"
        VisibleWhenLoggedIn="false" LoginButtonText="Logearse" UserNameLabelText="Nombre de Usuario:" PasswordLabelText="Contraseña:">
    </asp:Login>
</asp:Content>

