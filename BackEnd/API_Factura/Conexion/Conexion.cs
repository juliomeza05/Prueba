using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conexion
{
    public class Conexion
    {
        //cadena de conexion (Esto debe ser encriptado y tener situado en webConfig)
        private static string cadena = @"Data Source =192.168.1.3; Initial Catalog = Factura; User ID=julio;Password=admin";
        static SqlConnection conn;
        public static SqlConnection obtenerConexion()
        {
            conn = new SqlConnection(cadena);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }
    }
}
