<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="Multi1OX.aspx.cs" Inherits="Proyecto.Pages.Multi1OX" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width:100%;">
        <tr>
            <td>Modo Normal: </td>
            <td>&nbsp;</td>
            <td>Modo Inverso:</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Modo Normal" OnClick="Button1_Click" />
            </td>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Modo Inverso" OnClick="Button2_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="3">Nombre del Invitado:</td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:TextBox ID="TextBox1" runat="server" Width="266px"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
