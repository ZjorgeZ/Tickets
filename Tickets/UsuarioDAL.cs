using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{
    internal class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public void GuardarUsuario(string nombre, string email, string c, string correo)
        {
            SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion.AbrirConexion());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@apellido", apellido);
            cmd.Parameters.AddWithValue("@cedula", cedula);
            cmd.Parameters.AddWithValue("@correo", correo);

            cmd.ExecuteNonQuery();
        }
    }
}
}
