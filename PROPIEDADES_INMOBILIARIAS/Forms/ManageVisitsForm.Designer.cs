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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClienteID = new System.Windows.Forms.TextBox();
            this.txtPropiedadID = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGuardarVisita = new System.Windows.Forms.Button();
            this.btnActualizarVisita = new System.Windows.Forms.Button();
            this.btnEliminarVisita = new System.Windows.Forms.Button();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAgenteID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpHora = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Propiedad ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha";
            // 
            // txtClienteID
            // 
            this.txtClienteID.Location = new System.Drawing.Point(188, 50);
            this.txtClienteID.Name = "txtClienteID";
            this.txtClienteID.Size = new System.Drawing.Size(200, 20);
            this.txtClienteID.TabIndex = 4;
            // 
            // txtPropiedadID
            // 
            this.txtPropiedadID.Location = new System.Drawing.Point(188, 108);
            this.txtPropiedadID.Name = "txtPropiedadID";
            this.txtPropiedadID.Size = new System.Drawing.Size(200, 20);
            this.txtPropiedadID.TabIndex = 5;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpFecha.Location = new System.Drawing.Point(188, 210);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowUpDown = true;
            this.dtpFecha.Size = new System.Drawing.Size(200, 20);
            this.dtpFecha.TabIndex = 7;
            // 
            // btnGuardarVisita
            // 
            this.btnGuardarVisita.Location = new System.Drawing.Point(138, 313);
            this.btnGuardarVisita.Name = "btnGuardarVisita";
            this.btnGuardarVisita.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarVisita.TabIndex = 8;
            this.btnGuardarVisita.Text = "Guardar";
            this.btnGuardarVisita.UseVisualStyleBackColor = true;
            // 
            // btnActualizarVisita
            // 
            this.btnActualizarVisita.Location = new System.Drawing.Point(283, 313);
            this.btnActualizarVisita.Name = "btnActualizarVisita";
            this.btnActualizarVisita.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarVisita.TabIndex = 9;
            this.btnActualizarVisita.Text = "Actualizar";
            this.btnActualizarVisita.UseVisualStyleBackColor = true;
            // 
            // btnEliminarVisita
            // 
            this.btnEliminarVisita.Location = new System.Drawing.Point(444, 312);
            this.btnEliminarVisita.Name = "btnEliminarVisita";
            this.btnEliminarVisita.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarVisita.TabIndex = 10;
            this.btnEliminarVisita.Text = "Eliminar";
            this.btnEliminarVisita.UseVisualStyleBackColor = true;
            // 
            // dgvVisitas
            // 
            this.dgvVisitas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitas.Location = new System.Drawing.Point(422, 50);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.ReadOnly = true;
            this.dgvVisitas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVisitas.Size = new System.Drawing.Size(355, 241);
            this.dgvVisitas.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(58, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Agente ID";
            // 
            // txtAgenteID
            // 
            this.txtAgenteID.Location = new System.Drawing.Point(188, 161);
            this.txtAgenteID.Name = "txtAgenteID";
            this.txtAgenteID.Size = new System.Drawing.Size(200, 20);
            this.txtAgenteID.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 267);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Hora";
            // 
            // dtpHora
            // 
            this.dtpHora.Location = new System.Drawing.Point(188, 261);
            this.dtpHora.Name = "dtpHora";
            this.dtpHora.Size = new System.Drawing.Size(200, 20);
            this.dtpHora.TabIndex = 15;
            // 
            // ManageVisitsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtpHora);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAgenteID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvVisitas);
            this.Controls.Add(this.btnEliminarVisita);
            this.Controls.Add(this.btnActualizarVisita);
            this.Controls.Add(this.btnGuardarVisita);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.txtPropiedadID);
            this.Controls.Add(this.txtClienteID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ManageVisitsForm";
            this.Text = "ManageVisitsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtClienteID;
        private System.Windows.Forms.TextBox txtPropiedadID;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnGuardarVisita;
        private System.Windows.Forms.Button btnActualizarVisita;
        private System.Windows.Forms.Button btnEliminarVisita;
        private System.Windows.Forms.DataGridView dgvVisitas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAgenteID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpHora;
    }
}