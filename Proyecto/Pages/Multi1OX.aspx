﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="Multi1OX.aspx.cs" Inherits="Proyecto.Pages.Multi1OX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 316px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    
    <table style="width:100%;">
        <tr>
            <td colspan="2">Modo de Juego</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;&nbsp;<asp:RadioButton ID="RadioButton1" runat="server" GroupName="Modo" OnCheckedChanged="RadioButton1_CheckedChanged" />
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
                    <asp:ListItem>Rojo</asp:ListItem>
                    <asp:ListItem>Amarillo</asp:ListItem>
                    <asp:ListItem>Azul</asp:ListItem>
                    <asp:ListItem>Anaranjado</asp:ListItem>
                    <asp:ListItem>Verde</asp:ListItem>
                    <asp:ListItem>Violeta</asp:ListItem>
                    <asp:ListItem>Blanco</asp:ListItem>
                    <asp:ListItem>Negro</asp:ListItem>
                    <asp:ListItem>Celeste</asp:ListItem>
                    <asp:ListItem>Gris</asp:ListItem>
                </asp:CheckBoxList>
            </td>
            <td>
                <asp:CheckBoxList ID="CheckBoxList2" runat="server">
                    <asp:ListItem>Rojo</asp:ListItem>
                    <asp:ListItem>Amarillo</asp:ListItem>
                    <asp:ListItem>Azul</asp:ListItem>
                    <asp:ListItem>Anaranjado</asp:ListItem>
                    <asp:ListItem>Verde</asp:ListItem>
                    <asp:ListItem>Violeta</asp:ListItem>
                    <asp:ListItem>Blanco</asp:ListItem>
                    <asp:ListItem>Negro</asp:ListItem>
                    <asp:ListItem>Celeste</asp:ListItem>
                    <asp:ListItem>Gris</asp:ListItem>
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
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                </asp:DropDownList>
            </td>
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
                <asp:Button ID="Button2" runat="server" Text="Cargar Partida" Width="237px" />
            </td>
        </tr>
    </table>
    
</asp:Content>
