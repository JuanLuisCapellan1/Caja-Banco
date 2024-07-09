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
    public partial class GestionarTiposTransacciones : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarTiposTransacciones(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }
        private async Task GetDataTipoTransacciones()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/TipoTransacciones");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<TipoTransaccion> tipoTransaccions = JsonConvert.DeserializeObject<List<TipoTransaccion>>(jsonResponse);
                    datagridViewTipoTransacciones.DataSource = tipoTransaccions;
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

        private void datagridViewTipoTransacciones_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridViewTipoTransacciones.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewTipoTransacciones.SelectedRows[0];

                txtTipoTransaccionId.Text = selectedRow.Cells["tipoTransaccionID"].Value.ToString();
                txtNombreTipoTransaccion.Text = selectedRow.Cells["nombre"].Value.ToString();
                txtDescripcionTipoTransaccion.Text = selectedRow.Cells["descripcion"].Value.ToString();
            }
        }

        private async void GestionarTiposTransacciones_Load(object sender, EventArgs e)
        {
            await GetDataTipoTransacciones();
        }

        private void clearTextBoxs()
        {
            txtDescripcionTipoTransaccion.Clear();
            txtNombreTipoTransaccion.Clear();
            txtTipoTransaccionId.Clear();
        }
        public async Task CreateTipoTransaccion(TipoTransaccion tipoTransaccion)
        {
            try
            {
                var validationResult = ValidateTipoTransaccion(tipoTransaccion);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    MessageBox.Show(validationResult);
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                var json = JsonConvert.SerializeObject(tipoTransaccion);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/TipoTransacciones", content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();
                    MessageBox.Show(successMessage ?? "Tipo de Transaccion creado exitosamente.");
                    clearTextBoxs();
                    await GetDataTipoTransacciones();
                }
                else
                {
                    MessageBox.Show("Error al crear Tipo de Transaccion.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al realizar la solicitud: {ex.Message}");
            }
        }
        private async Task UpdateTipoTransaccion(int tipoTransaccionId, string nombre, string descripcion)
        {
            try
            {
                if (nombre == null || nombre == "")
                {
                    MessageBox.Show("Favor completar el campo nombre");
                    return;
                }
                if (descripcion == null || descripcion == "")
                {
                    MessageBox.Show("Favor completar el campo descripcion");
                    return;
                }

                var tipoTransaccionUpdate = new
                {
                    nombre = nombre,
                    descripcion = descripcion
                };

                var json = JsonConvert.SerializeObject(tipoTransaccionUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/TipoTransacciones/{tipoTransaccionId}", content);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Tipo de Transaccion editado exitosamente");
                    clearTextBoxs();
                    await GetDataTipoTransacciones();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al actualizar los tipos de Transacciones: {exeption.Message}");
            }
        }
        private string ValidateTipoTransaccion(TipoTransaccion tipoTransaccion)
        {
            if (string.IsNullOrWhiteSpace(tipoTransaccion.nombre))
            {
                return "El nombre es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(tipoTransaccion.descripcion))
            {
                return "La descripción es obligatoria.";
            }

            return string.Empty;
        }

        private async Task DeleteTipoTransacciones(int tipoTransacciones)
        {
            try
            {
                if (tipoTransacciones <= 0)
                {
                    MessageBox.Show("ID del Tipo transaccion no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/TipoTransacciones/{tipoTransacciones}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Perfil eliminado exitosamente.");
                    clearTextBoxs();
                    await GetDataTipoTransacciones();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al realizar la eliminación: {exeption.Message}");
            }
        }
        private async void btnEliminarTipoTransaccion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este Tipo de Transaccion?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int tipoTransaccion;
                if (int.TryParse(txtTipoTransaccionId.Text, out tipoTransaccion))
                {
                    await DeleteTipoTransacciones(tipoTransaccion);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de Tipo Transaccion válido.");
                }
            }
        }

        private async void btnCrearTipoTransaccion_Click(object sender, EventArgs e)
        {
            try
            {
                TipoTransaccion nuevoTipoTransaccion = new TipoTransaccion
                {
                    nombre = txtNombreTipoTransaccion.Text,
                    descripcion = txtDescripcionTipoTransaccion.Text,
                };
                await CreateTipoTransaccion(nuevoTipoTransaccion);
            }
            catch (Exception)
            {

                MessageBox.Show("Tipo de dato Invalido!");
            }
        }

        private async void btnActualizarTipoTransaccion_Click(object sender, EventArgs e)
        {
            int tipoTransaccionId;
            string nombre, descripcion;
            try
            {
                tipoTransaccionId = int.Parse(txtTipoTransaccionId.Text);
                nombre = txtNombreTipoTransaccion.Text;
                descripcion = txtDescripcionTipoTransaccion.Text;
                await UpdateTipoTransaccion(tipoTransaccionId, nombre, descripcion);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
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
