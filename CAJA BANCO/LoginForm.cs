using Newtonsoft.Json;
using System;
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
            //cajero = new Cajero { Usuario = "admin", Clave = "1234321", Sucursal = "Sucursal1" };
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
                    FormPrincipal formPrincipal = new FormPrincipal(newtoken, apiResponse.clienteID);
                    formPrincipal.Show();
                    this.Hide();
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
    }
}
