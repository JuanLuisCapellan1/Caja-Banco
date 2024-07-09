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
    public partial class GestionarUsuario : Form
    {
        private static readonly string apiUrl = ConfigurationManager.AppSettings["ApiUrl"];
        private static readonly HttpClient client = new HttpClient();
        Token token;
        int clienteId;
        public GestionarUsuario(Token token, int clienteId)
        {
            InitializeComponent();
            this.token = token;
            this.clienteId = clienteId;
        }

        private async void GestionarUsuario_Load(object sender, EventArgs e)
        {
            await GetDataUsuarios();
            await GetPerfilId();
            await GetClienteId();
        }

        private async Task GetPerfilId()
        {
            try
            {
                cbPerfilId.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Perfiles");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Perfil> perfiles = JsonConvert.DeserializeObject<List<Perfil>>(jsonResponse);

                    foreach (Perfil perfil in perfiles) {
                        cbPerfilId.Items.Add(perfil.perfilId);
                    }
                }
                else
                {
                    MessageBox.Show("Error en el request!");
                }
            }
            catch (HttpRequestException exeption)
            {
                MessageBox.Show($"Error al obtener los perfiles: {exeption.Message}");
            }
        }

        private async Task GetClienteId()
        {
            try
            {
                cbClienteId.Items.Clear();
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Clientes");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Cliente> clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonResponse);

                    foreach (Cliente cliente in clientes)
                    {
                        cbClienteId.Items.Add(cliente.ClienteId);
                    }
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

        private async Task GetDataUsuarios()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);
                HttpResponseMessage response = await client.GetAsync($"{apiUrl}/Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    List<Usuarios> usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(jsonResponse);
                    dataGridViewUsuario.DataSource = usuarios;
                    await GetPerfilId();
                    await GetClienteId();
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
        public async Task CreateUsuario(Usuarios usuario)
        {
            try
            {
                var validationResult = ValidateUsuario(usuario);
                if (!string.IsNullOrEmpty(validationResult))
                {
                    MessageBox.Show(validationResult);
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                var json = JsonConvert.SerializeObject(usuario);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{apiUrl}/Usuarios", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario creado exitosamente.");
                    clearTextBoxs();
                    await GetDataUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al crear usuario.");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error al realizar la solicitud: {ex.Message}");
            }
        }
        private string ValidateUsuario(Usuarios usuarios)
        {
            if (string.IsNullOrWhiteSpace(usuarios.nombreUsuario))
            {
                return "El nombre es obligatorio.";
            }

            if (string.IsNullOrWhiteSpace(usuarios.contraseña))
            {
                return "La contraseña es obligatoria.";
            }

            if (usuarios.perfilId <= 0)
            {
                return "El Perfil Id es obligatorio.";
            }

            if (usuarios.clienteId <= 0)
            {
                return "El Cliente Id es obligatorio.";
            }

            return string.Empty;
        }
        private void clearTextBoxs()
        {
            cbClienteId.Items.Clear();
            txtContraseña.Clear();
            txtNombreUsuario.Clear();
            cbPerfilId.Items.Clear();
            txtUserId.Clear();
        }
        private async Task updateUsuario(int usuarioId, string nombreUsuario, string contraseña, int perfilID, int clienteID)
        {
            try
            {
                if (nombreUsuario == null || nombreUsuario == "")
                {
                    MessageBox.Show("Favor completar el campo nombre");
                    return;
                }
                if (contraseña == null || contraseña == "")
                {
                    MessageBox.Show("Favor completar el campo contraseña");
                    return;
                }
                var usuarioUpdate = new
                {
                    nombreUsuario = nombreUsuario,
                    contraseña = contraseña,
                    perfilID = perfilID,
                    clienteID = clienteID
                };

                var json = JsonConvert.SerializeObject(usuarioUpdate);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.PutAsync($"{apiUrl}/Usuarios/{usuarioId}", content);


                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario actualizado exitosamente");
                    clearTextBoxs();
                    await GetDataUsuarios();
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
        private async Task DeleteUsuario(int usuarioId)
        {
            try
            {
                if (usuarioId <= 0)
                {
                    MessageBox.Show("ID del usuario no válido.");
                    return;
                }

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.accessToken);

                HttpResponseMessage response = await client.DeleteAsync($"{apiUrl}/Usuarios/{usuarioId}");

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario eliminado exitosamente.");
                    clearTextBoxs();
                    await GetDataUsuarios();
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
            Usuarios nuevoUsuario = new Usuarios()
            {
                nombreUsuario = txtNombreUsuario.Text,
                contraseña = txtContraseña.Text,
                perfilId = int.Parse(cbPerfilId.SelectedItem.ToString()),
                clienteId = int.Parse(cbClienteId.SelectedItem.ToString()),
            };
            await CreateUsuario(nuevoUsuario);
        }

        private void dataGridViewUsuario_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewUsuario.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewUsuario.SelectedRows[0];

                txtUserId.Text = selectedRow.Cells["usuarioID"].Value.ToString();
                txtNombreUsuario.Text = selectedRow.Cells["nombreUsuario"].Value.ToString();
                txtContraseña.Text = selectedRow.Cells["contraseña"].Value.ToString();
                cbPerfilId.Text = selectedRow.Cells["perfilID"].Value.ToString();
                cbClienteId.Text = selectedRow.Cells["clienteID"].Value.ToString();
            }
        }

        private async void btnActualizarPerfiles_Click(object sender, EventArgs e)
        {
            string nombreUsuario, contraseña;
            int clienteId, perfilId, usuarioId;

            try
            {
                if (cbClienteId.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un valor en el cliente Id.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbPerfilId.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un valor en el perfil Id.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                usuarioId = int.Parse(txtUserId.Text);
                clienteId = int.Parse(cbClienteId.SelectedItem.ToString());
                perfilId = int.Parse(cbPerfilId.SelectedItem.ToString());
                nombreUsuario = txtNombreUsuario.Text;
                contraseña = txtContraseña.Text;
                await updateUsuario(usuarioId, nombreUsuario, contraseña, perfilId, clienteId);
            }
            catch (Exception)
            {
                MessageBox.Show("Tipo de dato incorrecto!");
            }
        }

        private async void btnEliminarPerfiles_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmar Eliminación", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int usuarioId;
                if (int.TryParse(txtUserId.Text, out usuarioId))
                {
                    await DeleteUsuario(usuarioId);
                }
                else
                {
                    MessageBox.Show("Ingrese un ID de usuario válido.");
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
