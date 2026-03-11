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
    public partial class Clientes : Form
    {
        CargarClientes objClientes = new CargarClientes();
        GuardarClientes cliente = new GuardarClientes();
        EliminarClientes eliminar = new EliminarClientes();
        ActualizarCliente actualizar = new ActualizarCliente();
         
        public Clientes()
        {
            InitializeComponent();
            
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            dgvClientes.DataSource = objClientes.MostrarClientes();
            dgvClientes.ClearSelection();
            
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvClientes.CurrentRow != null)
            {
                txtID.Text = dgvClientes.CurrentRow.Cells["id"].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtApellido.Text = dgvClientes.CurrentRow.Cells["apellido"].Value.ToString();
                txtCedula.Text = dgvClientes.CurrentRow.Cells["cedula"].Value.ToString();
                txtCorreo.Text = dgvClientes.CurrentRow.Cells["correo"].Value.ToString();
               
            }
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
      string.IsNullOrEmpty(txtApellido.Text) ||
      string.IsNullOrEmpty(txtCedula.Text) ||
      string.IsNullOrEmpty(txtCorreo.Text))
            {
                MessageBox.Show("Complete los campos");
            }
            else
            {
                cliente.GuardarCliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text);

                dgvClientes.DataSource = objClientes.MostrarClientes();
                dgvClientes.ClearSelection(); // opcional para quitar la selección automática

                LimpiarCampos();
                MessageBox.Show("Cliente guardado correctamente");
            }

        }
        public void LimpiarCampos()
        {
            txtID.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            txtCorreo.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) 
            { 
                MessageBox.Show("Seleccione un cliente para eliminar");
                return;
            }

            
            int id = Convert.ToInt32(txtID.Text);

            eliminar.EliminarCliente(id);
            dgvClientes.DataSource = objClientes.MostrarClientes();
            LimpiarCampos();
            MessageBox.Show("Cliente eliminado correctamente");
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para actualizar");
                return;
            }
            else {
                int id = Convert.ToInt32(txtID.Text);

                actualizar.ActualizarCli(id, txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text);
                dgvClientes.DataSource = objClientes.MostrarClientes();
                LimpiarCampos();
                MessageBox.Show("Cliente actualizado correctamente");

            }

            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
