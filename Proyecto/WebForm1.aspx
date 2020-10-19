<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Site1.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Proyecto.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
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
    
    
&nbsp;<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="cronometro" >
                    <div id="hms" ></div>
                    <div id="hms2" ></div>
                    <%--<div class="boton start">start</div>        
                    <div class="boton stop">pause</div>--%>
                    
                    <asp:Button ID="start" class="boton start" runat="server" OnClick="start_Click" Text="start" />
                    <%--<asp:Button ID="start2" class="boton start2" runat="server" OnClick="start_Click" Text="start2" />--%>
                    <asp:Button ID="stop" class="boton stop" runat="server" OnClick="stop_Click" Text="stop" />
                    <%--<asp:Button ID="stop2" class="boton stop2" runat="server" OnClick="stop_Click" Text="stop2" />--%>
                    <input type="text" id="saber" />
                </div>
            </ContentTemplate>  
        </asp:UpdatePanel>
        
        
    
</asp:Content>
