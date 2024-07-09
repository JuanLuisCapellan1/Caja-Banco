using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAJA_BANCO
{
    public partial class LoginForm : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();

        public LoginForm()
        {
            InitializeComponent();
        }  

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            try
            {
                string requestUrl = $"{apiUrl}/Auth/login";
                var user = new
                {
                    username = txtUsuario.Text,
                    password = txtClave.Text,
                };

                var json = JsonConvert.SerializeObject(user);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(requestUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    
                    ApiResponse apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonResponse);

                    Token newtoken = new Token();
                    newtoken.accessToken = apiResponse.token;
                    MessageBox.Show("Login exitoso!");

                    VerifyTypeUser(apiResponse.perfilID, newtoken, apiResponse.clienteID);
                    
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas");
                }

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
        }

        private void VerifyTypeUser(int perfilId, Token token, int clienteId)
        {
            try
            {
                if (perfilId == 1)
                {
                    Main_Form___Admin main_Form___Admin = new Main_Form___Admin(token, clienteId);
                    this.Hide();
                    main_Form___Admin.Show();
                }
                else
                {
                    FormPrincipal formPrincipal = new FormPrincipal(token, clienteId);
                    this.Hide();
                    formPrincipal.Show();
                }
            }
            catch (HttpRequestException exeption)
            {

                MessageBox.Show($"Error al verificar usuario: {exeption.Message}");
            }
        }
        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
