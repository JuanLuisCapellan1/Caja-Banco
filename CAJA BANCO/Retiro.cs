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
    public partial class Retiro : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token;
        int cuentaId, clienteId;
        public Retiro(Token token, int CuentaId, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            cuentaId = CuentaId;
            this.clienteId = clienteId;
            lbl50.LinkClicked += ButtonRetiro_Click;
            lbl100.LinkClicked += ButtonRetiro_Click;
            lbl200.LinkClicked += ButtonRetiro_Click;
            lbl500.LinkClicked += ButtonRetiro_Click;
            lbl1000.LinkClicked += ButtonRetiro_Click;
            lbl2000.LinkClicked += ButtonRetiro_Click;
        }

        private async void ButtonRetiro_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel clickedLabel = sender as LinkLabel;
            if (clickedLabel != null)
            {
                decimal monto = 0;
                switch (clickedLabel.Name)
                {
                    case "lbl50":
                        monto = 50m;
                        break;
                    case "lbl100":
                        monto = 100m;
                        break;
                    case "lbl200":
                        monto = 200m;
                        break;
                    case "lbl500":
                        monto = 500m;
                        break;
                    case "lbl1000":
                        monto = 1000m;
                        break;
                    case "lbl2000":
                        monto = 2000m;
                        break;
                    default:
                        MessageBox.Show("Monto no reconocido.");
                        return;
                }

                await RetiroAsync(monto);
            }
        }


        private async Task RetiroAsync(decimal monto)
        {
            try
            {
                string requestUrl = $"{apiUrl}/Transacciones";
                var retiro = new
                {
                    cuentaId = cuentaId,
                    tipoTransaccionID = 2,
                    monto = monto,
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
                    
                    Factura factura = new Factura(token, int.Parse(responseMessage), clienteId);
                    factura.Show();

                    this.Close();
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

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void lbl2000_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void btnOtraCantidad_Click(object sender, EventArgs e)
        {
            this.Close();
            RetiroOtraCantidad retiroOtraCantidad = new RetiroOtraCantidad(token, cuentaId, clienteId);
            retiroOtraCantidad.Show();
        }
    }
}
