<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Catalogo.aspx.cs" Inherits="Catalogo"
    MasterPageFile="~/administracion/Administracion.master" ClientIDMode="Static" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <link href="css/Catalogo.css" rel="Stylesheet" />
    <script type="text/javascript" src="js/Catalogo.js"></script>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="content" ID="contentPage">
    <asp:ToolkitScriptManager runat="server" ID="scriptManager" ScriptMode="Release">
    </asp:ToolkitScriptManager>
    <div id="divCarga" style="display:none">
        <center>
            <div style="z-index:1000;position:fixed;width:100%;margin-top:5em;background-color:White;">
                <p><h1><b>Cargando la imagen, espere porfavor</h1></b></p>
                <img src="../css/images/ajax-loader.gif" alt="Cargando" />
            </div>
        </center>
    </div>
    <div id="divCatalogo">
        <div>
            <fieldset data-role="fieldcontain">
                <label for="textID">ID:</label>
                <asp:TextBox runat="server" ID="textID" Enabled="false"></asp:TextBox>
            </fieldset>
        </div>

        <div id="fieldDireccion">
            <fieldset data-role="fieldcontain">
                <span class="titulo">Direccion:</span><br /><br />

                <label for="textCalle">Calle:</label>
                <asp:TextBox runat="server" ID="textCalle"></asp:TextBox>

                <label for="textNumero">Numero:</label>
                <asp:TextBox runat="server" ID="textNumero"></asp:TextBox>

                <label for="textCodigoPostal">Codigo Postal:</label>
                <asp:TextBox runat="server" ID="textCodigoPostal"></asp:TextBox>

                <label for="selectColonia">Colonia:</label>
                <asp:DropDownList runat="server" ID="selectColonia"></asp:DropDownList>

                <label for="selectCiudad">Ciudad:</label>
                <asp:DropDownList runat="server" ID="selectCiudad"></asp:DropDownList>
            </fieldset>
        </div>
        <div id="fieldDatos">
            <fieldset data-role="fieldcontain">
                <span class="titulo">Datos de la Casa</span><br /><br />
                
                <label for="textPrecio">Precio:</label>
                <asp:TextBox runat="server" ID="textPrecio" type="number"></asp:TextBox>

                <label for="selectTipoInmueble">Tipo de Inmueble:</label>
                <asp:DropDownList runat="server" ID="selectTipoInmueble"> </asp:DropDownList>

                <label for="selectTipoVenta">Tipo de Venta</label>
                <asp:DropDownList runat="server" ID="selectTipoVenta"></asp:DropDownList>

                <!-- Seccion de combos -->
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <label for="textNiveles">
                            Niveles:</label>
                        <asp:TextBox runat="server" ID="textNiveles" type="number" Text="0"></asp:TextBox>
                    </div>
                    <div class="ui-block-b">
                        <label for="textRecamaras">
                            Recamaras:</label>
                        <asp:TextBox runat="server" ID="textRecamaras" type="number" Text="0"></asp:TextBox>
                    </div>
                </div>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <label for="textCochera">
                            Cochera:</label>
                        <asp:TextBox runat="server" ID="textCochera" type="number" Text="0"></asp:TextBox>
                    </div>
                    <div class="ui-block-b">
                        <label for="textBanos">
                            Baños:</label>
                        <asp:TextBox runat="server" ID="textBanos" type="number" Text="0" step="0.5"></asp:TextBox>
                    </div>
                </div>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <label for="textEdad">
                            Edad:</label>
                        <asp:TextBox runat="server" ID="textEdad" type="number" Text="0"></asp:TextBox>
                    </div>
                </div>
            </fieldset>
        </div>
        <div id="fieldMedidas">
            <fieldset data-role="fieldcontain">
                <span class="titulo">Medidas</span><br /><br />

                <label for="textTerreno">Terreno</label>
                <asp:TextBox runat="server" ID="textTerreno" type="number" Text="0" step="0.01"></asp:TextBox>
                    
                <label for="textConstruccion">Construccion</label>
                <asp:TextBox runat="server" ID="textConstruccion" type="number" Text="0" step="0.01"></asp:TextBox>

                <label for="textFrente">Frente</label>
                <asp:TextBox runat="server" ID="textFrente" type="number" Text="0" step="0.01"></asp:TextBox>

                <label for="textFondo">Fondo</label>
                <asp:TextBox runat="server" ID="textFondo" type="number" Text="0" step="0.01"></asp:TextBox>

                <label for="selectForma">Forma</label>
                <asp:DropDownList runat="server" ID="selectForma"></asp:DropDownList>
            </fieldset>
        </div>
        <div id="fieldPlus">
            <fieldset data-role="fieldcontain">
                <span class="titulo">Plus</span><br /><br />

                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <asp:CheckBox runat="server" ID="checkEsquina" Text="Esquina" />
                    </div>
                    <div class="ui-block-b">
                        <asp:CheckBox runat="server" ID="checkJardin" Text="Jardin" />
                    </div>
                </div>
                <div class="ui-grid-a">
                    <div class="ui-block-a">
                        <asp:CheckBox runat="server" ID="checkAlberca" Text="Alberca" />
                    </div>
                    <div class="ui-block-b">
                        <asp:CheckBox runat="server" ID="checkEstudio" Text="Estudio" />
                    </div>
                </div>
    
                <div>
                        <label for="fotografiaCasa">Fotografia:</label>
                        <asp:UpdatePanel runat="server" UpdateMode="Always">
                            <ContentTemplate>
                                <div>
                                    <asp:Image runat="server" ID="fotografiaCasa" style="background-color: White; min-height: 12em; width: 100%; max-width:450px" />
                                </div>
                                <asp:AsyncFileUpload ID="uploadFotografia" PersistFile="true" runat="server" style="width:100%;" onuploadedcomplete="uploadFotografia_UploadedComplete" OnClientUploadStarted="mostrarCarga" OnClientUploadComplete="esconderCarga" OnClientUploadError="esconderCarga" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <label for="textDescripcion">
                            Descripcion:</label>
                        <asp:TextBox runat="server" Width="100%" ID="textDescripcion" style="min-height:12em;" TextMode="MultiLine"></asp:TextBox>
                    </div>
            </fieldset>
        </div>
        <div class="ui-grid-a">
            <div class="ui-block-a">
                <input type="button" id="botonAtras" value="Atras" />
            </div>
            <div class="ui-block-b">
                <input type="button" id="botonSiguiente" value="Siguiente" />
                <div id='divBotones' style="display:none">
                    <asp:Button runat="server" ID="botonAlta" Text="Dar de Alta" OnClick="ActionAgregar_Click" />
                    <asp:Button runat="server" ID="botonModificar" Text="Modificar" onclick="botonModificar_Click" />
                </div>                
            </div>
        </div>
    </div>

    <asp:HiddenField runat="server" ID="hdnEnVenta" />
    <asp:HiddenField runat="server" ID="hiddenAction" />
    <asp:HiddenField runat="server" ID="hiddenField" Value="fieldDireccion" />
    <asp:HiddenField runat="server" ID="hiddenPropietario" />
    <asp:HiddenField runat="server" ID="hiddenTelefono" />
</asp:Content>