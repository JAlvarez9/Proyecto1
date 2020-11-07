using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;
using System.Xml;
using System.Data.SqlClient;
using System.Threading;

namespace Proyecto.Pages
{
    public partial class Multi2OXIn : System.Web.UI.Page
    {
        public string error;
        public SqlConnection conexion;
        Usuario actual = new Usuario();
        static Jugador player;
        static string[] turnos = new string[2];
        static string turnoactual = "";
        static Ficaha[,] tablero;
        static ImageButton[,] botones;
        static ImageButton[,] botones2;
        List<Ficaha> change;
        static int firstmoves = 0;
        Boolean apertura;
        public int columnas;
        public int fila;
        int enmedioX;
        int enmedioY;
        public Jugador1OX jugador1 = new Jugador1OX();
        public Jugador2OX jugador2 = new Jugador2OX();
        static int color1 = 0;
        static int color2 = 0;
        Boolean cargar;
        static int segundos1 = 0;
        static int segundos2 = 0;
        static int minutos1 = 0;
        static int minutos2 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            cargar = (Boolean)Session["cargar"];
            if (!IsPostBack)
            {
                minutos1 = 0;
                minutos2 = 0;
                segundos1 = 0;
                segundos2 = 0;
                Cronometro1.Enabled = false;
                Cronometro1.Enabled = false;
                if (cargar)
                {

                    columnas = (int)Session["columnas"];
                    fila = (int)Session["filas"];
                    jugador1 = (Jugador1OX)Session["jugador1"];
                    jugador2 = (Jugador2OX)Session["jugador2"];
                    tablero = (Ficaha[,])Session["tablero"];
                    apertura = (Boolean)Session["apertura"];
                    turnoactual = (string)Session["turnoactual"];
                    color1 = (int)Session["color1"];
                    color2 = (int)Session["color2"];
                    CreacionTableroCarga();
                }
                else
                {
                    columnas = (int)Session["columnas"];
                    fila = (int)Session["filas"];
                    apertura = (Boolean)Session["apertura"];
                    jugador1.colors = (List<string>)Session["colors1"];
                    jugador2.colors = (List<string>)Session["colors2"];
                    CreacionTablero();
                    Inicializacion();

                }

            }
            else
            {
                if (cargar)
                {
                    jugador1 = (Jugador1OX)Session["jugador1"];
                    jugador2 = (Jugador2OX)Session["jugador2"];
                    apertura = (Boolean)Session["apertura"];
                    columnas = (int)Session["columnas"];
                    fila = (int)Session["filas"];
                    MOdificacionTablero();
                }
                else
                {
                    jugador1.colors = (List<string>)Session["colors1"];
                    jugador2.colors = (List<string>)Session["colors2"];
                    apertura = (Boolean)Session["apertura"];
                    columnas = (int)Session["columnas"];
                    fila = (int)Session["filas"];
                    MOdificacionTablero();
                }



            }




        }

        public void Inicializacion()
        {
            color1 = 0;
            color2 = 0;
            player = new Jugador();
            turnos[0] = "player1";
            turnos[1] = "player2";
            Random rnd = new Random();
            int aux = rnd.Next(turnos.Length);
            player.color = turnos[aux];
            turnoactual = (string)Session["inicio"];
            Label4.Text = "Jugador2";

            for (int i = 0; i < jugador1.colors.Count; i++)
            {
                ListBox1.Items.Add(jugador1.colors[i]);
            }
            for (int i = 0; i < jugador2.colors.Count; i++)
            {
                ListBox2.Items.Add(jugador2.colors[i]);
            }


            if (turnoactual == "player1")
            {
                Cronometro1.Enabled = true;
                Cronometro2.Enabled = false;
                Label3.Text = jugador1.colors[color1] + "<--";
                Label6.Text = jugador2.colors[color2];
            }
            else if (turnoactual == "player2")
            {
                Cronometro1.Enabled = false;
                Cronometro2.Enabled = true;
                Label3.Text = jugador1.colors[color1];
                Label6.Text = jugador2.colors[color2] + "<--";
            }

            actual = (Usuario)Session["Usuario"];
            Label1.Text = actual.NmUsuario;
            jugador1.name = actual.NmUsuario;

            if (apertura)
            {
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        botones[i, j].Enabled = false;

                    }
                }
                enmedioX = (columnas / 2);
                enmedioY = (fila / 2);

                botones[enmedioY - 1, enmedioX - 1].Enabled = true;
                botones[enmedioY - 1, enmedioX].Enabled = true;
                botones[enmedioY, enmedioX - 1].Enabled = true;
                botones[enmedioY, enmedioX].Enabled = true;

            }
            else
            {
                enmedioX = (columnas / 2);
                enmedioY = (fila / 2);
                tablero[enmedioY - 1, enmedioX - 1].llenado = true;
                tablero[enmedioY - 1, enmedioX - 1].color = jugador1.colors[0];
                tablero[enmedioY - 1, enmedioX].llenado = true;
                tablero[enmedioY - 1, enmedioX].color = jugador2.colors[0];
                tablero[enmedioY, enmedioX - 1].llenado = true;
                tablero[enmedioY, enmedioX - 1].color = jugador2.colors[1];
                tablero[enmedioY, enmedioX].llenado = true;
                tablero[enmedioY, enmedioX].color = jugador1.colors[1];
                color1 += 2;
                color2 += 2;
                TurnosColores();
                if (turnoactual == "player1")
                {
                    Label3.Text = jugador1.colors[color1] + "<--";
                    Label6.Text = jugador2.colors[color2];
                }
                else if (turnoactual == "player2")
                {
                    Label3.Text = jugador1.colors[color1];
                    Label6.Text = jugador2.colors[color2] + "<--";
                }
            }
            PintarTablero();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ruta = TextBox1.Text;
            if (ruta == null | ruta == " ")
            {
                TextBox1.Text = "No coloco una ruta con el nombre del archivo";
            }

            XmlWriterSettings set = new XmlWriterSettings();
            set.Indent = true;
            string tiro = " ";
            if (turnoactual == "player1")
            {
                tiro = jugador1.colors[color1];
            }
            else if (turnoactual == "player2")
            {
                tiro = jugador2.colors[color2];
            }

            XmlWriter xmlWriter = XmlWriter.Create(@"" + ruta, set);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("partida");
            xmlWriter.WriteStartElement("filas");
            xmlWriter.WriteString(fila.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("columnas");
            xmlWriter.WriteString(columnas.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Jugador1");
            for (int i = 0; i < jugador1.colors.Count; i++)
            {
                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(jugador1.colors[i]);
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Jugador2");
            for (int i = 0; i < jugador2.colors.Count; i++)
            {
                xmlWriter.WriteStartElement("color");
                xmlWriter.WriteString(jugador2.colors[i]);
                xmlWriter.WriteEndElement();
            }
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("Modalidad");
            xmlWriter.WriteString("Normal");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteStartElement("tablero");
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (tablero[i, j].llenado == true)
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
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            botones = (ImageButton[,])Session["botones"];
            tablero = (Ficaha[,])Session["tab"];
            actual = (Usuario)Session["Usuario"];
            int fill = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (tablero[i, j].llenado == true)
                    {
                        fill += 1;
                    }
                }
            }
            if (fill == 63)
            {
                jugador1.score = 0;
                jugador2.score = 0;
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (jugador1.colors.Contains(tablero[i, j].color))
                        {
                            jugador1.score += 1;
                        }
                        else if (jugador2.colors.Contains(tablero[i, j].color))
                        {
                            jugador2.score += 1;
                        }
                    }
                }
                if (jugador1.score > jugador2.score)
                {
                    jugador1.score += 1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa gano');", true);
                }
                else if (jugador1.score < jugador2.score)
                {
                    jugador2.score += 1;
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa perdio');", true);
                }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (turnoactual == "player1")
            {
                Label3.Text = jugador1.colors[color1];
                Label6.Text = jugador2.colors[color2] + "<--";
                turnoactual = "player2";

            }
            else if (turnoactual == "player2")
            {
                Label3.Text = jugador1.colors[color1] + "<-";
                Label6.Text = jugador2.colors[color2];
                turnoactual = "player1";

            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            //clickedButton.ImageUrl = ("stuff/amarillo.jpg");
            if (firstmoves < 4 & apertura == true)
            {
                if (turnoactual == "player1")
                {
                    //Ficaha clicke;
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                tablero[i, j].llenado = true;
                                tablero[i, j].color = jugador1.colors[color1];
                            }
                        }
                    }
                    color1 += 1;
                    TurnosColores();
                    Label3.Text = jugador1.colors[color1];
                    Label6.Text = jugador2.colors[color2] + "<--";
                    turnoactual = "player2";
                    PintarTablero();
                }
                else if (turnoactual == "player2")
                {
                    //Ficaha clicke;
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                tablero[i, j].llenado = true;
                                tablero[i, j].color = jugador2.colors[color2];
                            }
                        }
                    }
                    color2 += 1;
                    TurnosColores();
                    Label3.Text = jugador1.colors[color1] + "<-";
                    Label6.Text = jugador2.colors[color2];
                    turnoactual = "player1";
                    PintarTablero();
                }
                firstmoves += 1;
                for (int i = 0; i < fila; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        botones[i, j].Enabled = false;
                    }
                }
                enmedioX = (columnas / 2);
                enmedioY = (fila / 2);
                botones[enmedioY - 1, enmedioX - 1].Enabled = true;
                botones[enmedioY - 1, enmedioX].Enabled = true;
                botones[enmedioY, enmedioX - 1].Enabled = true;
                botones[enmedioY, enmedioX].Enabled = true;
                if (firstmoves == 4)
                {
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            botones[i, j].Enabled = true;

                        }
                    }
                }
                Puntuaciones();

            }
            else
            {

                if (turnoactual == "player1")
                {
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                MovimientoPlayer1((int)tablero[i, j].y, tablero[i, j].x1, tablero[i, j]);
                            }
                        }
                    }

                }
                else if (turnoactual == "player2")
                {
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                MovimientoPlayer2((int)tablero[i, j].y, tablero[i, j].x1, tablero[i, j]);
                            }
                        }
                    }


                }
                Puntuaciones();
                VerificarJuego();

            }




        }

        public void MovimientoPlayer1(int y, int x, Ficaha nueva)
        {

            int id;
            Boolean move = false;
            Boolean next = false;

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
                        else if (jugador2.colors.Contains(tablero[i, j].color))
                        {
                            if (i == y - 1 && j == x - 1)
                            {
                                //Label3.Text = "UL";
                                move = RecursivoPlayer1(i, j, "UL");
                            }
                            else if (i == y && j == x - 1)
                            {
                                //Label3.Text = "L";
                                move = RecursivoPlayer1(i, j, "L");
                            }
                            else if (i == y + 1 && j == x - 1)
                            {
                                //Label3.Text = "DL";
                                move = RecursivoPlayer1(i, j, "DL");
                            }
                            else if (i == y - 1 && j == x)
                            {
                                //Label3.Text = "U";
                                move = RecursivoPlayer1(i, j, "U");
                            }
                            else if (i == y + 1 && j == x)
                            {
                                //Label3.Text = "D";
                                move = RecursivoPlayer1(i, j, "D");
                            }
                            else if (i == y - 1 && j == x + 1)
                            {
                                //Label3.Text = "UR";
                                move = RecursivoPlayer1(i, j, "UR");
                            }
                            else if (i == y && j == x + 1)
                            {
                                //Label3.Text = "R";
                                move = RecursivoPlayer1(i, j, "R");
                            }
                            else if (i == y + 1 && j == x + 1)
                            {
                                //Label3.Text = "DR";
                                move = RecursivoPlayer1(i, j, "DR");
                            }

                            if (move)
                            {
                                nueva.color = jugador1.colors[color1];
                                nueva.llenado = true;
                                tablero[(int)nueva.y, nueva.x1] = nueva;
                                int auxi = change.Count;
                                for (int k = 0; k < auxi; k++)
                                {
                                    change[k].color = jugador1.colors[color1];
                                }
                                next = true;

                                turnoactual = "player2";

                            }
                            else
                            {
                                //turnoactual = "blanco";

                            }

                        }
                    }
                    catch
                    {

                    }

                }
            }
            if (next)
            {
                Cronometro1.Enabled = false;
                Cronometro2.Enabled = true;
                color1 += 1;
                TurnosColores();
                PintarTablero();
                Label3.Text = jugador1.colors[color1];
                Label6.Text = jugador2.colors[color2] + "<--";
            }



        }

        public void MovimientoPlayer2(int y, int x, Ficaha nueva)
        {
            Boolean move = false;
            Boolean next = false;
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
                        else if (jugador1.colors.Contains(tablero[i, j].color))
                        {
                            if (i == y - 1 && j == x - 1)
                            {
                                //Label3.Text = "UL";
                                move = RecursivoPlayer2(i, j, "UL");
                            }
                            else if (i == y && j == x - 1)
                            {
                                //Label3.Text = "L";
                                move = RecursivoPlayer2(i, j, "L");
                            }
                            else if (i == y + 1 && j == x - 1)
                            {
                                //Label3.Text = "DL";
                                move = RecursivoPlayer2(i, j, "DL");
                            }
                            else if (i == y - 1 && j == x)
                            {
                                //Label3.Text = "U";
                                move = RecursivoPlayer2(i, j, "U");
                            }
                            else if (i == y + 1 && j == x)
                            {
                                //Label3.Text = "D";
                                move = RecursivoPlayer2(i, j, "D");
                            }
                            else if (i == y - 1 && j == x + 1)
                            {
                                //Label3.Text = "UR";
                                move = RecursivoPlayer2(i, j, "UR");
                            }
                            else if (i == y && j == x + 1)
                            {
                                //Label3.Text = "R";
                                move = RecursivoPlayer2(i, j, "R");
                            }
                            else if (i == y + 1 && j == x + 1)
                            {
                                //Label3.Text = "DR";
                                move = RecursivoPlayer2(i, j, "DR");
                            }
                            if (move)
                            {
                                nueva.color = jugador2.colors[color2];
                                nueva.llenado = true;
                                tablero[(int)nueva.y, nueva.x1] = nueva;
                                int auxi = change.Count;
                                for (int k = 0; k < auxi; k++)
                                {
                                    change[k].color = jugador2.colors[color2]; ;
                                }
                                next = true;

                                turnoactual = "player1";
                            }
                            else
                            {

                            }
                        }
                    }
                    catch
                    {

                    }


                }
            }
            if (next)
            {
                Cronometro1.Enabled = true;
                Cronometro2.Enabled = false;
                color2 += 1;
                TurnosColores();
                PintarTablero();
                Label3.Text = jugador1.colors[color1] + "<-";
                Label6.Text = jugador2.colors[color2];
            }

        }

        public Boolean RecursivoPlayer1(int y1, int x1, string D)
        {

            int y = y1;
            int x = x1;
            var posi = new Tuple<int, int>(y, x);


            Boolean moves = false;

            change.Add(tablero[posi.Item1, posi.Item2]);
            //Label5.Text = x.ToString();
            //Label4.Text = y.ToString();
            posi = Direction(posi.Item1, posi.Item2, D);

            if (jugador2.colors.Contains(tablero[posi.Item1, posi.Item2].color))
            {
                moves = RecursivoPlayer1(posi.Item1, posi.Item2, D);
            }
            else if (jugador1.colors.Contains(tablero[posi.Item1, posi.Item2].color))
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

        public Boolean RecursivoPlayer2(int y1, int x1, string D)
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
            if (jugador1.colors.Contains(tablero[posi.Item1, posi.Item2].color))
            {
                moves = RecursivoPlayer2(posi.Item1, posi.Item2, D);
            }
            else if (jugador2.colors.Contains(tablero[posi.Item1, posi.Item2].color))
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

        public void PintarTablero()
        {
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    switch (tablero[i, j].color)
                    {
                        case "blanco":
                            botones[i, j].ImageUrl = ("stuff/blanca.jpg");
                            break;
                        case "negro":
                            botones[i, j].ImageUrl = ("stuff/negra.jpg");
                            break;
                        case "rojo":
                            botones[i, j].ImageUrl = ("stuff/roja.jpg");
                            break;
                        case "amarillo":
                            botones[i, j].ImageUrl = ("stuff/amarillo.jpg");
                            break;
                        case "azul":
                            botones[i, j].ImageUrl = ("stuff/azul.jpg");
                            break;
                        case "anaranjado":
                            botones[i, j].ImageUrl = ("stuff/anaranjado.jpg");
                            break;
                        case "verde":
                            botones[i, j].ImageUrl = ("stuff/verde.jpg");
                            break;
                        case "violeta":
                            botones[i, j].ImageUrl = ("stuff/violeta.jpg");
                            break;
                        case "celeste":
                            botones[i, j].ImageUrl = ("stuff/celeste.jpg");
                            break;
                        case "gris":
                            botones[i, j].ImageUrl = ("stuff/gris.jpg");
                            break;
                    }

                }
            }
        }

        public void VerificarJuego()
        {
            int verfi = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
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
                if (jugador1.score < jugador2.score)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa gano');", true);
                    actual.PartidasGanadas += 1;
                    SQLcreationsWin();
                }
                else if (jugador1.score > jugador2.score)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa perdio');", true);
                    actual.PartidasPerdidas += 1;
                    SQLcreationsLoose();

                }
                else if (jugador1.score == jugador2.score)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Los jugadores empataron');", true);
                    actual.PartidasEmpatadas += 1;
                    SQLcreationsDraw();

                }
            }
            int j1 = 0;
            int j2 = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (jugador1.colors.Contains(tablero[i, j].color))
                    {
                        j1 += 1;

                    }
                    else if (jugador2.colors.Contains(tablero[i, j].color))
                    {
                        j2 += 1;
                    }
                }
            }
            if (j1 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa gana');", true);
                actual.PartidasPerdidas += 1;
                SQLcreationsLoose();

            }
            else if (j2 == 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('El jugador casa pierde');", true);
                actual.PartidasGanadas += 1;
                SQLcreationsWin();
            }
            Session["Usuario"] = actual;




        }

        public void Puntuaciones()
        {
            jugador1.score = 0;
            jugador2.score = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (jugador1.colors.Contains(tablero[i, j].color))
                    {
                        jugador1.score += 1;
                    }
                    else if (jugador2.colors.Contains(tablero[i, j].color))
                    {
                        jugador2.score += 1;
                    }
                }
            }
            Label2.Text = jugador1.score.ToString();
            Label5.Text = jugador2.score.ToString();
        }

        public void SQLcreationsWin()
        {
            this.conexion = Conexion.getConexion();
            Usuario actual = (Usuario)Session["Usuario"];
            SqlCommand comand = new SqlCommand();
            comand.Connection = conexion;
            comand.CommandText = "UPDATE Usuario set PartidasGanadas = @partidasganadas " +
                "where NombreUsuario = @nmusuario ;";
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
            Label10.Text = this.error;
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
            Label10.Text = this.error;
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
            Label10.Text = this.error;

        }

        public void CreacionTablero()
        {

            int cont = 0;
            string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };

            tablero = new Ficaha[fila, columnas];
            botones = new ImageButton[fila, columnas];
            TableRow first = new TableRow();
            TableCell fas = new TableCell();
            fas.Text = ".";
            fas.BorderWidth = 2;
            first.Cells.Add(fas);
            for (int i = 0; i < columnas; i++)
            {
                TableCell y = new TableCell();
                y.Text = abece[i];
                y.BorderWidth = 2;

                first.Cells.Add(y);
            }
            Table1.Rows.Add(first);
            for (int i = 0; i < fila; i++)
            {
                TableRow r = new TableRow();
                TableCell ias = new TableCell();
                ias.Text = (i + 1).ToString();
                ias.BorderWidth = 2;
                r.Cells.Add(ias);
                for (int j = 0; j < columnas; j++)
                {

                    TableCell niu = new TableCell();
                    niu.BorderWidth = 2;
                    ImageButton ibt = new ImageButton
                    {
                        ID = "i" + cont.ToString(),
                        ImageUrl = "stuff\\tans.png"
                    };
                    ibt.Click += new ImageClickEventHandler(ImageButton1_Click);
                    botones[i, j] = ibt;
                    Ficaha nueva = new Ficaha();
                    nueva.llenado = false;
                    nueva.x = abece[j];
                    nueva.x1 = j;
                    nueva.y = i;
                    tablero[i, j] = nueva;
                    niu.Controls.Add(ibt);
                    r.Cells.Add(niu);

                    cont++;
                }

                Table1.Rows.Add(r);

            }

        }

        public void MOdificacionTablero()
        {

            int cont = 0;
            string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };

            
            TableRow first = new TableRow();
            TableCell fas = new TableCell();
            fas.Text = ".";
            fas.BorderWidth = 2;
            first.Cells.Add(fas);
            for (int i = 0; i < columnas; i++)
            {
                TableCell y = new TableCell();
                y.Text = abece[i];
                y.BorderWidth = 2;

                first.Cells.Add(y);
            }
            Table1.Rows.Add(first);
            for (int i = 0; i < fila; i++)
            {
                TableRow r = new TableRow();
                TableCell ias = new TableCell();
                ias.Text = (i + 1).ToString();
                ias.BorderWidth = 2;
                r.Cells.Add(ias);
                for (int j = 0; j < columnas; j++)
                {

                    TableCell niu = new TableCell();
                    niu.BorderWidth = 2;
                    ImageButton ibt = new ImageButton
                    {
                        ID = "i" + cont.ToString(),
                        ImageUrl = "stuff\\tans.png"
                    };
                    ibt.Click += new ImageClickEventHandler(ImageButton1_Click);
                    botones[i, j] = ibt;
                    niu.Controls.Add(ibt);
                    r.Cells.Add(niu);


                    cont++;


                }

                Table1.Rows.Add(r);
                

            }
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    botones[i, j].Enabled = true;
                }
            }
            PintarTablero();
        }

        public void CreacionTableroCarga()
        {

            int cont = 0;
            string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };
            botones = new ImageButton[fila, columnas];
            TableRow first = new TableRow();
            TableCell fas = new TableCell();
            fas.Text = ".";
            fas.BorderWidth = 2;
            first.Cells.Add(fas);
            for (int i = 0; i < columnas; i++)
            {
                TableCell y = new TableCell();
                y.Text = abece[i];
                y.BorderWidth = 2;

                first.Cells.Add(y);
            }
            Table1.Rows.Add(first);
            for (int i = 0; i < fila; i++)
            {
                TableRow r = new TableRow();
                TableCell ias = new TableCell();
                ias.Text = (i + 1).ToString();
                ias.BorderWidth = 2;
                r.Cells.Add(ias);
                for (int j = 0; j < columnas; j++)
                {
                    tablero[i, j].x = abece[j];
                    tablero[i, j].x1 = j;
                    tablero[i, j].y = i;
                    TableCell niu = new TableCell();
                    niu.BorderWidth = 2;
                    ImageButton ibt = new ImageButton
                    {
                        ID = "i" + cont.ToString(),
                        ImageUrl = "stuff\\tans.png"
                    };
                    ibt.Click += new ImageClickEventHandler(ImageButton1_Click);
                    botones[i, j] = ibt;
                    niu.Controls.Add(ibt);
                    r.Cells.Add(niu);

                    cont++;
                }

                Table1.Rows.Add(r);

            }
            for (int i = 0; i < jugador1.colors.Count; i++)
            {
                ListBox1.Items.Add(jugador1.colors[i]);
            }
            for (int i = 0; i < jugador2.colors.Count; i++)
            {
                ListBox2.Items.Add(jugador2.colors[i]);
            }
            Label1.Text = jugador1.name;
            Label4.Text = jugador2.name;
            if (turnoactual == "player1")
            {
                Cronometro1.Enabled = true;
                Cronometro2.Enabled = false;
                Label3.Text = jugador1.colors[color1] + "<--";
                Label6.Text = jugador2.colors[color2];
            }
            else if (turnoactual == "player2")
            {
                Cronometro1.Enabled = false;
                Cronometro2.Enabled = true;
                Label3.Text = jugador1.colors[color1];
                Label6.Text = jugador2.colors[color2] + "<--";
            }
            Puntuaciones();
            PintarTablero();
        }

        public void TurnosColores()
        {
            if (color1 == jugador1.colors.Count)
            {
                color1 = 0;
            }
            if (color2 == jugador2.colors.Count)
            {
                color2 = 0;
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label7.Text = minutos1.ToString() + ':' + segundos1.ToString();
            segundos1 += 1;
            if (segundos1 > 59)
            {
                segundos1 = 0;
                minutos1 += 1;
            }
        }

        protected void Cronometro2_Tick(object sender, EventArgs e)
        {
            Label9.Text = minutos2.ToString() + ':' + segundos2.ToString();
            segundos2 += 1;
            if (segundos2 > 59)
            {
                segundos2 = 0;
                minutos2 += 1;
            }
        }
    }
}