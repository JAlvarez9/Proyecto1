<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="MenuSolitarioOX.aspx.cs" Inherits="Proyecto.Pages.MenuSolitario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width: 100%;">
    <tr>
        <td>Modo Normal</td>
        <td>&nbsp;</td>
        <td>Modo Inverso</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Normal" />
        </td>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Inverso" />
        </td>
    </tr>
</table>
</asp:Content>
