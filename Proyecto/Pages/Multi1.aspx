<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Multi1.aspx.cs" Inherits="Proyecto.Pages.Multi1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width:100%;">
    <tr>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Jugador vs Invitado" Width="292px" />
        </td>
        <td>
            <asp:Button ID="Button2" runat="server" Text="Jugador vs Jugador" Width="289px" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="Ingrese el nombre del invitado:"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" Width="282px"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
