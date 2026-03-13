using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tickets.Data;

namespace Tickets
{
    public partial class Tickets : Form
    {
        CargarClientes objClientes = new CargarClientes();
        GuardarClientes cliente = new GuardarClientes();
        EliminarClientes eliminar = new EliminarClientes();
        ActualizarCliente actualizar = new ActualizarCliente();
        BuscarCliente buscar = new BuscarCliente();
        private ToolTipHelper tooltipHelper;
        public Tickets()
        {
            InitializeComponent();
            // Inicializar la clase
            tooltipHelper = new ToolTipHelper();

            // Asignar mensajes a los íconos
            tooltipHelper.SetMessage(btnLimpiar, "Este es el ícono de Limpiar");
            tooltipHelper.SetMessage(btnAgregar, "Este es el ícono de Agregar");
            tooltipHelper.SetMessage(btnEliminar, "Este es el ícono de Eliminar");
            tooltipHelper.SetMessage(btnBuscar, "Este es el ícono de Buscar");
            tooltipHelper.SetMessage(btnExit, "Este es el ícono de salir");
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

            }
        }
        public void LimpiarCampos()
        {
            txtDescripcion.Clear();
            txtid_cliente.Clear();
            txtcorreo.Clear();
            txtnombre.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();

            
            SqlCommand cmdControl = new SqlCommand("SP_ControlTickets", conexion.AbrirConexion());
            cmdControl.CommandType = CommandType.StoredProcedure;

            int resultado = Convert.ToInt32(cmdControl.ExecuteScalar()); // o usar cmdControl.ExecuteNonQuery con RETURN

            if (resultado == 0)
            {
                MessageBox.Show("Ya se han creado 5 tickets hoy. No se pueden crear más.");
                return;
            }


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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtid_cliente.Text) &&
    string.IsNullOrWhiteSpace(txtnombre.Text) &&
    string.IsNullOrWhiteSpace(txtcorreo.Text))
            {
                MessageBox.Show("Debe ingresar al menos un criterio de búsqueda");
                return;
            }


            int? id = string.IsNullOrWhiteSpace(txtid_cliente.Text) ? (int?)null : Convert.ToInt32(txtid_cliente.Text);
            string nombre = txtnombre.Text;
            string correo = txtcorreo.Text;

            BuscarCliente buscador = new BuscarCliente();
            SqlDataReader reader = buscador.BuscarCli(id, nombre, correo);

            if (reader.Read())
            {
                txtid_cliente.Text = reader["id"].ToString();
                txtnombre.Text = reader["nombre"].ToString();
                txtcorreo.Text = reader["correo"].ToString();
                dgvTickets.ClearSelection();

            }
            else
            {
                MessageBox.Show("Cliente no encontrado");
                LimpiarCampos();
            }

            reader.Close();


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvTickets_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
