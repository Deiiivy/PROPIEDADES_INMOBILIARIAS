using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            btnManageVisits.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                new LoginForm().Show();
            }
        }

        private void btnManageOwnProperties_Click(object sender, EventArgs e)
        {
            int agenteId = UserSession.AgenteID ?? 0; 
            new ManagePropertiesForm(agenteId).Show();
        }

        private void btnManageVisits_Click(object sender, EventArgs e)
        {
            new ManageVisitsForm().Show();
        }
    }
}


