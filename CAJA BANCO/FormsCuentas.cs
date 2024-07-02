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
    public partial class FormsCuentas : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        Token token = new Token();
        int clienteId;
        string optionSelected;
        public FormsCuentas(Token token, string option, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
            optionSelected = option;
        }

        private void btnListCuentas_Click(object sender, EventArgs e)
        {
            if(optionSelected != null && optionSelected != "")
            {
                Cuenta selectedCuenta = cbCuentas.SelectedItem as Cuenta;

                if (selectedCuenta == null)
                {
                    MessageBox.Show("Seleccione una cuenta.");
                    return;
                }
                
                int cuentaId = selectedCuenta.CuentaId;

                switch (optionSelected)
                {
                    case "btnEntradaEfectivo":
                        EntradaEfectivoForm entradaEfectivoForm = new EntradaEfectivoForm(token, cuentaId, clienteId);
                        entradaEfectivoForm.Show();
                        this.Hide();
                        break;
                    case "btnConsulta":
                        Balance_actual balance_Actual = new Balance_actual(token, cuentaId, clienteId);
                        balance_Actual.Show();
                        this.Hide();
                        break;
                    case "btnRetiro":
                        Retiro retiro = new Retiro(token, cuentaId, clienteId);
                        retiro.Show();
                        this.Hide();
                        break;
                }
            }
        }

        private async void FormsCuentas_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
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
                    foreach (var item in cuentas)
                    {
                        cbCuentas.Items.Add(item);
                    }
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    string errorMessage = JObject.Parse(errorResponse)["message"]?.ToString();

                    MessageBox.Show($"Error al obtener datos: {errorMessage}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de solicitud HTTP: {ex.Message}");
            }
        }
    }
}
