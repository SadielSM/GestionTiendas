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
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarCategoriasCombo();
            CargarProductos();
            ConfigurarGrid();
        }

        private void CargarCategoriasCombo()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_categoria, nombre FROM categorias ORDER BY nombre";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCategoria.DataSource = dt;
                cmbCategoria.DisplayMember = "nombre";
                cmbCategoria.ValueMember = "id_categoria";
                cmbCategoria.SelectedIndex = -1;
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

        private void CargarProductos(string filtroNombre = "")
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT p.id_producto, p.nombre, p.descripcion, " +
                             "p.id_categoria, c.nombre AS categoria, " +
                             "p.precio_compra, p.precio_venta, p.stock, " +
                             "p.codigo_barras, p.activo " +
                             "FROM productos p " +
                             "INNER JOIN categorias c ON p.id_categoria = c.id_categoria";

                if (filtroNombre != "")
                {
                    sql += " WHERE p.nombre LIKE @filtro";
                }

                sql += " ORDER BY p.id_producto";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                if (filtroNombre != "")
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");
                }

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvProductos.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                dgvProductos.Columns["id_producto"].HeaderText = "ID";
                dgvProductos.Columns["nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["categoria"].HeaderText = "Categoría";
                dgvProductos.Columns["precio_compra"].HeaderText = "P. Compra";
                dgvProductos.Columns["precio_venta"].HeaderText = "P. Venta";
                dgvProductos.Columns["stock"].HeaderText = "Stock";
                dgvProductos.Columns["codigo_barras"].HeaderText = "Código barras";
                dgvProductos.Columns["activo"].HeaderText = "Activo";

                // columnas internas que igual no quieres mostrar
                if (dgvProductos.Columns["id_categoria"] != null)
                {
                    dgvProductos.Columns["id_categoria"].Visible = false;
                }

                dgvProductos.Columns["id_producto"].Width = 50;
            }
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Text = "";
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtStock.Text = "";
            txtCodigoBarras.Text = "";
            chkActivo.Checked = true;
            if (cmbCategoria.Items.Count > 0)
            {
                cmbCategoria.SelectedIndex = -1;
            }
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProductos.CurrentRow != null)
            {
                txtIdProducto.Text = dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString();
                txtNombre.Text = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
                txtPrecioCompra.Text = dgvProductos.CurrentRow.Cells["precio_compra"].Value.ToString();
                txtPrecioVenta.Text = dgvProductos.CurrentRow.Cells["precio_venta"].Value.ToString();
                txtStock.Text = dgvProductos.CurrentRow.Cells["stock"].Value.ToString();
                txtCodigoBarras.Text = dgvProductos.CurrentRow.Cells["codigo_barras"].Value.ToString();

                // activo
                object valorActivo = dgvProductos.CurrentRow.Cells["activo"].Value;
                if (valorActivo != null && valorActivo.ToString() == "1")
                {
                    chkActivo.Checked = true;
                }
                else
                {
                    chkActivo.Checked = false;
                }

                // categoría
                object idCat = dgvProductos.CurrentRow.Cells["id_categoria"].Value;
                if (idCat != null)
                {
                    cmbCategoria.SelectedValue = idCat;
                }
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
            string codigoBarras = txtCodigoBarras.Text.Trim();
            bool activo = chkActivo.Checked;

            if (nombre == "")
            {
                MessageBox.Show("El nombre del producto es obligatorio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCategoria.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una categoría.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);

            decimal precioCompra;
            decimal precioVenta;
            int stock;

            if (txtPrecioCompra.Text.Trim() == "")
            {
                precioCompra = 0;
            }
            else
            {
                if (!decimal.TryParse(txtPrecioCompra.Text.Trim(), out precioCompra))
                {
                    MessageBox.Show("Precio de compra no válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtPrecioVenta.Text.Trim() == "")
            {
                precioVenta = 0;
            }
            else
            {
                if (!decimal.TryParse(txtPrecioVenta.Text.Trim(), out precioVenta))
                {
                    MessageBox.Show("Precio de venta no válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (txtStock.Text.Trim() == "")
            {
                stock = 0;
            }
            else
            {
                if (!int.TryParse(txtStock.Text.Trim(), out stock))
                {
                    MessageBox.Show("Stock no válido.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion;

                if (txtIdProducto.Text == "")
                {
                    // INSERT
                    cmd.CommandText = "INSERT INTO productos " +
                                      "(nombre, descripcion, id_categoria, precio_compra, precio_venta, stock, codigo_barras, activo) " +
                                      "VALUES (@nombre, @descripcion, @id_categoria, @precio_compra, @precio_venta, @stock, @codigo_barras, @activo)";
                }
                else
                {
                    // UPDATE
                    cmd.CommandText = "UPDATE productos SET " +
                                      "nombre = @nombre, descripcion = @descripcion, " +
                                      "id_categoria = @id_categoria, precio_compra = @precio_compra, " +
                                      "precio_venta = @precio_venta, stock = @stock, " +
                                      "codigo_barras = @codigo_barras, activo = @activo " +
                                      "WHERE id_producto = @id_producto";

                    cmd.Parameters.AddWithValue("@id_producto", txtIdProducto.Text);
                }

                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@descripcion", descripcion);
                cmd.Parameters.AddWithValue("@id_categoria", idCategoria);
                cmd.Parameters.AddWithValue("@precio_compra", precioCompra);
                cmd.Parameters.AddWithValue("@precio_venta", precioVenta);
                cmd.Parameters.AddWithValue("@stock", stock);
                cmd.Parameters.AddWithValue("@codigo_barras", codigoBarras);
                cmd.Parameters.AddWithValue("@activo", activo ? 1 : 0);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Producto guardado correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProductos();
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
                MessageBox.Show("Error al guardar el producto:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtIdProducto.Text == "")
            {
                MessageBox.Show("Selecciona un producto para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult r = MessageBox.Show(
                "¿Seguro que deseas eliminar este producto?",
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

                string sql = "DELETE FROM productos WHERE id_producto = @id";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", txtIdProducto.Text);

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0)
                {
                    MessageBox.Show("Producto eliminado correctamente.",
                        "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarProductos();
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
                MessageBox.Show("No se puede eliminar el producto. " +
                                "Puede estar relacionado con ventas.\n\nDetalle técnico:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto:\n" + ex.Message,
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

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscarProducto.Text.Trim();
            CargarProductos(texto);
        }
    }
}
