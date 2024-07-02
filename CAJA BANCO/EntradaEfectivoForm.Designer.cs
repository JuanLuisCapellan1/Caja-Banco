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
            this.btnDeposito = new System.Windows.Forms.Button();
            this.lblEntradaEfectivo = new System.Windows.Forms.Label();
            this.NumValue = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDeposito
            // 
            this.btnDeposito.Location = new System.Drawing.Point(69, 130);
            this.btnDeposito.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeposito.Name = "btnDeposito";
            this.btnDeposito.Size = new System.Drawing.Size(131, 53);
            this.btnDeposito.TabIndex = 1;
            this.btnDeposito.Text = "Confirmar";
            this.btnDeposito.UseVisualStyleBackColor = true;
            this.btnDeposito.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblEntradaEfectivo
            // 
            this.lblEntradaEfectivo.AutoSize = true;
            this.lblEntradaEfectivo.Font = new System.Drawing.Font("Monotype Corsiva", 12.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntradaEfectivo.Location = new System.Drawing.Point(17, 37);
            this.lblEntradaEfectivo.Name = "lblEntradaEfectivo";
            this.lblEntradaEfectivo.Size = new System.Drawing.Size(262, 25);
            this.lblEntradaEfectivo.TabIndex = 5;
            this.lblEntradaEfectivo.Text = "Cuanto dinero desea depositar";
            this.lblEntradaEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEntradaEfectivo.Click += new System.EventHandler(this.label2_Click);
            // 
            // NumValue
            // 
            this.NumValue.DecimalPlaces = 2;
            this.NumValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumValue.Location = new System.Drawing.Point(69, 75);
            this.NumValue.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.NumValue.Name = "NumValue";
            this.NumValue.Size = new System.Drawing.Size(131, 28);
            this.NumValue.TabIndex = 6;
            this.NumValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NumValue.ThousandsSeparator = true;
            // 
            // EntradaEfectivoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 196);
            this.Controls.Add(this.NumValue);
            this.Controls.Add(this.lblEntradaEfectivo);
            this.Controls.Add(this.btnDeposito);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EntradaEfectivoForm";
            this.Text = "Entrada de Efectivo";
            this.Load += new System.EventHandler(this.EntradaEfectivoForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDeposito;
        private System.Windows.Forms.Label lblEntradaEfectivo;
        private System.Windows.Forms.NumericUpDown NumValue;
    }
}