namespace CAJA_BANCO
{
    partial class CuadreTransacciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CuadreTransacciones));
            this.rpvCuadre = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpvCuadre
            // 
            this.rpvCuadre.LocalReport.ReportEmbeddedResource = "CAJA_BANCO.CuadreTransacciones.rdlc";
            this.rpvCuadre.Location = new System.Drawing.Point(13, 13);
            this.rpvCuadre.Margin = new System.Windows.Forms.Padding(4);
            this.rpvCuadre.Name = "rpvCuadre";
            this.rpvCuadre.ServerReport.BearerToken = null;
            this.rpvCuadre.Size = new System.Drawing.Size(1067, 738);
            this.rpvCuadre.TabIndex = 0;
            this.rpvCuadre.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // CuadreTransacciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1100, 765);
            this.Controls.Add(this.rpvCuadre);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CuadreTransacciones";
            this.Text = "Cuadre Transacciones";
            this.Load += new System.EventHandler(this.CuadreTransacciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpvCuadre;
    }
}