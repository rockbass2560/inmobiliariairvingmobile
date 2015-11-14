<%@ Page Language="C#" EnableViewState="true" AutoEventWireup="true" CodeFile="Resultado.aspx.cs" Inherits="Resultado" MasterPageFile="~/Index.master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript" src="js/resultado.js"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <uc:BtnBackNext runat="server" ID="ucBackNextTop" />
    <div runat="server" id="divMensaje" visible="false">
        <b>No se encontraron resultados con el filtro establecido, pruebe con otro porfa</b>
    </div>
    <div class="centrarDiv" id="divMobil">
        <asp:Repeater ID="repeaterMobil" runat="server">
            <HeaderTemplate>
                <table id='tableMobil'>
                    <thead>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <table style="width: 100%;" class="rowAlternativo">
                            <tr>
                                <td style="text-align: center">
                                    <span style="font-weight: bold;">ID
                                        <%# Eval("ID") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15em;">
                                    <a href="Detalle.aspx?ID=<%# Eval("ID") %>">
                                        <img style="width: 100%; height: 13em;" src="<%# Eval("Fotografia") %>" alt="" />
                                        <b>Mas Detalles</b> </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green">
                                        <h1>
                                            Se
                                            <%# Eval("TipoTransaccion") %>
                                            <%# Eval("TipoInmueble") %></h1>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold">
                                        <%# Eval("Colonia") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold;">
                                        <%# Eval("Ciudad") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green;">
                                        <%# decimal.Parse(Eval("Precio").ToString()).ToString("$ ###,###.00") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rec:
                                    <%# Eval("Recamaras") %>
                                    | Ba&ntilde;os:
                                    <%# Eval("Baños") %>
                                    | Const.
                                    <%# Eval("Construccion") %>
                                    mts², Terr.
                                    <%# Eval("Terreno") %>
                                    mts²
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2">
                                    <span style="color: Green;">Comentarios:</span><span id="comentarios"><%# Eval("Descripcion") %></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td>
                        <table style="width: 100%;">
                            <tr>
                                <td style="text-align: center">
                                    <span style="font-weight: bold;">ID
                                        <%# Eval("ID") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 15em;">
                                    <a href="Detalle.aspx?ID=<%# Eval("ID") %>">
                                        <img style="width: 100%; height: 13em;" src="<%# Eval("Fotografia") %>" alt="" />
                                        <b>Mas Detalles</b> </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green">
                                        <h1>
                                            Se
                                            <%# Eval("TipoTransaccion") %>
                                            <%# Eval("TipoInmueble") %></h1>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold">
                                        <%# Eval("Colonia") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold;">
                                        <%# Eval("Ciudad") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green;">
                                        <%# decimal.Parse(Eval("Precio").ToString()).ToString("$ ###,###.00") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rec:
                                    <%# Eval("Recamaras") %>
                                    | Ba&ntilde;os:
                                    <%# Eval("Baños") %>
                                    | Const.
                                    <%# Eval("Construccion") %>
                                    mts², Terr.
                                    <%# Eval("Terreno") %>
                                    mts²
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2">
                                    <span style="color: Green;">Comentarios:</span><span id="comentarios"><%# Eval("Descripcion") %></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </tboyd> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="centrarDiv" id="divFull">
        <asp:Repeater ID="repeaterFull" runat="server">
            <HeaderTemplate>
                <table id='tableFull'>
                    <thead>
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <table style="width: 100%;" class="row">
                            <tr>
                                <td style="width: 15em;" rowspan="5">
                                    <a href="Detalle.aspx?ID=<%# Eval("ID") %>">
                                        <img style="width: 100%; height: 13em;" src="<%# Eval("Fotografia") %>" alt="" />
                                        <b>Mas Detalles</b> </a>
                                </td>
                                <td>
                                    <span style="color: Green">
                                        <h1>
                                            Se
                                            <%# Eval("TipoTransaccion") %>
                                            <%# Eval("TipoInmueble") %></h1>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold">
                                        <%# Eval("Colonia") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold;">
                                        <%# Eval("Ciudad") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green;">
                                        <%# decimal.Parse(Eval("Precio").ToString()).ToString("$ ###,###.00") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rec:
                                    <%# Eval("Recamaras") %>
                                    | Ba&ntilde;os:
                                    <%# Eval("Baños") %>
                                    | Const.
                                    <%# Eval("Construccion") %>
                                    mts², Terr.
                                    <%# Eval("Terreno") %>
                                    mts²
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <span style="font-weight: bold;">ID
                                        <%# Eval("ID") %></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2">
                                    <span style="color: Green;">Comentarios:</span><span id="comentarios"><%# Eval("Descripcion") %></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
                    <td>
                        <table style="width: 100%;" class="rowAlternativo">
                            <tr>
                                <td style="width: 15em;" rowspan="5">
                                    <a href="Detalle.aspx?ID=<%# Eval("ID") %>">
                                        <img style="width: 100%; height: 13em;" src="<%# Eval("Fotografia") %>" alt="" />
                                        <b>Mas Detalles</b> </a>
                                </td>
                                <td>
                                    <span style="color: Green">
                                        <h1>
                                            Se
                                            <%# Eval("TipoTransaccion") %>
                                            <%# Eval("TipoInmueble") %></h1>
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold">
                                        <%# Eval("Colonia") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="font-weight: bold;">
                                        <%# Eval("Ciudad") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span style="color: Green;">
                                        <%# decimal.Parse(Eval("Precio").ToString()).ToString("$ ###,###.00") %></span>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Rec:
                                    <%# Eval("Recamaras") %>
                                    | Ba&ntilde;os:
                                    <%# Eval("Baños") %>
                                    | Const.
                                    <%# Eval("Construccion") %>
                                    mts², Terr.
                                    <%# Eval("Terreno") %>
                                    mts²
                                </td>
                            </tr>
                            <tr>
                            </tr>
                            <tr>
                                <td style="text-align: center">
                                    <span style="font-weight: bold;">ID
                                        <%# Eval("ID") %></span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td colspan="2">
                                    <span style="color: Green;">Comentarios:</span><span id="comentarios"><%# Eval("Descripcion") %></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </tboyd> </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <uc:BtnBackNext runat="server" ID="ucBackNextFooter" />
</asp:Content>
