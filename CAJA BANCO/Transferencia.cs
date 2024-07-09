using CAJA_BANCO.Entitties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
        TipoTransaccion selectedTipoTransaccion;
        Beneficiario selectedBeneficiario;
        List<TipoTransaccion> tipoTransaccion;
        int clienteId;
        public Transferencia(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private async void Transferencia_Load(object sender, EventArgs e)
        {
            await GetTipoTransaccion();
            await LoadDataOrigenAsync();
        }
        private async Task LoadDataOrigenAsync()
        {
            try
            {
                comboBoxCuentaOrigen.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas/Cliente/{clienteId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);
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
                    this.tipoTransaccion = tipoTransacciones;
                    foreach (TipoTransaccion tipoTransaccion in tipoTransacciones)
                    {
                        if(tipoTransaccion.tipoTransaccionID >= 3)
                        {
                            cbTipoTransaccion.Items.Add(tipoTransaccion);
                        }
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
        private async Task GetBeneficiarioId()
        {
            try
            {
                cbBeneficiarios.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Beneficiarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Beneficiario> beneficiarios = JsonConvert.DeserializeObject<List<Beneficiario>>(jsonResponse);
                    foreach (Beneficiario beneficiario in beneficiarios)
                    {
                        cbBeneficiarios.Items.Add(beneficiario);
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
        private async Task GetCuentaDestino()
        {
            try
            {
                comboBoxCuentaDestino.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);
                    if(comboBoxCuentaOrigen.SelectedItem != null)
                    {
                        selectedCuentaOrigen = comboBoxCuentaOrigen.SelectedItem as Cuenta;
                        foreach (Cuenta cuenta in cuentas)
                        {
                            if(cuenta.CuentaId != selectedCuentaOrigen.CuentaId)
                            {
                                comboBoxCuentaDestino.Items.Add(cuenta);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccione una cuenta de origen!");
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
        private async void comboBoxCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTipoTransaccion = cbTipoTransaccion.SelectedItem as TipoTransaccion;
            selectedCuentaOrigen = comboBoxCuentaOrigen.SelectedItem as Cuenta;
            if (cbTipoTransaccion.SelectedItem != null)
            {
                if (selectedTipoTransaccion.tipoTransaccionID == 4)
                {
                    comboBoxCuentaDestino.Visible = false;
                    lblDestino.Visible = false;
                    cbBeneficiarios.Visible = true;
                    lblBeneficiario.Visible = true;
                    linkBeneficiario.Visible = true;
                    await GetBeneficiarioId();

                }
                else if (selectedTipoTransaccion.tipoTransaccionID == 3)
                {
                    comboBoxCuentaDestino.Visible = true;
                    lblDestino.Visible = true;
                    cbBeneficiarios.Visible = false;
                    lblBeneficiario.Visible = false;
                    linkBeneficiario.Visible = false;
                    await GetCuentaDestino();
                }

            }
            else
            {
                MessageBox.Show("Por favor seleccione un Tipo de transaccion");
            }
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (selectedCuentaOrigen == null)
            {
                MessageBox.Show("Por favor, selecciona una cuenta de origen.");
                return;
            }

            if (selectedTipoTransaccion == null)
            {
                MessageBox.Show("Por favor, selecciona un tipo de transacción.");
                return;
            }

            if (selectedTipoTransaccion.tipoTransaccionID == 3 && selectedCuentaDestino == null)
            {
                MessageBox.Show("Por favor, selecciona una cuenta de destino.");
                return;
            }

            if (selectedTipoTransaccion.tipoTransaccionID == 4 && cbBeneficiarios.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecciona un beneficiario.");
                return;
            }

            selectedBeneficiario = cbBeneficiarios.SelectedItem as Beneficiario;

            await TransaccionATerceros(selectedCuentaOrigen.CuentaId);
        }

        private async Task TransaccionATerceros(int cuentaId)
        {
            try
            {
                string requestUrl = $"{apiUrl}/Transacciones";

                decimal montoDeposito = numMontoTransferencia.Value;

                var transaccion = new
                {
                    cuentaID = cuentaId,
                    monto = montoDeposito,
                    fechaTransaccion = DateTime.Now,
                    cuentaDestinoID = (selectedTipoTransaccion.tipoTransaccionID == 3) ? selectedCuentaDestino.CuentaId : 0,
                    beneficiarioID = (selectedTipoTransaccion.tipoTransaccionID == 4) ? selectedBeneficiario.beneficiarioID : 0,
                    tipoTransaccionID = selectedTipoTransaccion.tipoTransaccionID,
                };

                var json = JsonConvert.SerializeObject(transaccion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                string responseBody = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    string Response = await response.Content.ReadAsStringAsync();
                    string responseMessage = JObject.Parse(Response)["transaccionID"]?.ToString();
                    MessageBox.Show("Transferencia registrada.");

                    Factura factura = new Factura(token, int.Parse(responseMessage), clienteId);
                    factura.Show();

                    this.Close();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    string errorMessage = JObject.Parse(errorResponse)["message"]?.ToString();
                    MessageBox.Show($"Error: {errorMessage}");
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

        private void cbTipoTransaccion_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void linkBeneficiario_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarBeneficiario registrarBeneficiario = new RegistrarBeneficiario(token, clienteId);
            registrarBeneficiario.Show();
            this.Close();
        }
    }
}
