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
    public partial class MenuSolitario : System.Web.UI.Page
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
                Session["cargar"] = false;

                if (RadioButton3.Checked)
                {
                    apertura = true;
                }
                else
                {
                    apertura = false;
                }
                Session["apertura"] = apertura;
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected == true)
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
                for (int i = 0; i < colors1.Count; i++)
                {
                    for (int j = 0; j < colors2.Count; j++)
                    {
                        if (colors1[i] == colors2[j])
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
                }
                else if (RadioButton6.Checked)
                {
                    Session["inicio"] = "player2";
                }
                if (RadioButton1.Checked & igual == false)
                {
                    Response.Redirect("SolitarioOX.aspx");
                }
                else if (RadioButton2.Checked & igual == false)
                {
                    Response.Redirect("SolitarioOXIn.aspx");
                }

            }

            protected void Button2_Click(object sender, EventArgs e)
            {

                int filas = 0;
                int columnas = 0;
                string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };
                Jugador1OX jugador1 = new Jugador1OX();
                Jugador2OX jugador2 = new Jugador2OX();
                string colortiro = "";
                Usuario actual = (Usuario)Session["Usuario"];
                int color1 = 0;
                int color2 = 0;
                string[] coloresj1 = new string[5];
                if (FileUpload1.HasFile)
                {
                    Boolean cargar = true;
                    FileUpload1.SaveAs(Server.MapPath("~/Archivos/" + FileUpload1.FileName));
                    XmlReader reader = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                    while (reader.Read())
                    {
                        if (reader.IsStartElement())
                        {
                            switch (reader.Name.ToString())
                            {
                                case "filas":
                                    filas = Int32.Parse(reader.ReadString());
                                    break;
                                case "columnas":
                                    columnas = Int32.Parse(reader.ReadString());
                                    break;
                            }
                        }

                    }
                    reader.Close();

                    string color = "";
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                    XmlNodeList xJugador = xdoc.GetElementsByTagName("Jugador1");
                    XmlNodeList xcolores = ((XmlElement)xJugador[0]).GetElementsByTagName("color");
                    foreach (XmlElement nodo in xcolores)
                    {
                        jugador1.colors.Add(nodo.InnerText);

                    }
                    jugador1.name = actual.NmUsuario;



                    XmlDocument xdoc2 = new XmlDocument();
                    xdoc2.Load(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                    XmlNodeList xJugador2 = xdoc.GetElementsByTagName("Jugador2");
                    XmlNodeList xcolores2 = ((XmlElement)xJugador2[0]).GetElementsByTagName("color");
                    foreach (XmlElement nodo in xcolores2)
                    {
                        jugador2.colors.Add(nodo.InnerText);

                    }
                    jugador2.name = "PONELO!!!";


                    Ficaha[,] ta = new Ficaha[filas, columnas];
                    for (int i = 0; i < filas; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            Ficaha agrego = new Ficaha();
                            agrego.llenado = false;
                            ta[i, j] = agrego;
                        }
                    }
                    color = "";
                    string x = "";
                    int y = -1;
                    string tiro = "";
                    string modo = "";
                    XmlReader reader3 = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                    while (reader3.Read())
                    {
                        if (reader3.IsStartElement())
                        {
                            switch (reader3.Name.ToString())
                            {
                                case "Modalidad":
                                    modo = reader3.ReadString();
                                    break;
                                case "color":
                                    color = reader3.ReadString();
                                    tiro = color;
                                    break;
                                case "columna":
                                    x = reader3.ReadString();
                                    break;
                                case "fila":
                                    y = Int32.Parse(reader3.ReadString());
                                    break;
                            }
                        }
                        colortiro = tiro;
                        if (color != "" & x != "" & y != -1)
                        {
                            try
                            {
                                Ficaha agre = new Ficaha();
                                agre.color = color;
                                agre.x = x;
                                agre.x1 = Array.IndexOf(abece, x);
                                agre.y = y - 1;
                                agre.llenado = true;
                                if (ta[(int)agre.y, agre.x1].llenado == false)
                                {
                                    ta[(int)agre.y, agre.x1] = agre;
                                }
                            }
                            catch
                            {

                            }


                            color = "";
                            x = "";
                            y = -1;
                        }
                    }
                    reader3.Close();
                    if (jugador1.colors.Contains(colortiro))
                    {
                        color1 = jugador1.colors.IndexOf(colortiro);
                        Session["turnoactual"] = "player1";
                    }
                    else if (jugador2.colors.Contains(colortiro))
                    {
                        color2 = jugador2.colors.IndexOf(colortiro);
                        Session["turnoactual"] = "player2";
                    }

                    Session["jugador1"] = jugador1;
                    Session["jugador2"] = jugador2;
                    Session["filas"] = filas;
                    Session["columnas"] = columnas;
                    Session["tablero"] = ta;
                    Session["cargar"] = cargar;
                    Session["apertura"] = false;
                    Session["color1"] = color1;
                    Session["color2"] = color2;
                    Session["apertura"] = false;
                    if (modo == "Normal")
                    {
                        Response.Redirect("SolitarioOX.aspx");
                    }
                    else if (modo == "Inversa")
                    {
                        Response.Redirect("SolitarioOXIn.aspx");
                    }
                }
            }
        
    }
}