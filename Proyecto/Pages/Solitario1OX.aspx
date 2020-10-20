<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="Solitario1OX.aspx.cs" Inherits="Proyecto.Pages.Solitario1OX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 297px;
        }
        .auto-style3 {
            width: 64px;
        }
        .auto-style4 {
            height: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
&nbsp;<table style="width:100%;">
        <tr>
            <td class="auto-style2">Colores Jugador 1</td>
            <td class="auto-style3">&nbsp;</td>
            <td>Colores Maquina&nbsp; 2</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem>Blanco</asp:ListItem>
                    <asp:ListItem>Negro</asp:ListItem>
                    <asp:ListItem>Rojo</asp:ListItem>
                    <asp:ListItem>Amarillo</asp:ListItem>
                    <asp:ListItem>Anaranjado</asp:ListItem>
                    <asp:ListItem>Verde</asp:ListItem>
                    <asp:ListItem>Violeta</asp:ListItem>
                    <asp:ListItem>Celeste</asp:ListItem>
                    <asp:ListItem>Gris</asp:ListItem>
                    <asp:ListItem>Azul</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                    <asp:ListItem>Blanco</asp:ListItem>
                    <asp:ListItem>Negro</asp:ListItem>
                    <asp:ListItem>Rojo</asp:ListItem>
                    <asp:ListItem>Amarillo</asp:ListItem>
                    <asp:ListItem>Anaranjado</asp:ListItem>
                    <asp:ListItem>Verde</asp:ListItem>
                    <asp:ListItem>Violeta</asp:ListItem>
                    <asp:ListItem>Celeste</asp:ListItem>
                    <asp:ListItem>Gris</asp:ListItem>
                    <asp:ListItem>Azul</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Tamanio Tablero</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Numero columnas:<input id="Text1" class="auto-style4" type="text" /></td>
            <td class="auto-style3">&nbsp;</td>
            <td>Numero de Filas:
                <input id="Text2" class="auto-style4" type="text" /></td>
        </tr>
        <tr>
            <td class="auto-style2">Cargar Archivo</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="281px" />
            </td>
            <td colspan="2">
                <asp:Button ID="Button1" runat="server" Text="Cargar Partida" Width="271px" />
            </td>
        </tr>
    </table>
&nbsp;
</asp:Content>
