using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.App_Code
{
    public class EquiposT
    {
        public string name;
        public List<JugadoresT> jugadores = new List<JugadoresT>();
        Boolean vivo;
        public int score =0;
        public EquiposT()
        {

        }
    }
}