namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class ClienteDashboard
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvPropiedades;
        private System.Windows.Forms.DataGridView dgvVisitas; 
        private System.Windows.Forms.Button btnSolicitarVisita;
        private System.Windows.Forms.Button btnMarcarInteres;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPropiedades;
        private System.Windows.Forms.Label lblVisitas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvPropiedades = new System.Windows.Forms.DataGridView();
            this.dgvVisitas = new System.Windows.Forms.DataGridView();
            this.btnSolicitarVisita = new System.Windows.Forms.Button();
            this.btnMarcarInteres = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblPropiedades = new System.Windows.Forms.Label();
            this.lblVisitas = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).BeginInit();
            this.SuspendLayout();

            // dgvPropiedades
            this.dgvPropiedades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPropiedades.Location = new System.Drawing.Point(30, 50);
            this.dgvPropiedades.Name = "dgvPropiedades";
            this.dgvPropiedades.Size = new System.Drawing.Size(700, 180);
            this.dgvPropiedades.TabIndex = 0;

            // dgvVisitas
            this.dgvVisitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVisitas.Location = new System.Drawing.Point(30, 290);
            this.dgvVisitas.Name = "dgvVisitas";
            this.dgvVisitas.Size = new System.Drawing.Size(700, 150);
            this.dgvVisitas.TabIndex = 1;

            // btnSolicitarVisita
            this.btnSolicitarVisita.Location = new System.Drawing.Point(750, 50);
            this.btnSolicitarVisita.Name = "btnSolicitarVisita";
            this.btnSolicitarVisita.Size = new System.Drawing.Size(130, 40);
            this.btnSolicitarVisita.TabIndex = 2;
            this.btnSolicitarVisita.Text = "Solicitar Visita";
            this.btnSolicitarVisita.UseVisualStyleBackColor = true;
            this.btnSolicitarVisita.Click += new System.EventHandler(this.btnSolicitarVisita_Click);

            // btnMarcarInteres
            this.btnMarcarInteres.Location = new System.Drawing.Point(750, 100);
            this.btnMarcarInteres.Name = "btnMarcarInteres";
            this.btnMarcarInteres.Size = new System.Drawing.Size(130, 40);
            this.btnMarcarInteres.TabIndex = 3;
            this.btnMarcarInteres.Text = "Marcar Interés";
            this.btnMarcarInteres.UseVisualStyleBackColor = true;
            this.btnMarcarInteres.Click += new System.EventHandler(this.btnMarcarInteres_Click);

            // btnCerrarSesion
            this.btnCerrarSesion.Location = new System.Drawing.Point(750, 400);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(130, 40);
            this.btnCerrarSesion.TabIndex = 4;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);

            // btnVolver
            this.btnVolver.Location = new System.Drawing.Point(750, 350);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(130, 40);
            this.btnVolver.TabIndex = 5;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);

            // lblPropiedades
            this.lblPropiedades.AutoSize = true;
            this.lblPropiedades.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPropiedades.Location = new System.Drawing.Point(30, 20);
            this.lblPropiedades.Name = "lblPropiedades";
            this.lblPropiedades.Size = new System.Drawing.Size(182, 19);
            this.lblPropiedades.Text = "Propiedades disponibles:";

            // lblVisitas
            this.lblVisitas.AutoSize = true;
            this.lblVisitas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblVisitas.Location = new System.Drawing.Point(30, 260);
            this.lblVisitas.Name = "lblVisitas";
            this.lblVisitas.Size = new System.Drawing.Size(144, 19);
            this.lblVisitas.Text = "Visitas agendadas:";

            // ClienteDashboard
            this.ClientSize = new System.Drawing.Size(900, 470);
            this.Controls.Add(this.lblPropiedades);
            this.Controls.Add(this.lblVisitas);
            this.Controls.Add(this.dgvPropiedades);
            this.Controls.Add(this.dgvVisitas);
            this.Controls.Add(this.btnSolicitarVisita);
            this.Controls.Add(this.btnMarcarInteres);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnCerrarSesion);
            this.Name = "ClienteDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel del Cliente";

            ((System.ComponentModel.ISupportInitialize)(this.dgvPropiedades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVisitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
