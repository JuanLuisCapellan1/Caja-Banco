using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA_BANCO
{
    public partial class FormPrincipal : Form
    {
        Token token = new Token();
        int clienteid;
        public FormPrincipal(Token token, int clienteid)
        {
            InitializeComponent();
            this.token = token;
            this.clienteid = clienteid;
            btnEntradaEfectivo.Click += new EventHandler(Button_Click);
            btnRetiro.Click += new EventHandler(Button_Click);
            btnConsulta.Click += new EventHandler(Button_Click);
            btnSalir.Click += new EventHandler(Button_Click);
            btnTransferencia.Click += new EventHandler(Button_Click);

        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                FormsCuentas formsCuentas;
                switch (clickedButton.Name)
                {
                    case "btnEntradaEfectivo":
                        this.Close();
                        formsCuentas = new FormsCuentas(token, "btnEntradaEfectivo", clienteid);
                        formsCuentas.Show();
                        break;
                    case "btnRetiro":
                        this.Close();
                        formsCuentas = new FormsCuentas(token, "btnRetiro", clienteid);
                        formsCuentas.Show();
                        break;
                    case "btnConsulta":
                        this.Close();
                        formsCuentas = new FormsCuentas(token, "btnConsulta", clienteid);
                        formsCuentas.Show();
                        break;
                    case "btnTransferencia":
                        this.Close();
                        Transferencia transferencia = new Transferencia(token, clienteid);
                        transferencia.Show();
                        break;
                    case "btnSalir":
                        Application.Exit();
                        break;
                }
            }
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}

