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
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
           
        }

        private void btnManageProperties_Click(object sender, EventArgs e)
        {
            new ManagePropertiesForm().Show();
        }

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            new ClientesForm().Show();
        }

        private void btnManageAgents_Click(object sender, EventArgs e)
        {
            new ManageAgentsForm().Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
          
            this.Hide();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void btnManageVisits_Click(object sender, EventArgs e)
        {
            new ManageVisitsForm().Show();
        }

    }
}
