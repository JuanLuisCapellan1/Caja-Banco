using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
using System.Windows.Media.Media3D;

namespace CAJA_BANCO
{
    public partial class EntradaEfectivoForm : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token = new Token();
        int CuentaId, clienteId;
        public EntradaEfectivoForm(Token token, int CuentaId, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.CuentaId = CuentaId;
            this.clienteId = clienteId;
        }

        private async void btnConfirmar_Click(object sender, EventArgs e)
        {
            await DepositoAsync();
        }
        private async Task DepositoAsync()
        {
            try
            {
                string requestUrl = $"{apiUrl}/Transacciones";

                decimal montoDeposito = NumValue.Value;
                var deposito = new
                {
                    cuentaId = CuentaId,
                    tipoTransaccionID = 1,
                    monto = montoDeposito,
                    fechaTransaccion = DateTime.Now,
                    cuentaOrigenID = 0,
                    cuentaDestinoID = 0
                };

                var json = JsonConvert.SerializeObject(deposito);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string Response = await response.Content.ReadAsStringAsync();
                    string responseMessage = JObject.Parse(Response)["transaccionID"]?.ToString();
                    MessageBox.Show("Entrada de efectivo registrada.");

                    Factura factura = new Factura(token, int.Parse(responseMessage), clienteId);
                    factura.Show();

                    this.Close();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();

                    MessageBox.Show($"Error al obtener datos: {errorResponse}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}");
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void EntradaEfectivoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
