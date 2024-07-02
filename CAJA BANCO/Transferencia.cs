using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA_BANCO
{
    public partial class Transferencia : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token;
        Cuenta selectedCuentaOrigen;
        Cuenta selectedCuentaDestino;
        List<Cuenta> cuentas;
        int clienteId;
        public Transferencia(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private async void Transferencia_Load(object sender, EventArgs e)
        {
            await LoadDataOrigenAsync();
        }
        private async Task LoadDataOrigenAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas/Cliente/{clienteId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);
                    this.cuentas = cuentas;
                    foreach (var item in cuentas)
                    {
                        comboBoxCuentaOrigen.Items.Add(item);
                    }
                }
                else
                {
                    MessageBox.Show("Error al obtener datos.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}");
            }
        }
        private void comboBoxCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxCuentaDestino.Items.Clear();
            selectedCuentaOrigen = comboBoxCuentaOrigen.SelectedItem as Cuenta;
            if (selectedCuentaOrigen != null)
            {
                foreach (var item in this.cuentas)
                {
                    if (item.CuentaId != selectedCuentaOrigen.CuentaId)
                    {
                        comboBoxCuentaDestino.Items.Add(item);
                    }
                }
            }
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (selectedCuentaOrigen == null || selectedCuentaDestino == null)
            {
                MessageBox.Show("Por favor, selecciona una cuenta de origen y destino.");
                return;
            }

            await TransaccionATerceros();
        }

        private async Task TransaccionATerceros()
        {
            try
            {
                string requestUrl = $"{apiUrl}/Transacciones";

                decimal montoDeposito = numMontoTransferencia.Value;
                var transaccion = new
                {
                    cuentaId = 0,
                    tipoTransaccionID = 3,
                    monto = montoDeposito,
                    fechaTransaccion = DateTime.Now,
                    cuentaOrigenID = selectedCuentaOrigen.CuentaId,
                    cuentaDestinoID = selectedCuentaDestino.CuentaId
                };

                var json = JsonConvert.SerializeObject(transaccion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Transferencia registrada.");
                    this.Close();
                    FormPrincipal mainForm = new FormPrincipal(token, clienteId);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show($"Error: {responseBody}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}");
            }
        }

        private void comboBoxCuentaDestino_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            selectedCuentaDestino = comboBoxCuentaDestino.SelectedItem as Cuenta;
        }
    }
}
