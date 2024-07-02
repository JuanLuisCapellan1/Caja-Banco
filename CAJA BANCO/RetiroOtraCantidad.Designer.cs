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
            this.lblEntradaEfectivo = new System.Windows.Forms.Label();
            this.numRetiroValue = new System.Windows.Forms.NumericUpDown();
            this.btnRetiro = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numRetiroValue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEntradaEfectivo
            // 
            this.lblEntradaEfectivo.AutoSize = true;
            this.lblEntradaEfectivo.Font = new System.Drawing.Font("Monotype Corsiva", 12.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradaEfectivo.Location = new System.Drawing.Point(24, 46);
            this.lblEntradaEfectivo.Name = "lblEntradaEfectivo";
            this.lblEntradaEfectivo.Size = new System.Drawing.Size(252, 25);
            this.lblEntradaEfectivo.TabIndex = 6;
            this.lblEntradaEfectivo.Text = "Cuanto dinero desea Retirar:";
            this.lblEntradaEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numRetiroValue
            // 
            this.numRetiroValue.DecimalPlaces = 2;
            this.numRetiroValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRetiroValue.Location = new System.Drawing.Point(75, 107);
            this.numRetiroValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numRetiroValue.Name = "numRetiroValue";
            this.numRetiroValue.Size = new System.Drawing.Size(131, 28);
            this.numRetiroValue.TabIndex = 7;
            this.numRetiroValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numRetiroValue.ThousandsSeparator = true;
            // 
            // btnRetiro
            // 
            this.btnRetiro.Location = new System.Drawing.Point(75, 204);
            this.btnRetiro.Margin = new System.Windows.Forms.Padding(4);
            this.btnRetiro.Name = "btnRetiro";
            this.btnRetiro.Size = new System.Drawing.Size(131, 53);
            this.btnRetiro.TabIndex = 8;
            this.btnRetiro.Text = "Confirmar";
            this.btnRetiro.UseVisualStyleBackColor = true;
            this.btnRetiro.Click += new System.EventHandler(this.btnRetiro_Click);
            // 
            // RetiroOtraCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 317);
            this.Controls.Add(this.btnRetiro);
            this.Controls.Add(this.numRetiroValue);
            this.Controls.Add(this.lblEntradaEfectivo);
            this.Name = "RetiroOtraCantidad";
            this.Text = "RetiroOtraCantidad";
            ((System.ComponentModel.ISupportInitialize)(this.numRetiroValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEntradaEfectivo;
        private System.Windows.Forms.NumericUpDown numRetiroValue;
        private System.Windows.Forms.Button btnRetiro;
    }
}