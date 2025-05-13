using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;
using PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class AgentDashboard : Form
    {
        private int _agenteId;

        public AgentDashboard(int agenteId)
        {
            InitializeComponent();
            _agenteId = agenteId;
        }

        private void AgentDashboard_Load(object sender, EventArgs e)
        {
            // Puedes mostrar info personalizada, como:
            // lblWelcome.Text = $"Bienvenido Agente {_agenteId}";
        }
        private void btnManageOwnProperties_Click(object sender, EventArgs e)
        {
            int agenteId = UserSession.AgenteID ?? 0; // Usa el AgenteID directamente
            new ManagePropertiesForm(agenteId).Show();
        }

        private void btnManageVisits_Click(object sender, EventArgs e)
        {
            new ManageVisitsForm().Show();
        }
    }
}


