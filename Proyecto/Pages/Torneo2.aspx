<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Torneo2.aspx.cs" Inherits="Proyecto.Pages.Torneo2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 43px;
        }
        .auto-style3 {
            height: 42px;
        }
        .auto-style4 {
            height: 36px;
        }
        .auto-style5 {
            height: 130px;
            overflow: scroll;
            width: 630px;
        }
    .auto-style6 {
        height: 26px;
    }
    .auto-style7 {
        height: 27px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">
    <table style="width:100%;">
        <tr>
            <td colspan="4">
                <div class="auto-style5">
                    <asp:Image ID="Image1" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">Octavos de Final</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Partida1" OnClick="Button_Octavos" />
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Partida2" OnClick="Button_Octavos"/>
            </td>
            <td>
                <asp:Button ID="Button3" runat="server" Text="Partida3" OnClick="Button_Octavos"/>
            </td>
            <td>
                <asp:Button ID="Button4" runat="server" Text="Partida4" OnClick="Button_Octavos"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label5" runat="server" ></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label7" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button5" runat="server" Text="Partida5" OnClick="Button_Octavos"/>
            </td>
            <td>
                <asp:Button ID="Button6" runat="server" Text="Partida6" OnClick="Button_Octavos"/>
            </td>
            <td>
                <asp:Button ID="Button7" runat="server" Text="Partida7" OnClick="Button_Octavos"/>
            </td>
            <td>
                <asp:Button ID="Button8" runat="server" Text="Partida8" OnClick="Button_Octavos"/>
            </td>
        </tr>
        <tr>
            <td colspan="4">Cuartos de Final</td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:Label ID="Label9" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="Label10" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="Label11" runat="server"></asp:Label>
            </td>
            <td class="auto-style4">
                <asp:Label ID="Label12" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button9" runat="server" Text="Partida1"  OnClick="Button_Cuartos"/>
            </td>
            <td>
                <asp:Button ID="Button10" runat="server" Text="Partida2" OnClick="Button_Cuartos"/>
            </td>
            <td>
                <asp:Button ID="Button11" runat="server" Text="Partida3" OnClick="Button_Cuartos"/>
            </td>
            <td>
                <asp:Button ID="Button12" runat="server" Text="Partida4" OnClick="Button_Cuartos"/>
            </td>
        </tr>
        <tr>
            <td colspan="4">Semifinales:</td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style6">
                <asp:Label ID="Label13" runat="server"></asp:Label>
            </td>
            <td colspan="2" class="auto-style6">
                <asp:Label ID="Label14" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="Button13" runat="server" OnClick="Button_Semis" Text="Partida1" />
            </td>
            <td colspan="2">
                <asp:Button ID="Button14" runat="server" Text="Partida2" OnClick="Button_Semis"/>
            </td>
        </tr>
        <tr>
            <td colspan="4">FINAL</td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style7">
                <asp:Label ID="Label15" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button15" runat="server" Text="GRAN FINAL" OnClick="Button_Final"/>
            </td>
        </tr>
    </table>
</asp:Content>
