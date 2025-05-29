using PROPIEDADES_INMOBILIARIAS.Models;
using PROPIEDADES_INMOBILIARIAS.Repositories.PermisoDecorators;
using PROPIEDADES_INMOBILIARIAS.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Data;



namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class ClienteDashboard : Form
    {
        private UnitOfWork _unitOfWork;

        public ClienteDashboard()
        {
            InitializeComponent();

            try
            {
                _unitOfWork = new UnitOfWork(habilitarPermisos: false);

                var connection = _unitOfWork.GetConnection();
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

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
                CargarVisitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private void ClienteDashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _unitOfWork?.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cerrando conexión: {ex.Message}");
            }
        }

        private void CargarPropiedades()
        {
            var propiedades = _unitOfWork.Propiedades.GetDisponibles().ToList();
            dgvPropiedades.DataSource = propiedades;

            if (dgvPropiedades.Columns.Contains("PropiedadID"))
                dgvPropiedades.Columns["PropiedadID"].Visible = false;

            dgvPropiedades.Columns["Direccion"].HeaderText = "Dirección";
            dgvPropiedades.Columns["Tipo"].HeaderText = "Tipo";
            dgvPropiedades.Columns["Superficie"].HeaderText = "Superficie";
            dgvPropiedades.Columns["Precio"].HeaderText = "Precio";
            dgvPropiedades.Columns["Estado"].HeaderText = "Estado";
        }

        private void CargarVisitas()
        {
            var visitas = _unitOfWork.Visitas.GetVisitasPorCliente(UserSession.UsuarioID).ToList();
            dgvVisitas.DataSource = visitas;

            if (dgvVisitas.Columns.Contains("VisitaID"))
                dgvVisitas.Columns["VisitaID"].Visible = false;

            dgvVisitas.Columns["PropiedadID"].HeaderText = "ID Propiedad";
            dgvVisitas.Columns["Fecha"].HeaderText = "Fecha";
            dgvVisitas.Columns["Hora"].HeaderText = "Hora";

            if (dgvVisitas.Columns.Contains("Estado"))
                dgvVisitas.Columns["Estado"].HeaderText = "Estado";
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm login = new LoginForm();
            login.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
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

            var filaSeleccionada = dgvPropiedades.SelectedRows[0];
            int propiedadId = Convert.ToInt32(filaSeleccionada.Cells["PropiedadID"].Value);
            string direccionPropiedad = filaSeleccionada.Cells["Direccion"].Value.ToString();

            using (var uowTemp = new UnitOfWork())
            {
                var form = new SolicitarVisitaForm(uowTemp, UserSession.UsuarioID, propiedadId, direccionPropiedad);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        uowTemp.Commit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al guardar visita: {ex.Message}");
                        return;
                    }
                }
            }

    
            _unitOfWork = new UnitOfWork(habilitarPermisos: false);
            CargarVisitas();
        }

        private void btnMarcarInteres_Click(object sender, EventArgs e)
        {
            if (dgvPropiedades.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una propiedad para marcar interés.");
                return;
            }

            try
            {
                int propiedadId = (int)dgvPropiedades.SelectedRows[0].Cells["PropiedadID"].Value;
                decimal precio = (decimal)dgvPropiedades.SelectedRows[0].Cells["Precio"].Value;

                var transaccion = new Transaccion
                {
                    PropiedadID = propiedadId,
                    ClienteID = UserSession.UsuarioID,
                    FechaVenta = DateTime.Now,
                    Monto = precio
                };

                _unitOfWork.Transacciones.Add(transaccion);
                _unitOfWork.Commit();

               
                _unitOfWork = new UnitOfWork(habilitarPermisos: false);

                MessageBox.Show("Interés registrado correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el interés: {ex.Message}");
            }
        }
    }
}
