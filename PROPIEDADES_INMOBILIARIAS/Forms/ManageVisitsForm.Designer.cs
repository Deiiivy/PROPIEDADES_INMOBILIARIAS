using System.Drawing;
using System.Windows.Forms;
using System;

namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ManageVisitsForm
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
            this.components = new System.ComponentModel.Container();
            this.Text = "Gestión de Visitas";
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Gestión de Visitas";
            lblTitulo.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblTitulo.Location = new Point(280, 10);
            lblTitulo.AutoSize = true;
            this.Controls.Add(lblTitulo);

            GroupBox grpDatos = new GroupBox();
            grpDatos.Text = "Datos de la Visita";
            grpDatos.Location = new Point(30, 50);
            grpDatos.Size = new Size(370, 270);
            this.Controls.Add(grpDatos);

            Label label1 = new Label { Text = "Cliente ID", Location = new Point(20, 30), AutoSize = true };
            TextBox txtClienteID = new TextBox { Location = new Point(120, 27), Size = new Size(200, 20) };

            Label label2 = new Label { Text = "Propiedad ID", Location = new Point(20, 70), AutoSize = true };
            TextBox txtPropiedadID = new TextBox { Location = new Point(120, 67), Size = new Size(200, 20) };

            Label label5 = new Label { Text = "Agente ID", Location = new Point(20, 110), AutoSize = true };
            TextBox txtAgenteID = new TextBox { Location = new Point(120, 107), Size = new Size(200, 20) };

            Label label3 = new Label { Text = "Fecha", Location = new Point(20, 150), AutoSize = true };
            DateTimePicker dtpFecha = new DateTimePicker { Location = new Point(120, 147), Size = new Size(200, 20) };

            Label label4 = new Label { Text = "Hora", Location = new Point(20, 190), AutoSize = true };
            DateTimePicker dtpHora = new DateTimePicker
            {
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true,
                Location = new Point(120, 187),
                Size = new Size(200, 20)
            };

            grpDatos.Controls.AddRange(new Control[] {
        label1, txtClienteID,
        label2, txtPropiedadID,
        label5, txtAgenteID,
        label3, dtpFecha,
        label4, dtpHora
    });

            Panel pnlBotones = new Panel();
            pnlBotones.Location = new Point(30, 340);
            pnlBotones.Size = new Size(500, 40);
            this.Controls.Add(pnlBotones);

            Button btnGuardarVisita = new Button
            {
                Text = "Registrar Visita",
                BackColor = Color.LightGreen,
                Location = new Point(10, 5),
                Size = new Size(130, 30)
            };
            btnGuardarVisita.Click += new EventHandler(this.btnGuardarVisita_Click);

            Button btnActualizarVisita = new Button
            {
                Text = "Modificar Visita",
                BackColor = Color.LightSkyBlue,
                Location = new Point(150, 5),
                Size = new Size(130, 30)
            };
            btnActualizarVisita.Click += new EventHandler(this.btnActualizarVisita_Click);

            Button btnEliminarVisita = new Button
            {
                Text = "Cancelar Visita",
                BackColor = Color.IndianRed,
                Location = new Point(290, 5),
                Size = new Size(130, 30)
            };
            btnEliminarVisita.Click += new EventHandler(this.btnEliminarVisita_Click);

            pnlBotones.Controls.AddRange(new Control[] {
        btnGuardarVisita,
        btnActualizarVisita,
        btnEliminarVisita
    });

            DataGridView dgvVisitas = new DataGridView();
            dgvVisitas.Location = new Point(420, 60);
            dgvVisitas.Size = new Size(350, 250);
            dgvVisitas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVisitas.ReadOnly = true;
            dgvVisitas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVisitas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvVisitas.DefaultCellStyle.Font = new Font("Segoe UI", 9);
            dgvVisitas.BackgroundColor = Color.White;
            dgvVisitas.GridColor = Color.LightGray;
            this.Controls.Add(dgvVisitas);

            // Asignación a campos de clase si los usas
            this.txtClienteID = txtClienteID;
            this.txtPropiedadID = txtPropiedadID;
            this.txtAgenteID = txtAgenteID;
            this.dtpFecha = dtpFecha;
            this.dtpHora = dtpHora;
            this.dgvVisitas = dgvVisitas;
            this.btnGuardarVisita = btnGuardarVisita;
            this.btnActualizarVisita = btnActualizarVisita;
            this.btnEliminarVisita = btnEliminarVisita;
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.TextBox txtPropiedadID;
        private System.Windows.Forms.DateTimePicker dtpHora;
        private System.Windows.Forms.Button btnGuardarVisita;
        private System.Windows.Forms.Button btnActualizarVisita;
        private System.Windows.Forms.Button btnEliminarVisita;
        private System.Windows.Forms.DataGridView dgvVisitas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgenteID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}