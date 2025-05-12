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
        }

        private void ManageAgentsForm_Load(object sender, EventArgs e)
        {
            CargarAgentes();
        }

        private void CargarAgentes()
        {
            dgvAgentes.DataSource = _agenteRepository.GetAll();
        }

        private void btnGuardarAgente_Click(object sender, EventArgs e)
        {
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
            if (dgvAgentes.SelectedRows.Count == 0) return;

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
            if (dgvAgentes.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvAgentes.SelectedRows[0].Cells["AgenteID"].Value);
            _agenteRepository.Delete(id);
            MessageBox.Show("Agente eliminado.");
            LimpiarCampos();
            CargarAgentes();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtZona.Clear();
            txtTelefono.Clear();
        }
    }
}
