using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;

namespace Proyecto
{
    public partial class Formulario : System.Web.UI.Page
    {

        Gestionar ges = new Gestionar();
        protected void Page_Load(object sender, EventArgs e)
        {
            //txtnaci.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Usuario agregar = new Usuario();

            agregar.Nombres = txtnombres.Text;
            agregar.Apellidos = txtapellidos.Text;
            agregar.NmUsuario = txtnmusua.Text;
            agregar.Contrasena = txtcontra.Text;
            string q = txtnaci.Text;
            string[] a = q.Split('/');
            string na = a[2]+ "/" + a[1]+"/"+a[0];
            agregar.Nacimiento = Convert.ToDateTime(na);
            agregar.Pais = txtpais.Text;
            agregar.Correo = txtcorreo.Text;
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
            txtnombres.Text = "";
            txtapellidos.Text = "";
            txtnmusua.Text = "";
            txtcontra.Text = "";
            txtnaci.Text = "";
            txtpais.Text = "";
            txtcorreo.Text = "";
        }
    }
}