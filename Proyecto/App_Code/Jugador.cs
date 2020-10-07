using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.App_Code
{
    public class Jugador
    {
        public string name { get; set; }

        public string color { get; set; }

        public int score { get; set; }

        public int moves { get; set; }

        public Boolean win { get; set; }

        public Jugador()
        {

        }
    }
}