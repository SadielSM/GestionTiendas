using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorMovilChip.Clase;
using MySql.Data.MySqlClient;

namespace GestorMovilChip
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvClientes.Columns.Count > 0)
            {
                dgvClientes.Columns["id_cliente"].HeaderText = "ID";
                dgvClientes.Columns["nombre"].HeaderText = "Nombre";
                dgvClientes.Columns["telefono"].HeaderText = "Teléfono";
                dgvClientes.Columns["email"].HeaderText = "Email";
                dgvClientes.Columns["dni"].HeaderText = "DNI";
                dgvClientes.Columns["direccion"].HeaderText = "Dirección";

                dgvClientes.Columns["id_cliente"].Width = 60;
            }
        }

        private void CargarClientes(string filtroNombre = "")
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_cliente, nombre, telefono, email, dni, direccion " +
                             "FROM clientes";

                if (filtroNombre != "")
                {
                    sql += " WHERE nombre LIKE @filtro";
                }

                sql += " ORDER BY nombre";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                if (filtroNombre != "")
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClientes.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }


        private void LimpiarCampos()
        {
            txtIdCliente.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDni.Text = "";
            txtDireccion.Text = "";
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvClientes.CurrentRow != null)
            {
                txtIdCliente.Text = dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString();
                txtNombre.Text = dgvClientes.CurrentRow.Cells["nombre"].Value.ToString();
                txtTelefono.Text = dgvClientes.CurrentRow.Cells["telefono"].Value.ToString();
                txtEmail.Text = dgvClientes.CurrentRow.Cells["email"].Value.ToString();
                txtDni.Text = dgvClientes.CurrentRow.Cells["dni"].Value.ToString();
                txtDireccion.Text = dgvClientes.CurrentRow.Cells["direccion"].Value.ToString();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string email = txtEmail.Text.Trim();
            string dni = txtDni.Text.Trim();
            string direccion = txtDireccion.Text.Trim();

            if (nombre == "")
            {
                MessageBox.Show("El nombre del cliente es obligatorio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;

                if (txtIdCliente.Text == "")
                {
                    // INSERT
                    cmd.CommandText = "INSERT INTO clientes " +
                                      "(nombre, telefono, email, dni, direccion) " +
                                      "VALUES (@nombre, @telefono, @email, @dni, @direccion)";
                }
                else
                {
                    // UPDATE
                    cmd.CommandText = "UPDATE clientes SET " +
                                      "nombre = @nombre, telefono = @telefono, " +
                                      "email = @email, dni = @dni, direccion = @direccion " +
                                      "WHERE id_cliente = @id_cliente";

                    cmd.Parameters.AddWithValue("@id_cliente", txtIdCliente.Text);
                }

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@dni", dni);
                cmd.Parameters.AddWithValue("@direccion", direccion);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Cliente guardado correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se realizó ningún cambio.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el cliente:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdCliente.Text == "")
            {
                MessageBox.Show("Selecciona un cliente para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar este cliente?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (r != DialogResult.Yes)
                return;

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "DELETE FROM clientes WHERE id_cliente = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", txtIdCliente.Text);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Cliente eliminado correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarClientes();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se eliminó ninguna fila.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                // Por si en un futuro quieres bloquear eliminación si tiene ventas asociadas
                MessageBox.Show("No se puede eliminar el cliente. " +
                                "Es posible que tenga ventas asociadas.\n\nDetalle:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarCliente.Text.Trim();
            CargarClientes(texto);
        }
    }
}
