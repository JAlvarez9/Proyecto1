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
    public partial class Torneo1 : System.Web.UI.Page
    {
        Torneos torneo = new Torneos();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Archivos/" + FileUpload1.FileName));
                XmlDocument xdoc = new XmlDocument();
                xdoc.Load(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                XmlNodeList xEquipo = xdoc.GetElementsByTagName("equipo");
                XmlNodeList xTorneonombre = xdoc.GetElementsByTagName("nombre");
                foreach(XmlElement no in xTorneonombre)
                {
                    torneo.name = no.InnerText;
                }
                foreach(XmlElement no in xEquipo)
                {
                    EquiposT nuevo = new EquiposT();
                    nuevo.name = no.InnerText;
                    torneo.equipos.Add(nuevo);
                }

                for(int i =0;i< xEquipo.Count; i++)
                {
                    XmlNodeList xcnombres = ((XmlElement)xEquipo[i]).GetElementsByTagName("jugador");
                    foreach(XmlElement nodo in xcnombres)
                    {
                        JugadoresT nue = new JugadoresT();
                        nue.name = nodo.InnerText;
                        torneo.equipos[i].jugadores.Add(nue); 
                    }
                    XmlNodeList xnombre = ((XmlElement)xEquipo[i]).GetElementsByTagName("nombreEquipo");
                    foreach (XmlElement nodo in xnombre)
                    {

                        torneo.equipos[i].name = nodo.InnerText;
                    }
                }
                switch (torneo.equipos.Count)
                {
                    case 16:
                        foreach(EquiposT equip in torneo.equipos)
                        {
                            torneo.octavos.Add(equip);
                        }
                        break;
                    case 8:
                        foreach (EquiposT equip in torneo.equipos)
                        {
                            torneo.cuartos.Add(equip);
                        }
                        break;
                    case 4:
                        foreach (EquiposT equip in torneo.equipos)
                        {
                            torneo.semis.Add(equip);
                        }
                        break;

                }
                
                Session["torneo"] = torneo;
                Response.Redirect("Torneo2.aspx");
            }
        }
    }
}