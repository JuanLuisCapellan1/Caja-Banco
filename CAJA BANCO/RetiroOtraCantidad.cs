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

namespace CAJA_BANCO
{
    public partial class RetiroOtraCantidad : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token;
        int cuentaId, clienteId;
        public RetiroOtraCantidad(Token token, int cuentaId, int clienteId)
        {
            InitializeComponent();
            this.cuentaId = cuentaId;   
            this.token = token;
            this.clienteId = clienteId;
        }

        private async void btnRetiro_Click(object sender, EventArgs e)
        {
            decimal montoRetiro = numRetiroValue.Value;
            await RetiroOtraCantidadAsync(montoRetiro);
        }

        private async Task RetiroOtraCantidadAsync(decimal montoRetiro)
        {
            try
            {
                string requestUrl = $"{apiUrl}/Transacciones";
                var retiro = new
                {
                    cuentaId = cuentaId,
                    tipoTransaccionID = 2,
                    monto = montoRetiro,
                    fechaTransaccion = DateTime.Now,
                    cuentaOrigenID = 0,
                    cuentaDestinoID = 0
                };

                var json = JsonConvert.SerializeObject(retiro);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);


                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                string responseBody = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    string Response = await response.Content.ReadAsStringAsync();
                    string responseMessage = JObject.Parse(Response)["transaccionID"]?.ToString();
                    MessageBox.Show("Retiro de efectivo registrado");
                    this.Close();

                    ReciboTransacciones frm = new ReciboTransacciones(int.Parse(responseMessage));
                    frm.ShowDialog();

                    FormPrincipal mainForm = new FormPrincipal(token, clienteId);
                    mainForm.Show();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error a la hora de realizar el retiro: {errorResponse}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error a la hora de realizar el retiro: {ex.Message}");
            }
        }
    }
}
