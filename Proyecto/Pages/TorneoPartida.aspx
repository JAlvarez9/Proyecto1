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
            <asp:RadioButton ID="RadioButton1" runat="server" GroupName="Partida1" />
            Ganar</td>
        <td class="auto-style3">
            <asp:Button ID="Button2" runat="server" Text="Jugar Partida" OnClick="Button2_Play" />
            <asp:Button ID="Button3" runat="server" Text="Simular" OnClick="Button3_Simular" />
            <br />
            <br />
            <asp:RadioButton ID="RadioButton2" runat="server" GroupName="Partida1"/>
            Empate</td>
        <td>
            <asp:RadioButton ID="RadioButton3" runat="server" GroupName="Partida1"/>
            Ganar</td>
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
            <asp:RadioButton ID="RadioButton4" runat="server" GroupName="Partida2"/>
            Ganar</td>
        <td class="auto-style3">
            <asp:Button ID="Button4" runat="server" Text="Jugar Partida" />
            <asp:Button ID="Button5" runat="server" Text="Simular" OnClick="Button3_Simular"/>
            <br />
            <asp:RadioButton ID="RadioButton5" runat="server" GroupName="Partida2"/>
            Empate<br />
        </td>
        <td>
            <asp:RadioButton ID="RadioButton6" runat="server" GroupName="Partida2"/>
            Ganar</td>
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
            <asp:RadioButton ID="RadioButton7" runat="server" GroupName="Partida3"/>
            Ganar</td>
        <td class="auto-style3">
            <asp:Button ID="Button6" runat="server" Text="Jugar Partida" />
            <asp:Button ID="Button7" runat="server" Text="Simular" OnClick="Button3_Simular"/>
            <br />
            <asp:RadioButton ID="RadioButton8" runat="server" GroupName="Partida3"/>
            Empate<br />
        </td>
        <td>
            <asp:RadioButton ID="RadioButton9" runat="server" GroupName="Partida3"/>
            Ganar</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="Button8" runat="server" Text="Comprobar" Width="143px" OnClick="Button_Comprobar" />
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
            <asp:RadioButton ID="RadioButton10" runat="server" GroupName="Partida4"/>
            Ganar</td>
        <td class="auto-style3">
            <asp:Button ID="Button9" runat="server" Text="Jugar Partida" OnClick="Button2_Play"/>
            <asp:Button ID="Button10" runat="server" OnClick="Button3_Simular" Text="Simular" />
            <br />
            <asp:RadioButton ID="RadioButton11" runat="server" GroupName="Partida4"/>
            Empate<br />
        </td>
        <td>
            <asp:RadioButton ID="RadioButton12" runat="server" GroupName="Partida4"/>
            Ganar</td>
    </tr>
    <tr>
        <td class="auto-style2">Punteo Equipo: <asp:Label ID="Label7" runat="server"></asp:Label>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>Punteo Equipo:
            <asp:Label ID="Label8" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>
