using System.Data;
using System.Data.SqlClient;
using Tickets;
using Tickets.Modelo;

public class ClienteRepository
{
    private readonly Conexion conexion;

    public ClienteRepository()
    {
        conexion = new Conexion();
    }

    public void EliminarCliente(int id)
    {
        using (SqlCommand cmd = new SqlCommand("SP_eliminar", conexion.AbrirConexion()))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }

    public DataTable MostrarClientes()
    {
        using (SqlCommand cmd = new SqlCommand("ST_leer", conexion.AbrirConexion()))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

    public void ActualizarCliente(Cliente cliente)
    {
        using (SqlCommand cmd = new SqlCommand("SP_actualizarCLiente", conexion.AbrirConexion()))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", cliente.Id);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@apellido", cliente.Apellido);
            cmd.Parameters.AddWithValue("@cedula", cliente.Cedula);
            cmd.Parameters.AddWithValue("@correo", cliente.Correo);

            cmd.ExecuteNonQuery();
        }
    }

    public void ActualizarTicket(int id, string descripcion)
    {
        using (SqlCommand cmd = new SqlCommand("SP_UpTickets", conexion.AbrirConexion()))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@descripcion", descripcion);
            cmd.ExecuteNonQuery();
        }
    }


}