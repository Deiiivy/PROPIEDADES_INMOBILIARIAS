namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class AdminDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador

        private void InitializeComponent()
        {
            this.btnManageProperties = new System.Windows.Forms.Button();
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnManageAgents = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnManageProperties
            // 
            this.btnManageProperties.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnManageProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageProperties.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageProperties.ForeColor = System.Drawing.Color.White;
            this.btnManageProperties.Location = new System.Drawing.Point(100, 140);
            this.btnManageProperties.Name = "btnManageProperties";
            this.btnManageProperties.Size = new System.Drawing.Size(180, 40);
            this.btnManageProperties.TabIndex = 0;
            this.btnManageProperties.Text = "Gestionar Propiedades";
            this.btnManageProperties.UseVisualStyleBackColor = false;
            this.btnManageProperties.Click += new System.EventHandler(this.btnManageProperties_Click);
            // 
            // btnManageClients
            // 
            this.btnManageClients.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnManageClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageClients.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageClients.ForeColor = System.Drawing.Color.White;
            this.btnManageClients.Location = new System.Drawing.Point(320, 140);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(180, 40);
            this.btnManageClients.TabIndex = 1;
            this.btnManageClients.Text = "Gestionar Clientes";
            this.btnManageClients.UseVisualStyleBackColor = false;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnManageAgents
            // 
            this.btnManageAgents.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnManageAgents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageAgents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnManageAgents.ForeColor = System.Drawing.Color.White;
            this.btnManageAgents.Location = new System.Drawing.Point(540, 140);
            this.btnManageAgents.Name = "btnManageAgents";
            this.btnManageAgents.Size = new System.Drawing.Size(180, 40);
            this.btnManageAgents.TabIndex = 2;
            this.btnManageAgents.Text = "Gestionar Agentes";
            this.btnManageAgents.UseVisualStyleBackColor = false;
            this.btnManageAgents.Click += new System.EventHandler(this.btnManageAgents_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(220, 53, 69); // rojo para salir
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(680, 20);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(90, 30);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Cerrar sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.Gray;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(20, 20);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(90, 30);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Volver";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(320, 40);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(180, 37);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Panel Admin";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 300);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageAgents);
            this.Controls.Add(this.btnManageClients);
            this.Controls.Add(this.btnManageProperties);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "AdminDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel Administrativo";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnManageProperties;
        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnManageAgents;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelTitle;
    }
}
