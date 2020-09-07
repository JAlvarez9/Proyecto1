using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Proyecto.App_Code
{
    
    public class Gestionar
    {
        public SqlConnection conexion;
        public SqlTransaction transi;
        public string error;

        public Gestionar()
        {
            this.conexion = Conexion.getConexion();
        }

        public bool agregar(Usuario nuevo)
        {
            bool agregar = false;
            SqlCommand comand = new SqlCommand();
            comand.Connection = conexion;
            comand.CommandText = "insert into UsuariosR values(@nombres, @apellidos, @nmusuarios, @contra, @naci, @pais, @correo)";
            
            comand.Parameters.AddWithValue("@nombres", nuevo.Nombres);
            comand.Parameters.AddWithValue("@apellidos", nuevo.Apellidos);
            comand.Parameters.AddWithValue("@nmusuarios", nuevo.NmUsuario);
            comand.Parameters.AddWithValue("@contra", nuevo.Contrasena);
            comand.Parameters.AddWithValue("@naci", nuevo.Nacimiento);
            comand.Parameters.AddWithValue("@pais", nuevo.Pais);
            comand.Parameters.AddWithValue("@correo", nuevo.Correo);
            try
            {
                
                comand.ExecuteNonQuery();
                
                
                agregar = true;
            }
            catch (SqlException ex)
            {
                this.error = ex.Message;
            }
            return agregar;

        }

        public Usuario consultapersona(string nmusuario)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandText = "select * from UsuariosR where NombreUsuario = @nmusua ";
            comando.Parameters.AddWithValue("@nmusua",nmusuario);
            SqlDataReader regis = comando.ExecuteReader();
            if (regis.Read())
            {
                Usuario llamar = new Usuario();
                llamar.Idpersona = regis.GetInt32(0);
                llamar.Nombres = regis.GetString(1);
                llamar.Apellidos = regis.GetString(2);
                llamar.NmUsuario = regis.GetString(3);
                llamar.Contrasena = regis.GetString(4);
                llamar.Nacimiento = regis.GetDateTime(5);
                llamar.Pais = regis.GetString(6);
                llamar.Correo = regis.GetString(7);
                regis.Close();
                return llamar;

            }
            else
            {
                regis.Close();
                return null;
            }

        }
    }
}