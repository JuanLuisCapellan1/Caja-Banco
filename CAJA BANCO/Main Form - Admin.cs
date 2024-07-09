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
    public partial class Main_Form___Admin : Form
    {
        Token token;
        int clienteId;
        public Main_Form___Admin(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnEntradaEfectivo_Click(object sender, EventArgs e)
        {
            GestionarClientes gestionarClientes = new GestionarClientes(token, clienteId);
            gestionarClientes.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GestionarTiposTransacciones gestionarTiposTransacciones = new GestionarTiposTransacciones(token, clienteId);
            gestionarTiposTransacciones.Show();
            this.Hide();
        }

        private void btnGestionarCuentas_Click(object sender, EventArgs e)
        {
            GestionarCuentas___Admin gestionarCuentas___Admin = new GestionarCuentas___Admin(token, clienteId);
            gestionarCuentas___Admin.Show();
            this.Close();
        }

        private void btnGestionarPerfiles_Click(object sender, EventArgs e)
        {
            GestionarPerfiles gestionarPerfiles = new GestionarPerfiles(token, clienteId);
            gestionarPerfiles.Show();
            this.Close();
        }

        private void btnGestionarUsuarios_Click(object sender, EventArgs e)
        {
            GestionarUsuario gestionarUsuario = new GestionarUsuario(token, clienteId);
            gestionarUsuario.Show();
            this.Close();
        }

        private void btnGestionarTransacciones_Click(object sender, EventArgs e)
        {
            GestionarTransacciones gestionarTransacciones = new GestionarTransacciones(token, clienteId);
            gestionarTransacciones.Show();
            this.Close();

        }

        private void btnBeneficiarios_Click(object sender, EventArgs e)
        {
            GestionarBeneficiarios beneficiarios = new GestionarBeneficiarios(token, clienteId);
            beneficiarios.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CuadreTransacciones cuadreTransacciones = new CuadreTransacciones();
            cuadreTransacciones.ShowDialog();
        }
    }
}
