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
using Tickets.UI;

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
                // Mostrar formulario de loading
                LoadingForm loading = new LoadingForm();
                loading.Show();

                // Simular carga (ejemplo con Task.Delay)
                Task.Run(async () =>
                {
                    await Task.Delay(3000); // Simula proceso de carga
                    this.Invoke(new Action(() =>
                    {
                        loading.Close();
                        // Abrir el formulario principal
                        Form1 main = new Form1();
                        main.Show();
                        this.Hide();
                    }));
                });


                //MessageBox.Show("Login exitoso");
                // Abrir formulario principal
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                return;
            }

            //Form1 mainForm = new Form1();
            //mainForm.Show();
            //this.Hide();
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
