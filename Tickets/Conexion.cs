using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class Conexion
    {
        private string cadena = "Server=TOR-ITM-03\\SQLEXPRESS;Database=DB;Trusted_Connection=True;TrustServerCertificate=true";

        public SqlConnection AbrirConexion()
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            return cn;
        }


    }
}
