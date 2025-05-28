namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class AgentDashboard
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnManageOwnProperties = new System.Windows.Forms.Button();
            this.btnManageVisits = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(800, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Panel del Agente";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Location = new System.Drawing.Point(0, 80);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(800, 23);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Bienvenido, Agente";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnManageOwnProperties
            // 
            this.btnManageOwnProperties.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnManageOwnProperties.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageOwnProperties.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageOwnProperties.ForeColor = System.Drawing.Color.White;
            this.btnManageOwnProperties.Location = new System.Drawing.Point(250, 140);
            this.btnManageOwnProperties.Name = "btnManageOwnProperties";
            this.btnManageOwnProperties.Size = new System.Drawing.Size(300, 40);
            this.btnManageOwnProperties.TabIndex = 2;
            this.btnManageOwnProperties.Text = "Gestionar Mis Propiedades";
            this.btnManageOwnProperties.UseVisualStyleBackColor = false;
            this.btnManageOwnProperties.Click += new System.EventHandler(this.btnManageOwnProperties_Click);
            // 
            // btnManageVisits
            // 
            this.btnManageVisits.BackColor = System.Drawing.Color.Teal;
            this.btnManageVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageVisits.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnManageVisits.ForeColor = System.Drawing.Color.White;
            this.btnManageVisits.Location = new System.Drawing.Point(250, 200);
            this.btnManageVisits.Name = "btnManageVisits";
            this.btnManageVisits.Size = new System.Drawing.Size(300, 40);
            this.btnManageVisits.TabIndex = 3;
            this.btnManageVisits.Text = "Gestionar Visitas";
            this.btnManageVisits.UseVisualStyleBackColor = false;
            this.btnManageVisits.Click += new System.EventHandler(this.btnManageVisits_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.LightCoral;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(640, 385);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(130, 35);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Cerrar Sesión";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // AgentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnManageVisits);
            this.Controls.Add(this.btnManageOwnProperties);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AgentDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel del Agente";
            this.Load += new System.EventHandler(this.AgentDashboard_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnManageOwnProperties;
        private System.Windows.Forms.Button btnManageVisits;
        private System.Windows.Forms.Button btnLogout;
    }
}
