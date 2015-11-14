<%@ Page Language="C#" MasterPageFile="~/Index.master" AutoEventWireup="true" CodeFile="Detalle.aspx.cs"
    Inherits="Detalle" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="head" runat="Server">
    
</asp:Content>
<asp:Content ID="contenido" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="background-color: White; width: 100%; max-width: 491px; margin: 0 auto 0 auto;">
        <tr>
            <td>
                <div>
                    <div style="float: left;">
                        <h3>
                            <b>Detalle</b></h3>
                    </div>
                    <div style="float: right; background-color: white">
                        <span>
                            <h3>
                                <b>ID<asp:Literal runat="server" ID="ltrID" /></b></h3>
                        </span>
                    </div>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <span style="color: Green; font-size: xx-large">Se
                    <asp:Literal runat="server" ID="ltrTipoTransaccion" />
                    <asp:Literal runat="server" ID="ltrTipoInmueble" /></span>
            </td>
        </tr>
        <tr>
            <td>
                <span style="font-weight: bold; font-size: large">
                    <asp:Literal runat="server" ID="ltrPrecio"></asp:Literal></span>
            </td>
        </tr>
        <tr>
            <td>
                <span style="font-weight: bold;">Vendedor:</span> <span style="color: Green; font-weight: bold;">
                    <asp:Literal runat="server" ID="ltrVendedor"></asp:Literal></span>
            </td>
        </tr>
        <tr>
            <td>
                <span style="color: Green">Tel: <a href="" runat="server" id="linkTel">
                    <asp:Literal runat="server" ID="ltrTelefono" /></a></span>
            </td>
        </tr>
        <tr>
            <td>
                <img runat="server" id="fotografia" src="" style="height: 15em;" alt="" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal runat="server" ID="ltrColonia" />
                |
                <asp:Literal runat="server" ID="ltrCiudad"></asp:Literal>
                | Sinaloa | C.P.
                <asp:Literal runat="server" ID="ltrCodigoPostal"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <span class="encabezadoH2Verde">Ubicaci&oacute;n</span>
            </td>
        </tr>
        <tr>
            <td>
                <span class="negrita">Domicilio:</span><asp:Literal runat="server" ID="ltrCalle" />&nbsp;<asp:Literal
                    runat="server" ID="ltrNumero" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="negrita">Colonia:</span>
                <asp:Literal runat="server" ID="ltrColonia2" />
            </td>
        </tr>
        <tr>
            <td>
                <span class="negrita">C.P.:</span>
                <asp:Literal runat="server" ID="ltrCodigoPostal2" />
            </td>
        </tr>
        <tr>
            <tr>
                <td>
                    <span class="negrita">Ciudad:</span>
                    <asp:Literal runat="server" ID="ltrCiudad2" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="negrita">Estado:</span> Sinaloa
                </td>
            </tr>
            <tr style="display: none;">
                <td>
                    <br />
                    <br />
                    <br />
                    Observaciones del vendedor<br />
                    <%-- Seccion de observaciones del vendedor, por ahora no se imprime en la pagina web --%>
                </td>
            </tr>
            <tr>
                <td>
                    <span class="encabezadoH2Verde">Especificaciones</span>
                </td>
            </tr>
            <!--<tr>
                <td>
                    <span class="negrita">Precio:</span>
                    <asp:Literal runat="server" ID="ltrPrecio2"></asp:Literal>
                </td>
            </tr>-->
            <tr>
                <td>
                    <span class="negrita">Superficie:</span>
                    <asp:Literal runat="server" ID="ltrTerreno" />
                    m²
                </td>
            </tr>
            <tr>
                <td>
                    <span class="negrita">Metros Construidos:</span>
                    <asp:Literal runat="server" ID="ltrConstruccion" />
                    m²
                </td>
            </tr>
            <tr>
                <td>
                    <span class="negrita">No. Niveles:</span>
                    <asp:Literal runat="server" ID="ltrNiveles" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="negrita">No. Baños:</span>
                    <asp:Literal runat="server" ID="ltrBaños" />
                </td>
            </tr>
            <tr>
                <td>
                    <span class="negrita">Tipo Casa:</span>
                    <asp:Literal runat="server" ID="ltrTipoInmueble2" />
                </td>
            </tr>
    </table>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="footer">
    <div data-role="navbar">
        <ul data-theme="a">
            <li><a runat="server" id="telefono" href="" data-iconpos="top" data-icon="phone">Telefono</a>
            </li>
            <li><a runat="server" id="email" href="" data-iconpos="top" data-icon="email">Email</a>
            </li>
            <li><a href="#popupCompartir" data-rel="dialog" data-iconpos="top" data-icon="facebook">
                Compartir</a> </li>
        </ul>
    </div>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPopup">
    <div id="popupCompartir" data-role="dialog" data-theme="d">
        <div data-role="header">
        </div>
        <div data-role="content">
            <fieldset class="ui-grid-a">
                <div class="ui-block-a">
                    <a data-iconpos="top" id="linkFacebook" runat="server" href="http://www.facebook.com/sharer.php?u="
                        data-role="button" data-icon="facebook">Facebook</a>
                </div>
                <div class="ui-block-b">
                    <a data-iconpos="top" id="linkTwitter" runat="server" href="http://www.twitter.com/home?status="
                        data-role="button" data-icon="twitter">Twitter</a>
                </div>
                <div class="ui-block-c">
                    <a data-iconpos="top" id="linkCorreo" runat="server" href="mailto:?body=" data-role="button"
                        data-icon="email">Email</a>
                </div>
            </fieldset>
        </div>
        <div data-role="footer">
            <a href="#contentDiv" data-iconpos="left" data-icon="back" data-rel="back" data-role="button"
                data-direction="reverse">Regresar</a>
        </div>
    </div>
</asp:Content>
