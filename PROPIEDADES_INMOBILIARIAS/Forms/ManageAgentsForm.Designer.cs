namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ManageAgentsForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.btnGuardarAgente = new System.Windows.Forms.Button();
            this.btnActualizarAgente = new System.Windows.Forms.Button();
            this.btnEliminarAgente = new System.Windows.Forms.Button();
            this.dgvAgentes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentes)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Gestión de Agentes";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(50, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.Text = "Nombre del Agente:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(200, 90);
            this.txtNombre.Size = new System.Drawing.Size(180, 23);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 23);
            this.label2.Text = "Zona de Especialización:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(200, 130);
            this.txtZona.Size = new System.Drawing.Size(180, 23);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(50, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.Text = "Teléfono:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(200, 170);
            this.txtTelefono.Size = new System.Drawing.Size(180, 23);
            // 
            // btnGuardarAgente
            // 
            this.btnGuardarAgente.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnGuardarAgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarAgente.ForeColor = System.Drawing.Color.White;
            this.btnGuardarAgente.Location = new System.Drawing.Point(60, 220);
            this.btnGuardarAgente.Size = new System.Drawing.Size(90, 30);
            this.btnGuardarAgente.Text = "Guardar";
            this.btnGuardarAgente.UseVisualStyleBackColor = false;
            this.btnGuardarAgente.Click += new System.EventHandler(this.btnGuardarAgente_Click);
            // 
            // btnActualizarAgente
            // 
            this.btnActualizarAgente.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnActualizarAgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizarAgente.ForeColor = System.Drawing.Color.White;
            this.btnActualizarAgente.Location = new System.Drawing.Point(170, 220);
            this.btnActualizarAgente.Size = new System.Drawing.Size(90, 30);
            this.btnActualizarAgente.Text = "Actualizar";
            this.btnActualizarAgente.UseVisualStyleBackColor = false;
            this.btnActualizarAgente.Click += new System.EventHandler(this.btnActualizarAgente_Click);
            // 
            // btnEliminarAgente
            // 
            this.btnEliminarAgente.BackColor = System.Drawing.Color.IndianRed;
            this.btnEliminarAgente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarAgente.ForeColor = System.Drawing.Color.White;
            this.btnEliminarAgente.Location = new System.Drawing.Point(280, 220);
            this.btnEliminarAgente.Size = new System.Drawing.Size(90, 30);
            this.btnEliminarAgente.Text = "Eliminar";
            this.btnEliminarAgente.UseVisualStyleBackColor = false;
            this.btnEliminarAgente.Click += new System.EventHandler(this.btnEliminarAgente_Click);
            // 
            // dgvAgentes
            // 
            this.dgvAgentes.AllowUserToAddRows = false;
            this.dgvAgentes.AllowUserToDeleteRows = false;
            this.dgvAgentes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgentes.Location = new System.Drawing.Point(410, 90);
            this.dgvAgentes.MultiSelect = false;
            this.dgvAgentes.Name = "dgvAgentes";
            this.dgvAgentes.ReadOnly = true;
            this.dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgentes.Size = new System.Drawing.Size(360, 250);
            this.dgvAgentes.TabIndex = 10;
            // 
            // ManageAgentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZona);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.btnGuardarAgente);
            this.Controls.Add(this.btnActualizarAgente);
            this.Controls.Add(this.btnEliminarAgente);
            this.Controls.Add(this.dgvAgentes);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ManageAgentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Agentes Inmobiliarios";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtZona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Button btnGuardarAgente;
        private System.Windows.Forms.Button btnActualizarAgente;
        private System.Windows.Forms.Button btnEliminarAgente;
        private System.Windows.Forms.DataGridView dgvAgentes;
    }
}
