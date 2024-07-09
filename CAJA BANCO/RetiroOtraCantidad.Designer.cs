namespace CAJA_BANCO
{
    partial class RetiroOtraCantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RetiroOtraCantidad));
            this.lblEntradaEfectivo = new System.Windows.Forms.Label();
            this.numRetiroValue = new System.Windows.Forms.NumericUpDown();
            this.btnRetiro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numRetiroValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntradaEfectivo
            // 
            this.lblEntradaEfectivo.AutoSize = true;
            this.lblEntradaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradaEfectivo.Location = new System.Drawing.Point(37, 15);
            this.lblEntradaEfectivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEntradaEfectivo.Name = "lblEntradaEfectivo";
            this.lblEntradaEfectivo.Size = new System.Drawing.Size(132, 20);
            this.lblEntradaEfectivo.TabIndex = 6;
            this.lblEntradaEfectivo.Text = "¿Cuánto dinero";
            this.lblEntradaEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numRetiroValue
            // 
            this.numRetiroValue.DecimalPlaces = 2;
            this.numRetiroValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRetiroValue.Location = new System.Drawing.Point(51, 71);
            this.numRetiroValue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.numRetiroValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numRetiroValue.Name = "numRetiroValue";
            this.numRetiroValue.Size = new System.Drawing.Size(98, 28);
            this.numRetiroValue.TabIndex = 7;
            this.numRetiroValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRetiroValue.ThousandsSeparator = true;
            // 
            // btnRetiro
            // 
            this.btnRetiro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(105)))), ((int)(((byte)(7)))));
            this.btnRetiro.FlatAppearance.BorderSize = 0;
            this.btnRetiro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRetiro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetiro.ForeColor = System.Drawing.Color.Snow;
            this.btnRetiro.Location = new System.Drawing.Point(51, 128);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(98, 43);
            this.btnRetiro.TabIndex = 8;
            this.btnRetiro.Text = "Confirmar";
            this.btnRetiro.UseVisualStyleBackColor = false;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "desea retirar?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(-18, 103);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(248, 124);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            // 
            // RetiroOtraCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(209, 193);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRetiro);
            this.Controls.Add(this.numRetiroValue);
            this.Controls.Add(this.lblEntradaEfectivo);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "RetiroOtraCantidad";
            this.Text = "Retiro Otra Cantidad";
            ((System.ComponentModel.ISupportInitialize)(this.numRetiroValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntradaEfectivo;
        private System.Windows.Forms.NumericUpDown numRetiroValue;
        private System.Windows.Forms.Button btnRetiro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}