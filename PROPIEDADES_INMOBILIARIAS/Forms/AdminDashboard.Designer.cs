namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class AdminDashboard
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
            this.btnManageProperties = new System.Windows.Forms.Button();
            this.btnManageClients = new System.Windows.Forms.Button();
            this.btnManageAgents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageProperties
            // 
            this.btnManageProperties.Location = new System.Drawing.Point(166, 115);
            this.btnManageProperties.Name = "btnManageProperties";
            this.btnManageProperties.Size = new System.Drawing.Size(143, 23);
            this.btnManageProperties.TabIndex = 0;
            this.btnManageProperties.Text = "Gestionar Propiedades";
            this.btnManageProperties.UseVisualStyleBackColor = true;
            this.btnManageProperties.Click += new System.EventHandler(this.btnManageProperties_Click);
            // 
            // btnManageClients
            // 
            this.btnManageClients.Location = new System.Drawing.Point(348, 115);
            this.btnManageClients.Name = "btnManageClients";
            this.btnManageClients.Size = new System.Drawing.Size(134, 23);
            this.btnManageClients.TabIndex = 1;
            this.btnManageClients.Text = "Gestionar Clientes";
            this.btnManageClients.UseVisualStyleBackColor = true;
            this.btnManageClients.Click += new System.EventHandler(this.btnManageClients_Click);
            // 
            // btnManageAgents
            // 
            this.btnManageAgents.Location = new System.Drawing.Point(506, 115);
            this.btnManageAgents.Name = "btnManageAgents";
            this.btnManageAgents.Size = new System.Drawing.Size(160, 23);
            this.btnManageAgents.TabIndex = 2;
            this.btnManageAgents.Text = "Gestionar Agentes";
            this.btnManageAgents.UseVisualStyleBackColor = true;
            this.btnManageAgents.Click += new System.EventHandler(this.btnManageAgents_Click);
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageAgents);
            this.Controls.Add(this.btnManageClients);
            this.Controls.Add(this.btnManageProperties);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageProperties;
        private System.Windows.Forms.Button btnManageClients;
        private System.Windows.Forms.Button btnManageAgents;
    }
}