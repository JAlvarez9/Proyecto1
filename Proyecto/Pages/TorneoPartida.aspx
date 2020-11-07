<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="TorneoPartida.aspx.cs" Inherits="Proyecto.Pages.TorneoPartida" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
        width: 205px;
    }
    .auto-style3 {
        width: 197px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width:100%;">
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            <asp:Button ID="Button2" runat="server" Text="Jugar Partida" />
            <br />
            <asp:Button ID="Button3" runat="server" Text="Simular" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList2" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:Label ID="Label4" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:DropDownList ID="DropDownList3" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            <asp:Button ID="Button4" runat="server" Text="Jugar Partida" />
            <br />
            <asp:Button ID="Button5" runat="server" Text="Simular" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList4" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="Label5" runat="server"></asp:Label>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:DropDownList ID="DropDownList5" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            <asp:Button ID="Button6" runat="server" Text="Jugar Partida" />
            <br />
            <asp:Button ID="Button7" runat="server" Text="Simular" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList6" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="Button8" runat="server" Text="Comprobar" Width="143px" />
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Desempate:</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:DropDownList ID="DropDownList7" runat="server">
            </asp:DropDownList>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:DropDownList ID="DropDownList8" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:DropDownList ID="DropDownList9" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            <asp:Button ID="Button9" runat="server" Text="Jugar Partida" />
            <br />
            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="Simular" />
        </td>
        <td>
            <asp:DropDownList ID="DropDownList10" runat="server">
                <asp:ListItem>Ganar</asp:ListItem>
                <asp:ListItem>Perder</asp:ListItem>
                <asp:ListItem>Empatar</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
