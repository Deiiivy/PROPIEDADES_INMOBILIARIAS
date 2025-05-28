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
using System.Configuration;
using System.Data.SqlClient;


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
                try
                {
                    _transaction?.Commit();
                }
                catch
                {
                }
                finally
                {
                    _connection?.Close();
                }
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

            DateTime fecha = (DateTime)row.Cells["Fecha"].Value;
            TimeSpan hora = (TimeSpan)row.Cells["Hora"].Value;

            dtpFecha.Value = fecha.Date;             // Control fecha (solo fecha)
            dtpHora.Value = DateTime.Today.Add(hora); // Control hora (solo hora)
        }

        private bool ValidarVisita(out string errorMsg)
        {
            errorMsg = "";

            if (string.IsNullOrWhiteSpace(txtClienteID.Text) ||
                string.IsNullOrWhiteSpace(txtPropiedadID.Text) ||
                string.IsNullOrWhiteSpace(txtAgenteID.Text))
            {
                errorMsg = "Todos los campos de ID deben estar completos.";
                return false;
            }

            if (!int.TryParse(txtClienteID.Text, out int clienteId) ||
                !int.TryParse(txtPropiedadID.Text, out int propiedadId) ||
                !int.TryParse(txtAgenteID.Text, out int agenteId))
            {
                errorMsg = "Los campos de ID deben ser números válidos.";
                return false;
            }

            DateTime fecha = dtpFecha.Value.Date;
            TimeSpan hora = dtpHora.Value.TimeOfDay;
            DateTime fechaHoraVisita = fecha.Add(hora);

            DateTime ahora = DateTime.Now;
            ahora = ahora.AddSeconds(-ahora.Second).AddMilliseconds(-ahora.Millisecond);

            if (fechaHoraVisita < ahora)
            {
                errorMsg = "La fecha y hora de la visita no puede ser pasada.";
                return false;
            }

            var visitas = _visitaRepository.GetAll().ToList();
            bool existeDuplicado = visitas.Any(v =>
                v.ClienteID == clienteId &&
                v.PropiedadID == propiedadId &&
                v.Fecha == fecha &&
                v.Hora == hora &&
                (dgvVisitas.SelectedRows.Count == 0 || v.VisitaID != Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value))
            );

            if (existeDuplicado)
            {
                errorMsg = "Ya existe una visita agendada con los mismos datos.";
                return false;
            }

            return true;
        }

        private void btnGuardarVisita_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarVisita(out string errorMsg))
                {
                    MessageBox.Show(errorMsg, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var visita = new Visita
                {
                    PropiedadID = int.Parse(txtPropiedadID.Text),
                    ClienteID = int.Parse(txtClienteID.Text),
                    AgenteID = int.Parse(txtAgenteID.Text),
                    Fecha = dtpFecha.Value.Date,
                    Hora = dtpHora.Value.TimeOfDay
                };

                _visitaRepository.Add(visita);
                _transaction.Commit();
                _transaction = _connection.BeginTransaction();
                _visitaRepository = new VisitaRepository(_connection, _transaction);

                MessageBox.Show("Visita registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarVisitas();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                MessageBox.Show($"Error al guardar la visita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizarVisita_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVisitas.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Seleccione una visita para actualizar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidarVisita(out string errorMsg))
                {
                    MessageBox.Show(errorMsg, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var visita = new Visita
                {
                    VisitaID = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value),
                    PropiedadID = int.Parse(txtPropiedadID.Text),
                    ClienteID = int.Parse(txtClienteID.Text),
                    AgenteID = int.Parse(txtAgenteID.Text),
                    Fecha = dtpFecha.Value.Date,
                    Hora = dtpHora.Value.TimeOfDay
                };

                _visitaRepository.Update(visita);
                _transaction.Commit();
                _transaction = _connection.BeginTransaction();
                _visitaRepository = new VisitaRepository(_connection, _transaction);

                MessageBox.Show("Visita actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarVisitas();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                MessageBox.Show($"Error al actualizar la visita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarVisita_Click(object sender, EventArgs e)
        {
            if (dgvVisitas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una visita para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvVisitas.SelectedRows[0].Cells["VisitaID"].Value);
                _visitaRepository.Delete(id);
                _transaction.Commit();
                _transaction = _connection.BeginTransaction();
                _visitaRepository = new VisitaRepository(_connection, _transaction);

                MessageBox.Show("Visita eliminada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
                CargarVisitas();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                MessageBox.Show($"Error al eliminar la visita: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            txtClienteID.Clear();
            txtPropiedadID.Clear();
            txtAgenteID.Clear();
            dtpFecha.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
        }
    }
}
