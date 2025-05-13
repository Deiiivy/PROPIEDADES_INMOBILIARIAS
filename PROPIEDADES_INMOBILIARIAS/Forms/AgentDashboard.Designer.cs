namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class AgentDashboard
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
            this.btnManageOwnProperties = new System.Windows.Forms.Button();
            this.btnManageVisits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnManageOwnProperties
            // 
            this.btnManageOwnProperties.Location = new System.Drawing.Point(90, 104);
            this.btnManageOwnProperties.Name = "btnManageOwnProperties";
            this.btnManageOwnProperties.Size = new System.Drawing.Size(152, 23);
            this.btnManageOwnProperties.TabIndex = 0;
            this.btnManageOwnProperties.Text = "Gestionar Propiedades";
            this.btnManageOwnProperties.UseVisualStyleBackColor = true;
            this.btnManageOwnProperties.Click += new System.EventHandler(this.btnManageOwnProperties_Click);
            // 
            // btnManageVisits
            // 
            this.btnManageVisits.Location = new System.Drawing.Point(265, 104);
            this.btnManageVisits.Name = "btnManageVisits";
            this.btnManageVisits.Size = new System.Drawing.Size(182, 23);
            this.btnManageVisits.TabIndex = 1;
            this.btnManageVisits.Text = "Gestionar Visitas";
            this.btnManageVisits.UseVisualStyleBackColor = true;
            this.btnManageVisits.Click += new System.EventHandler(this.btnManageVisits_Click);
            // 
            // AgentDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnManageVisits);
            this.Controls.Add(this.btnManageOwnProperties);
            this.Name = "AgentDashboard";
            this.Text = "AgentDashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnManageOwnProperties;
        private System.Windows.Forms.Button btnManageVisits;
    }
}