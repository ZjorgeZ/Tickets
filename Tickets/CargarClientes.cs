using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets
{

    internal class CargarClientes
    {
        //Conexion conexion = new Conexion();
       

        Conexion conexion = new Conexion();

        public DataTable MostrarClientes()
        {
            SqlCommand cmd = new SqlCommand("ST_leer", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();

            da.Fill(tabla);

            return tabla;
        }
   
  
         public DataTable MostrarTickets()
        {
            SqlCommand cmd = new SqlCommand("SP_lticktes", conexion.AbrirConexion());
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();

            da.Fill(tabla);

            return tabla;
        }



    }

}
          
        
        
 
