<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="MenuSolitarioOX.aspx.cs" Inherits="Proyecto.Pages.MenuSolitario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 316px;
        }
        .auto-style4 {
            width: 316px;
            height: 12px;
        }
        .auto-style5 {
            height: 12px;
        }
        .auto-style6 {
            width: 316px;
            height: 11px;
        }
        .auto-style7 {
            height: 11px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td colspan="2">Modo de Juego</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;&nbsp;
                <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Modo" />
                Normal</td>
            <td>
                <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Modo" />
                Inverso</td>
        </tr>
        <tr>
            <td colspan="2">Apertura Personalizada</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Apertura" />
                Si</td>
            <td>
                <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Apertura" />
                No</td>
        </tr>
        <tr>
            <td>Colores por jugador:</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Jugador Casa</td>
            <td>Jugador Visitante</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    <asp:ListItem>rojo</asp:ListItem>
                    <asp:ListItem>amarillo</asp:ListItem>
                    <asp:ListItem>azul</asp:ListItem>
                    <asp:ListItem>anaranjado</asp:ListItem>
                    <asp:ListItem>verde</asp:ListItem>
                    <asp:ListItem>violeta</asp:ListItem>
                    <asp:ListItem>blanco</asp:ListItem>
                    <asp:ListItem>negro</asp:ListItem>
                    <asp:ListItem>celeste</asp:ListItem>
                    <asp:ListItem>gris</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                    <asp:ListItem>rojo</asp:ListItem>
                    <asp:ListItem>amarillo</asp:ListItem>
                    <asp:ListItem>azul</asp:ListItem>
                    <asp:ListItem>anaranjado</asp:ListItem>
                    <asp:ListItem>verde</asp:ListItem>
                    <asp:ListItem>violeta</asp:ListItem>
                    <asp:ListItem>blanco</asp:ListItem>
                    <asp:ListItem>negro</asp:ListItem>
                    <asp:ListItem>celeste</asp:ListItem>
                    <asp:ListItem>gris</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Numero de Filas:</td>
            <td>Numero de Columnas:</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                Turno Inicial:</td>
            <td class="auto-style5">
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                <asp:RadioButton ID="RadioButton5" runat="server" GroupName="inicio" />
&nbsp;Casa</td>
            <td class="auto-style7">
                <asp:RadioButton ID="RadioButton6" runat="server" GroupName="inicio" />
&nbsp;Visitante</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Iniciar Juego" Width="217px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">Cargar Una Partida</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Cargar Partida" Width="237px" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    
</asp:Content>

