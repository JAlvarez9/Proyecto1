using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;
using System.Xml;
using System.Data.SqlClient;

namespace Proyecto.Pages
{
    public partial class Multi2 : System.Web.UI.Page
    {
        public string error;
        public SqlConnection conexion;
        Usuario actual = new Usuario();
        static Jugador player;
        static int numjugadas1;
        static int score2;
        static string[] turnos = new string[2];
        static string turnoactual = "";
        static Ficaha[,] tablero;
        static ImageButton[,] botones = new ImageButton[8, 8];
        List<Ficaha> change;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //Label4.Text = "Primer carga";
                Session["botones"] = botones;
                Session["tab"] = tablero;
                try
                {
                    llenado();


                }
                catch (Exception asa)
                {

                }
                
                Session["tab"] = tablero;
                Button3.Enabled = false;
            }
            else
            {
                llenado();

            }




        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            tablero = new Ficaha[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Ficaha agrego = new Ficaha();
                    agrego.llenado = false;
                    tablero[i, j] = agrego;
                }
            }
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
            player = new Jugador();
            turnos = new string[2];
            botones = (ImageButton[,])Session["botones"];
            Random rnd = new Random();
            turnos[0] = "blanco";
            turnos[1] = "negro";
            int aux = rnd.Next(turnos.Length);
            player.color = turnos[aux];

            Label4.Text = "Maquina";
            if (player.color == "blanco")
            {
                Label3.Text = player.color;
                Label6.Text = "Negro";
            }
            else
            {
                Label3.Text = player.color;
                Label6.Text = "Blanco";
            }

            turnoactual = "negro";
            if (player.color == "negro")
            {
                Label3.Text = "Negro <--";
            }
            else if (player.color != "negro")
            {
                Label6.Text = "Negro <--";
            }
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


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {

                    if (tablero[i, j].llenado == false)
                    {
                        botones[i, j].ImageUrl = ("stuff\\tans.png");
                    }
                }
            }

            Label1.Text = actual.NmUsuario;
            //Label3.Text = numjugadas1.ToString();  
            Button3.Enabled = true;

            Session["botones"] = botones;
            if (player.color == turnoactual)
            {
                string javaScript = "cronometrar();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }
            else
            {
                string javaScript = "cronometrar2();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
            }

            //Bloqueo();
            //HabilitarBotones();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            if (FileUpload1.HasFile)
            {
                FileUpload1.SaveAs(Server.MapPath("~/Archivos/" + FileUpload1.FileName));


                botones = (ImageButton[,])Session["botones"];
                Ficaha[,] ta = new Ficaha[8, 8];
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Ficaha agrego = new Ficaha();
                        agrego.llenado = false;
                        ta[i, j] = agrego;
                    }
                }
                player = new Jugador();
                turnos = new string[2];
                Random rnd = new Random();
                turnos[0] = "blanco";
                turnos[1] = "negro";
                int aux = rnd.Next(turnos.Length);
                player.color = turnos[aux];
                Label3.Text = player.color;
                Label4.Text = "Maquina";
                if (player.color == "blanco")
                {
                    Label6.Text = "Negro";
                }
                else
                {
                    Label6.Text = "Blanco";
                }
                actual = (Usuario)Session["Usuario"];
                Label1.Text = actual.NmUsuario;

                player.color = turnos[aux];
                string color = "";
                string x = "";
                int puntne = 0;
                int puntbl = 0;
                int y = -1;
                string tiro = "";
                //Label6.Text = "Cerro";
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        botones[i, j].Enabled = true;
                    }
                }
                //"C:\Users\Byron Alvarez\Desktop\Proyecto\Proyecto\Archivos" + FileUpload1.FileName
                XmlReader reader = XmlReader.Create(@"C:\Users\Byron Alvarez\Desktop\Proyectos\Proyecto\Proyecto\Archivos\" + FileUpload1.FileName);
                while (reader.Read())
                {
                    //Label6.Text = "si while";
                    if (reader.IsStartElement())
                    {
                        //return only when you have START tag  
                        switch (reader.Name.ToString())
                        {
                            case "color":
                                color = reader.ReadString();
                                tiro = color;
                                //Label1.Text = tiro;
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
                        try
                        {
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
                                    else if (ta[i, j].llenado == false)
                                    {
                                        botones[i, j].ImageUrl = ("stuff\\tans.png");
                                    }


                                }
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
                if (player.color == tiro)
                {
                    Label3.Text = player.color + "<-";
                }
                else
                {
                    Label6.Text = tiro + "<-";
                }
                reader.Close();
                tablero = ta;
                Session["scoren"] = puntne;
                Session["scoreb"] = puntbl;
                Session["tab"] = tablero;
                Session["botones"] = botones;
                //Bloqueo();
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
            //turnoactual = (string)Session["turnac"];
            
            //Label4.Text = turnoactual;
            ImageButton clickedButton = (ImageButton)sender;
            botones = (ImageButton[,])Session["botones"];
            tablero = (Ficaha[,])Session["tab"];
            
            if (turnoactual == "negro")
            {
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1, 2));
                tablero = (Ficaha[,])Session["tab"];
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "negro");
                nueva.llenado = true;
                MovimientoNegro((int)nueva.y, nueva.x1, nueva);
                
            }
            else if (turnoactual == "blanco")
            {
                idaux = clickedButton.ID;
                id = Int32.Parse(idaux.Substring(1, 2));
                tablero = (Ficaha[,])Session["tab"];
                Ficaha nueva = new Ficaha();
                nueva = Creacion(id, "blanco");
                nueva.llenado = true;
                MovimientoBlanco((int)nueva.y, nueva.x1, nueva);
                

            }
            Button3.Enabled = true;
            Session["botones"] = botones;
            Puntuaciones();
            VerificarJuego();

        }


        public Ficaha Creacion(int id, string color)
        {
            Ficaha nueva = new Ficaha();
            if (color == "negro")
            {
                nueva.color = "negro";

                nueva.y = Math.Floor((double)id / 8);
                int res = (id % 8) - 1;
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
                if (id == 8 | id == 16 | id == 24 | id == 32 | id == 40 | id == 48 | id == 56 | id == 64)
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

        public int leer(string a)
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
                        try
                        {
                            if (tablero[i, j].llenado == true && tablero[i, j].color == "blanco")
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
                        catch
                        {

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
                        try
                        {
                            if (tablero[i, j].llenado == true && tablero[i, j].color == "negro")
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
                        catch
                        {

                        }

                    }
                }
            }
        }

        public void MovimientoBlanco(int y, int x, Ficaha nueva)
        {

            int id;
            Boolean move = false;

            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    change = new List<Ficaha>();
                    try
                    {
                        if (i == y && j == x)
                        {

                        }
                        else if (tablero[i, j].color == "negro")
                        {
                            if (i == y - 1 && j == x - 1)
                            {
                                //Label3.Text = "UL";
                                move = RecursivoBlanco(i, j, "UL");
                            }
                            else if (i == y && j == x - 1)
                            {
                                //Label3.Text = "L";
                                move = RecursivoBlanco(i, j, "L");
                            }
                            else if (i == y + 1 && j == x - 1)
                            {
                                //Label3.Text = "DL";
                                move = RecursivoBlanco(i, j, "DL");
                            }
                            else if (i == y - 1 && j == x)
                            {
                                //Label3.Text = "U";
                                move = RecursivoBlanco(i, j, "U");
                            }
                            else if (i == y + 1 && j == x)
                            {
                                //Label3.Text = "D";
                                move = RecursivoBlanco(i, j, "D");
                            }
                            else if (i == y - 1 && j == x + 1)
                            {
                                //Label3.Text = "UR";
                                move = RecursivoBlanco(i, j, "UR");
                            }
                            else if (i == y && j == x + 1)
                            {
                                //Label3.Text = "R";
                                move = RecursivoBlanco(i, j, "R");
                            }
                            else if (i == y + 1 && j == x + 1)
                            {
                                //Label3.Text = "DR";
                                move = RecursivoBlanco(i, j, "DR");
                            }

                            if (move)
                            {
                                tablero[(int)nueva.y, nueva.x1] = nueva;
                                int auxi = change.Count;
                                for (int k = 0; k < auxi; k++)
                                {
                                    change[k].color = "blanco";
                                }
                                if (player.color == "blanco")
                                {
                                    
                                    Label6.Text = "Negro" + "<--";
                                    Label3.Text = "Blanco";
                                }
                                else if (player.color != "blanco")
                                {
                                    Label3.Text = "Negro" + "<--";
                                    Label6.Text = "Blanco";
                                }
                                if (player.color == turnoactual)
                                {
                                    string javaScript1 = "parar();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script1", javaScript1, true);
                                    string javaScript2 = "cronometrar2();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script2", javaScript2, true);
                                }
                                else
                                {
                                    string javaScript3 = "parar2();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script3", javaScript3, true);
                                    string javaScript4 = "cronometrar();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script4", javaScript4, true);
                                }
                                PintarBlanco();
                                turnoactual = "negro";
                                Session["tab"] = tablero;
                                Session["botones"] = botones;
                            }   
                            else
                            {
                                turnoactual = "blanco";

                            }

                        }
                    }
                    catch
                    {

                    }

                }
            }




        }

        public void MovimientoNegro(int y, int x, Ficaha nueva)
        {
            Boolean move = false;

            for (int i = y - 1; i <= y + 1; i++)
            {
                for (int j = x - 1; j <= x + 1; j++)
                {
                    change = new List<Ficaha>();
                    try
                    {
                        if (i == y && j == x)
                        {

                        }
                        else if (tablero[i, j].color == "blanco")
                        {
                            if (i == y - 1 && j == x - 1)
                            {
                                //Label3.Text = "UL";
                                move = RecursivoNegro(i, j, "UL");
                            }
                            else if (i == y && j == x - 1)
                            {
                                //Label3.Text = "L";
                                move = RecursivoNegro(i, j, "L");
                            }
                            else if (i == y + 1 && j == x - 1)
                            {
                                //Label3.Text = "DL";
                                move = RecursivoNegro(i, j, "DL");
                            }
                            else if (i == y - 1 && j == x)
                            {
                                //Label3.Text = "U";
                                move = RecursivoNegro(i, j, "U");
                            }
                            else if (i == y + 1 && j == x)
                            {
                                //Label3.Text = "D";
                                move = RecursivoNegro(i, j, "D");
                            }
                            else if (i == y - 1 && j == x + 1)
                            {
                                //Label3.Text = "UR";
                                move = RecursivoNegro(i, j, "UR");
                            }
                            else if (i == y && j == x + 1)
                            {
                                //Label3.Text = "R";
                                move = RecursivoNegro(i, j, "R");
                            }
                            else if (i == y + 1 && j == x + 1)
                            {
                                //Label3.Text = "DR";
                                move = RecursivoNegro(i, j, "DR");
                            }
                            if (move)
                            {
                                tablero[(int)nueva.y, nueva.x1] = nueva;
                                int auxi = change.Count;
                                for (int k = 0; k < auxi; k++)
                                {
                                    change[k].color = "negro";
                                }
                                if (player.color == "negro")
                                {
                                    Label6.Text = "Blanco" + "<--";
                                    Label3.Text = "Negro";
                                }
                                else if (player.color != "negro")
                                {
                                    Label3.Text = "Blanco" + "<--";
                                    Label6.Text = "Negro";
                                }
                                if (player.color == turnoactual)
                                {
                                    string javaScript1 = "parar();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script1", javaScript1, true);
                                    string javaScript2 = "cronometrar2();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script2", javaScript2, true);
                                }
                                else
                                {
                                    string javaScript3 = "parar2();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script3", javaScript3, true);
                                    string javaScript4 = "cronometrar();";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script4", javaScript4, true);
                                }
                                PintarNegro();
                                turnoactual = "blanco";
                                Session["tab"] = tablero;
                                Session["botones"] = botones;
                            }
                            else
                            {
                                turnoactual = "negro";
                            }
                        }
                    }
                    catch
                    {

                    }


                }
            }


        }

        public Boolean RecursivoBlanco(int y1, int x1, string D)
        {

            int y = y1;
            int x = x1;
            var posi = new Tuple<int, int>(y, x);


            Boolean moves = false;

            change.Add(tablero[posi.Item1, posi.Item2]);
            //Label5.Text = x.ToString();
            //Label4.Text = y.ToString();
            posi = Direction(posi.Item1, posi.Item2, D);

            if (tablero[posi.Item1, posi.Item2].color == "negro")
            {
                moves = RecursivoBlanco(posi.Item1, posi.Item2, D);
            }
            else if (tablero[posi.Item1, posi.Item2].color == "blanco")
            {
                moves = true;

            }
            else if (tablero[posi.Item1, posi.Item2].color == " ")
            {
                moves = false;
            }
            else
            {
                moves = false;
            }
            return moves;
        }

        public Boolean RecursivoNegro(int y1, int x1, string D)
        {
            int y = y1;
            int x = x1;
            var posi = new Tuple<int, int>(y, x);
            Boolean moves = false;

            change.Add(tablero[posi.Item1, posi.Item2]);
            //Label5.Text = x.ToString();
            //Label4.Text = y.ToString();
            posi = Direction(posi.Item1, posi.Item2, D);

            //System.Diagnostics.Debug.WriteLine(y.ToString() + "|" + x.ToString());
            if (tablero[posi.Item1, posi.Item2].color == "blanco")
            {
                moves = RecursivoNegro(posi.Item1, posi.Item2, D);
            }
            else if (tablero[posi.Item1, posi.Item2].color == "negro")
            {
                moves = true;

            }
            else if (tablero[posi.Item1, posi.Item2].color == " ")
            {
                moves = false;
            }
            else
            {
                moves = false;
            }
            return moves;
        }

        public Tuple<int, int> Direction(int y, int x, string D)
        {
            int y1 = y;
            int x1 = x;
            if (D == "UL")
            {
                x1 = x1 - 1;
                y1 = y1 - 1;
            }
            else if (D == "U")
            {
                y1 = y1 - 1;

            }
            else if (D == "UR")
            {
                x1 = x1 + 1;
                y1 = y1 - 1;
            }
            else if (D == "R")
            {
                x1 = x1 + 1;

            }
            else if (D == "L")
            {
                x1 = x1 - 1;

            }
            else if (D == "DL")
            {
                x1 = x1 - 1;
                y1 = y1 + 1;
            }
            else if (D == "D")
            {
                y1 = y1 + 1;

            }
            else if (D == "DR")
            {
                x1 = x1 + 1;
                y1 = y1 + 1;
            }

            var posi = new Tuple<int, int>(y1, x1);
            return posi;
        }

        public void PintarBlanco()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j].color == "blanco")
                    {
                        botones[i, j].ImageUrl = ("stuff\\blanca.jpg");
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

        public void VerificarJuego()
        {
            int verfi = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j].llenado == true)
                    {
                        verfi = verfi + 1;

                    }
                }
            }
            
            actual = (Usuario)Session["Usuario"];
            if (verfi == 64)
            {
                if (player.score > score2)
                {
                    string script = string.Format("alert('El jugador gano:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasGanadas += 1;
                    SQLcreationsWin();
                }
                else if(player.score < score2)
                {
                    string script = string.Format("alert('El jugador perdio:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasPerdidas += 1;
                    SQLcreationsLoose();

                }else if(player.score == score2)
                {
                    string script = string.Format("alert('El jugador empato:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasEmpatadas += 1;

                }
            }
            Session["Usuario"] = actual;




        }

        public void Puntuaciones()
        {
            player.score = 0;
            score2 = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (tablero[i, j].color == player.color)
                    {
                        player.score = player.score + 1;
                    }
                    else if (tablero[i, j].color != player.color && tablero[i, j].llenado == true)
                    {
                        score2 = score2 + 1;
                    }
                }
            }
            Label2.Text = player.score.ToString();
            Label5.Text = score2.ToString();
        }

        public void SQLcreationsWin()
        {
            this.conexion = Conexion.getConexion();
            Usuario actual = (Usuario)Session["Usuario"];
            SqlCommand comand = new SqlCommand();
            comand.Connection = conexion;
            comand.CommandText = "UPDATE Usuario set PartidasGanadas = @partidasganadas " +
                "where NombreUsuario = @nmusuario ;" ;
            comand.Parameters.AddWithValue("@nmusuario", actual.NmUsuario);
            comand.Parameters.AddWithValue("@partidasganadas", actual.PartidasGanadas);
            try
            {
                comand.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            Label8.Text = this.error;
        }

        public void SQLcreationsLoose()
        {
            this.conexion = Conexion.getConexion();
            Usuario actual = (Usuario)Session["Usuario"];
            SqlCommand comand = new SqlCommand();
            comand.Connection = conexion;
            comand.CommandText = "UPDATE Usuario set PartidasPerdidas = @partidasperdidas " +
                "where NombreUsuario = @nmusuario ;";
            comand.Parameters.AddWithValue("@nmusuario", actual.NmUsuario);
            comand.Parameters.AddWithValue("@partidasperdidas", actual.PartidasPerdidas);
            try
            {
                comand.ExecuteNonQuery();
                
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            Label8.Text = this.error;
        }

        public void SQLcreationsDraw()
        {
            this.conexion = Conexion.getConexion();
            Usuario actual = (Usuario)Session["Usuario"];
            SqlCommand comand = new SqlCommand();
            comand.Connection = conexion;
            comand.CommandText = "UPDATE Usuario set PartidasEmpatadas = @partidasempatadas " +
                "where NombreUsuario = @nmusuario ;";
            comand.Parameters.AddWithValue("@nmusuario", actual.NmUsuario);
            comand.Parameters.AddWithValue("@partidasempatadas", actual.PartidasEmpatadas);
            try
            {
                comand.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            Label8.Text = this.error;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            botones = (ImageButton[,])Session["botones"];
            tablero = (Ficaha[,])Session["tab"];
            actual = (Usuario)Session["Usuario"];
            int fill = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if(tablero[i,j].llenado == true)
                    {
                        fill += 1;
                    }
                }
            }
            if(fill == 63)
            {
                player.score = 0;
                score2 = 0;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (tablero[i, j].color == player.color)
                        {
                            player.score = player.score + 1;
                        }
                        else if (tablero[i, j].color != player.color && tablero[i, j].llenado == true)
                        {
                            score2 = score2 + 1;
                        }
                    }
                }
                if(player.score > score2)
                {
                    player.score += 1;
                    string script = string.Format("alert('El jugador gano:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
                else
                {
                    score2 += 1;
                    string script = string.Format("alert('El jugador perdio:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                }
            }
        }
    }
}