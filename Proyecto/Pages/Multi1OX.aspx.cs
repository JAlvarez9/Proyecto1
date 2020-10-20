using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto.Pages
{
    public partial class Multi1OX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string invitado = TextBox1.Text;
            Session["invitado"] = invitado;
            Response.Redirect("Multi2OX.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string invitado = TextBox1.Text;
            Session["invitado"] = invitado;
            Response.Redirect("Multi2OXIn.aspx");
        }
    }
}