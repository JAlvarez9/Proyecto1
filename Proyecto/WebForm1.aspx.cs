using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public Boolean hola ;
        
        public static string timee;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                
            }
            else
            {
                
                
                

            }
        }

        protected void start_Click(object sender, EventArgs e)
        {
            string javaScript = "cronometrar();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            //hola = true;
            
        }

        protected void stop_Click(object sender, EventArgs e)
        {
            string javaScript = "parar();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script1", javaScript, true);
            //hola = false;
        }
    }
}