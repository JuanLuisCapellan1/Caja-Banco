using CAJA_BANCO.Entitties;
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
    public partial class GestionarCuentas___Admin : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarCuentas___Admin(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private async void Balance_actual___Admin_Load(object sender, EventArgs e)
        {
            await getDataCuentas();
        }

        private async Task getDataCuentas()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);
                    datagridViewCuentas.DataSource = cuentas;
                    await GetDataTipoCuentas();
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

        private async Task GetDataTipoCuentas()
        {
            try
            {
                cbTipoCuenta.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/TipoCuenta");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<TipoCuenta> tiposCuenta = JsonConvert.DeserializeObject<List<TipoCuenta>>(jsonResponse);

                    foreach (TipoCuenta tipoCuenta in tiposCuenta)
                    {
                        cbTipoCuenta.Items.Add(tipoCuenta.tipoCuentaId);
                    }
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los tipos de cuentas: {exeption.Message}");
            }
        }

        private void datagridViewCuentas_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridViewCuentas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewCuentas.SelectedRows[0];

                txtNoCuentaAdminView.Text = selectedRow.Cells["cuentaId"].Value.ToString();
                txtBalanceAdminView.Text = selectedRow.Cells["balance"].Value.ToString();
                txtFechaCreaciónAdminView.Text = selectedRow.Cells["fechacreacion"].Value.ToString();
                cbTipoCuenta.Text = selectedRow.Cells["tipocuentaid"].Value.ToString();
            }
        }

        private async void btnGestionarPerfiles_Click(object sender, EventArgs e)
        {
            decimal balance = 0m;
            int cuentaId;
            DateTime fechaCreacion;
            try
            {
                cuentaId = int.Parse(txtNoCuentaAdminView.Text);
                fechaCreacion = DateTime.Parse(txtFechaCreaciónAdminView.Text);
                balance = decimal.Parse(txtBalanceAdminView.Text);
                await updateCuenta(cuentaId, balance, fechaCreacion);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private async Task updateCuenta(int cuentaId, decimal nuevoBalance, DateTime fechaCreacion)
        {
            try
            {
                if (nuevoBalance < 0)
                {
                    MessageBox.Show("El balance no puede ser negativo.");
                    return;
                }

                var cuentaUpdate = new
                {
                    balance = nuevoBalance,
                    fechaCreacion = fechaCreacion
                };

                var json = JsonConvert.SerializeObject(cuentaUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Cuentas/{cuentaId}", content);


                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();

                    MessageBox.Show(successMessage);
                    txtBalanceAdminView.Clear();
                    txtFechaCreaciónAdminView.Clear();
                    txtNoCuentaAdminView.Clear();
                    await getDataCuentas();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al actualizar las cuentas: {exeption.Message}");
            }
        }

        private async Task deleteCuenta(int cuentaId)
        {
            try
            {
                if (cuentaId <= 0)
                {
                    MessageBox.Show("ID de cuenta no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Cuentas/{cuentaId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();


                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();

                    MessageBox.Show(successMessage ?? "Cuenta eliminada exitosamente.");
                    txtBalanceAdminView.Clear();
                    txtFechaCreaciónAdminView.Clear();
                    txtNoCuentaAdminView.Clear();
                    await getDataCuentas();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    string errorMessage = JObject.Parse(errorResponse)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al realizar la eliminación: {exeption.Message}");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar esta cuenta?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int cuentaId;
                if (int.TryParse(txtNoCuentaAdminView.Text, out cuentaId))
                {
                    await deleteCuenta(cuentaId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de cuenta válido.");
                }
            }
        }

        private void lblIBalanceActual_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Main_Form___Admin main_Form___Admin = new Main_Form___Admin(token, clienteId);
            main_Form___Admin.Show();
            
        }
    }
}
