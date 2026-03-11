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
    internal class UsuarioLogin
    {

        Conexion conexion = new Conexion();
        public bool LoginUsuario(string usuario, string contraseña)
        {


            {
                SqlCommand cmd = new SqlCommand("sp_LoginUsuario", conexion.AbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);
                cmd.Parameters.AddWithValue("@Contraseña", contraseña);

                //conexion.AbrirConexion().Open();
                int resultado = (int)cmd.ExecuteScalar();
                return resultado == 1;
            }
        }
    }
}
