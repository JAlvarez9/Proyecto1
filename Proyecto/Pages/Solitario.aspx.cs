using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Proyecto.App_Code;

namespace Proyecto.Pages
{
    public partial class Solitario : System.Web.UI.Page
    {
        Usuario actual = new Usuario();
        int numjugadas1 = 0;
        int numjugadas2 = 0;
        int score1 = 2;
        int score2 = 2;
        string[] turnos = new string[2];
        string turnoactual = "";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            turnos[0] = "blancas";
            turnos[1] = "negras";
            int aux = rnd.Next(turnos.Length);
            Label4.Text = aux.ToString();
            
            turnoactual = turnos[aux];
             Label2.Text = score1.ToString();
            actual = (Usuario)Session["Usuario"];
            



            Label1.Text = actual.NmUsuario;
            Label3.Text = numjugadas1.ToString();  
            Button3.Enabled = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label6.Text = "Cerro";
            //Button3.Enabled = true;
        }

        
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Label5.Text = turnoactual;
            ImageButton clickedButton = (ImageButton)sender;
            clickedButton.ImageUrl = ("stuff\\negra.jpg");
            //if (turnoactual == "negras") { 
                
                
            //    turnoactual = "blancas";
            //}
            //else if(turnoactual == "blancas")
            //{
                
            //    clickedButton.ImageUrl = ("stuff\\blanca.jpg");
            //    turnoactual = "negras";
            //}
        }

        
    }
}