using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
        internal class EliminarClientes
    {
        Conexion conexion = new Conexion();

        public void EliminarCliente(int id)
        {
            SqlCommand cmd = new SqlCommand("SP_eliminar", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public static void EliminarTck0(int id)
        {
            Conexion conexion = new Conexion();
            SqlCommand cmd = new SqlCommand("SP_Tisket0", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);


            cmd.ExecuteNonQuery();
        }


    }
}
