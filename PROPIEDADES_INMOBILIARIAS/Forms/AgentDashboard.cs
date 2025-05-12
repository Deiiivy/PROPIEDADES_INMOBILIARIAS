using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class AgentDashboard : Form
    {
        public AgentDashboard()
        {
            InitializeComponent();
        }

        private void AgentDashboard_Load(object sender, EventArgs e)
        {
            // Aquí puedes cargar datos específicos si es necesario
        }

        private void btnManageOwnProperties_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para gestionar las propiedades del agente
           // new ManageAgentPropertiesForm().Show();
        }

        private void btnManageVisits_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para gestionar las visitas del agente
            new ManageVisitsForm().Show();
        }
    }
}

