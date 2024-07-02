namespace CAJA_BANCO
{
    partial class Factura
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
            this.lblFactura = new System.Windows.Forms.Label();
            this.btnNoFactura = new System.Windows.Forms.Button();
            this.btnSiFactura = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(62, 29);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(159, 27);
            this.lblFactura.TabIndex = 7;
            this.lblFactura.Text = "¿Desea factura?";
            this.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNoFactura
            // 
            this.btnNoFactura.Location = new System.Drawing.Point(162, 83);
            this.btnNoFactura.Name = "btnNoFactura";
            this.btnNoFactura.Size = new System.Drawing.Size(110, 41);
            this.btnNoFactura.TabIndex = 8;
            this.btnNoFactura.Text = "No";
            this.btnNoFactura.UseVisualStyleBackColor = true;
            this.btnNoFactura.Click += new System.EventHandler(this.btnNoFactura_Click);
            // 
            // btnSiFactura
            // 
            this.btnSiFactura.Location = new System.Drawing.Point(22, 83);
            this.btnSiFactura.Name = "btnSiFactura";
            this.btnSiFactura.Size = new System.Drawing.Size(110, 41);
            this.btnSiFactura.TabIndex = 9;
            this.btnSiFactura.Text = "Si";
            this.btnSiFactura.UseVisualStyleBackColor = true;
            this.btnSiFactura.Click += new System.EventHandler(this.btnSiFactura_Click);
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 161);
            this.Controls.Add(this.btnSiFactura);
            this.Controls.Add(this.btnNoFactura);
            this.Controls.Add(this.lblFactura);
            this.Name = "Factura";
            this.Text = "Factura";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Button btnNoFactura;
        private System.Windows.Forms.Button btnSiFactura;
    }
}