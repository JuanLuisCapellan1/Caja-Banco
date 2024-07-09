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
    public partial class CuadreTransacciones : Form
    {
        public CuadreTransacciones()
        {
            InitializeComponent();
        }

        private void CuadreTransacciones_Load(object sender, EventArgs e)
        {

            this.rpvCuadre.Clear();

            ObtenerTransaccionesPorDiaTableAdapter adapter = new ObtenerTransaccionesPorDiaTableAdapter();
            CoreBancarioDataSet.ObtenerTransaccionesPorDiaDataTable tbl = adapter.GetDataByDay(DateTime.Now.Date);

            ReportDataSource ds = new ReportDataSource("DataSetReporteCuadre", (DataTable)tbl);

            rpvCuadre.LocalReport.DataSources.Add(ds);

            this.rpvCuadre.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
