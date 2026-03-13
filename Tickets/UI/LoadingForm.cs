using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.UI
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;   // Quita los bordes
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
