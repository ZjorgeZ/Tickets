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

        }
    }
}
