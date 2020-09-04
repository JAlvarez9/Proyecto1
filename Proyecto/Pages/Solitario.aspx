<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="Solitario.aspx.cs" Inherits="Proyecto.Pages.Solitario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="conte" runat="server">

    
        <table>
            <tr>
                <td >
                    <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="Nueva Partida" Width="205px" />
                </td>
                <td >
                    <asp:Button ID="Button2" runat="server" Height="43px" OnClick="Button2_Click" Text="Cargar Partida" Width="234px" />
                </td>
                <td class="auto-style15" >
                    <asp:Button ID="Button3" runat="server" Height="43px" Text="Guardar Partida" Width="207px" />
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
        </table class="hide">
        <br />
        <table class="auto-style16">
            <tr>
                <td class="auto-style17">
                    
                </td>
                <td class="auto-style18">
                    <table class="auto-style19" border="1">
                        <tr style="background-color:#FF0000">
                            <td>&nbsp;</td>
                            <td class="auto-style20" >A</td>
                            <td class="auto-style20" >B</td>
                            <td>C</td>
                            <td>D</td>
                            <td>E</td>
                            <td>F</td>
                            <td>G</td>
                            <td>H</td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800" class="auto-style21">1</td>
                            <td class="auto-style22">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style22">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">2</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton15" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton16" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">3</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton17" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                               <asp:ImageButton ID="ImageButton18" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton20" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton21" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton22" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton23" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton24" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">4</td>
                            <td class="auto-style20">
                               <asp:ImageButton ID="ImageButton25" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton26" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton27" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton28" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton29" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton30" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton31" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton32" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">5</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton33" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton34" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton35" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton36" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton37" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton38" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton39" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton40" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">6</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton41" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton42" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton43" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton44" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton45" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton46" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton47" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton48" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">7</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton49" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton50" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton51" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton52" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="ImageButton53" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton54" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton55" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton56" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">8</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton57" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="ImageButton58" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton59" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton60" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton61" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton62" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton63" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton64" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
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
        .auto-style19 {
            width: 100%;
            height: 380px;
        }
        .auto-style20 {
            width: 56px;
        }
        .auto-style21 {
            height: 41px;
        }
        .auto-style22 {
            width: 56px;
            height: 41px;
        }
        .hide {
            visibility: hidden;

        }

    </style>
    </style>

    
    
    </asp:Content>


