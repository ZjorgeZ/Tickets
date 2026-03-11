using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class GuardarClientes
    {
        Conexion conexion = new Conexion();

        public void GuardarCliente(string nombre, string apellido, string cedula, string correo)
        {
            SqlCommand cmd = new SqlCommand("SP_guardar", conexion.AbrirConexion());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@correo", correo);

            cmd.ExecuteNonQuery();
        }
    }
}
