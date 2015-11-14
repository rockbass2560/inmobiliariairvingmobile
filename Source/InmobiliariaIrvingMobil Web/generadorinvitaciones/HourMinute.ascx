<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HourMinute.ascx.cs" Inherits="HourMinute" %>

<asp:TextBox runat="server" ID="txtHoraInicio"></asp:TextBox>
<span style="font-weight:bold;font-size:larger">:</span>
<asp:TextBox runat="server" ID="txtMinutoInicio"></asp:TextBox>
<asp:DropDownList runat="server" CssClass="" ID="ddlAMPM">
    <asp:ListItem Selected="True" Value="1">AM</asp:ListItem>
    <asp:ListItem Value="2">PM</asp:ListItem>
</asp:DropDownList>
