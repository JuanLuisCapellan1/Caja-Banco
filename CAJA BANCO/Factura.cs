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
    public partial class Factura : Form
    {
        public Factura()
        {
            InitializeComponent();
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // Código para cargar datos de la factura por si es necesario
        }

        private void btnSiFactura_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm(); //vuelve al login
            loginForm.Show();
        }

        private void btnNoFactura_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm(); //vuelve al login
            loginForm.Show();
        }
    }
     
    
}
