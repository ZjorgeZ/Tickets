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

namespace Tickets
{
    public partial class Login : Form
    {
        Conexion conexion = new Conexion();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

      

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UsuarioLogin bl = new UsuarioLogin();
            bool acceso = bl.LoginUsuario(txtUsuario.Text, txtContraseña.Text);

            if (acceso)
            {
                MessageBox.Show("Login exitoso");
                // Abrir formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                return;
            }

            Form1 mainForm = new Form1();
            mainForm.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Usuarios mainForm = new Usuarios();
            mainForm.ShowDialog();
            //mainForm.Show();
            //this.Hide();
        }
    }
}
