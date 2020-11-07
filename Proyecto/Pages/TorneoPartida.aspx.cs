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
                DropDownList7.Enabled = false;
                DropDownList8.Enabled = false;
                DropDownList9.Enabled = false;
                DropDownList10.Enabled = false;
                Button9.Enabled = false;
                Button10.Enabled = false;
            }
            else
            {

            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {

        }

        public void LlenarEquipo1()
        {
            Label1.Text = equipo1.jugadores[0].name;
            Label3.Text = equipo1.jugadores[1].name;
            Label5.Text = equipo1.jugadores[2].name;
            for(int i =0; i< equipo1.jugadores.Count; i++)
            {
                DropDownList7.Items.Add(equipo1.jugadores[i].name);
            }
        }
        public void LlenarEquipo2()
        {
            Label2.Text = equipo2.jugadores[0].name;
            Label4.Text = equipo2.jugadores[1].name;
            Label6.Text = equipo2.jugadores[2].name;
            for (int i = 0; i < equipo2.jugadores.Count; i++)
            {
                DropDownList8.Items.Add(equipo2.jugadores[i].name);
            }
        }
    }
}