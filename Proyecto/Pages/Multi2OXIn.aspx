<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/OthelloXtreme.Master" AutoEventWireup="true" CodeBehind="Multi2OXIn.aspx.cs" Inherits="Proyecto.Pages.Multi2OXIn" %>
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

        .auto-style25 {
            overflow: scroll;
            height: 372px;
        }

    </style>
    <script>
        //se obtuvo ayuda del siguiente link para la realizacion del codigo https://es.stackoverflow.com/questions/200537/crear-tabla-din%C3%A1mica-html-y-js
        function crear(){
            var col = '<%=columnas%>';
            var filas = '<%=filas%>';
            var tabla = "<table border=\"0\">";
            var cont = 0;
            var cont2 = 0;
            var ident = cont2 + cont;
    	    mai=["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","U","V","W","X","Y","Z"];
    	    tabla+="<tr><td></td>";
    	    for(j=0;j<col;j++){ 
        	    tabla+="<td>"+(mai[j])+ "</td>";
    	    }
    	    tabla+="</tr>";
            //<asp:ImageButton ID="i01" runat="server" ImageUrl="stuff\tans.png" Height="35px" OnClick="ImageButton1_Click" Width="45px"/>
    	    for(i=0;i<filas;i++){
        	    tabla+="<tr>";
        	    tabla+="<td>"+(i+1)+ "</td>";
                for (j = 0; j < col; j++){
                    tabla += "<td>"+"<input type=\"button\" size=\"15\">"+ "</td>";
                    cont++;
            	    if(cont < 9){
        			cont2++;
        			cont = 0
        		    }
        		    ident = cont2+cont;
        	    }
        	    tabla+="</tr>";
    	    }
    	    tabla+="</table>";
    	    document.getElementById("tabla").innerHTML=tabla;
	    }
       }

    </script>
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
                    <asp:Label ID="Label9" runat="server"></asp:Label>
                    <br />
                    
                </td>
                <td class="auto-style18">
                    
                    <div id="tabla" class="auto-style25">

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


