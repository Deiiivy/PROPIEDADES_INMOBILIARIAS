namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ClienteDashboard
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.btnSolicitarVisita = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPropiedades
            // 
            this.dgvPropiedades.AllowUserToAddRows = false;
            this.dgvPropiedades.AllowUserToDeleteRows = false;
            this.dgvPropiedades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPropiedades.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPropiedades.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropiedades.GridColor = System.Drawing.Color.LightGray;
            this.dgvPropiedades.Location = new System.Drawing.Point(25, 20);
            this.dgvPropiedades.MultiSelect = false;
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.ReadOnly = true;
            this.dgvPropiedades.RowHeadersVisible = false;
            this.dgvPropiedades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPropiedades.Size = new System.Drawing.Size(750, 320);
            this.dgvPropiedades.TabIndex = 0;
            this.dgvPropiedades.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SteelBlue;
            this.dgvPropiedades.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            // 
            // btnSolicitarVisita
            // 
            this.btnSolicitarVisita.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSolicitarVisita.FlatAppearance.BorderSize = 0;
            this.btnSolicitarVisita.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSolicitarVisita.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSolicitarVisita.ForeColor = System.Drawing.Color.White;
            this.btnSolicitarVisita.Location = new System.Drawing.Point(25, 360);
            this.btnSolicitarVisita.Name = "btnSolicitarVisita";
            this.btnSolicitarVisita.Size = new System.Drawing.Size(140, 40);
            this.btnSolicitarVisita.TabIndex = 1;
            this.btnSolicitarVisita.Text = "Solicitar Visita";
            this.btnSolicitarVisita.UseVisualStyleBackColor = false;
            this.btnSolicitarVisita.Click += new System.EventHandler(this.btnSolicitarVisita_Click);
            this.btnSolicitarVisita.MouseEnter += (s, e) => { this.btnSolicitarVisita.BackColor = System.Drawing.Color.DodgerBlue; };
            this.btnSolicitarVisita.MouseLeave += (s, e) => { this.btnSolicitarVisita.BackColor = System.Drawing.Color.SteelBlue; };
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.IndianRed;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(635, 360);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(140, 40);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            this.btnCerrarSesion.MouseEnter += (s, e) => { this.btnCerrarSesion.BackColor = System.Drawing.Color.Firebrick; };
            this.btnCerrarSesion.MouseLeave += (s, e) => { this.btnCerrarSesion.BackColor = System.Drawing.Color.IndianRed; };
            // 
            // btnVolver
            // 
            this.btnVolver.BackColor = System.Drawing.Color.Gray;
            this.btnVolver.FlatAppearance.BorderSize = 0;
            this.btnVolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnVolver.ForeColor = System.Drawing.Color.White;
            this.btnVolver.Location = new System.Drawing.Point(460, 360);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(140, 40);
            this.btnVolver.TabIndex = 3;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = false;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            this.btnVolver.MouseEnter += (s, e) => { this.btnVolver.BackColor = System.Drawing.Color.DarkGray; };
            this.btnVolver.MouseLeave += (s, e) => { this.btnVolver.BackColor = System.Drawing.Color.Gray; };
            // 
            // ClienteDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.btnSolicitarVisita);
            this.Controls.Add(this.dgvPropiedades);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ClienteDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel de Cliente - Propiedades Disponibles";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.Button btnSolicitarVisita;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnVolver;
    }
}
