using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.Data
{
  
        public class BuscarCliente
        {
            Conexion conexion = new Conexion();

            public SqlDataReader BuscarCli(int? id, string nombre, string correo)
            {
                SqlCommand cmd = new SqlCommand("SP_BuscarCliente", conexion.AbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", (object)id ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", string.IsNullOrEmpty(nombre) ? (object)DBNull.Value : nombre);
                cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(correo) ? (object)DBNull.Value : correo);

                SqlDataReader reader = cmd.ExecuteReader();
                return reader; // devolvemos el reader directamente
            }
        }


    
}
