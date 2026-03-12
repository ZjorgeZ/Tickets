using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets
{
    public partial class Tickets : Form
    {
        CargarClientes objClientes = new CargarClientes();
        GuardarClientes cliente = new GuardarClientes();
        EliminarClientes eliminar = new EliminarClientes();
        ActualizarCliente actualizar = new ActualizarCliente();
        public Tickets()
        {
            InitializeComponent();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            dgvTickets.DataSource = objClientes.MostrarTickets();
        }

        private void dgvTickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTickets.CurrentRow != null)
            {
                txtDescripcion.Text = dgvTickets.CurrentRow.Cells["Descripcion"].Value.ToString();
                //txtNombre.Text = dgvTickets.CurrentRow.Cells["nombre"].Value.ToString();
                //txtApellido.Text = dgvTickets.CurrentRow.Cells["apellido"].Value.ToString();
                //txtCedula.Text = dgvTickets.CurrentRow.Cells["cedula"].Value.ToString();
                //txtCorreo.Text = dgvTickets.CurrentRow.Cells["correo"].Value.ToString();

            }
        }
        public void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtid_cliente.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text) ||
    string.IsNullOrEmpty(txtid_cliente.Text))
            {
                MessageBox.Show("Complete los campos");
            }
            else
            {
                cliente.GuardarTickets(txtDescripcion.Text, int.Parse(txtid_cliente.Text));

                dgvTickets.DataSource = objClientes.MostrarTickets();
                dgvTickets.ClearSelection(); // opcional para quitar la selección automática

                LimpiarCampos();
                MessageBox.Show("Ticket guardado correctamente");
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ticket para Eliminar");
                return;
            }

            DataGridViewRow fila = dgvTickets.SelectedRows[0];

            var valorActive = fila.Cells["Active"].Value;

            if (valorActive != null && valorActive.ToString() == "1")
            {
                DialogResult result = MessageBox.Show("¿Está seguro que desea ejecutar el procedimiento para este ticket?",
                   "Confirmación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question
               );

                if (result == DialogResult.Yes)
                {


                    int idTicket = Convert.ToInt32(fila.Cells["id"].Value);

                    EliminarClientes.EliminarTck0(idTicket);


                    dgvTickets.DataSource = objClientes.MostrarTickets();


                    LimpiarCampos();

                    MessageBox.Show("Ticket Eliminado correctamente");
                }
            }
            else
            {
                MessageBox.Show("El ticket seleccionado no está activo.");
            }


        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvTickets.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un ticket para actualizar");
                return;
            }

            DataGridViewRow fila = dgvTickets.SelectedRows[0];
            int idTicket = Convert.ToInt32(fila.Cells["id"].Value);
            string descripcion = txtDescripcion.Text;

            // Mensaje de confirmación
            DialogResult result = MessageBox.Show(
                $"¿Está seguro que desea actualizar el ticket {idTicket} - {descripcion}?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                // Ejecuta el SP
                ActualizarCliente.ActualizarTck0(idTicket, descripcion);

                // Refresca el DataGridView
                dgvTickets.DataSource = objClientes.MostrarTickets();

                // Limpia campos
                LimpiarCampos();

                MessageBox.Show("Ticket Actualizado correctamente");
            }
            else
            {
                MessageBox.Show("Operación cancelada por el usuario.");
            }


        }
    }
}
