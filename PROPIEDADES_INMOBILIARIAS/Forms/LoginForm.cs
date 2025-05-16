using PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators;
using PROPIEDADES_INMOBILIARIAS.Repositories;
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
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor ingrese sus credenciales.");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var authRepo = new AuthRepository(connection);
                var usuario = authRepo.Login(email, password);

                if (usuario != null)
                {
                   
                    UserSession.UsuarioID = usuario.UsuarioID;
                    UserSession.Rol = usuario.Rol;
                    UserSession.AgenteID = usuario.AgenteID;
                    UserSession.ClienteID = usuario.ClienteID;

                    MessageBox.Show($"Bienvenido {usuario.Rol}", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   
                    switch (usuario.Rol.ToLower())
                    {
                        case "admin":
                            new AdminDashboard().Show();
                            break;
                        case "agente":
                            new AgentDashboard(usuario.UsuarioID).Show();
                            break;
                        case "cliente":
                            new ClienteDashboard().Show();
                            break;
                        default:
                            MessageBox.Show("Rol no reconocido.");
                            return;
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