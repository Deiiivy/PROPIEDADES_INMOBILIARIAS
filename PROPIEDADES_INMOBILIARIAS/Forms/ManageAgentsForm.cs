using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories;


namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class ManageAgentsForm : Form
    {
        private readonly AgenteRepository _agenteRepository;

        public ManageAgentsForm()
        {
            InitializeComponent();
            var connection = DatabaseConnection.Instance.GetConnection();
            _agenteRepository = new AgenteRepository(connection, null);
            this.Load += ManageAgentsForm_Load;
            dgvAgentes.SelectionChanged += dgvAgentes_SelectionChanged;
        }

        private void btnGuardarAgente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtZona.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            var agente = new Agente
            {
                Nombre = txtNombre.Text,
                ZonaEspecializacion = txtZona.Text,
                Telefono = txtTelefono.Text
            };

            _agenteRepository.Add(agente);
            MessageBox.Show("Agente guardado exitosamente.");
            LimpiarCampos();
            CargarAgentes();
        }

        private void btnActualizarAgente_Click(object sender, EventArgs e)
        {
            if (dgvAgentes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un agente para actualizar.");
                return;
            }

            var agente = new Agente
            {
                AgenteID = Convert.ToInt32(dgvAgentes.SelectedRows[0].Cells["AgenteID"].Value),
                Nombre = txtNombre.Text,
                ZonaEspecializacion = txtZona.Text,
                Telefono = txtTelefono.Text
            };

            _agenteRepository.Update(agente);
            MessageBox.Show("Agente actualizado.");
            LimpiarCampos();
            CargarAgentes();
        }

        private void btnEliminarAgente_Click(object sender, EventArgs e)
        {
            if (dgvAgentes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un agente para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvAgentes.SelectedRows[0].Cells["AgenteID"].Value);

            try
            {
                _agenteRepository.Delete(id);
                MessageBox.Show("Agente eliminado exitosamente.");
                LimpiarCampos();
                CargarAgentes();
            }
            catch (SqlException ex)
            {
                if (ex.Message.Contains("REFERENCE constraint") || ex.Number == 547) // 547 es código para violación de restricción FK
                {
                    MessageBox.Show("No se puede eliminar este agente porque tiene propiedades asignadas.\nDebe reasignar o eliminar esas propiedades primero.",
                                    "Eliminación no permitida",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Error al eliminar el agente: " + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }


        private void ManageAgentsForm_Load(object sender, EventArgs e)
        {
            CargarAgentes();
        }

        private void dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAgentes.SelectedRows.Count == 0) return;

            var row = dgvAgentes.SelectedRows[0];
            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtZona.Text = row.Cells["ZonaEspecializacion"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
        }

        private void CargarAgentes()
        {
            dgvAgentes.DataSource = _agenteRepository.GetAll();
            dgvAgentes.ClearSelection();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtZona.Clear();
            txtTelefono.Clear();
        }
    }
}
