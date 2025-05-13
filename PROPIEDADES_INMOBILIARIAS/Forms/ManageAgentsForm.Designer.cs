namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ManageAgentsForm
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(96, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(189, 59);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Zona de Especialización";
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(189, 122);
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(100, 20);
            this.txtZona.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(99, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "telefono";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(189, 171);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 5;
            // 
            // btnGuardarAgente
            // 
            this.btnGuardarAgente.Location = new System.Drawing.Point(102, 232);
            this.btnGuardarAgente.Name = "btnGuardarAgente";
            this.btnGuardarAgente.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarAgente.TabIndex = 6;
            this.btnGuardarAgente.Text = "Guardar";
            this.btnGuardarAgente.UseVisualStyleBackColor = true;
            this.btnGuardarAgente.Click += new System.EventHandler(this.btnGuardarAgente_Click);
            // 
            // btnActualizarAgente
            // 
            this.btnActualizarAgente.Location = new System.Drawing.Point(223, 232);
            this.btnActualizarAgente.Name = "btnActualizarAgente";
            this.btnActualizarAgente.Size = new System.Drawing.Size(75, 23);
            this.btnActualizarAgente.TabIndex = 7;
            this.btnActualizarAgente.Text = "Actualizar";
            this.btnActualizarAgente.UseVisualStyleBackColor = true;
            this.btnActualizarAgente.Click += new System.EventHandler(this.btnActualizarAgente_Click);
            // 
            // btnEliminarAgente
            // 
            this.btnEliminarAgente.Location = new System.Drawing.Point(357, 232);
            this.btnEliminarAgente.Name = "btnEliminarAgente";
            this.btnEliminarAgente.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarAgente.TabIndex = 8;
            this.btnEliminarAgente.Text = "Eliminar";
            this.btnEliminarAgente.UseVisualStyleBackColor = true;
            this.btnEliminarAgente.Click += new System.EventHandler(this.btnEliminarAgente_Click);
            // 
            // dgvAgentes
            // 
            this.dgvAgentes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgentes.Location = new System.Drawing.Point(378, 44);
            this.dgvAgentes.Name = "dgvAgentes";
            this.dgvAgentes.ReadOnly = true;
            this.dgvAgentes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAgentes.Size = new System.Drawing.Size(285, 172);
            this.dgvAgentes.TabIndex = 9;
            // 
            // ManageAgentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvAgentes);
            this.Controls.Add(this.btnEliminarAgente);
            this.Controls.Add(this.btnActualizarAgente);
            this.Controls.Add(this.btnGuardarAgente);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtZona);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "ManageAgentsForm";
            this.Text = "ManageAgentsForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgentes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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