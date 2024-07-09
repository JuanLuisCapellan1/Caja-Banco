namespace CAJA_BANCO
{
    partial class EntradaEfectivoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntradaEfectivoForm));
            this.btnDeposito = new System.Windows.Forms.Button();
            this.lblEntradaEfectivo = new System.Windows.Forms.Label();
            this.NumValue = new System.Windows.Forms.NumericUpDown();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeposito
            // 
            this.btnDeposito.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(105)))), ((int)(((byte)(7)))));
            this.btnDeposito.FlatAppearance.BorderSize = 0;
            this.btnDeposito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeposito.ForeColor = System.Drawing.Color.Snow;
            this.btnDeposito.Location = new System.Drawing.Point(42, 107);
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(98, 43);
            this.btnDeposito.TabIndex = 1;
            this.btnDeposito.Text = "Confirmar";
            this.btnDeposito.UseVisualStyleBackColor = false;
            this.btnDeposito.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblEntradaEfectivo
            // 
            this.lblEntradaEfectivo.AutoSize = true;
            this.lblEntradaEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradaEfectivo.Location = new System.Drawing.Point(35, 12);
            this.lblEntradaEfectivo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEntradaEfectivo.Name = "lblEntradaEfectivo";
            this.lblEntradaEfectivo.Size = new System.Drawing.Size(119, 17);
            this.lblEntradaEfectivo.TabIndex = 5;
            this.lblEntradaEfectivo.Text = "¿Cuánto dinero";
            this.lblEntradaEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntradaEfectivo.UseMnemonic = false;
            this.lblEntradaEfectivo.Click += new System.EventHandler(this.label2_Click);
            // 
            // NumValue
            // 
            this.NumValue.DecimalPlaces = 2;
            this.NumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumValue.Location = new System.Drawing.Point(42, 58);
            this.NumValue.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NumValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumValue.Name = "NumValue";
            this.NumValue.Size = new System.Drawing.Size(98, 28);
            this.NumValue.TabIndex = 6;
            this.NumValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumValue.ThousandsSeparator = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(-20, 77);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(225, 118);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "desea depositar?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.UseMnemonic = false;
            // 
            // EntradaEfectivoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(192, 172);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumValue);
            this.Controls.Add(this.lblEntradaEfectivo);
            this.Controls.Add(this.btnDeposito);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EntradaEfectivoForm";
            this.Text = "Entrada de Efectivo";
            this.Load += new System.EventHandler(this.EntradaEfectivoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDeposito;
        private System.Windows.Forms.Label lblEntradaEfectivo;
        private System.Windows.Forms.NumericUpDown NumValue;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label label1;
    }
}