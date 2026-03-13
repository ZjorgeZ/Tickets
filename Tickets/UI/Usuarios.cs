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
    public partial class Usuarios : Form
    {
      
        CargarClientes objClientes = new CargarClientes();
        GuardarClientes cliente = new GuardarClientes();
        EliminarClientes eliminar = new EliminarClientes();
        ActualizarCliente actualizar = new ActualizarCliente();

        public void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEmail.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
        }
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) ||
    string.IsNullOrEmpty(txtEmail.Text) ||
    string.IsNullOrEmpty(txtUsuario.Text) ||
    string.IsNullOrEmpty(txtContraseña.Text))
            {
                MessageBox.Show("Complete los campos");
            }
            else
            {
                cliente.GuardarUsuario(txtNombre.Text, txtEmail.Text, txtUsuario.Text, txtContraseña.Text);

                //dgvClientes.DataSource = objClientes.MostrarClientes();
                //dgvClientes.ClearSelection(); // opcional para quitar la selección automática

                LimpiarCampos();
                MessageBox.Show("Cliente guardado correctamente");
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login mainForm = new Login(); 
            mainForm.Show();
            this.Hide();
        }
    }
}