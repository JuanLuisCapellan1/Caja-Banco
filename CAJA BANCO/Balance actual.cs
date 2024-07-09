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
    public partial class Balance_actual : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token;
        int cuentaId, clienteId;
        public Balance_actual(Token token, int cuentaId, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.cuentaId = cuentaId;
            this.clienteId = clienteId;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormPrincipal home = new FormPrincipal(token, clienteId);
            home.Show();
        }

        private async void Balance_actual_Load(object sender, EventArgs e)
        {
            await ConsultarBalanceAsync();
        }

        private async Task ConsultarBalanceAsync()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas/{cuentaId}");
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    Cuenta cuenta = JsonConvert.DeserializeObject<Cuenta>(jsonResponse);
                   
                    lblIBalanceActual.Text = cuenta.Balance.ToString();
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
    }
}
