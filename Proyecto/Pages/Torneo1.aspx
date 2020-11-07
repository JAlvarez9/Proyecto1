<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Torneo1.aspx.cs" Inherits="Proyecto.Pages.Torneo1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width:100%;">
    <tr>
        <td colspan="2">Crear Nuevo Torneo</td>
    </tr>
    <tr>
        <td>Nombre Del Toreno</td>
        <td>Tamanio del Torneo:</td>
    </tr>
    <tr>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Width="155px"></asp:TextBox>
        </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>8</asp:ListItem>
                <asp:ListItem>16</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Cargar Torneo:</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
        </td>
        <td>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cargar Torneo" Width="199px" />
        </td>
    </tr>
</table>
</asp:Content>
