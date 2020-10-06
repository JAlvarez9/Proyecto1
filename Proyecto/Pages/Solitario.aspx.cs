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
        
        static int numjugadas1 = 0;
        static int numjugadas2 = 0;
        static int score1 = 2;
        static int score2 = 2;
        static string[] turnos = new string[2];
        static string turnoactual = "";
        static Ficaha[,] tablero = new Ficaha[8,8];
        static ImageButton[,] botones = new ImageButton[8, 8];

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                //Label4.Text = "Primer carga";
                Session["botones"] = botones;
                Session["tab"] = tablero;
                llenado();
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Ficaha agrego = new Ficaha();
                        agrego.llenado = false;
                        tablero[i, j] = agrego;
                    }
                }
                Session["tab"] = tablero;
                Button3.Enabled = false;
            }
            else
            {
                llenado();
                //Label4.Text = "No es la primera carga";
                //tablero = (Ficaha[,])Session["tab"];
                //botones = (ImageButton[,])Session["botones"];
                
                //HabilitarBotones();
                //int auxiliar = 0;
                //for (int i = 0; i < 8; i++)
                //{
                //    for (int j = 0; j < 8; j++)
                //    {
                //        if(tablero[i,j].llenado == true)
                //        {
                //            auxiliar += 1;
                //        }
                //    }
                //}
                //Label5.Text = auxiliar.ToString();
                //    for (int i = 0; i < 8; i++)
                //    {
                //        for (int j = 0; j < 8; j++)
                //        {
                //            if (tablero[i, j].llenado == true)
                //            {
                //                Label6.Text = "Entre a if";
                //                botones[i, j].Enabled = false;
                //            }
                //            else
                //            {
                //                botones[i, j].Enabled = true;
                //            }
                //        }
                //    }
                //    Session["botones"] = botones;
                
            }
            
            
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Button1.Attributes.Add("onclick", "return false;");
            
            tablero = (Ficaha[,])Session["tab"];
            int scoren;
            int scoreb;
            botones = (ImageButton[,])Session["botones"];
            Random rnd = new Random();
            turnos[0] = "blanco";
            turnos[1] = "negro";
            int aux = rnd.Next(turnos.Length);
            //Label4.Text = aux.ToString();
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
            pred1.y = 3;
            pred1.llenado = true;
            tablero[3, 3] = pred1;

            Ficaha pred2 = new Ficaha();
            pred2.color = "negro";
            pred2.x = "E";
            pred2.y = 3;
            pred2.llenado = true;
            tablero[3, 4] = pred2;

            Ficaha pred3 = new Ficaha();
            pred3.color = "negro";
            pred3.x = "D";
            pred3.y = 4;
            pred3.llenado = true;
            tablero[4, 3] = pred3;

            Ficaha pred4 = new Ficaha();
            pred4.color = "blanco";
            pred4.x = "E";
            pred4.y = 4;
            pred4.llenado = true;
            tablero[4, 4] = pred4;
            
            Session["tab"] = tablero;
            
            i28.ImageUrl = ("stuff\\blanca.jpg");
            i29.ImageUrl = ("stuff\\negra.jpg");
            i36.ImageUrl = ("stuff\\negra.jpg");
            i37.ImageUrl = ("stuff\\blanca.jpg");
            
           
            
            Label1.Text = actual.NmUsuario;
            Label3.Text = numjugadas1.ToString();  
            Button3.Enabled = true;
            
            Session["botones"] = botones;
            Bloqueo();
            //HabilitarBotones();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Archivos/" + FileUpload1.FileName));


                botones = (ImageButton[,])Session["botones"];
                Ficaha[,] ta = new Ficaha[8, 8];
                string color = "";
                string x = "";
                int puntne = 0;
                int puntbl = 0;
                int y = -1;
                string tiro = "";
                Label6.Text = "Cerro";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        botones[i, j].Enabled = true;
                    }
                }
                XmlReader reader = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Proyecto\Proyecto\Archivos\"+FileUpload1.FileName);
                while (reader.Read())
                {
                    Label6.Text = "si while";
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "color":
                                color = reader.ReadString();
                                tiro = color;
                                Label1.Text = tiro;
                                break;
                            case "columna":
                                x = reader.ReadString();
                                break;
                            case "fila":
                                y = Int32.Parse(reader.ReadString());
                                break;
                                //case "siguienteTiro":
                                //    tiro = reader.ReadString();
                                //    break;
                        }

                    }
                    Session["turnac"] = tiro;
                    if (color != "" & x != "" & y != -1)
                    {
                        //Label5.Text = "entre al if";
                        Ficaha agre = new Ficaha();
                        agre.color = color;
                        agre.x = x;
                        agre.x1 = leer(x);
                        agre.y = y - 1;
                        agre.llenado = true;
                        ta[(int)agre.y, agre.x1] = agre;
                        for (int i = 0; i < 8; i++)
                        {
                            for (int j = 0; j < 8; j++)
                            {
                                if (i == agre.y & j == agre.x1 & agre.color == "blanco")
                                {
                                    botones[i, j].ImageUrl = ("stuff\\blanca.jpg");
                                    //botones[i, j].Enabled = false;

                                    puntbl++;
                                }
                                else if (i == agre.y & j == agre.x1 & agre.color == "negro")
                                {
                                    
                                    botones[i, j].ImageUrl = ("stuff\\negra.jpg");
                                    //botones[i, j].Enabled = false;
                                    puntne++;
                                }



                            }
                        }

                        color = "";
                        x = "";
                        y = -1;
                    }

                }

                tablero = ta;
                Session["scoren"] = puntne;
                Session["scoreb"] = puntbl;
                Session["tab"] = tablero;
                Session["botones"] = botones;
                Button3.Enabled = true;
            }
            else
            {

            }
        }
        
        protected void Button3_Click(object sender, EventArgs e)
        {
            string ruta = TextBox1.Text;
            if (ruta == null | ruta == " ")
            {
                TextBox1.Text = "No coloco una ruta con el nombre del archivo";
            }

            //Label6.Text = "Si entre al if";
            tablero = (Ficaha[,])Session["tab"];
            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            string tiro = (string)Session["turnac"];
            XmlWriter xmlWriter = XmlWriter.Create(@"" + ruta, set);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("tablero");
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j] != null)
                    {

                        xmlWriter.WriteStartElement("ficha");
                        xmlWriter.WriteStartElement("color");
                        xmlWriter.WriteString(tablero[i, j].color);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("columna");
                        xmlWriter.WriteString(tablero[i, j].x);
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteStartElement("fila");
                        xmlWriter.WriteString((tablero[i, j].y + 1).ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndElement();

                    }

                }


            }
            xmlWriter.WriteStartElement("siguienteTiro");
            xmlWriter.WriteStartElement("color");
            xmlWriter.WriteString(tiro);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Close();

            Button3.Enabled = true;
        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string idaux;
            int id;
            turnoactual = (string)Session["turnac"];
            Label5.Text = turnoactual;
            ImageButton clickedButton = (ImageButton)sender;
            botones = (ImageButton[,])Session["botones"];
            tablero = (Ficaha[,])Session["tab"];
            
            if (turnoactual == "negro") {
                Label3.Text = "negro";
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1, 2));
                tablero = (Ficaha[,])Session["tab"];
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "negro");
                nueva.llenado = true;
                Label3.Text = nueva.y.ToString();
                Label4.Text = nueva.x1.ToString();
                MovimientoNegro((int)nueva.y, nueva.x1);
                //int scoren =(int) Session["scoren"];
                //int scoreb = (int)Session["scoreb"];
                //string l = clickedButton.ID;
                //for (int i = 0; i < 8; i++)
                //{
                //    for (int j = 0; j < 8; j++)
                //    {

                //        string k = botones[i, j].ID;

                //        if (l == k)
                //        {
                //            //Label3.Text = "Si entre a la negra";
                //            botones[i, j].ImageUrl = ("stuff/negra.jpg");
                //            //clickedButton.ImageUrl = ("stuff\\negra.jpg");

                //        }


                //    }
                //}
                //Session["botones"] = botones;

                //Session["turnac"] = "blanco";

                //Label2.Text = (scoren+1).ToString();
                //Label5.Text = scoreb.ToString();
                //idaux = clickedButton.ID;
                //id = Int32.Parse(idaux.Substring(1, 2));
                //tablero = (Ficaha[,])Session["tab"];
                //Ficaha nueva = new Ficaha();
                //nueva = Creacion(id, "negro");
                //nueva.llenado = true;
                //tablero[(int)nueva.y, nueva.x1] = nueva;
                //Session["tab"] = tablero;
                //Session["scoren"] = scoren + 1;

            }
            else if(turnoactual == "blanco")
            {
                Label3.Text = "blanco";
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1, 2));
                tablero = (Ficaha[,])Session["tab"];
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "blanco");
                nueva.llenado = true;
                Label3.Text = nueva.y.ToString();
                Label4.Text = nueva.x1.ToString();
                MovimientoBlanco((int)nueva.y, nueva.x1);
                //int scoreb = (int)Session["scoreb"];
                //int scoren = (int)Session["scoren"];
                //string l = clickedButton.ID;
                //for (int i = 0; i < 8; i++)
                //{
                //    for (int j = 0; j < 8; j++)
                //    {
                //        string k = botones[i, j].ID;   
                //        if (l == k)
                //        {
                //            //Label3.Text = "Si entre a la blanca";
                //            botones[i, j].ImageUrl = ("stuff\\blanca.jpg");
                //            //clickedButton.ImageUrl = ("stuff\\blanca.jpg");

                //        }
                //    }
                //}
                //Session["botones"] = botones;
                //Session["turnac"] = "negro";
                ////Session["scoreb"] = score2 + 1;

                //Label5.Text = (scoreb + 1).ToString();
                //Label2.Text = scoren.ToString();
                //idaux = clickedButton.ID;
                //id = Int32.Parse(idaux.Substring(1, 2));
                //tablero = (Ficaha[,])Session["tab"];
                //Ficaha nueva = new Ficaha();
                //nueva = Creacion(id, "blanco");
                //nueva.llenado = true;
                //tablero[(int)nueva.y, nueva.x1] = nueva;
                //Session["tab"] = tablero;
                //Session["scoreb"] = scoreb + 1;
            }
            Button3.Enabled = true;
            Session["botones"] = botones;
            Bloqueo();
            //HabilitarBotones();
        }


        public Ficaha Creacion(int id , string color)
        {
            Ficaha nueva = new Ficaha();
            if(color == "negro")
            {
                nueva.color = "negro";
               
                nueva.y = Math.Floor((double)id / 8);
                int res = (id % 8)-1;
                nueva.x1 = res;
                if (id == 8 | id == 16 | id == 24 | id == 32 | id == 40 | id == 48 | id == 56 | id == 64)
                {
                    nueva.y = (id / 8) - 1;
                    nueva.x = "H";
                    nueva.x1 = 7;
                    return nueva;
                }
               

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
                    

                }

                return nueva;

            }
            if (color == "blanco")
            {
                nueva.color = "blanco";
                
                nueva.y = Math.Floor((double)id / 8);
                int res = (id % 8) - 1;
                if(id == 8 | id == 16 | id ==24 | id == 32 | id == 40 | id == 48 | id==56 | id==64)
                {
                    nueva.y = (id / 8) - 1;
                    nueva.x = "H";
                    nueva.x1 = 7;
                    return nueva;
                }
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

        public void llenado()
        {
            
            botones[0, 0] = i01;
            botones[0, 1] = i02;
            botones[0, 2] = i03;
            botones[0, 3] = i04;
            botones[0, 4] = i05;
            botones[0, 5] = i06;
            botones[0, 6] = i07;
            botones[0, 7] = i08;
            botones[1, 0] = i09;
            botones[1, 1] = i10;
            botones[1, 2] = i11;
            botones[1, 3] = i12;
            botones[1, 4] = i13;
            botones[1, 5] = i14;
            botones[1, 6] = i15;
            botones[1, 7] = i16;
            botones[2, 0] = i17;
            botones[2, 1] = i18;
            botones[2, 2] = i19;
            botones[2, 3] = i20;
            botones[2, 4] = i21;
            botones[2, 5] = i22;
            botones[2, 6] = i23;
            botones[2, 7] = i24;
            botones[3, 0] = i25;
            botones[3, 1] = i26;
            botones[3, 2] = i27;
            botones[3, 3] = i28;
            botones[3, 4] = i29;
            botones[3, 5] = i30;
            botones[3, 6] = i31;
            botones[3, 7] = i32;
            botones[4, 0] = i33;
            botones[4, 1] = i34;
            botones[4, 2] = i35;
            botones[4, 3] = i36;
            botones[4, 4] = i37;
            botones[4, 5] = i38;
            botones[4, 6] = i39;
            botones[4, 7] = i40;
            botones[5, 0] = i41;
            botones[5, 1] = i42;
            botones[5, 2] = i43;
            botones[5, 3] = i44;
            botones[5, 4] = i45;
            botones[5, 5] = i46;
            botones[5, 6] = i47;
            botones[5, 7] = i48;
            botones[6, 0] = i49;
            botones[6, 1] = i50;
            botones[6, 2] = i51;
            botones[6, 3] = i52;
            botones[6, 4] = i53;
            botones[6, 5] = i54;
            botones[6, 6] = i55;
            botones[6, 7] = i56;
            botones[7, 0] = i57;
            botones[7, 1] = i58;
            botones[7, 2] = i59;
            botones[7, 3] = i60;
            botones[7, 4] = i61;
            botones[7, 5] = i62;
            botones[7, 6] = i63;
            botones[7, 7] = i64;
            Session["botones"] = botones;

           

        }

        public void Bloqueo()
        {
            tablero = (Ficaha[,])Session["tab"];
            botones = (ImageButton[,])Session["botones"];
            turnoactual = (string)Session["turnac"];
            for (int i = 0; i < 8; i++)
            {   
                for (int j = 0; j < 8; j++)
                {
                    botones[i, j].Enabled = false;
                }
            }

            if (turnoactual == "negro")
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tablero[i, j].llenado == true && tablero[i,j].color == "blanco")
                        {
                            if (tablero[i + 1, j].llenado == false)
                            {
                                botones[i + 1, j].Enabled = true;
                            }
                            if (tablero[i, j + 1].llenado == false)
                            {
                                botones[i, j + 1].Enabled = true;
                            }
                            if (tablero[i + 1, j + 1].llenado == false)
                            {
                                botones[i + 1, j + 1].Enabled = true;
                            }
                            if (tablero[i + 1, j - 1].llenado == false)
                            {
                                botones[i + 1, j - 1].Enabled = true;
                            }
                            if (tablero[i - 1, j + 1].llenado == false)
                            {
                                botones[i - 1, j + 1].Enabled = true;
                            }
                            if (tablero[i - 1, j].llenado == false)
                            {
                                botones[i - 1, j].Enabled = true;
                            }
                            if (tablero[i, j - 1].llenado == false)
                            {
                                botones[i, j - 1].Enabled = true;
                            }
                            if (tablero[i - 1, j - 1].llenado == false)
                            {
                                botones[i - 1, j - 1].Enabled = true;
                            }
                        }
                    }
                }
            }
            else if (turnoactual == "blanco")
            {
                for (int i = 0; i < 8; i++) 
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tablero[i, j].llenado == true && tablero[i,j].color == "negro")
                        {
                            if (tablero[i + 1, j].llenado == false)
                            {
                                botones[i + 1, j].Enabled = true;
                            }
                            if (tablero[i, j + 1].llenado == false)
                            {
                                botones[i, j + 1].Enabled = true;
                            }
                            if (tablero[i + 1, j + 1].llenado == false)
                            {
                                botones[i + 1, j + 1].Enabled = true;
                            }
                            if (tablero[i + 1, j - 1].llenado == false)
                            {
                                botones[i + 1, j - 1].Enabled = true;
                            }
                            if (tablero[i - 1, j + 1].llenado == false)
                            {
                                botones[i - 1, j + 1].Enabled = true;
                            }
                            if (tablero[i - 1, j].llenado == false)
                            {
                                botones[i - 1, j].Enabled = true;
                            }
                            if (tablero[i, j - 1].llenado == false)
                            {
                                botones[i, j - 1].Enabled = true;
                            }
                            if (tablero[i - 1, j - 1].llenado == false)
                            {
                                botones[i - 1, j - 1].Enabled = true;
                            }
                        }
                    }
                }
            }
        }

        public void MovimientoBlanco(int x, int y)
        {
            
            int id;
            Boolean move = false;
            Ficaha[] change = new Ficaha[64];
            for (int i = x - 1; i <= x + 1; i++)
            {
                for(int j = y - 1; j<= y + 1; j++)
                {
                    if(i == x && j == y)
                    {
                        
                    }
                    else if(tablero[i,j].color == "negro")
                    {
                        if(i == x-1 && j == y - 1)
                        {
                            move = RecursivoBlanco(x - 1, y - 1, "UL",change);
                        }
                        else if (i == x && j==y - 1)
                        {
                            move = RecursivoBlanco(x, y - 1, "U",change);
                        }
                        else if (i == x + 1 && j == y - 1)
                        {
                            move = RecursivoBlanco(x + 1, y - 1, "UR", change);
                        }
                        else if (i == x-1 && j == y)
                        {
                            move = RecursivoBlanco(x - 1, y, "L", change);
                        }
                        else if (i== x+1 && j == y)
                        {
                            move = RecursivoBlanco(x + 1, y, "R", change);
                        }
                        else if (i == x -1 && j == y + 1)
                        {
                            move = RecursivoBlanco(x - 1, y + 1, "DL", change);
                        }
                        else if ( i == x && j == y + 1)
                        {
                            move = RecursivoBlanco(x, y + 1, "D", change);
                        }
                        else if (i == x+1 && j == y + 1)
                        {
                            move = RecursivoBlanco(x + 1, y + 1, "DR", change);
                        }
                    }
                }
            }

            if (move)
            {
                
                //tablero[(int)nueva.y, nueva.x1] = nueva;
                for (int i = 0; i< change.Length; i++)
                {
                    change[i].color = "blanco";
                }
                PintarBlanco();
                Session["turnac"] = "negro";
                Session["tab"] = tablero;
                Session["botones"] = botones;
            }
            else
            {

            }
            

        }
        public void MovimientoNegro(int x, int y)
        {
            Boolean move = false;
            Ficaha[] change = new Ficaha[64];
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i == x && j == y)
                    {

                    }
                    else if (tablero[i, j].color == "blanco")
                    {
                        if (i == x - 1 && j == y - 1)
                        {
                            //Label3.Text = (x - 1).ToString + (y - 1).ToString;
                            move = RecursivoNegro(x - 1, y - 1, "UL", change);
                        }
                        else if (i == x && j == y - 1)
                        {
                            move = RecursivoNegro(x, y - 1, "U", change);
                        }
                        else if (i == x + 1 && j == y - 1)
                        {
                            move = RecursivoNegro(x + 1, y - 1, "UR", change);
                        }
                        else if (i == x - 1 && j == y)
                        {
                            move = RecursivoNegro(x - 1, y, "L", change);
                        }
                        else if (i == x + 1 && j == y)
                        {
                            move = RecursivoNegro(x + 1, y, "R", change);
                        }
                        else if (i == x - 1 && j == y + 1)
                        {
                            move = RecursivoNegro(x - 1, y + 1, "DL", change);
                        }
                        else if (i == x && j == y + 1)
                        {
                            move = RecursivoNegro(x, y + 1, "D", change);
                        }
                        else if (i == x + 1 && j == y + 1)
                        {
                            move = RecursivoNegro(x + 1, y + 1, "DR", change);
                        }
                    }
                }
            }

            if (move)
            {
                for (int i = 0; i < change.Length; i++)
                {
                    change[i].color = "negro";
                }
                PintarNegro();
                Session["turnac"] = "blanco";
                Session["tab"] = tablero;
                Session["botones"] = botones;
            }
            else
            {

            }
        }


        public Boolean RecursivoBlanco(int x, int y, string D, Ficaha[] change)
        {
            Boolean moves = false;
            int cont = 0;
            //while(change[cont] == null)
            //{
            //    change[cont + 1] = tablero[x, y];
            //}
            //Label3.Text = "recurBla";
            Direction(x,y,D);
            if(tablero[x,y].color == "negro")
            {
                moves = RecursivoBlanco(x, y, D,change);
            }
            else if (tablero[x, y].color == "blanco")
            {
                return true;
            }
            else if (tablero[x, y].color == "")
            {
                return false;
            }
            else
            {
                return false;
            }
            return false;
        }

        public Boolean RecursivoNegro(int x, int y, string D, Ficaha[] change)
        {
            Boolean moves = false;
            int cont = 0;
            //while (change[cont] == null)
            //{
            //    change[cont + 1] = tablero[x, y];
            //}
            //Label3.Text = "recurNeg";

            Direction(x, y, D);
            if (tablero[x, y].color == "blanco")
            {
                RecursivoNegro(x, y, D, change);
            }
            else if (tablero[x, y].color == "negro")
            {
                return true;
            }
            else if (tablero[x, y].llenado == false)
            {
                return false;
            }
            else
            {
                return false;
            }
            return false;
        }

        public void Direction(int x, int y, string D)
        {
            if(D == "UL")
            {
                x = x - 1;
                y = y - 1;
            }else if ( D == "U")
            {
                y = y - 1;
            }else if( D == "UR")
            {
                x = x + 1;
                y = y - 1;
            }else if(D == "R")
            {
                x = x + 1;
            }else if(D == "L")
            {
                x = x - 1;
            }else if(D == "DL")
            {
                x = x - 1;
                y = y + 1;
            }else if (D == "D")
            {
                y = y - 1;
            }else if (D == "DR")
            {
                x = x + 1;
                y = y + 1;
            }
        }

        public void PintarBlanco()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i,j].color == "blanco")
                    {
                        botones[i,j].ImageUrl = ("stuff\\blanca.jpg");
                    }
                }
            }
        }

        public void PintarNegro()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j].color == "negro")
                    {
                        botones[i, j].ImageUrl = ("stuff/negra.jpg");
                    }
                }
            }
        }
    }
}