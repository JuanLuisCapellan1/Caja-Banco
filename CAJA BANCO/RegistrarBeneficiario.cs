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
    public partial class RegistrarBeneficiario : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        Cuenta selectedCuenta;
        Usuarios selectedUser;
        int clienteId;
        public RegistrarBeneficiario(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }
        private async Task GetCuentas()
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
                        cbCuentaId.Items.Add(cuenta);
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
        private async Task GetUsuarioId()
        {
            try
            {
                cbUsuarioId.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Usuarios> usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(jsonResponse);

                    foreach (Usuarios usuario in usuarios)
                    {
                        cbUsuarioId.Items.Add(usuario);
                    }
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
        private string ValidateBeneficiario(Beneficiario beneficiario)
        {
            if (string.IsNullOrWhiteSpace(beneficiario.nombre))
            {
                return "El nombre es obligatorio.";
            }
            return string.Empty;
        }
        private void clearTextBoxs()
        {
            txtNombreBeneficiario.Clear();
            cbCuentaId.Items.Clear();
            cbUsuarioId.Items.Clear();
        }
        public async Task CreateBeneficiario(Beneficiario beneficiario)
        {
            try
            {
                var validationResult = ValidateBeneficiario(beneficiario);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    MessageBox.Show(validationResult);
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                var json = JsonConvert.SerializeObject(beneficiario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/Beneficiarios", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Beneficiario creado exitosamente.");
                    clearTextBoxs();
                }
                else
                {
                    MessageBox.Show("Error al crear el beneficiario.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al realizar la solicitud: {ex.Message}");
            }
        }
        private async void RegistrarBeneficiario_Load(object sender, EventArgs e)
        {
            await GetCuentas();
            await GetUsuarioId();
        }

        private async void btnCrearBeneficiario_Click(object sender, EventArgs e)
        {
            selectedCuenta = cbCuentaId.SelectedItem as Cuenta;
            selectedUser = cbUsuarioId.SelectedItem as Usuarios;
            Beneficiario nuevoBeneficiario = new Beneficiario()
            {
                nombre = txtNombreBeneficiario.Text,
                cuentaID = selectedCuenta.CuentaId,
                usuarioID = selectedUser.usuarioId
            };
            await CreateBeneficiario(nuevoBeneficiario);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Transferencia transferencia = new Transferencia(token, clienteId);
            transferencia.Show();
            this.Close();
        }
    }
}
