<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="JuegoTorneo.aspx.cs" Inherits="Proyecto.Pages.JuegoTorneo" %>
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

        .auto-style23 {
            height: 74px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table class="auto-style23">
            <tr>
                <td >
                    <asp:Button ID="Button1" runat="server" Height="43px" OnClick="Button1_Click" Text="Nueva Partida" Width="205px" />
                </td>
                <td >
                    <asp:FileUpload ID="FileUpload1" runat="server" accept=".xml" Width="145px"/>
                    <asp:Button ID="Button2" runat="server" Height="22px" OnClick="Button2_Click" Text="Cargar Partida" Width="234px" />
                </td>
                <td class="auto-style15" >
                    <asp:TextBox ID="TextBox1" runat="server" Width="195px"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" Height="26px" OnClick="Button3_Click" Text="Guardar Partida" Width="207px" />
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
        </table class="hide">
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <table class="auto-style16">
            <tr>
                <td class="auto-style17">
                    
                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Finalizar" />
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
                                <asp:ImageButton ID="i01" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style22">
                                <asp:ImageButton ID="i02" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i03" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i04" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i05" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i06" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i07" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style21">
                                <asp:ImageButton ID="i08" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">2</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i09" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i10" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i11" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i12" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i13" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i14" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i15" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i16" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">3</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i17" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                               <asp:ImageButton ID="i18" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i19" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i20" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i21" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i22" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i23" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i24" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">4</td>
                            <td class="auto-style20">
                               <asp:ImageButton ID="i25" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i26" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i27" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i28" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i29" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i30" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i31" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i32" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">5</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i33" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i34" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i35" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i36" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i37" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i38" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i39" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i40" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">6</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i41" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i42" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i43" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i44" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i45" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i46" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i47" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i48" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">7</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i49" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i50" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i51" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i52" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                               <asp:ImageButton ID="i53" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i54" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i55" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i56" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                        <tr style="background-color:#006602">
                            <td style="background-color:#8E5800">8</td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i57" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td class="auto-style20">
                                <asp:ImageButton ID="i58" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i59" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i60" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i61" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i62" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i63" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                            <td>
                                <asp:ImageButton ID="i64" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Skip" OnClick="Button5_Click" />
                    <br />
                </td>
            </tr>
        </table>
        <br />
       


        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:Timer ID="Cronometro1" runat="server" OnTick="Timer1_Tick" Interval="1000"></asp:Timer>
            <asp:Timer ID="Cronometro2" runat="server" Interval="1000" OnTick="Cronometro2_Tick" ></asp:Timer>
            <asp:Label ID="Label7" runat="server"></asp:Label>

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server"></asp:Label>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="Cronometro1" EventName="Tick" />
            <asp:AsyncPostBackTrigger ControlID="Cronometro2" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
