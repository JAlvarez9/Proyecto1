using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

//Se obtuvo la ayuda pra realizarlo del siguiente link https://www.youtube.com/watch?v=4izXx3TfS2w
namespace Proyecto.App_Code
{
    public class Conexion
    {
        

        private static SqlConnection objconect;
        private static string bad;

        public static SqlConnection getConexion()
        {
            if (objconect != null)
                return objconect;
            objconect = new SqlConnection();
            objconect.ConnectionString = "Data Source=DESKTOP-KB0REKE\\SQLEXPRESS; Initial Catalog= ProyectoIPC2_Fase1; Integrated Security=True";
            try
            {
                objconect.Open();
                return objconect;
            }
            catch(Exception e)
            {
                bad = e.Message;
                return null;
            }
        }

        public static void Cerrar()
        {
            if (objconect != null)
                objconect.Close();
        }
    }
}