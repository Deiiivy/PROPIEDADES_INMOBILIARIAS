using PROPIEDADES_INMOBILIARIAS.Models;
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
    public partial class ClienteDashboard : Form
    {
        private readonly SqlConnection _connection;
        private readonly SqlTransaction _transaction;
        private readonly PropiedadRepository _propiedadRepository;

        public ClienteDashboard()
        {
            InitializeComponent();

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString;
                _connection = new SqlConnection(connectionString);
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                _propiedadRepository = new PropiedadRepository(_connection, _transaction);

                this.FormClosing += ClienteDashboard_FormClosing;
                this.Load += ClienteDashboard_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando ClienteDashboard: {ex.Message}");
                this.Close();
            }
        }

        private void ClienteDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                CargarPropiedades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando propiedades: {ex.Message}");
            }
        }

        private void ClienteDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _transaction?.Commit();
                _connection?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cerrando conexión: {ex.Message}");
            }
        }

        private void CargarPropiedades()
        {
            var propiedades = _propiedadRepository.GetDisponibles().ToList();
            dgvPropiedades.DataSource = propiedades;

            if (dgvPropiedades.Columns.Contains("PropiedadID"))
                dgvPropiedades.Columns["PropiedadID"].Visible = false;

            dgvPropiedades.Columns["Direccion"].HeaderText = "Dirección";
            dgvPropiedades.Columns["Tipo"].HeaderText = "Tipo";
            dgvPropiedades.Columns["Superficie"].HeaderText = "Superficie";
            dgvPropiedades.Columns["Precio"].HeaderText = "Precio";
            dgvPropiedades.Columns["Estado"].HeaderText = "Estado";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnSolicitarVisita_Click(object sender, EventArgs e)
        {
            if (dgvPropiedades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una propiedad para solicitar visita.");
                return;
            }

            int propiedadId = (int)dgvPropiedades.SelectedRows[0].Cells["PropiedadID"].Value;
            MessageBox.Show($"Solicitud de visita enviada para propiedad ID {propiedadId}.\n(Implementar lógica más adelante)");
        }
    }
}
