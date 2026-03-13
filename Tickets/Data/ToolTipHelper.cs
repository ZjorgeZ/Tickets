using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tickets.Data
{
    public class ToolTipHelper
    {
        private ToolTip toolTip;

        public ToolTipHelper()
        {
            toolTip = new ToolTip();

            // Configuración general
            toolTip.AutoPopDelay = 5000;
            toolTip.InitialDelay = 500;
            toolTip.ReshowDelay = 200;
            toolTip.ShowAlways = true;

            // Personalización
            toolTip.ToolTipTitle = "Información";
            toolTip.ToolTipIcon = ToolTipIcon.Info;
        }

        // Método para asignar mensajes a controles
        public void SetMessage(Control control, string message)
        {
            toolTip.SetToolTip(control, message);
        }


    }
}
