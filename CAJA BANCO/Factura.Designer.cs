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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Factura));
            this.lblFactura = new System.Windows.Forms.Label();
            this.btnNoFactura = new System.Windows.Forms.Button();
            this.btnSiFactura = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFactura
            // 
            this.lblFactura.AutoSize = true;
            this.lblFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFactura.Location = new System.Drawing.Point(26, 22);
            this.lblFactura.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFactura.Name = "lblFactura";
            this.lblFactura.Size = new System.Drawing.Size(159, 24);
            this.lblFactura.TabIndex = 7;
            this.lblFactura.Text = "¿Desea factura?";
            this.lblFactura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNoFactura
            // 
            this.btnNoFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(51)))), ((int)(((byte)(64)))));
            this.btnNoFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNoFactura.ForeColor = System.Drawing.Color.Snow;
            this.btnNoFactura.Location = new System.Drawing.Point(122, 67);
            this.btnNoFactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNoFactura.Name = "btnNoFactura";
            this.btnNoFactura.Size = new System.Drawing.Size(82, 33);
            this.btnNoFactura.TabIndex = 8;
            this.btnNoFactura.Text = "No";
            this.btnNoFactura.UseVisualStyleBackColor = false;
            this.btnNoFactura.Click += new System.EventHandler(this.btnNoFactura_Click);
            // 
            // btnSiFactura
            // 
            this.btnSiFactura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(105)))), ((int)(((byte)(7)))));
            this.btnSiFactura.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSiFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSiFactura.ForeColor = System.Drawing.Color.Snow;
            this.btnSiFactura.Location = new System.Drawing.Point(16, 67);
            this.btnSiFactura.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSiFactura.Name = "btnSiFactura";
            this.btnSiFactura.Size = new System.Drawing.Size(82, 33);
            this.btnSiFactura.TabIndex = 9;
            this.btnSiFactura.Text = "Si";
            this.btnSiFactura.UseVisualStyleBackColor = false;
            this.btnSiFactura.Click += new System.EventHandler(this.btnSiFactura_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(-2, 67);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(225, 118);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(220, 131);
            this.Controls.Add(this.btnSiFactura);
            this.Controls.Add(this.btnNoFactura);
            this.Controls.Add(this.lblFactura);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Factura";
            this.Text = "Factura";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFactura;
        private System.Windows.Forms.Button btnNoFactura;
        private System.Windows.Forms.Button btnSiFactura;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}