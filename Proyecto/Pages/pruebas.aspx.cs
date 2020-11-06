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
    public partial class pruebas : System.Web.UI.Page
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
        static ImageButton[,] botones;
        static ImageButton[,] botones2;
        List<Ficaha> change;
        public int columnas = 6;
        public int fila = 6;
        static int firstmoves = 0;
        int enmedioX;
        int enmedioY;
        static int segundos = 0;
        static int minutos = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CreacionTablero();
            }
            else
            {
                MOdificacionTablero();
            }
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //CreacionTablero();

            player = new Jugador();
            turnos[0] = "blanco";
            turnos[1] = "negro";
            Random rnd = new Random();
            int aux = rnd.Next(turnos.Length);
            player.color = turnos[aux];
            turnoactual = "negro";
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




            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    botones[i, j].Enabled = false;
                    
                }
            }
            enmedioX = (columnas/2);
            enmedioY = (fila/2);
            
            botones[enmedioY-1, enmedioX-1].Enabled = true;
            botones[enmedioY - 1, enmedioX].Enabled = true;
            botones[enmedioY, enmedioX-1].Enabled = true;
            botones[enmedioY, enmedioX].Enabled = true;
            Label1.Text = actual.NmUsuario;

        }
        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            
            ImageButton clickedButton = (ImageButton)sender;
            
            if (firstmoves < 4)
            {
                if (turnoactual == "negro")
                {
                    //Ficaha clicke;
                    for(int i = 0; i < fila; i++)
                    {
                        for(int j = 0; j<columnas; j++)
                        {
                            if(clickedButton.ID == botones[i, j].ID)
                            {
                                tablero[i, j].llenado = true;
                                tablero[i, j].color = "negro";
                            }
                        }
                    }
                    
                    if (player.color == "negro")
                    {
                        Cronometro1.Enabled = false;
                        Label6.Text = "Blanco" + "<--";
                        Label3.Text = "Negro";
                    }
                    else if (player.color != "negro")
                    {
                        Cronometro1.Enabled = true;
                        Label3.Text = "Blanco" + "<--";
                        Label6.Text = "Negro";
                    }
                    turnoactual = "blanco";
                    PintarNegro();
                }
                else if (turnoactual == "blanco")
                {
                    //Ficaha clicke;
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                tablero[i, j].llenado = true;
                                tablero[i, j].color = "blanco";
                            }
                        }
                    }
                    if (player.color == "blanco")
                    {
                        Cronometro1.Enabled = false;
                        Label6.Text = "Negro" + "<--";
                        Label3.Text = "Blanco";
                    }
                    else if (player.color != "blanco")
                    {
                        Cronometro1.Enabled = true;
                        Label3.Text = "Negro" + "<--";
                        Label6.Text = "Blanco";
                    }
                    turnoactual = "negro";
                    PintarBlanco();
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
            }
            else
            {

                if (turnoactual == "negro")
                {
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                //tablero[i, j].llenado = true;
                                //tablero[i, j].color = "negro";
                                MovimientoNegro((int)tablero[i,j].y, tablero[i, j].x1, tablero[i, j]);
                            }
                        }
                    }
                    
                    

                    //Session["turnac"] = "blanco";

                }
                else if (turnoactual == "blanco")
                {
                    for (int i = 0; i < fila; i++)
                    {
                        for (int j = 0; j < columnas; j++)
                        {
                            if (clickedButton.ID == botones[i, j].ID)
                            {
                                //tablero[i, j].llenado = true;
                                //tablero[i, j].color = "blanco";
                                MovimientoBlanco((int)tablero[i, j].y, tablero[i, j].x1, tablero[i, j]);
                            }
                        }
                    }
                    

                }
                
            }
            Puntuaciones();


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
                                nueva.color = "blanco";
                                nueva.llenado = true;
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
                                PintarBlanco();
                                turnoactual = "negro";
                                
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
                                nueva.color = "negro";
                                nueva.llenado = true;
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
                                PintarNegro();
                                turnoactual = "blanco";
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
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
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
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
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
                if (player.score > score2)
                {
                    string script = string.Format("alert('El jugador gano:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasGanadas += 1;
                    SQLcreationsWin();
                }
                else if (player.score < score2)
                {
                    string script = string.Format("alert('El jugador perdio:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasPerdidas += 1;
                    SQLcreationsLoose();

                }
                else if (player.score == score2)
                {
                    string script = string.Format("alert('El jugador empato:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasEmpatadas += 1;

                }
            }
            int white = 0;
            int black = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (tablero[i, j].color == "blanco")
                    {
                        white += 1;

                    }
                    else if (tablero[i, j].color == "negro")
                    {
                        black += 1;
                    }
                }
            }
            if (white == 0)
            {
                if (player.color == "blanco")
                {
                    string script = string.Format("alert('El jugador gano:{0}');", actual.NmUsuario);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", script, true);
                    actual.PartidasGanadas += 1;
                    //SQLcreationsWin();
                }
                else
                {
                    string script = string.Format("alert('El jugador perdio:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasPerdidas += 1;
                    //SQLcreationsLoose();
                }
            }
            else if (black == 0)
            {
                if (player.color == "negro")
                {
                    string script = string.Format("alert('El jugador gano:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasGanadas += 1;
                    //SQLcreationsWin();
                }
                else
                {
                    string script = string.Format("alert('El jugador perdio:{0}');", actual.NmUsuario);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                    actual.PartidasPerdidas += 1;
                    //SQLcreationsLoose();
                }
            }
            Session["Usuario"] = actual;




        }

        public void Puntuaciones()
        {
            player.score = 0;
            score2 = 0;
            for (int i = 0; i < fila; i++)
            {
                for (int j = 0; j < columnas; j++)
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
                    if (tablero[i, j].llenado == true)
                    {
                        fill += 1;
                    }
                }
            }
            if (fill == 63)
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
                if (player.score > score2)
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

        public void CreacionTablero()
        {
            
            int cont = 0;
            string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };
            //columnas = Int32.Parse(TextBox1.Text);
            //fila = Int32.Parse(TextBox2.Text);
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
                    ListItem li = new ListItem(ibt.ID, cont.ToString()); ;
                    //DropDownList1.Items.Add(li);
                    //Page.Controls.Add(ibt);
                    cont++;
                    

                }
                
                Table1.Rows.Add(r);
                
            }
            
        }

        public void MOdificacionTablero()
        {

            int cont = 0;
            string[] abece = new string[20] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "U" };
            //columnas = Int32.Parse(TextBox1.Text);
            //fila = Int32.Parse(TextBox2.Text);
            
            botones2 = new ImageButton[fila, columnas];
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
                    botones2[i, j] = ibt;
                    niu.Controls.Add(ibt);
                    r.Cells.Add(niu);
                    ListItem li = new ListItem(ibt.ID, cont.ToString()); ;
                    //DropDownList1.Items.Add(li);
                    //Page.Controls.Add(ibt);
                    cont++;


                }

                Table1.Rows.Add(r);
                botones2 = botones;


            }

        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label9.Text = minutos.ToString() + ":" + segundos.ToString();
            segundos += 1;
            if (segundos > 59)
            {
                segundos = 0;
                minutos += 1;
            }
        }
       

        protected void Button7_Click1(object sender, EventArgs e)
        {
            Cronometro1.Enabled = true;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            Cronometro1.Enabled = false;
        }
    }
}