using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;




namespace Proyecto
{   
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        Gestionar ges = new Gestionar();   
        
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox5.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label2.Text = "perro";
            Usuario agregar = new Usuario();
            
            agregar.Nombres = TextBox1.Text;
            agregar.Apellidos = TextBox2.Text;
            agregar.NmUsuario = TextBox3.Text;
            agregar.Contrasena = TextBox4.Text;
            
            agregar.Nacimiento =Convert.ToDateTime(TextBox5.Text);
            agregar.Pais = TextBox6.Text;
            agregar.Correo = TextBox7.Text;
            bool agregado = ges.agregar(agregar);

            if (agregado)
            {
                Label1.Text = "Se Ha registrado Correctamente";
                limpiar();
            }
            else
            {
                Label1.Text = ges.error;
            }
        }

        private void limpiar()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
        }

    }
}