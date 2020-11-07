using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto.App_Code;

namespace Proyecto.Pages
{
    public partial class Torneo2 : System.Web.UI.Page
    {
        static Torneos torneo = new Torneos();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                torneo = (Torneos)Session["torneo"];
                ColocarImagen();
                ColocarLabels();
            }
            else
            {
                torneo = (Torneos)Session["torneo"];
            }
        }

        protected void Button_Octavos(object sender, EventArgs e)
        {
            Button clickButton =(Button)sender;
            
            switch (clickButton.ID)
            {
                case "Button1":
                    Session["equipo1"] = torneo.octavos[0];
                    Session["equipo2"] = torneo.octavos[1];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button2":
                    Session["equipo1"] = torneo.octavos[2];
                    Session["equipo2"] = torneo.octavos[3];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button3":
                    Session["equipo1"] = torneo.octavos[4];
                    Session["equipo2"] = torneo.octavos[5];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button4":
                    Session["equipo1"] = torneo.octavos[6];
                    Session["equipo2"] = torneo.octavos[7];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button5":
                    Session["equipo1"] = torneo.octavos[8];
                    Session["equipo2"] = torneo.octavos[9];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button6":
                    Session["equipo1"] = torneo.octavos[10];
                    Session["equipo2"] = torneo.octavos[11];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button7":
                    Session["equipo1"] = torneo.octavos[12];
                    Session["equipo2"] = torneo.octavos[13];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button8":
                    Session["equipo1"] = torneo.octavos[14];
                    Session["equipo2"] = torneo.octavos[15];
                    Session["tipo"] = "octavos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
            }
        }

        protected void Button_Cuartos(object sender, EventArgs e)
        {
            for (int i = 0; i < torneo.cuartos.Count; i++)
            {
                torneo.cuartos[i].score = 0;
            }
            Button clickButton = (Button)sender;
            switch (clickButton.ID)
            {
                case "Button9":
                    Session["equipo1"] = torneo.cuartos[0];
                    Session["equipo2"] = torneo.cuartos[1];
                    Session["tipo"] = "cuartos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button10":
                    Session["equipo1"] = torneo.cuartos[2];
                    Session["equipo2"] = torneo.cuartos[3];
                    Session["tipo"] = "cuartos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button11":
                    Session["equipo1"] = torneo.cuartos[4];
                    Session["equipo2"] = torneo.cuartos[5];
                    Session["tipo"] = "cuartos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button12":
                    Session["equipo1"] = torneo.cuartos[6];
                    Session["equipo2"] = torneo.cuartos[7];
                    Session["tipo"] = "cuartos";
                    Response.Redirect("TorneoPartida.aspx");
                    break;

            }
        }

        protected void Button_Semis(object sender, EventArgs e)
        {
            for (int i = 0; i < torneo.semis.Count; i++)
            {
                torneo.semis[i].score = 0;
            }
            Button clickButton = (Button)sender;
            switch (clickButton.ID)
            {
                case "Button13":
                    Session["equipo1"] = torneo.semis[0];
                    Session["equipo2"] = torneo.semis[1];
                    Session["tipo"] = "semis";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
                case "Button14":
                    Session["equipo1"] = torneo.semis[2];
                    Session["equipo2"] = torneo.semis[3];
                    Session["tipo"] = "semis";
                    Response.Redirect("TorneoPartida.aspx");
                    break;
               

            }

        }
        protected void Button_Final(object sender, EventArgs e)
        {
            for (int i = 0; i < torneo.final.Count; i++)
            {
                torneo.final[i].score = 0;
            }
            Session["equipo1"] = torneo.final[0];
            Session["equipo2"] = torneo.final[1];
            Session["tipo"] = "final";
            Response.Redirect("TorneoPartida.aspx");
        }
        public void ColocarImagen()
        {
            switch (torneo.equipos.Count)
            {
                case 16:
                    Image1.ImageUrl = ("stuff/t16.jpg");
                    break;
                case 8:
                    Image1.ImageUrl = ("stuff/t8.jpg");
                    break;
                case 4:
                    Image1.ImageUrl = ("stuff/t4.jpg");
                    break;
                    
            }

            for(int i = 0; i< torneo.equipos.Count;i++)
            {
                DropDownList1.Items.Add("Equipo"+(i+1).ToString()+"-"+torneo.equipos[i].name);
            }

        }

        public void ColocarLabels()
        {
            switch (torneo.equipos.Count)
            {
                case 16:
                    Octavos();
                    if (torneo.cuartos.Count == 8)
                    {
                        Cuartos();
                        if(torneo.semis.Count == 4)
                        {
                            Semis();
                            if(torneo.final.Count == 2)
                            {
                                Final();
                            }
                        }
                    }
                    break;
                case 8:
                    Cuartos();
                    if(torneo.semis.Count == 4)
                    {
                        Semis();
                        if (torneo.final.Count == 2)
                        {
                            Final();
                        }
                    }
                    break;
                case 4:
                    Semis();
                    if (torneo.final.Count == 2)
                    {
                        Final();
                    }
                    break;

            }
        }

        public void Octavos()
        {
            Label1.Text = torneo.octavos[0].name + " vs " + torneo.octavos[1].name;
            Label2.Text = torneo.octavos[2].name + " vs " + torneo.octavos[3].name;
            Label3.Text = torneo.octavos[4].name + " vs " + torneo.octavos[5].name;
            Label4.Text = torneo.octavos[6].name + " vs " + torneo.octavos[7].name;
            Label5.Text = torneo.octavos[8].name + " vs " + torneo.octavos[9].name;
            Label6.Text = torneo.octavos[10].name + " vs " + torneo.octavos[11].name;
            Label7.Text = torneo.octavos[12].name + " vs " + torneo.octavos[13].name;
            Label8.Text = torneo.octavos[14].name + " vs " + torneo.octavos[15].name;
        }

        public void Cuartos()
        {
            Label9.Text = torneo.cuartos[0].name + " vs " + torneo.cuartos[1].name;
            Label10.Text = torneo.cuartos[2].name + " vs " + torneo.cuartos[3].name;
            Label11.Text = torneo.cuartos[4].name + " vs " + torneo.cuartos[5].name;
            Label12.Text = torneo.cuartos[6].name + " vs " + torneo.cuartos[7].name;
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;

        }

        public void Semis()
        {
            Label13.Text = torneo.semis[0].name + " vs " + torneo.semis[1].name;
            Label14.Text = torneo.semis[2].name + " vs " + torneo.semis[3].name;
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;
            Button10.Enabled = false;
            Button11.Enabled = false;
            Button12.Enabled = false;
        }

        public void Final()
        {
            Label15.Text = torneo.equipos[0].name + " vs " + torneo.equipos[1].name;
            Button1.Enabled = false;
            Button2.Enabled = false;
            Button3.Enabled = false;
            Button4.Enabled = false;
            Button5.Enabled = false;
            Button6.Enabled = false;
            Button7.Enabled = false;
            Button8.Enabled = false;
            Button9.Enabled = false;
            Button10.Enabled = false;
            Button11.Enabled = false;
            Button12.Enabled = false;
            Button13.Enabled = false;
            Button14.Enabled = false;
        }

    }
}