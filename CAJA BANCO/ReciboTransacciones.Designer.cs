namespace CAJA_BANCO
{
    partial class ReciboTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReciboTransacciones));
            this.rpvTransaccion = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvTransaccion
            // 
            this.rpvTransaccion.LocalReport.ReportEmbeddedResource = "CAJA_BANCO.ReciboTransacciones.rdlc";
            this.rpvTransaccion.Location = new System.Drawing.Point(17, 12);
            this.rpvTransaccion.Name = "rpvTransaccion";
            this.rpvTransaccion.ServerReport.BearerToken = null;
            this.rpvTransaccion.Size = new System.Drawing.Size(1007, 739);
            this.rpvTransaccion.TabIndex = 0;
            // 
            // ReciboTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1040, 772);
            this.Controls.Add(this.rpvTransaccion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReciboTransacciones";
            this.Text = "Recibo Transacciones";
            this.Load += new System.EventHandler(this.ReciboTransacciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvTransaccion;
    }
}