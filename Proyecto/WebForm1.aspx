<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Proyecto.WebForm1" %>

<!DOCTYPE html>
<html lang="en">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <meta charset="UTF-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
    <link rel="stylesheet" type="text/css" href="vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.7.0/css/font-awesome.min.css">
	<link rel="stylesheet" type="text/css" href="fonts/Linearicons-Free-v1.0.0/icon-font.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animate/animate.css">
	<link rel="stylesheet" type="text/css" href="vendor/css-hamburgers/hamburgers.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/animsition/css/animsition.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/select2/select2.min.css">
	<link rel="stylesheet" type="text/css" href="vendor/daterangepicker/daterangepicker.css">
	<link rel="stylesheet" type="text/css" href="css/util.css">
	<link rel="stylesheet" type="text/css" href="css/main.css">

</head>
<body>
    <form  runat="server">
    <div class="limiter">
		<div class="container-login100">
			<div class="wrap-login100 p-b-160 p-t-50">
				</div>
					<span class="login100-form-title p-b-43">
						Account Login
					</span>

					<div class="wrap-input100 rs1 validate-input" data-validate = "Username is required">
						<asp:TextBox ID="TextBox1" class="input100" runat="server" name="username"/>
						<span class="label-input100">Username</span>
					</div>


					<div class="wrap-input100 rs2 validate-input" data-validate="Password is required">
						<asp:TextBox ID="TextBox2" class="input100" TextMode="Password" runat="server" name="pass"/>
						<span class="label-input100">Password</span>
					</div>

					<div class="container-login100-form-btn">
						<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(local)\SQLEXPRESS;Initial Catalog=ProyectoIPC2_Fase1;Integrated Security=True" ProviderName="System.Data.SqlClient" SelectCommand="consulta" SelectCommandType="StoredProcedure">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="TextBox1" Name="usu" PropertyName="Text" Type="String" />
                                <asp:ControlParameter ControlID="TextBox2" Name="pass" PropertyName="Text" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
						<asp:Button class="login100-form-btn" Text="Iniciar Sesion" runat="server" OnClick="Unnamed3_Click"/>
							
						
					</div>

					<div class="text-center w-full p-t-23">
						<a href="Formulario.aspx" class="txt1">
							Registrar
						</a>
					</div>
				</form>
			</div>
		</div>
	</div>

    </form>
	<script src="vendor/jquery/jquery-3.2.1.min.js"></script>
	<script src="vendor/animsition/js/animsition.min.js"></script>
	<script src="vendor/bootstrap/js/popper.js"></script>
	<script src="vendor/bootstrap/js/bootstrap.min.js"></script>
	<script src="vendor/select2/select2.min.js"></script>
	<script src="vendor/daterangepicker/moment.min.js"></script>
	<script src="vendor/daterangepicker/daterangepicker.js"></script>
	<script src="vendor/countdowntime/countdowntime.js"></script>
	<script src="js/main.js"></script>


</body>
</html>
