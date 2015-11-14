<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Generador.aspx.cs" Inherits="Generador" %>

<%@ Register Src="HourMinute.ascx" TagName="HourMinute" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Pagina generador de Invitacion de Servicio de Mediacion</title>
    <link href="../css/GeneradorInvitaciones.css" type="text/css" rel="Stylesheet" />
    <link href="../css/ui-lightness/jquery-ui-1.10.3.custom.min.css" type="text/css" rel="Stylesheet" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/jquery-ui-1.10.3.custom.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("#tabs").tabs();
        });
    </script>
</head>
<body>
    <form id="frmDefault" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="true">
    </ajaxToolkit:ToolkitScriptManager>
    <div id="tabs">
        <ul>
            <li><a href="#tabs-1">Generador</a></li>
            <li><a href="#tabs-2">Configuracion</a></li>
        </ul>
        <div id="tabs-1">
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtInvitacion" Text="Fecha de Invitacion:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtInvitacion" Width="99%"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender runat="server" ID="calendarInvitacion" TargetControlID="txtInvitacion"
                            Format="D" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFechaMediacion" runat="server" AssociatedControlID="txtMediacion"
                            Text="Fecha de Mediacion:"></asp:Label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox runat="server" ID="txtMediacion" Width="99%"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="calendarMediacion" runat="server" TargetControlID="txtMediacion"
                            Format="D" />
                    </td>
                </tr>
                <tr class="hours">
                    <td>
                        <asp:Label runat="server" ID="lblHoraMediacion" Text="Hora de Mediacion:"></asp:Label>
                    </td>
                    <td>
                        <uc1:HourMinute ID="HourMinuteInitial" runat="server" />
                        a
                        <uc1:HourMinute ID="HourMinuteFinal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblFileExcel" runat="server" AssociatedControlID="fileExcel" Text="Archivo Excel: "></asp:Label>
                    </td>
                    <td>
                        <asp:FileUpload runat="server" ID="fileExcel" Width="99%" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button Style="float: right" runat="server" ID="btnCrear" Text="Crear Archivos"
                            OnClick="btnCrear_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabs-2">
                <table>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblColumnName" Text="Posicion del Nombre:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtColumnNombre"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblColumnCredito" Text="Posicion del Numero de Credito:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtColumnCredito"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblColumnCalle" Text="Calle:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtColumnCalle"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" ID="lblColumnColonia" Text="Colonia:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtColumnColonia"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="float:right">
                                <asp:Button runat="server" ID="btnGuardarConfiguracion" 
                                    Text="Guardar Configuracion" onclick="btnGuardarConfiguracion_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
        </div>
    </div>
    </form>
</body>
</html>
