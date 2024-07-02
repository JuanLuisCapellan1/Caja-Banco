namespace CAJA_BANCO
{
    partial class Transferencia
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
            this.comboBoxCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxCuentaDestino = new System.Windows.Forms.ComboBox();
            this.numMontoTransferencia = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoTransferencia)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCuentaOrigen
            // 
            this.comboBoxCuentaOrigen.FormattingEnabled = true;
            this.comboBoxCuentaOrigen.Location = new System.Drawing.Point(12, 66);
            this.comboBoxCuentaOrigen.Name = "comboBoxCuentaOrigen";
            this.comboBoxCuentaOrigen.Size = new System.Drawing.Size(363, 24);
            this.comboBoxCuentaOrigen.TabIndex = 0;
            this.comboBoxCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.comboBoxCuentaOrigen_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione la cuenta de origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(89, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Seleccione la cuenta de Destino";
            // 
            // comboBoxCuentaDestino
            // 
            this.comboBoxCuentaDestino.FormattingEnabled = true;
            this.comboBoxCuentaDestino.Location = new System.Drawing.Point(12, 160);
            this.comboBoxCuentaDestino.Name = "comboBoxCuentaDestino";
            this.comboBoxCuentaDestino.Size = new System.Drawing.Size(363, 24);
            this.comboBoxCuentaDestino.TabIndex = 3;
            this.comboBoxCuentaDestino.SelectedIndexChanged += new System.EventHandler(this.comboBoxCuentaDestino_SelectedIndexChanged_1);
            // 
            // numMontoTransferencia
            // 
            this.numMontoTransferencia.DecimalPlaces = 2;
            this.numMontoTransferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMontoTransferencia.Location = new System.Drawing.Point(126, 231);
            this.numMontoTransferencia.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMontoTransferencia.Name = "numMontoTransferencia";
            this.numMontoTransferencia.Size = new System.Drawing.Size(120, 28);
            this.numMontoTransferencia.TabIndex = 4;
            this.numMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMontoTransferencia.ThousandsSeparator = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(106, 296);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(161, 54);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // Transferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 409);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.numMontoTransferencia);
            this.Controls.Add(this.comboBoxCuentaDestino);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCuentaOrigen);
            this.Name = "Transferencia";
            this.Text = "Transferencia";
            this.Load += new System.EventHandler(this.Transferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMontoTransferencia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCuentaOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxCuentaDestino;
        private System.Windows.Forms.NumericUpDown numMontoTransferencia;
        private System.Windows.Forms.Button btnConfirmar;
    }
}