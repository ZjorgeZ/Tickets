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
        UsuarioDAL dal = new UsuarioDAL();
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //        if (string.IsNullOrEmpty(txtNombre.Text) ||
            //string.IsNullOrEmpty(txtApellido.Text) ||
            //string.IsNullOrEmpty(txtCedula.Text) ||
            //string.IsNullOrEmpty(txtCorreo.Text))
            //        {
            //            MessageBox.Show("Complete los campos");
            //        }
            //        else
            //        {
            //            cliente.GuardarCliente(txtNombre.Text, txtApellido.Text, txtCedula.Text, txtCorreo.Text);

            //            dgvClientes.DataSource = objClientes.MostrarClientes();
            //            dgvClientes.ClearSelection(); // opcional para quitar la selección automática

            //            LimpiarCampos();
            //            MessageBox.Show("Cliente guardado correctamente");
            //        }

            //    }
        }
    }
}