using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
