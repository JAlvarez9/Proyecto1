using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.App_Code
{
    public class Usuario
    {
        private int idpersona; 
        private string nombres;
        private string apellidos;
        private string nmUsuario;
        private string contrasena;
        private DateTime nacimiento;
        private string pais;
        private string correo;
        private int partidasGanadas { get; set; }
        private int partidasPerdidas { get; set; }
        private int partidasEmpatadas { get; set; }
        private int torneosJugados { get; set; }
        private int torneosGanados { get; set; }
        private int torneosPerdidos { get; set; }


        public Usuario()
        {

        }
        public Usuario(string Nombres, string Apellidos, string NmUsuarios, string Contrasena, DateTime Nacimiento, string Pais, string Correo)
        {
            this.nombres = Nombres;
            this.apellidos = Apellidos;
            this.nmUsuario = NmUsuarios;
            this.contrasena = Contrasena;
            this.nacimiento = Nacimiento;
            this.pais = Pais;
            this.correo = Correo;
           
        }
        public int Idpersona {
            get { return idpersona; }
            set { idpersona = value; }
        }
        public string Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string NmUsuario
        {
            get { return nmUsuario; }
            set { nmUsuario = value; }
        }
        public string Contrasena
        {
            get { return contrasena; }
            set { contrasena = value; }
        }
        public DateTime Nacimiento
        {
            get { return nacimiento; }
            set { nacimiento = value; }
        }
        public string Pais
        {
            get { return pais; }
            set { pais = value; }
        }
        public string Correo
        {
            get { return correo; }
            set { correo = value; }
        }

    }
}