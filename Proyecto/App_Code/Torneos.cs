using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.App_Code
{
    public class Torneos
    {
        public List<EquiposT> equipos = new List<EquiposT>();
        public List<EquiposT> octavos = new List<EquiposT>();
        public List<EquiposT> cuartos = new List<EquiposT>();
        public List<EquiposT> semis = new List<EquiposT>();
        public List<EquiposT> final = new List<EquiposT>();
        public string name;
        public Torneos()
        {

        }

    }
}