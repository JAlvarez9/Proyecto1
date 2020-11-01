<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="Multi2OX.aspx.cs" Inherits="Proyecto.Pages.Multi2OX" %>
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

        .auto-style26 {
            width: 237px;
        }

    </style>
    <script type="text/javascript">
        //se consigui parte del codigo de https://francescricart.com/ejercicio-js-crear-un-cronometro-con-javascript/    
	    window.onload = init;
        function init(){
            h = 0;
            m = 0;
            s = 0;
            h2 = 0;
            m2 = 0;
            s2 = 0;
            if(times )
            document.getElementById("hms").innerHTML = "00:00:00";
            document.getElementById("hms2").innerHTML = "00:00:00";
            
            
        }         
        function cronometrar(){
            escribir();
            id = setInterval(escribir,1000);
            
        }
        function cronometrar2(){
            escribir2();
            id2 = setInterval(escribir2,1000);
            
        }
        function escribir(){
            var hAux, mAux, sAux;
            s++;
            if (s>59){m++;s=0;}
            if (m>59){h++;m=0;}
            if (h>24){h=0;}

            if (s<10){sAux="0"+s;}else{sAux=s;}
            if (m<10){mAux="0"+m;}else{mAux=m;}
            if (h<10){hAux="0"+h;}else{hAux=h;}

            document.getElementById("hms").innerHTML = hAux + ":" + mAux + ":" + sAux; 
        }
        function escribir2(){
            var hAux2, mAux2, sAux2;
            s2++;
            if (s2>59){m2++;s2=0;}
            if (m2>59){h2++;m2=0;}
            if (h2>24){h2=0;}

            if (s2<10){sAux2="0"+s2;}else{sAux2=s2;}
            if (m2<10){mAux2="0"+m2;}else{mAux2=m2;}
            if (h2<10){hAux2="0"+h2;}else{hAux2=h2;}

            document.getElementById("hms2").innerHTML = hAux2 + ":" + mAux2 + ":" + sAux2; 
            
        }
        function parar(){
            clearInterval(id);
            

        }
        function parar2(){
            clearInterval(id2);
            

        }
        
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conte" runat="server">

        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
             <table style="width:100%;">
                 <tr>
                     <td class="auto-style26">
                         <asp:TextBox ID="TextBox1" runat="server" Width="180px"></asp:TextBox>
                     </td>
                     <td>
                         <asp:Button ID="Button6" runat="server" Text="Guardar Partida" Width="195px" />
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
                    
                    <asp:Button ID="Button1" runat="server" OnClick="Button4_Click" Text="Finalizar" />
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    <br />
                    
                </td>
                <td class="auto-style18">
                    
                    <div id="tabla" style="width: 500px; height:300px; overflow:scroll;" >
                        <asp:Table ID="Table1" runat="server" BorderWidth="2"></asp:Table>
                    </div>
                    
                </td>
                <td>
                    <asp:Button ID="Button5" runat="server" Text="Skip" />
                    <asp:Label ID="Label10" runat="server"></asp:Label>
                    
                    <br />
                </td>
            </tr>
        </table>
        <br />
       
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

