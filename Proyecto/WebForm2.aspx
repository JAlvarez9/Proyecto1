<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Proyecto.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 147px;
        }
        .auto-style2 {
            width: 233px;
        }
        #Text1 {
            width: 238px;
        }
        #Text2 {
            width: 235px;
        }
        #Text3 {
            width: 233px;
        }
        #Password1 {
            width: 227px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 45%; height: 241px;">
                <tr>
                    <td class="auto-style1">Nombres:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox1" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Apellidos:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox2" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Nombre Usuario:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox3" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Contrasena:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox4" TextMode="Password" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Fecha de Nacimiento:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox5"  runat="server" Width="241px"></asp:TextBox>
                        
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Pais:</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox6" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">Correo</td>
                    <td class="auto-style2">
                        <asp:TextBox ID="TextBox7" runat="server" Width="241px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registrar" />
    </form>
</body>
</html>
