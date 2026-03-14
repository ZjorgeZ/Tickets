using System;
using System.Windows.Forms;
using Tickets.Modelo;

public class ClienteService
{
    private readonly ClienteRepository repository;

    public ClienteService()
    {
        repository = new ClienteRepository();
    }

    public void EliminarCliente(int id, DataGridView dgv, Action limpiarCampos)
    {
        if (dgv.SelectedRows.Count == 0)
        {
            MessageBox.Show("Seleccione un cliente para eliminar");
            return;
        }

        repository.EliminarCliente(id);

        dgv.DataSource = repository.MostrarClientes();
        dgv.ClearSelection();

        limpiarCampos?.Invoke();

        MessageBox.Show("Cliente eliminado correctamente");
    }

    public void ActualizarCliente(Cliente cliente)
    {
        if (string.IsNullOrEmpty(cliente.Nombre) || string.IsNullOrEmpty(cliente.Apellido))
            throw new ArgumentException("Nombre y Apellido son obligatorios");

        repository.ActualizarCliente(cliente);
    }

    public void ActualizarTicket(int id, string descripcion)
    {
        if (string.IsNullOrEmpty(descripcion))
            throw new ArgumentException("La descripción no puede estar vacía");

        repository.ActualizarTicket(id, descripcion);
    }


}