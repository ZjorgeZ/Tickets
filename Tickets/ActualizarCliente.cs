using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class ActualizarCliente
    {
        Conexion conexion = new Conexion();

        public void ActualizarCli(int id, string nombre, string apellido, string cedula, string correo)
        {
            SqlCommand cmd = new SqlCommand("SP_actualizarCLiente", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@correo", correo);

            cmd.ExecuteNonQuery();
        }
    }
}
