using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Proyecto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            int num = 0;
            DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            if (dvSql.Count > 0)
                {
                    num = 1;
                }

            if (num == 1)
            {
                Session["Nombres"] = dvSql;
                Response.Redirect("MenuPrincipal.aspx");
            }


        }
    }
}