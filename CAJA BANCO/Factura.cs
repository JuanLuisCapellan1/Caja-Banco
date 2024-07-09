using CAJA_BANCO.Entitties;
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
        Token token;
        int idTransaccion, clienteId;
        public Factura(Token token, int idTransaccion, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.idTransaccion = idTransaccion;
            this.clienteId = clienteId;
        }

        private void Factura_Load(object sender, EventArgs e)
        {
            // Código para cargar datos de la factura por si es necesario
        }

        private void btnSiFactura_Click(object sender, EventArgs e)
        {
            ReciboTransacciones frm = new ReciboTransacciones(idTransaccion);
            frm.ShowDialog();
            this.Close();
            FormPrincipal mainForm = new FormPrincipal(token, clienteId);
            mainForm.Show();
        }

        private void btnNoFactura_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPrincipal mainForm = new FormPrincipal(token, clienteId);
            mainForm.Show();
        }
    }
     
    
}
