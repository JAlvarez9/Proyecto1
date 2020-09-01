<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Proyecto.Formulario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
  <meta name="author" content="Jose Fernando Alvarez Morales">
  <meta name="description" content="Formulario, para tarea IPC">
  <title>Formulario</title>
    <link href="stuff/style.css" rel="stylesheet" type="text/css">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
</head>
    <header>
    <h1>Formulario</h1>
</header>
<body>
    <form id="form1" runat="server">
    <div id="uno">
    <p class="primero">Nombres: <asp:TextBox name="Nombres" size="50" runat="server" ID="txtnombres"/></p>
    <p class="primero">Apellidos: <asp:TextBox name="Apellidos" size="50" runat="server" ID="txtapellidos"/></p>
    <p class="primero">Nombre de Usuario: <asp:TextBox name="nmusua" size="40" runat="server" ID="txtnmusua"/></p>
    <p class="primero">Contrasenia: <asp:TextBox TextMode="Password" name="repass" size="40" runat="server" ID="txtcontra"/></p>
    <p class="primero">Fecha de Nacimiento <asp:TextBox  name="nacimiento" size="30" runat="server" ID="txtnaci"/></p>
    <p class="primero">Pais: <asp:TextBox  name="Pais" size="50" runat="server" ID="txtpais"/></p>
    <p class="primero">Correo Electronico: <asp:TextBox  name="Correo" size="50" runat="server" ID="txtcorreo"/></p>
  </div>
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:Button id="Registrar" Text="Registrarse" runat="server" OnClick="Button1_Click"/>
        <a href="Login.aspx" class="txt1">
							Log In
						</a>
    </form>
</body>
</html>
