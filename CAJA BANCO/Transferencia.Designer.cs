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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Transferencia));
            this.comboBoxCuentaOrigen = new System.Windows.Forms.ComboBox();
            this.lblOrigen = new System.Windows.Forms.Label();
            this.lblDestino = new System.Windows.Forms.Label();
            this.comboBoxCuentaDestino = new System.Windows.Forms.ComboBox();
            this.numMontoTransferencia = new System.Windows.Forms.NumericUpDown();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cbTipoTransaccion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBeneficiarios = new System.Windows.Forms.ComboBox();
            this.lblBeneficiario = new System.Windows.Forms.Label();
            this.linkBeneficiario = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numMontoTransferencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxCuentaOrigen
            // 
            this.comboBoxCuentaOrigen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxCuentaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCuentaOrigen.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCuentaOrigen.FormattingEnabled = true;
            this.comboBoxCuentaOrigen.Location = new System.Drawing.Point(12, 117);
            this.comboBoxCuentaOrigen.Name = "comboBoxCuentaOrigen";
            this.comboBoxCuentaOrigen.Size = new System.Drawing.Size(363, 26);
            this.comboBoxCuentaOrigen.TabIndex = 0;
            this.comboBoxCuentaOrigen.SelectedIndexChanged += new System.EventHandler(this.comboBoxCuentaOrigen_SelectedIndexChanged);
            // 
            // lblOrigen
            // 
            this.lblOrigen.AutoSize = true;
            this.lblOrigen.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrigen.Location = new System.Drawing.Point(12, 90);
            this.lblOrigen.Name = "lblOrigen";
            this.lblOrigen.Size = new System.Drawing.Size(285, 24);
            this.lblOrigen.TabIndex = 1;
            this.lblOrigen.Text = "Seleccione la cuenta de origen";
            // 
            // lblDestino
            // 
            this.lblDestino.AutoSize = true;
            this.lblDestino.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDestino.Location = new System.Drawing.Point(12, 171);
            this.lblDestino.Name = "lblDestino";
            this.lblDestino.Size = new System.Drawing.Size(296, 24);
            this.lblDestino.TabIndex = 2;
            this.lblDestino.Text = "Seleccione la cuenta de Destino";
            this.lblDestino.Visible = false;
            // 
            // comboBoxCuentaDestino
            // 
            this.comboBoxCuentaDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxCuentaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCuentaDestino.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCuentaDestino.FormattingEnabled = true;
            this.comboBoxCuentaDestino.Location = new System.Drawing.Point(12, 198);
            this.comboBoxCuentaDestino.Name = "comboBoxCuentaDestino";
            this.comboBoxCuentaDestino.Size = new System.Drawing.Size(363, 26);
            this.comboBoxCuentaDestino.TabIndex = 3;
            this.comboBoxCuentaDestino.Visible = false;
            this.comboBoxCuentaDestino.SelectedIndexChanged += new System.EventHandler(this.comboBoxCuentaDestino_SelectedIndexChanged_1);
            // 
            // numMontoTransferencia
            // 
            this.numMontoTransferencia.DecimalPlaces = 2;
            this.numMontoTransferencia.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMontoTransferencia.Location = new System.Drawing.Point(100, 357);
            this.numMontoTransferencia.Margin = new System.Windows.Forms.Padding(1);
            this.numMontoTransferencia.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMontoTransferencia.Name = "numMontoTransferencia";
            this.numMontoTransferencia.Size = new System.Drawing.Size(180, 48);
            this.numMontoTransferencia.TabIndex = 4;
            this.numMontoTransferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numMontoTransferencia.ThousandsSeparator = true;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(105)))), ((int)(((byte)(7)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmar.ForeColor = System.Drawing.Color.Snow;
            this.btnConfirmar.Location = new System.Drawing.Point(100, 433);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(180, 54);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.InitialImage")));
            this.pictureBox4.Location = new System.Drawing.Point(-173, 346);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(750, 213);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 14;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(183, 146);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 101);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // cbTipoTransaccion
            // 
            this.cbTipoTransaccion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbTipoTransaccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipoTransaccion.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipoTransaccion.FormattingEnabled = true;
            this.cbTipoTransaccion.Location = new System.Drawing.Point(12, 54);
            this.cbTipoTransaccion.Name = "cbTipoTransaccion";
            this.cbTipoTransaccion.Size = new System.Drawing.Size(363, 26);
            this.cbTipoTransaccion.TabIndex = 16;
            this.cbTipoTransaccion.SelectedIndexChanged += new System.EventHandler(this.cbTipoTransaccion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(314, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "Seleccione el tipo de Trasferencia:";
            // 
            // cbBeneficiarios
            // 
            this.cbBeneficiarios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbBeneficiarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeneficiarios.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeneficiarios.FormattingEnabled = true;
            this.cbBeneficiarios.Location = new System.Drawing.Point(12, 273);
            this.cbBeneficiarios.Name = "cbBeneficiarios";
            this.cbBeneficiarios.Size = new System.Drawing.Size(363, 26);
            this.cbBeneficiarios.TabIndex = 19;
            this.cbBeneficiarios.Visible = false;
            // 
            // lblBeneficiario
            // 
            this.lblBeneficiario.AutoSize = true;
            this.lblBeneficiario.Font = new System.Drawing.Font("Montserrat", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiario.Location = new System.Drawing.Point(12, 246);
            this.lblBeneficiario.Name = "lblBeneficiario";
            this.lblBeneficiario.Size = new System.Drawing.Size(251, 24);
            this.lblBeneficiario.TabIndex = 18;
            this.lblBeneficiario.Text = "Seleccione un beneficiario:";
            this.lblBeneficiario.Visible = false;
            // 
            // linkBeneficiario
            // 
            this.linkBeneficiario.AutoSize = true;
            this.linkBeneficiario.Location = new System.Drawing.Point(12, 302);
            this.linkBeneficiario.Name = "linkBeneficiario";
            this.linkBeneficiario.Size = new System.Drawing.Size(136, 16);
            this.linkBeneficiario.TabIndex = 20;
            this.linkBeneficiario.TabStop = true;
            this.linkBeneficiario.Text = "Registrar Beneficiario";
            this.linkBeneficiario.Visible = false;
            this.linkBeneficiario.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkBeneficiario_LinkClicked);
            // 
            // Transferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(230)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(387, 499);
            this.Controls.Add(this.linkBeneficiario);
            this.Controls.Add(this.cbBeneficiarios);
            this.Controls.Add(this.lblBeneficiario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTipoTransaccion);
            this.Controls.Add(this.lblOrigen);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.numMontoTransferencia);
            this.Controls.Add(this.comboBoxCuentaDestino);
            this.Controls.Add(this.lblDestino);
            this.Controls.Add(this.comboBoxCuentaOrigen);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Transferencia";
            this.Text = "Transferencia";
            this.Load += new System.EventHandler(this.Transferencia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numMontoTransferencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCuentaOrigen;
        private System.Windows.Forms.Label lblOrigen;
        private System.Windows.Forms.Label lblDestino;
        private System.Windows.Forms.ComboBox comboBoxCuentaDestino;
        private System.Windows.Forms.NumericUpDown numMontoTransferencia;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cbTipoTransaccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbBeneficiarios;
        private System.Windows.Forms.Label lblBeneficiario;
        private System.Windows.Forms.LinkLabel linkBeneficiario;
    }
}