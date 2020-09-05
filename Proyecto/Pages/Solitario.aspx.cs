using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.App_Code;
using System.Xml;

namespace Proyecto.Pages
{
    public partial class Solitario : System.Web.UI.Page
    {
        Usuario actual = new Usuario();
        
        int numjugadas1 = 0;
        int numjugadas2 = 0;
        //int score1 = 2;
        //int score2 = 2;
        string[] turnos = new string[2];
        string turnoactual = "";
        Ficaha[,] tablero = new Ficaha[8,8];
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label6.Text = "Si entre al if";
            tablero = (Ficaha[,])Session["tab"];
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            string tiro =(string) Session["turnac"];
            XmlWriter xmlWriter = XmlWriter.Create(@"C:\Users\Byron Alvarez\Desktop\Stuff\ejemplo.xml", set);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("tablero");
            for(int i = 0; i < 8; i++)
            {
                for(int j =0; j< 8; j++)
                {
                    if (tablero[i, j] != null) {
                        
                        xmlWriter.WriteStartElement("ficha");
                        xmlWriter.WriteStartElement("color");
                        xmlWriter.WriteString(tablero[i, j].color);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("columna");
                        xmlWriter.WriteString(tablero[i, j].x);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("fila");
                        xmlWriter.WriteString(tablero[i, j].y.ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();

                    }
                    
                }
                

            }
            
            xmlWriter.WriteStartElement("siguienteTiro");
            xmlWriter.WriteString(tiro);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            Button3.Enabled = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int scoren;
            int scoreb;
            Random rnd = new Random();
            turnos[0] = "blanco";
            turnos[1] = "negro";
            int aux = rnd.Next(turnos.Length);
            Label4.Text = aux.ToString();
            Session["scoren"] = 2;
            Session["scoreb"] = 2;
            Session["turnac"] = turnos[aux];
            scoren = (int)Session["scoren"];
            scoreb = (int)Session["scoreb"];
             Label2.Text = scoren.ToString();
            Label5.Text = scoreb.ToString();
            actual = (Usuario)Session["Usuario"];

            Ficaha pred1 = new Ficaha();
            pred1.color = "blanco";
            pred1.x = "D";
            pred1.y = 4;
            tablero[3, 3] = pred1;

            Ficaha pred2 = new Ficaha();
            pred2.color = "negro";
            pred2.x = "E";
            pred2.y = 4;
            tablero[3, 4] = pred2;

            Ficaha pred3 = new Ficaha();
            pred3.color = "negro";
            pred3.x = "D";
            pred3.y = 4;
            tablero[4, 3] = pred3;

            Ficaha pred4 = new Ficaha();
            pred4.color = "blanco";
            pred4.x = "E";
            pred4.y = 5;
            tablero[4, 4] = pred4;

            Session["tab"] = tablero;

            i28.ImageUrl = ("stuff\\blanca.jpg");
            i29.ImageUrl = ("stuff\\negra.jpg");
            i36.ImageUrl = ("stuff\\negra.jpg");
            i37.ImageUrl = ("stuff\\blanca.jpg");
            i28.Enabled = false;
            i29.Enabled = false;
            i36.Enabled = false;
            i37.Enabled = false;

            Label1.Text = actual.NmUsuario;
            Label3.Text = numjugadas1.ToString();  
            Button3.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string color = "";
            string x = "";
            int y = -1;
            string tiro = "";
            Label6.Text = "Cerro";
            XmlReader reader = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Stuff\ejemplo.xml");
            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    //return only when you have START tag  
                    switch (reader.Name.ToString())
                    {
                        case "color":
                            color= reader.ReadString();
                            break;
                        case "columna":
                            x = reader.ReadString();
                            break;
                        case "fila":
                            y = Int32.Parse(reader.ReadString());
                            break;
                        case "siguienteTiro":
                            tiro = reader.ReadString();
                            break;
                    }

                }
                if(color != "" & x != "" & y != -1)
                {
                    Ficaha agre = new Ficaha();
                    agre.color = color;
                    agre.x = x;
                    agre.x1 = leer(x);
                    agre.y = y;
                    Ficaha[,] ta = new Ficaha[8, 8];
                    ta[(int) agre.y,agre.x1] = agre;
                    color = "";
                    x = "";
                    y = -1;
                }

            }
            //Button3.Enabled = true;
        }

        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string idaux;
            int id;
            Label5.Text = turnoactual;
            ImageButton clickedButton = (ImageButton)sender;
            
            turnoactual = (string)Session["turnac"];
            if (turnoactual == "negro") {

                int scoren =(int) Session["scoren"];
                int scoreb = (int)Session["scoreb"];
                clickedButton.ImageUrl = ("stuff\\negra.jpg");
                clickedButton.Enabled = false;
                Session["turnac"] = "blanco";
                 
                Label2.Text = scoren.ToString();
                Label5.Text = scoreb.ToString();
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1,2));
                tablero = (Ficaha[,])Session["tab"];
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "negro");
                tablero[(int)nueva.y,nueva.x1] = nueva;
                Session["tab"] = tablero;
                Session["scoren"] = scoren + 1;
                
            }
            else if(turnoactual == "blanco")
            {
                int scoreb = (int)Session["scoreb"];
                int scoren = (int)Session["scoren"];
                clickedButton.ImageUrl = ("stuff\\blanca.jpg");
                clickedButton.Enabled = false;
                Session["turnac"] = "negro";
                //Session["scoreb"] = score2 + 1;

                Label5.Text = scoreb.ToString();
                Label2.Text = scoren.ToString();
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1, 2));
                tablero = (Ficaha[,])Session["tab"]; 
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "blanco");
                tablero[(int)nueva.y, nueva.x1] = nueva;
                Session["tab"] = tablero;
                Session["scoreb"] = scoreb + 1;
            }
            Button3.Enabled = true;
        }


        public Ficaha Creacion(int id , string color)
        {
            Ficaha nueva = new Ficaha();
            if(color == "negro")
            {
                nueva.color = "negra";
                nueva.y = Math.Ceiling((double)id / 8);
                int res = (id % 8) - 1;
                nueva.x1 = res;
                switch (res)
                {
                    case 0:
                        nueva.x = "A";
                        break;
                    case 1:
                        nueva.x = "B";
                        break;
                    case 2:
                        nueva.x = "C";
                        break;
                    case 3:
                        nueva.x = "D";
                        break;
                    case 4:
                        nueva.x = "E";
                        break;
                    case 5:
                        nueva.x = "F";
                        break;
                    case 6:
                        nueva.x = "G";
                        break;
                    case 7:
                        nueva.x = "H";
                        break;
                        
                }

                return nueva;

            }
            if (color == "blanco")
            {
                nueva.color = "blanco";
                nueva.y = Math.Ceiling((double)id / 8);
                int res = (id % 8) - 1;
                switch (res)
                {
                    case 0:
                        nueva.x = "A";
                        break;
                    case 1:
                        nueva.x = "B";
                        break;
                    case 2:
                        nueva.x = "C";
                        break;
                    case 3:
                        nueva.x = "D";
                        break;
                    case 4:
                        nueva.x = "E";
                        break;
                    case 5:
                        nueva.x = "F";
                        break;
                    case 6:
                        nueva.x = "G";
                        break;
                    case 7:
                        nueva.x = "H";
                        break;

                }

                return nueva;

            }
            return null;

        }

        public int leer (string a)
        {
            int x1 = -1;
            switch (a)
            {
                case "A":
                    x1 = 0;
                    break;
                case "B":
                    x1 = 1;
                    break;
                case "C":
                    x1 = 2;
                    break;
                case "D":
                    x1 = 3;
                    break;
                case "E":
                    x1 = 4;
                    break;
                case "F":
                    x1 = 5;
                    break;
                case "G":
                    x1 = 6;
                    break;
                case "H":
                    x1 = 7;
                    break;

            }
            return x1;
        }



        
    }
}