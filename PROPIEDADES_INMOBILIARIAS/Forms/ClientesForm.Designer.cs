using System.Windows.Forms;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ClientesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        private void InitializeComponent()
        {
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.cmbInteres = new System.Windows.Forms.ComboBox();
            this.btnGuardarCliente = new System.Windows.Forms.Button();
            this.btnActualizarCliente = new System.Windows.Forms.Button();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.SuspendLayout();

            // Form
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 480);
            this.Text = "Gestión de Clientes";

            // Labels
            var labels = new[] { label1, label2, label3, label4 };
            foreach (var lbl in labels)
            {
                lbl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
                lbl.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            }

            this.label1.Location = new System.Drawing.Point(40, 50);
            this.label1.Text = "Nombre";

            this.label2.Location = new System.Drawing.Point(40, 100);
            this.label2.Text = "Teléfono";

            this.label3.Location = new System.Drawing.Point(40, 150);
            this.label3.Text = "Email";

            this.label4.Location = new System.Drawing.Point(40, 200);
            this.label4.Text = "Interés";

            // TextBoxes y ComboBox
            this.txtNombre.Location = new System.Drawing.Point(130, 50);
            this.txtTelefono.Location = new System.Drawing.Point(130, 100);
            this.txtEmail.Location = new System.Drawing.Point(130, 150);
            this.cmbInteres.Location = new System.Drawing.Point(130, 200);
            this.txtNombre.Size = this.txtTelefono.Size = this.txtEmail.Size = new System.Drawing.Size(160, 22);
            this.cmbInteres.Size = new System.Drawing.Size(160, 22);
            this.cmbInteres.DropDownStyle = ComboBoxStyle.DropDownList;

            // Botones
            this.btnGuardarCliente.Text = "Guardar";
            this.btnGuardarCliente.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnGuardarCliente.ForeColor = System.Drawing.Color.White;
            this.btnGuardarCliente.FlatStyle = FlatStyle.Flat;
            this.btnGuardarCliente.Location = new System.Drawing.Point(40, 260);
            this.btnGuardarCliente.Size = new System.Drawing.Size(80, 35);
            this.btnGuardarCliente.Click += new System.EventHandler(this.btnGuardarCliente_Click);

            this.btnActualizarCliente.Text = "Actualizar";
            this.btnActualizarCliente.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnActualizarCliente.ForeColor = System.Drawing.Color.White;
            this.btnActualizarCliente.FlatStyle = FlatStyle.Flat;
            this.btnActualizarCliente.Location = new System.Drawing.Point(140, 260);
            this.btnActualizarCliente.Size = new System.Drawing.Size(80, 35);
            this.btnActualizarCliente.Click += new System.EventHandler(this.btnActualizarCliente_Click);

            this.btnEliminarCliente.Text = "Eliminar";
            this.btnEliminarCliente.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnEliminarCliente.ForeColor = System.Drawing.Color.White;
            this.btnEliminarCliente.FlatStyle = FlatStyle.Flat;
            this.btnEliminarCliente.Location = new System.Drawing.Point(240, 260);
            this.btnEliminarCliente.Size = new System.Drawing.Size(80, 35);
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);

            // DataGridView
            this.dgvClientes.Location = new System.Drawing.Point(350, 50);
            this.dgvClientes.Size = new System.Drawing.Size(420, 300);
            this.dgvClientes.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Agregar controles
            this.Controls.AddRange(new Control[]
            {
        txtNombre, txtTelefono, txtEmail, cmbInteres,
        btnGuardarCliente, btnActualizarCliente, btnEliminarCliente,
        dgvClientes,
        label1, label2, label3, label4
            });

            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        #endregion

        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbInteres;
        private System.Windows.Forms.Button btnGuardarCliente;
        private System.Windows.Forms.Button btnActualizarCliente;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}