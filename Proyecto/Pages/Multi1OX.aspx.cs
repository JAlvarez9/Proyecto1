using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;
using System.Xml;

namespace Proyecto.Pages
{
    public partial class Multi1OX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> colors1 = new List<string>();
            List<string> colors2 = new List<string>();
            Boolean apertura;
            Boolean igual = false;
            Session["filas"] = Int32.Parse(DropDownList1.Text);
            Session["columnas"] = Int32.Parse(DropDownList2.Text);
            if (RadioButton3.Checked)
            {
                apertura = true;
            }
            else
            {
                apertura = false;
            }
            Session["apertura"] = apertura;
            foreach(ListItem item in CheckBoxList1.Items)
            {
                if(item.Selected == true)
                {
                    colors1.Add(item.Text);
                }
            }
            foreach (ListItem item in CheckBoxList2.Items)
            {
                if (item.Selected == true)
                {
                    colors2.Add(item.Text);
                }
            }
            for(int i = 0; i< colors1.Count; i++)
            {
                for(int j = 0; j < colors2.Count; j++)
                {
                    if(colors1[i] == colors2[j])
                    {
                        Label1.Text = "Verifique que no se repita los colores.";
                        igual = true;
                    }
                }
            }
            Session["colors1"] = colors1;
            Session["colors2"] = colors2;
            if (RadioButton5.Checked)
            {
                Session["inicio"] = "player1";
            }else if (RadioButton6.Checked)
            {
                Session["inicio"] = "player2";
            }
            if (RadioButton1.Checked & igual == false)
            {
                Response.Redirect("Multi2OX.aspx");
            }
            else if (RadioButton2.Checked & igual == false)
            {
                Response.Redirect("Multi2OXIn.aspx");
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int filas = Int32.Parse(DropDownList1.Text);
            int columnas = Int32.Parse(DropDownList2.Text);
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Archivos/" + FileUpload1.FileName));
                Ficaha[,] ta = new Ficaha[8, 8];
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        Ficaha agrego = new Ficaha();
                        agrego.llenado = false;
                        ta[i, j] = agrego;
                    }
                }
                XmlReader reader = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name.ToString())
                        {
                            case "filas":
                                Session["filas"] = Int32.Parse(reader.ReadString());
                                break;
                            case "columnas":
                                Session["columnas"] = Int32.Parse(reader.ReadString());
                                break;
                        }
                    }
                }
            }
        }
    }
}