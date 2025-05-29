using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    public partial class SolicitarVisitaForm : Form
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly int _clienteId;
        private readonly int _propiedadId;
        private readonly string _direccionPropiedad;


        public SolicitarVisitaForm(UnitOfWork unitOfWork, int clienteId, int propiedadId, string direccionPropiedad)
        {
            InitializeComponent();

            _unitOfWork = unitOfWork;
            _clienteId = clienteId;
            _propiedadId = propiedadId;
            _direccionPropiedad = direccionPropiedad;

           
            comboPropiedades.DataSource = new List<object> { new { PropiedadID = _propiedadId, Direccion = _direccionPropiedad } };
            comboPropiedades.DisplayMember = "Direccion";
            comboPropiedades.ValueMember = "PropiedadID";
            comboPropiedades.Enabled = false;

            btnEnviar.Click += BtnEnviar_Click;
        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fecha = dateTimePickerFecha.Value.Date;
                TimeSpan hora = dateTimePickerHora.Value.TimeOfDay;

                _unitOfWork.Visitas.RegistrarSolicitudVisita(_clienteId, _propiedadId, fecha, hora);
                this.DialogResult = DialogResult.OK;
                this.Close();

                MessageBox.Show("Solicitud de visita enviada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al enviar solicitud: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
