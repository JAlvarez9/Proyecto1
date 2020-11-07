using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;

namespace Proyecto.Pages
{
    public partial class TorneoPartida : System.Web.UI.Page
    {
        EquiposT equipo1;
        EquiposT equipo2;
        string tipo;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                equipo1 = (EquiposT)Session["equipo1"];
                equipo2 = (EquiposT)Session["equipo2"];
                tipo = (string)Session["tipo"];
                LlenarEquipo1();
                LlenarEquipo2();
                
            }
            else
            {
                equipo1 = (EquiposT)Session["equipo1"];
                equipo2 = (EquiposT)Session["equipo2"];
                tipo = (string)Session["tipo"];
            }
        }

        protected void Button_Comprobar(object sender, EventArgs e)
        {
            Torneos torneo = (Torneos)Session["torneo"];
            switch (tipo)
            {
                case "octavos":
                    if(equipo1.score > equipo2.score)
                    {
                        torneo.cuartos.Add(equipo1);
                    }else if(equipo1.score < equipo2.score)
                    {
                        torneo.cuartos.Add(equipo2);

                    }
                    break;
                case "cuartos":
                    if (equipo1.score > equipo2.score)
                    {
                        torneo.semis.Add(equipo1);
                    }
                    else if (equipo1.score < equipo2.score)
                    {
                        torneo.semis.Add(equipo2);

                    }
                    break;
                case "semis":
                    if (equipo1.score > equipo2.score)
                    {
                        torneo.final.Add(equipo1);
                    }
                    else if (equipo1.score < equipo2.score)
                    {
                        torneo.final.Add(equipo2);

                    }
                    break;
            }
            Session["torneo"] = torneo;
            Response.Redirect("Torneo2.aspx");
        }

        public void LlenarEquipo1()
        {
            Label1.Text = equipo1.jugadores[0].name;
            Label3.Text = equipo1.jugadores[1].name;
            Label5.Text = equipo1.jugadores[2].name;
            Label7.Text = equipo1.score.ToString();
            for (int i =0; i< equipo1.jugadores.Count; i++)
            {
                DropDownList7.Items.Add(equipo1.jugadores[i].name);
            }
            
        }
        public void LlenarEquipo2()
        {
            Label2.Text = equipo2.jugadores[0].name;
            Label4.Text = equipo2.jugadores[1].name;
            Label6.Text = equipo2.jugadores[2].name;
            Label8.Text = equipo2.score.ToString();
            for (int i = 0; i < equipo2.jugadores.Count; i++)
            {
                DropDownList8.Items.Add(equipo2.jugadores[i].name);
            }
        }

        protected void Button2_Play(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            switch (clickedButton.ID)
            {
                case "Button2":
                    Session["jugador1"] = equipo1.jugadores[0];
                    Session["jugador2"] = equipo2.jugadores[0];
                    Response.Redirect("JuegoTorneo.aspx");
                    break;

                case "Button4":
                    Session["jugador1"] = equipo1.jugadores[1];
                    Session["jugador2"] = equipo2.jugadores[1];
                    Response.Redirect("JuegoTorneo.aspx");
                    break;

                case "Button6":
                    Session["jugador1"] = equipo1.jugadores[2];
                    Session["jugador2"] = equipo2.jugadores[3];
                    Response.Redirect("JuegoTorneo.aspx");
                    break;
                case "Button9":
                    string name = DropDownList7.SelectedValue;
                    string name2 = DropDownList8.SelectedValue;
                    foreach(JugadoresT jug in equipo1.jugadores)
                    {
                        if(name == jug.name)
                        {
                            Session["jugador1"] = jug;
                        }
                    }
                    foreach (JugadoresT jug in equipo2.jugadores)
                    {
                        if (name2 == jug.name)
                        {
                            Session["jugador2"] = jug;
                        }
                    }
                    Response.Redirect("JuegoTorneo.aspx");
                    break;
                    
            }

        }
        
        protected void Button3_Simular(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            switch (clickedButton.ID)
            {
                case "Button3":
                    if (RadioButton1.Checked)
                    {
                        equipo1.jugadores[0].pts += 3;
                        
                        equipo1.score += 3;
                    }
                    else if (RadioButton2.Checked)
                    {
                        equipo1.jugadores[0].pts += 1;
                        equipo2.jugadores[0].pts += 1;
                        equipo1.score += 1;
                        equipo2.score += 1;
                    }
                    else if (RadioButton3.Checked)
                    {
                        equipo2.jugadores[0].pts += 3;
                        
                        equipo2.score += 3;
                    }
                    break;

                case "Button5":
                    if (RadioButton4.Checked)
                    {
                        equipo1.jugadores[1].pts += 3;

                        equipo1.score += 3;
                    }
                    else if (RadioButton5.Checked)
                    {
                        equipo1.jugadores[1].pts += 1;
                        equipo2.jugadores[1].pts += 1;
                        equipo1.score += 1;
                        equipo2.score += 1;
                    }
                    else if (RadioButton6.Checked)
                    {
                        equipo2.jugadores[1].pts += 3;

                        equipo2.score += 3;
                    }
                    break;

                case "Button7":
                    if (RadioButton7.Checked)
                    {
                        equipo1.jugadores[2].pts += 3;

                        equipo1.score += 3;
                    }
                    else if (RadioButton8.Checked)
                    {
                        equipo1.jugadores[2].pts += 1;
                        equipo2.jugadores[2].pts += 1;
                        equipo1.score += 1;
                        equipo2.score += 1;
                    }
                    else if (RadioButton9.Checked)
                    {
                        equipo2.jugadores[2].pts += 3;

                        equipo2.score += 3;
                    }
                    break;
                case "Button10":

                    break;
            }
            Label7.Text = equipo1.score.ToString();
            Label8.Text = equipo2.score.ToString();
        }
    }
}