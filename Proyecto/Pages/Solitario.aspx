<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Solitario.aspx.cs" Inherits="Proyecto.Pages.Solitario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conte" runat="server">

    
        <table style="width:100%;">
            <tr>
                <td class="auto-style1">
                    <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="Nueva Partida" Width="162px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button2" runat="server" Height="43px" OnClick="Button2_Click" Text="Cargar Partida" Width="163px" />
                </td>
                <td class="auto-style1">
                    <asp:Button ID="Button3" runat="server" Height="43px" Text="Guardar Partida" Width="162px" />
                </td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style10">Jugador</td>
                <td>Puntaje</td>
                <td class="auto-style4">Movimientos</td>
                <td class="auto-style8">Jugador</td>
                <td class="auto-style6">Puntaje</td>
                <td>Movimientos</td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
       

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

    
    
    <style type="text/css">
        .auto-style1 {
            height: 52px;
        }
        .auto-style3 {
            height: 28px;
        }
        .auto-style4 {
            width: 105px;
        }
        .auto-style5 {
            height: 28px;
            width: 105px;
        }
        .auto-style6 {
            width: 80px;
        }
        .auto-style7 {
            height: 28px;
            width: 80px;
        }
        .auto-style8 {
            width: 125px;
        }
        .auto-style9 {
            height: 28px;
            width: 125px;
        }
        .auto-style10 {
            width: 136px;
        }
        .auto-style11 {
            height: 28px;
            width: 136px;
        }
    </style>

    
    
    </asp:Content>


