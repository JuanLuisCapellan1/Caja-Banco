namespace CAJA_BANCO
{
    partial class Balance_actual
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblIBalanceActual = new System.Windows.Forms.Label();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tu ingreso total es:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIBalanceActual
            // 
            this.lblIBalanceActual.AutoSize = true;
            this.lblIBalanceActual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblIBalanceActual.Location = new System.Drawing.Point(49, 94);
            this.lblIBalanceActual.Name = "lblIBalanceActual";
            this.lblIBalanceActual.Size = new System.Drawing.Size(152, 16);
            this.lblIBalanceActual.TabIndex = 5;
            this.lblIBalanceActual.Text = "Aqui pongan la cantidad";
            this.lblIBalanceActual.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnContinuar
            // 
            this.btnContinuar.Location = new System.Drawing.Point(68, 165);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(110, 41);
            this.btnContinuar.TabIndex = 7;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = true;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // Balance_actual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 264);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblIBalanceActual);
            this.Name = "Balance_actual";
            this.Text = "Balance ";
            this.Load += new System.EventHandler(this.Balance_actual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblIBalanceActual;
        private System.Windows.Forms.Button btnContinuar;
    }
}