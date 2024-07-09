using CAJA_BANCO.Entitties;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace CAJA_BANCO
{
    public partial class GestionarPerfiles : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarPerfiles(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void GestionarPerfiles_Load(object sender, EventArgs e)
        {
            await getDataPerfiles();
        }

        private async Task getDataPerfiles()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Perfiles");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Perfil> clientes = JsonConvert.DeserializeObject<List<Perfil>>(jsonResponse);
                    datagridViewPerfiles.DataSource = clientes;
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los Perfiles: {exeption.Message}");
            }
        }

        private void datagridViewPerfiles_SelectionChanged(object sender, EventArgs e)
        {

            if (datagridViewPerfiles.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewPerfiles.SelectedRows[0];

                txtPerfilId.Text = selectedRow.Cells["perfilID"].Value.ToString();
                txtNombrePerfil.Text = selectedRow.Cells["nombrePerfil"].Value.ToString();
                txtDescripcionPerfil.Text = selectedRow.Cells["descripcion"].Value.ToString();
            }
        }

        private void clearTextBoxs()
        {
            txtPerfilId.Clear();
            txtNombrePerfil.Clear();
            txtDescripcionPerfil.Clear();
        }

        private async Task updatePerfil(int perfilId, string nombrePerfil, string descripcion)
        {
            try
            {
                if (nombrePerfil == null || nombrePerfil == "")
                {
                    MessageBox.Show("Favor completar el campo nombre");
                    return;
                }
                if (descripcion == null || descripcion == "")
                {
                    MessageBox.Show("Favor completar el campo descripcion");
                    return;
                }

                var perfilUpdate = new
                {
                    nombrePerfil = nombrePerfil,
                    descripcion = descripcion
                };

                var json = JsonConvert.SerializeObject(perfilUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Perfiles/{perfilId}", content);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Perfil editado exitosamente");
                    clearTextBoxs();
                    await getDataPerfiles();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al actualizar los Perfiles: {exeption.Message}");
            }
        }

        private async void btnActualizarPerfiles_Click(object sender, EventArgs e)
        {
            int perfilId;
            string nombrePerfil, descripcion;
            try
            {
                perfilId = int.Parse(txtPerfilId.Text);
                nombrePerfil = txtNombrePerfil.Text;
                descripcion = txtDescripcionPerfil.Text;
                await updatePerfil(perfilId, nombrePerfil, descripcion);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        public async Task createPerfil(Perfil perfil)
        {
            try
            {
                var validationResult = ValidatePerfil(perfil);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    MessageBox.Show(validationResult);
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                var json = JsonConvert.SerializeObject(perfil);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/Perfiles", content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();
                    MessageBox.Show(successMessage ?? "Cliente creado exitosamente.");
                    clearTextBoxs();
                    await getDataPerfiles();
                }
                else
                {
                    MessageBox.Show("Error al crear cliente.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        private string ValidatePerfil(Perfil perfil)
        {
            if (string.IsNullOrWhiteSpace(perfil.nombrePerfil))
            {
                return "El nombre es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(perfil.descripcion))
            {
                return "La descripción es obligatoria.";
            }

            return string.Empty;
        }

        private async Task deletePerfil(int perfilId)
        {
            try
            {
                if (perfilId <= 0)
                {
                    MessageBox.Show("ID del perfil no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Perfiles/{perfilId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Perfil eliminado exitosamente.");
                    clearTextBoxs();
                    await getDataPerfiles();
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

        private async void btnCrearPerfiles_Click(object sender, EventArgs e)
        {
            try
            {
                Perfil nuevoPerfil = new Perfil
                {
                    perfilId = int.Parse(txtPerfilId.Text),
                    nombrePerfil = txtNombrePerfil.Text,
                    descripcion = txtDescripcionPerfil.Text,
                };
                await createPerfil(nuevoPerfil);
            }
            catch (Exception)
            {

                MessageBox.Show("Tipo de dato Invalido!");
            }
        }

        private async void btnEliminarPerfiles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este perfil?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int perfilId;
                if (int.TryParse(txtPerfilId.Text, out perfilId))
                {
                    await deletePerfil(perfilId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de perfil válido.");
                }
            }
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {

            this.Close();
            Main_Form___Admin main_Form___Admin = new Main_Form___Admin(token, clienteId);
            main_Form___Admin.Show();
        }
    }
}
