using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.App_Code;

namespace Proyecto
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string usu = login_name.Text;
            Usuario consulta = new Usuario();
            Gestionar ges = new Gestionar();
            
                consulta = ges.consultapersona(usu);
           
                
            
            if(consulta != null)
            {
                Session["Usuario"] = consulta;
                Response.Redirect("Inicio.aspx");

            }
            else
            {
                Label1.Text = "Verifique si el usuario o contraña que ingreso existen";
            }
            int num = 0;
            
        }
    }
}