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


        public void GuardarTickets(string descripcion, int id_cliente)
        {
            SqlCommand cmd = new SqlCommand("SP_guardarT", conexion.AbrirConexion());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.Parameters.AddWithValue("@id_cliente", id_cliente);
       

            cmd.ExecuteNonQuery();
        }


        public void GuardarUsuario(string nombre, string email, string usuario, string contraseña)
        {
            SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", conexion.AbrirConexion());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nombre", nombre);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@contraseña", contraseña);


            cmd.ExecuteNonQuery();
        }
    }
}
