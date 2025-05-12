using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Rol FROM Usuarios WHERE Email = @Email AND PasswordHash = @Password";
                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", username);
                cmd.Parameters.AddWithValue("@Password", password);  // Aquí deshabilitamos el hash

                connection.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string role = result.ToString();
                    MessageBox.Show($"Bienvenido {role}", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Si es admin, abrir formulario admin; si es agente, abrir formulario de agente
                    if (role == "Admin")
                    {
                        new AdminDashboard().Show();
                    }
                    else if (role == "Agente")
                    {
                        new AgentDashboard().Show();
                    }
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
