<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="pruebas.aspx.cs" Inherits="Proyecto.Pages.pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        .auto-style15 {
            width: 323px;
        }
        .auto-style16 {
            width: 100%;
            height: 378px;
        }
        .auto-style17 {
            width: 68px;
        }
        .auto-style18 {
            width: 529px;
        }
        .hide {
            visibility: hidden;

        }

        .auto-style23 {
            height: 74px;
        }

    </style>
   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        
         <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
             
            <table class="auto-style23">
            <tr>
                <td >
                    <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="Nueva Partida" Width="205px" />
                </td>
                <td >
                    &nbsp;</td>
                <td class="auto-style15" >
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    &nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />
        <table style="width:100%;">
            <tr>
                <td class="auto-style10">Jugador</td>
                <td>Puntaje</td>
                <td class="auto-style4">Color</td>
                <td class="auto-style8">Jugador</td>
                <td class="auto-style6">Puntaje</td>
                <td>Color</td>
            </tr>
            <tr>
                <td class="auto-style11">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
                <td class="auto-style5">
                    <asp:Label ID="Label3" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </td>
                <td class="auto-style7">
                    <asp:Label ID="Label5" runat="server"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label6" runat="server"></asp:Label>
                </td>
            </tr>
        </table >
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <table class="auto-style16">
            <tr>
                <td class="auto-style17">
                    
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Finalizar" />
                    
                    
                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Button" />
                    <asp:Button ID="Button7" runat="server" OnClick="Button7_Click1" Text="Button" />
                    
                    
                </td>
                <td class="auto-style18">
                    
                    <div id="tabla" style="width: 500px; height:300px; overflow:scroll;" >
                        <asp:Table ID="Table1" runat="server" BorderWidth="2"></asp:Table>
                    </div>
                    
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Skip" />
                    
                    <br />
                </td>
            </tr>
        </table>
        <br />
       
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="Cronometros" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Timer ID="Cronometro1" runat="server" Interval="900" OnTick="Timer1_Tick">
             </asp:Timer>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>
                            <asp:Label ID="Label9" runat="server"></asp:Label>
                             </td>
                <td>
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                    
                    </td>
            </tr>
            </table>
    </div>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Cronometro1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>

    
</asp:Content>
