<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Login" %>

<!DOCTYPE html>
<!-- Plantilla obtenida del siguiente link
    https://codepen.io/Tushkiz/pen/xqfsy/
    
    -->
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="stuff/loginstyle.css" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server">
    <body>
	<div class="login">
		<div class="login-screen">
			<div class="app-title">
				<h1>Login</h1>
			</div>

			<div class="login-form">
				<div class="control-group">
				    <asp:TextBox ID="login_name" runat="server" placeholder="username"></asp:TextBox>
&nbsp;<label class="login-field-icon fui-user" for="login_name"></label></div>

				<div class="control-group">
				    <asp:TextBox ID="login_pass" placeholder="password" TextMode="Password" runat="server" class="login-field"></asp:TextBox>
&nbsp;<label class="login-field-icon fui-lock" for="login_pass"></label></div>

				
                <asp:Button ID="Button1" runat="server" Text="Iniciar Sesión" BackColor="#0066CC" OnClick="Button1_Click" />
                </a>&nbsp;<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=ProyectoIPC2_Fase1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="consulta" SelectCommandType="StoredProcedure">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="login_name" Name="usu" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="login_pass" Name="pass" PropertyName="Text" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <a class="login-link" href="Formulario.aspx">Register Here</a>
			</div>
		</div>
	</div>
</body>
    </form>
</body>
</html>
