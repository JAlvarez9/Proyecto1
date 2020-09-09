﻿using System;
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
            try
            {
                consulta = ges.consultapersona(usu);
            }catch(Exception ex)
            {
                Label1.Text = ex.Message;
            }
            if(consulta != null)
            {
                Session["Usuario"] = consulta;
                Response.Redirect("Inicio.aspx");

            }
            int num = 0;
            //login_name.Text=consulta.Nombres;
            //DataView dvSql = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
            
            //if (dvSql.Count > 0)
            //{
            //    num = 1;
            //}

            //if (num == 1)
            //{
            //    //login_name.Text = consulta.Nombres;
            //    Session["Usuario"] = consulta;
            //    Response.Redirect("Inicio.aspx");
            //}
        }
    }
}