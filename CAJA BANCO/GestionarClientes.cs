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
    public partial class GestionarClientes : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarClientes(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private async  void btnActualizarClientes_Click(object sender, EventArgs e)
        {
            string nombre, apellido, docIdentidad;
            DateTime fechaRegistro;
            int clienteId;

            try
            {
                clienteId = int.Parse(txtClienteId.Text);
                nombre = txtNombreCliente.Text;
                fechaRegistro = DateTime.Parse(txtFechaRegistroCliente.Text);
                apellido = txtApellidoCliente.Text;
                docIdentidad = txtDocIdentidad.Text;
                await updateCliente(clienteId, nombre, apellido, docIdentidad, fechaRegistro);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private async Task getDataClientes()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Clientes");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonResponse);
                    datagridViewClientes.DataSource = clientes;
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los clientes: {exeption.Message}");
            }
        }

        private async Task updateCliente(int clienteId, string nuevoNombre, string nuevoApellido, string docIdentidad, DateTime fechaRegistro)
        {
            try
            {
                if (nuevoNombre == null || nuevoNombre == "")
                {
                    MessageBox.Show("Favor completar el campo nombre");
                    return;
                }
                if (nuevoApellido == null || nuevoApellido == "")
                {
                    MessageBox.Show("Favor completar el campo apellido");
                    return;
                }
                if (docIdentidad == null || docIdentidad == "")
                {
                    MessageBox.Show("Favor completar el campo Documento de Identidad");
                    return;
                }
                var clienteUpdate = new
                {
                    nombre = nuevoNombre,
                    apellido = nuevoApellido,
                    documentoIdentidad = docIdentidad,
                    fechaRegistro = fechaRegistro
                };

                var json = JsonConvert.SerializeObject(clienteUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Clientes/{clienteId}", content);


                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();

                    MessageBox.Show(successMessage);
                    clearTextBoxs();
                    await getDataClientes();
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al actualizar los clientes: {exeption.Message}");
            }
        }

        private async Task deleteCliente(int clienteId)
        {
            try
            {
                if (clienteId <= 0)
                {
                    MessageBox.Show("ID del cliente no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Clientes/{clienteId}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();


                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();

                    MessageBox.Show(successMessage ?? "Cuenta eliminada exitosamente.");
                    clearTextBoxs();
                    await getDataClientes();
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

        public async Task CreateClienteAsync(Cliente cliente)
        {
            try
            {
                var validationResult = ValidateCliente(cliente);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    MessageBox.Show(validationResult);
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/Clientes", content);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    string successMessage = JObject.Parse(jsonResponse)["message"]?.ToString();
                    MessageBox.Show(successMessage ?? "Cliente creado exitosamente.");
                    clearTextBoxs();
                    await getDataClientes();
                }
                else
                {
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    string errorMessage = JObject.Parse(errorResponse)["message"]?.ToString();
                    MessageBox.Show(errorMessage ?? "Error al crear cliente.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al realizar la solicitud: {ex.Message}");
            }
        }

        private string ValidateCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                return "El nombre es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
            {
                return "El apellido es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(cliente.Documentoidentidad))
            {
                return "El documento de identidad es obligatorio.";
            }

            if (cliente.FechaRegistro == null || cliente.FechaRegistro > DateTime.Now)
            {
                return "La fecha de registro debe ser válida y no puede ser en el futuro.";
            }
            return string.Empty;
        }
        private void clearTextBoxs()
        {
            txtApellidoCliente.Clear();
            txtFechaRegistroCliente.Clear();
            txtClienteId.Clear();
            txtDocIdentidad.Clear();
            txtNombreCliente.Clear();
        }

        private async void GestionarClientes_Load(object sender, EventArgs e)
        {
            await getDataClientes();
            txtFechaRegistroCliente.Text = DateTime.Now.ToString();
        }

        private void datagridViewClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (datagridViewClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = datagridViewClientes.SelectedRows[0];

                txtClienteId.Text = selectedRow.Cells["clienteid"].Value.ToString();
                txtNombreCliente.Text = selectedRow.Cells["nombre"].Value.ToString();
                txtApellidoCliente.Text = selectedRow.Cells["apellido"].Value.ToString();
                txtDocIdentidad.Text = selectedRow.Cells["documentoidentidad"].Value.ToString();
                txtFechaRegistroCliente.Text = selectedRow.Cells["fecharegistro"].Value.ToString();
            }
        }

        private async void btnEliminarClientes_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int clienteId;
                if (int.TryParse(txtClienteId.Text, out clienteId))
                {
                    await deleteCliente(clienteId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de cuenta válido.");
                }
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Cliente nuevoCliente = new Cliente
            {
                Nombre = txtNombreCliente.Text,
                Apellido = txtApellidoCliente.Text,
                Documentoidentidad = txtDocIdentidad.Text,
                FechaRegistro = DateTime.Now
            };
            await CreateClienteAsync(nuevoCliente);
        }

        private void txtClienteId_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void datagridViewClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtFechaRegistroCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDocIdentidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtApellidoCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
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
