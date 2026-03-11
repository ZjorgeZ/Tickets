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
        public Tickets()
        {
            InitializeComponent();
        }

        private void Tickets_Load(object sender, EventArgs e)
        {
            dgvTickets.DataSource = objClientes.MostrarTickets();
        }

 
    }
}
