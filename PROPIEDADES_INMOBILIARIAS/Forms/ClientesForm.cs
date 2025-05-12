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
        }

        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
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
            int clienteId = Convert.ToInt32(dgvClientes.SelectedRows[0].Cells["ClienteID"].Value);
            _clienteRepository.Delete(clienteId);
            MessageBox.Show("Cliente eliminado.");
            LimpiarCampos();
            CargarClientes();
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
            var clientes = _clienteRepository.GetAll();
            dgvClientes.DataSource = clientes;
        }

        private void ClientesForm_Load(object sender, EventArgs e)
        {
            cmbInteres.Items.Add("Compra");
            cmbInteres.Items.Add("Renta");
            cmbInteres.SelectedIndex = -1;

            CargarClientes();
        }
    }
}

