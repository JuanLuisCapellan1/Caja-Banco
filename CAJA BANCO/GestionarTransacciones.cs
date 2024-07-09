using CAJA_BANCO.Entitties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA_BANCO
{
    public partial class GestionarTransacciones : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarTransacciones(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private async void GestionarTransacciones_Load(object sender, EventArgs e)
        {
            await GetDataTransacciones();
        }
        private void clearTextBoxs()
        {
            cbBeneficiario.Items.Clear();
            cbCuentaId.Items.Clear();
            cbTipoTransaccion.Items.Clear();
            txtMontoTransaccion.Clear();
            txtTransaccionId.Clear();
            txtFechaTransaccion.Clear();
        }
        private async Task GetCuentaId()
        {
            try
            {
                cbCuentaId.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);

                    foreach (Cuenta cuenta in cuentas)
                    {
                        cbCuentaId.Items.Add(cuenta.CuentaId);
                    }
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener las cuentas: {exeption.Message}");
            }
        }
        private async Task GetBeneficiarioId()
        {
            try
            {
                cbBeneficiario.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Beneficiarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Beneficiario> beneficiarios = JsonConvert.DeserializeObject<List<Beneficiario>>(jsonResponse);

                    cbBeneficiario.Items.Add(0);
                    foreach (Beneficiario beneficiario in beneficiarios)
                    {
                        cbBeneficiario.Items.Add(beneficiario.beneficiarioID);
                    }
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los beneficiarios: {exeption.Message}");
            }
        }
        private async Task GetTipoTransaccion()
        {
            try
            {
                cbTipoTransaccion.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/TipoTransacciones");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<TipoTransaccion> tipoTransacciones = JsonConvert.DeserializeObject<List<TipoTransaccion>>(jsonResponse);

                    foreach (TipoTransaccion tipoTransaccion in tipoTransacciones)
                    {
                        cbTipoTransaccion.Items.Add(tipoTransaccion.tipoTransaccionID);
                    }
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los tipos de transacciones: {exeption.Message}");
            }
        }
        private async Task GetDataTransacciones()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Transacciones");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Transaccion> transaccions = JsonConvert.DeserializeObject<List<Transaccion>>(jsonResponse);
                    datagridViewTransaccion.DataSource = transaccions;
                    await GetCuentaId();
                    await GetTipoTransaccion();
                    await GetBeneficiarioId();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los usuarios: {exeption.Message}");
            }
        }
        private async Task UpdateTransacciones(int transaccionId, int beneficiarioId, int cuentaId, int tipoTransaccionId, decimal monto, DateTime fechatransaccion)
        {
            try
            {
                var transaccionUpdate = new
                {
                    beneficiarioId = beneficiarioId,
                    cuentaId = cuentaId,
                    tipoTransaccionId = tipoTransaccionId,
                    monto = monto,
                    fechatransaccion = fechatransaccion
                };

                var json = JsonConvert.SerializeObject(transaccionUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Transacciones/{transaccionId}", content);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Transaccion actualizada exitosamente");
                    clearTextBoxs();
                    await GetDataTransacciones();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al actualizar los clientes: {exeption.Message}");
            }
        }
        private async Task DeleteTransacciones(int transaccionId)
        {
            try
            {
                if (transaccionId <= 0)
                {
                    MessageBox.Show("ID de la transaccion no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Transacciones/{transaccionId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Transaccion eliminada exitosamente.");
                    clearTextBoxs();
                    await GetDataTransacciones();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al realizar la eliminación: {exeption.Message}");
            }
        }
        private void datagridViewTransaccion_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridViewTransaccion.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewTransaccion.SelectedRows[0];

                txtTransaccionId.Text = selectedRow.Cells["transaccionID"].Value.ToString();
                txtFechaTransaccion.Text = selectedRow.Cells["fechaTransaccion"].Value.ToString();
                txtMontoTransaccion.Text = selectedRow.Cells["monto"].Value.ToString();
                cbBeneficiario.Text = selectedRow.Cells["beneficiarioID"].Value.ToString();
                cbCuentaId.Text = selectedRow.Cells["cuentaID"].Value.ToString();
                cbTipoTransaccion.Text = selectedRow.Cells["tipoTransaccionID"].Value.ToString();

            }
        }

        private async void btnActualizarCuentas_Click(object sender, EventArgs e)
        {
            int transaccionId, beneficiarioId, cuentaId, tipotransaccionId;
            decimal monto;
            DateTime fechaTransaccion;
            try
            {
                if (cbBeneficiario.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un valor en el Beneficiario Id.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbCuentaId.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un valor en la Cuenta Id.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbTipoTransaccion.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un valor en el Tipo de Transaccion.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                beneficiarioId = int.Parse(cbBeneficiario.SelectedItem.ToString());
                cuentaId = int.Parse(cbCuentaId.SelectedItem.ToString());
                tipotransaccionId = int.Parse(cbTipoTransaccion.SelectedItem.ToString());
                monto = decimal.Parse(txtMontoTransaccion.Text);
                transaccionId = int.Parse(txtTransaccionId.Text);
                fechaTransaccion = DateTime.Parse(txtFechaTransaccion.Text);
                await UpdateTransacciones(transaccionId, beneficiarioId, cuentaId, tipotransaccionId, monto, fechaTransaccion);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private async void btnEliminarCuentas_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta Transaccion?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int transaccionId;
                if (int.TryParse(txtTransaccionId.Text, out transaccionId))
                {
                    await DeleteTransacciones(transaccionId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de Transaccion válido.");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
            Main_Form___Admin main_Form___Admin = new Main_Form___Admin(token, clienteId);
            main_Form___Admin.Show();
        }
    }
}
