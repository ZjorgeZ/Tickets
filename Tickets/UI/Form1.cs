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
    public partial class Form1 : Form
    {
        CargarClientes objClientes = new CargarClientes();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;   // Quita los bordes
            this.WindowState = FormWindowState.Maximized;  // Maximiza
            panel1.Dock = DockStyle.Top;    // Ocupa todo el ancho, pegado arriba

            dgvTickets.DataSource = objClientes.MostrarTickets();




        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes f2 = new Clientes();
            f2.ShowDialog();

        }

        private void btnTickets_Click(object sender, EventArgs e)
        {
            Tickets f2 = new Tickets();
            f2.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            dgvTickets.DataSource = objClientes.MostrarTickets();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir el formulario principal
            Login main = new Login();
            main.Show();
            this.Hide();
        }
    }
}
