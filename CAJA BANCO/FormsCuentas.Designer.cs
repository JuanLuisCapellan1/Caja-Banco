namespace CAJA_BANCO
{
    partial class FormsCuentas
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbCuentas = new System.Windows.Forms.ComboBox();
            this.btnListCuentas = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(86, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una cuenta:";
            // 
            // cbCuentas
            // 
            this.cbCuentas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCuentas.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbCuentas.FormattingEnabled = true;
            this.cbCuentas.Location = new System.Drawing.Point(12, 102);
            this.cbCuentas.Name = "cbCuentas";
            this.cbCuentas.Size = new System.Drawing.Size(351, 24);
            this.cbCuentas.TabIndex = 2;
            // 
            // btnListCuentas
            // 
            this.btnListCuentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListCuentas.Location = new System.Drawing.Point(136, 147);
            this.btnListCuentas.Name = "btnListCuentas";
            this.btnListCuentas.Size = new System.Drawing.Size(104, 32);
            this.btnListCuentas.TabIndex = 3;
            this.btnListCuentas.Text = "Continuar";
            this.btnListCuentas.UseVisualStyleBackColor = true;
            this.btnListCuentas.Click += new System.EventHandler(this.btnListCuentas_Click);
            // 
            // FormsCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 208);
            this.Controls.Add(this.btnListCuentas);
            this.Controls.Add(this.cbCuentas);
            this.Controls.Add(this.label1);
            this.Name = "FormsCuentas";
            this.Text = "FormsCuentas";
            this.Load += new System.EventHandler(this.FormsCuentas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCuentas;
        private System.Windows.Forms.Button btnListCuentas;
    }
}