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
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();
        }

        private void FormCategorias_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            if (dgvCategorias.Columns.Count > 0)
            {
                dgvCategorias.Columns["id_categoria"].HeaderText = "ID";
                dgvCategorias.Columns["nombre"].HeaderText = "Nombre";
                dgvCategorias.Columns["descripcion"].HeaderText = "Descripción";

                dgvCategorias.Columns["id_categoria"].Width = 60;
            }
        }

        private void CargarCategorias()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_categoria, nombre, descripcion FROM categorias ORDER BY id_categoria";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvCategorias.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCategorias.CurrentRow != null)
            {
                txtId.Text = dgvCategorias.CurrentRow.Cells["id_categoria"].Value.ToString();
                txtNombre.Text = dgvCategorias.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dgvCategorias.CurrentRow.Cells["descripcion"].Value.ToString();
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
            string descripcion = txtDescripcion.Text.Trim();

            if (nombre == "")
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;

                if (txtId.Text == "")
                {
                    // INSERT
                    cmd.CommandText = "INSERT INTO categorias (nombre, descripcion) " +
                                      "VALUES (@nombre, @descripcion)";
                }
                else
                {
                    // UPDATE
                    cmd.CommandText = "UPDATE categorias " +
                                      "SET nombre = @nombre, descripcion = @descripcion " +
                                      "WHERE id_categoria = @id";

                    cmd.Parameters.AddWithValue("@id", txtId.Text);
                }

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Categoría guardada correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCategorias();
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
                MessageBox.Show("Error al guardar la categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecciona una categoría para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar esta categoría?",
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

                string sql = "DELETE FROM categorias WHERE id_categoria = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Categoría eliminada correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCategorias();
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
                // Por si la categoría está en uso en productos (FK)
                MessageBox.Show("No se puede eliminar la categoría. " +
                                "Es posible que tenga productos asociados.\n\nDetalle técnico:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoría:\n" + ex.Message,
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
    

}
}
