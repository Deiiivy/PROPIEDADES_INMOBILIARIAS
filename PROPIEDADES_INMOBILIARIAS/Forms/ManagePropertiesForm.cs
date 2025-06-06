﻿using System;
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
    public partial class ManagePropertiesForm : Form
    {
        private readonly PropiedadRepository _repo;
        private readonly int? _agenteId;

        public ManagePropertiesForm(int? agenteId = null)
        {
            InitializeComponent();
            _repo = new PropiedadRepository(DatabaseConnection.Instance.GetConnection(), null);
            _agenteId = agenteId;
            this.Shown += ManagePropertiesForm_Shown;
            this.dgvPropiedades.SelectionChanged += dgvPropiedades_SelectionChanged;
        }

        private void ManagePropertiesForm_Shown(object sender, EventArgs e)
        {
            try
            {
                cmbTipo.DataSource = Enum.GetValues(typeof(TipoPropiedad));
                cmbEstado.DataSource = Enum.GetValues(typeof(EstadoPropiedad));
                cmbTipo.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
                CargarPropiedades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el formulario: " + ex.Message);
            }
        }

        private string ObtenerZonaPorAgenteId()
        {
            if (!_agenteId.HasValue)
                return "Sin Zona";

            int ultimoDigito = _agenteId.Value % 10;

            switch (ultimoDigito)
            {
                case 1:
                    return "Sur";     // Carlos
                case 2:
                    return "Norte";   // Ana Gómez
                case 3:
                    return "Este";    // Juan Pérez
                case 4:
                    return "Oeste";
                default:
                    return "Sin Zona";
            }
        }




        private void CargarPropiedades()
        {
            try
            {
                dgvPropiedades.DataSource = null;
                var lista = _agenteId.HasValue
                    ? _repo.GetByAgenteId(_agenteId.Value).ToList()
                    : _repo.GetAll().ToList();

                // Asignar "Sur" a la zona si es Carlos
                string zonaAgente = ObtenerZonaPorAgenteId();
                foreach (var propiedad in lista)
                {
                    propiedad.Zona = zonaAgente;
                }

                dgvPropiedades.AutoGenerateColumns = true;
                dgvPropiedades.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar propiedades: " + ex.Message);
            }
        }

        private void dgvPropiedades_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvPropiedades.SelectedRows.Count == 0) return;

                var row = dgvPropiedades.SelectedRows[0];
                txtDireccion.Text = row.Cells["Direccion"].Value?.ToString();
                cmbTipo.SelectedItem = Enum.Parse(typeof(TipoPropiedad), row.Cells["Tipo"].Value.ToString());
                txtSuperficie.Text = row.Cells["Superficie"].Value?.ToString();
                txtPrecio.Text = row.Cells["Precio"].Value?.ToString();
                cmbEstado.SelectedItem = Enum.Parse(typeof(EstadoPropiedad), row.Cells["Estado"].Value.ToString());
                txtAgenteID.Text = row.Cells["AgenteID"].Value?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar propiedad: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                var propiedad = new Propiedad
                {
                    Direccion = txtDireccion.Text,
                    Tipo = (TipoPropiedad)Enum.Parse(typeof(TipoPropiedad), cmbTipo.SelectedItem.ToString()),
                    Superficie = double.Parse(txtSuperficie.Text),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = (EstadoPropiedad)Enum.Parse(typeof(EstadoPropiedad), cmbEstado.SelectedItem.ToString()),
                    AgenteID = _agenteId ?? int.Parse(txtAgenteID.Text)
                };

                _repo.Add(propiedad);
                MessageBox.Show("Propiedad agregada exitosamente.");
                LimpiarCampos();
                CargarPropiedades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar propiedad: " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvPropiedades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una propiedad para actualizar.");
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                int id = Convert.ToInt32(dgvPropiedades.SelectedRows[0].Cells["PropiedadID"].Value);
                var propiedad = new Propiedad
                {
                    PropiedadID = id,
                    Direccion = txtDireccion.Text,
                    Tipo = (TipoPropiedad)Enum.Parse(typeof(TipoPropiedad), cmbTipo.SelectedItem.ToString()),
                    Superficie = double.Parse(txtSuperficie.Text),
                    Precio = decimal.Parse(txtPrecio.Text),
                    Estado = (EstadoPropiedad)Enum.Parse(typeof(EstadoPropiedad), cmbEstado.SelectedItem.ToString()),
                    AgenteID = _agenteId ?? int.Parse(txtAgenteID.Text)
                };

                _repo.Update(propiedad);
                MessageBox.Show("Propiedad actualizada.");
                LimpiarCampos();
                CargarPropiedades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar propiedad: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvPropiedades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una propiedad para eliminar.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvPropiedades.SelectedRows[0].Cells["PropiedadID"].Value);
                _repo.Delete(id);
                MessageBox.Show("Propiedad eliminada.");
                LimpiarCampos();
                CargarPropiedades();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("No se puede eliminar la propiedad: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar propiedad: " + ex.Message);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtSuperficie.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                (_agenteId == null && string.IsNullOrWhiteSpace(txtAgenteID.Text)) ||
                cmbTipo.SelectedItem == null ||
                cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor complete todos los campos y seleccione tipo/estado.");
                return false;
            }

            if (!double.TryParse(txtSuperficie.Text, out _) || !decimal.TryParse(txtPrecio.Text, out _))
            {
                MessageBox.Show("Superficie o precio no tienen un formato válido.");
                return false;
            }

            if (_agenteId == null && !int.TryParse(txtAgenteID.Text, out _))
            {
                MessageBox.Show("El ID del agente debe ser numérico.");
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            txtDireccion.Clear();
            txtSuperficie.Clear();
            txtPrecio.Clear();
            txtAgenteID.Clear();
            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
        }

        private void ManagePropertiesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
