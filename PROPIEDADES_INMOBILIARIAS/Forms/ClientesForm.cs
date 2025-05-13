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
using System.Data.SqlClient;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class ClientesForm : Form
    {
        private ClienteRepository _clienteRepository;
        private SqlConnection _connection;

        public ClientesForm()
        {
            InitializeComponent();
            _connection = DatabaseConnection.Instance.GetConnection();
            _clienteRepository = new ClienteRepository(_connection, null);
            this.Load += ClientesForm_Load;
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            cmbInteres.Items.Clear();
            cmbInteres.Items.Add("Compra");
            cmbInteres.Items.Add("Renta");
            cmbInteres.SelectedIndex = -1;

            CargarClientes();
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                cmbInteres.SelectedItem == null)
            {
                MessageBox.Show("Complete todos los campos antes de guardar.");
                return;
            }

            var cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Interes = cmbInteres.SelectedItem.ToString()
            };

            _clienteRepository.Add(cliente);
            MessageBox.Show("Cliente guardado exitosamente.");
            LimpiarCampos();
            CargarClientes();
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0 || cmbInteres.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un cliente y un tipo de interés válido.");
                return;
            }

            var cliente = new Cliente
            {
                ClienteID = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value),
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Email = txtEmail.Text,
                Interes = cmbInteres.SelectedItem.ToString()
            };

            _clienteRepository.Update(cliente);
            MessageBox.Show("Cliente actualizado.");
            LimpiarCampos();
            CargarClientes();
        }

        private void btnEliminarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
                return;
            }

            int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
            _clienteRepository.Delete(clienteId);
            MessageBox.Show("Cliente eliminado.");
            LimpiarCampos();
            CargarClientes();
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;

            var row = dgvClientes.SelectedRows[0];
            txtNombre.Text = row.Cells["Nombre"].Value.ToString();
            txtTelefono.Text = row.Cells["Telefono"].Value.ToString();
            txtEmail.Text = row.Cells["Email"].Value.ToString();

            string interes = row.Cells["Interes"].Value.ToString();
            cmbInteres.SelectedItem = cmbInteres.Items.Contains(interes) ? interes : null;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbInteres.SelectedIndex = -1;
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = _clienteRepository.GetAll();
            dgvClientes.ClearSelection();
        }
    }
}
