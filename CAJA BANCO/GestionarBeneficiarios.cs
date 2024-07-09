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
    public partial class GestionarBeneficiarios : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarBeneficiarios(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private async Task GetCuentaId()
        {
            try
            {
                CbCuentaId.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Cuentas");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cuenta> cuentas = JsonConvert.DeserializeObject<List<Cuenta>>(jsonResponse);

                    foreach (Cuenta cuenta in cuentas)
                    {
                        CbCuentaId.Items.Add(cuenta.CuentaId);
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
                cbUsuario.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Usuarios> usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(jsonResponse);

                    foreach (Usuarios cuenta in usuarios)
                    {
                        cbUsuario.Items.Add(cuenta.usuarioId);
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

        private async Task GetDataBeneficiario()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Beneficiarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Beneficiario> beneficiarios = JsonConvert.DeserializeObject<List<Beneficiario>>(jsonResponse);
                    datagridViewBeneficiario.DataSource = beneficiarios;
                    await GetCuentaId();
                    await GetUsuarioId();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los beneficiarios: {exeption.Message}");
            }
        }

        private void clearTextBoxs()
        {
            txtBeneficiarioId.Clear();
            txtNombreBeneficiario.Clear();
            cbUsuario.Items.Clear();
            CbCuentaId.Items.Clear();
        }

        private async Task DeleteBeneficiario(int beneficiarioId)
        {
            try
            {
                if (beneficiarioId <= 0)
                {
                    MessageBox.Show("Id del Beneficiario no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Beneficiarios/{beneficiarioId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Beneficiario eliminado exitosamente.");
                    clearTextBoxs();
                    await GetDataBeneficiario();
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

        private async Task UpdateBeneficiarios(int beneficiarioId, string nombre, int cuentaId, int usuarioId)
        {
            try
            {
                if (nombre == null || nombre == "")
                {
                    MessageBox.Show("Favor completar el campo nombre");
                    return;
                }

                var beneficiarioUpdate = new
                {
                    nombre = nombre,
                    cuentaId = cuentaId,
                    usuarioId = usuarioId
                };

                var json = JsonConvert.SerializeObject(beneficiarioUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Beneficiarios/{beneficiarioId}", content);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Beneficiario editado exitosamente");
                    clearTextBoxs();
                    await GetDataBeneficiario();
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void datagridViewBeneficiario_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridViewBeneficiario.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewBeneficiario.SelectedRows[0];

                txtBeneficiarioId.Text = selectedRow.Cells["beneficiarioID"].Value.ToString();
                txtNombreBeneficiario.Text = selectedRow.Cells["nombre"].Value.ToString();
                cbUsuario.Text = selectedRow.Cells["usuarioID"].Value.ToString();
                CbCuentaId.Text = selectedRow.Cells["cuentaID"].Value.ToString();

            }
        }

        private async void GestionarBeneficiarios_Load(object sender, EventArgs e)
        {
            await GetDataBeneficiario();
        }

        private async void btnActualizarPerfiles_Click(object sender, EventArgs e)
        {
            int beneficiarioId, usuarioId, cuentaId;
            string nombre;
            try
            {
                beneficiarioId = int.Parse(txtBeneficiarioId.Text);
                nombre = txtNombreBeneficiario.Text;
                usuarioId = int.Parse(cbUsuario.SelectedItem.ToString());
                cuentaId = int.Parse(CbCuentaId.SelectedItem.ToString());
                await UpdateBeneficiarios(beneficiarioId, nombre, cuentaId, usuarioId);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private async void btnEliminarPerfiles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este Beneficiario?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int beneficiarioId;
                if (int.TryParse(txtBeneficiarioId.Text, out beneficiarioId))
                {
                    await DeleteBeneficiario(beneficiarioId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de Beneficiario válido.");
                }
            }
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

        private void datagridViewBeneficiario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
