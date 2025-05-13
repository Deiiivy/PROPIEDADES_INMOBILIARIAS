using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class ManageVisitsForm : Form
    {
        private readonly SqlConnection _connection;
        private SqlTransaction _transaction;
        private VisitaRepository _visitaRepository;

        public ManageVisitsForm()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["RealEstateDB"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _visitaRepository = new VisitaRepository(_connection, _transaction);

            this.FormClosing += (s, e) =>
            {
                _transaction?.Commit();
                _connection?.Close();
            };
        }

        private void ManageVisitsForm_Load(object sender, EventArgs e)
        {
            CargarVisitas();
            dgvVisitas.Columns["VisitaID"].Visible = false;
            dgvVisitas.Columns["ClienteID"].HeaderText = "Cliente";
            dgvVisitas.Columns["PropiedadID"].HeaderText = "Propiedad";
            dgvVisitas.Columns["AgenteID"].HeaderText = "Agente";
            dgvVisitas.Columns["Fecha"].HeaderText = "Fecha";
            dgvVisitas.Columns["Hora"].HeaderText = "Hora";
        }

        private void CargarVisitas()
        {
            var visitas = _visitaRepository.GetAll().ToList();
            dgvVisitas.DataSource = visitas;
        }

      



        private void dgvVisitas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVisitas.SelectedRows.Count == 0) return;

            var row = dgvVisitas.SelectedRows[0];
            txtPropiedadID.Text = row.Cells["PropiedadID"].Value.ToString();
            txtClienteID.Text = row.Cells["ClienteID"].Value.ToString();
            txtAgenteID.Text = row.Cells["AgenteID"].Value.ToString();
            dtpHora.Value = (DateTime)row.Cells["Fecha"].Value;
            dtpFecha.Value = DateTime.Today.Add((TimeSpan)row.Cells["Hora"].Value);
        }

      
        private void btnGuardarVisita_Click(object sender, EventArgs e)
        {
            var visita = new Visita
            {
                PropiedadID = int.Parse(txtPropiedadID.Text),
                ClienteID = int.Parse(txtClienteID.Text),
                AgenteID = int.Parse(txtAgenteID.Text),
                Fecha = dtpHora.Value.Date,
                Hora = dtpFecha.Value.TimeOfDay
            };

            _visitaRepository.Add(visita);
            MessageBox.Show("Visita registrada exitosamente.");
            LimpiarCampos();
            CargarVisitas();
        }

        private void btnActualizarVisita_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.SelectedRows.Count == 0) return;

            var visita = new Visita
            {
                VisitaID = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value),
                PropiedadID = int.Parse(txtPropiedadID.Text),
                ClienteID = int.Parse(txtClienteID.Text),
                AgenteID = int.Parse(txtAgenteID.Text),
                Fecha = dtpHora.Value.Date,
                Hora = dtpFecha.Value.TimeOfDay
            };

            _visitaRepository.Update(visita);
            MessageBox.Show("Visita actualizada correctamente.");
            LimpiarCampos();
            CargarVisitas();
        }

        private void btnEliminarVisita_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value);
            _visitaRepository.Delete(id);
            MessageBox.Show("Visita eliminada.");
            LimpiarCampos();
            CargarVisitas();
        }

        private void LimpiarCampos()
        {
            txtClienteID.Clear();
            txtPropiedadID.Clear();
            txtAgenteID.Clear();
            dtpHora.Value = DateTime.Now;
            dtpFecha.Value = DateTime.Now;
        }

    }
}
