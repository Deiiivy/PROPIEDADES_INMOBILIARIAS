namespace PROPIEDADES_INMOBILIARIAS.Forms
{
    partial class SolicitarVisitaForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboPropiedades;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.DateTimePicker dateTimePickerHora;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label labelPropiedad;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelHora;

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
            this.comboPropiedades = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFecha = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerHora = new System.Windows.Forms.DateTimePicker();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.labelPropiedad = new System.Windows.Forms.Label();
            this.labelFecha = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelPropiedad
            // 
            this.labelPropiedad.AutoSize = true;
            this.labelPropiedad.Location = new System.Drawing.Point(12, 15);
            this.labelPropiedad.Name = "labelPropiedad";
            this.labelPropiedad.Size = new System.Drawing.Size(56, 13);
            this.labelPropiedad.TabIndex = 0;
            this.labelPropiedad.Text = "Propiedad";
            // 
            // comboPropiedades
            // 
            this.comboPropiedades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPropiedades.FormattingEnabled = true;
            this.comboPropiedades.Location = new System.Drawing.Point(90, 12);
            this.comboPropiedades.Name = "comboPropiedades";
            this.comboPropiedades.Size = new System.Drawing.Size(200, 21);
            this.comboPropiedades.TabIndex = 1;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.Location = new System.Drawing.Point(12, 50);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(37, 13);
            this.labelFecha.TabIndex = 2;
            this.labelFecha.Text = "Fecha";
            // 
            // dateTimePickerFecha
            // 
            this.dateTimePickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFecha.Location = new System.Drawing.Point(90, 46);
            this.dateTimePickerFecha.Name = "dateTimePickerFecha";
            this.dateTimePickerFecha.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFecha.TabIndex = 3;
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.Location = new System.Drawing.Point(12, 85);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(30, 13);
            this.labelHora.TabIndex = 4;
            this.labelHora.Text = "Hora";
            // 
            // dateTimePickerHora
            // 
            this.dateTimePickerHora.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePickerHora.ShowUpDown = true;
            this.dateTimePickerHora.Location = new System.Drawing.Point(90, 81);
            this.dateTimePickerHora.Name = "dateTimePickerHora";
            this.dateTimePickerHora.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerHora.TabIndex = 5;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(90, 120);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 6;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            // 
            // SolicitarVisitaForm
            // 
            this.ClientSize = new System.Drawing.Size(310, 160);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.dateTimePickerHora);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.dateTimePickerFecha);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.comboPropiedades);
            this.Controls.Add(this.labelPropiedad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SolicitarVisitaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitar Visita";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }

}