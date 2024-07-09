//using CAJA_BANCO.CoreBancarioDataSetTableAdapters;
using CAJA_BANCO.CoreBancarioDataSetTableAdapters;
using Microsoft.Reporting.WinForms;
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
    public partial class ReciboTransacciones : Form
    {
        int transaccionId;
        public ReciboTransacciones(int IdTransaccion)
        {
            InitializeComponent();
            transaccionId = IdTransaccion;
        }

        private void ReciboTransacciones_Load(object sender, EventArgs e)
        {
            this.rpvTransaccion.Clear();

            SelectTransactionTableAdapter adapter = new SelectTransactionTableAdapter();

            CoreBancarioDataSet.SelectTransactionDataTable tbl = adapter.GetDataById(transaccionId);

            ReportDataSource ds = new ReportDataSource("DataSetTransaccion", (DataTable)tbl);

            rpvTransaccion.LocalReport.DataSources.Add(ds);

            this.rpvTransaccion.RefreshReport();
        }
    }
}
