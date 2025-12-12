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
using GestorMovilChip.Modelos;
using GestorMovilChip.Datos;

namespace GestorMovilChip
{
    public partial class FormProductos : Form
    {
        public FormProductos()
        {
            InitializeComponent();

            EstilosUI.AplicarPantallaCrudOscuroConDetalleClaro(
                  form: this,
                  textoTitulo: "Gestión de productos",
                  dgv: dgvProductos,
                  splitContainer: splitProductos,
                  grpDatos: grpDatosProducto,
                  panelBusqueda: panelBusqueda,
                  tblCampos: tblCamposProducto,
                  panelBotones: panelBotones,
                  lblBuscar: lblBuscarProducto,
                  chkActivo: chkActivo,
                  cajasTexto: new TextBox[]
                  {
                      txtIdProducto,
                      txtNombre,
                      txtDescripcion,
                      txtPrecioCompra,
                      txtPrecioVenta,
                      txtStock,
                      txtCodigoBarras,
                      txtBuscarProducto
                  },
                  comboCategoria: cmbCategoria,
                  btnNuevo: btnNuevo,
                  btnGuardar: btnGuardar,
                  btnEliminar: btnEliminar,
                  btnCancelar: btnCancelar
              );

            EstilosUI.AplicarBotonesCrud(btnNuevo, btnGuardar, btnEliminar, btnCancelar);


        }


        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarCategoriasCombo();
            CargarProductos();
           // ConfigurarGrid();
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
            try
            {
                List<Producto> lista = ProductoDAO.ObtenerTodos(filtroNombre);

                dgvProductos.DataSource = null;
                dgvProductos.DataSource = lista;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarGrid()
        {
            if (dgvProductos.Columns.Count > 0)
            {
                dgvProductos.Columns["IdProducto"].HeaderText = "ID";
                dgvProductos.Columns["Nombre"].HeaderText = "Nombre";
                dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
                dgvProductos.Columns["NombreCategoria"].HeaderText = "Categoría";
                dgvProductos.Columns["PrecioCompra"].HeaderText = "P. Compra";
                dgvProductos.Columns["PrecioVenta"].HeaderText = "P. Venta";
                dgvProductos.Columns["Stock"].HeaderText = "Stock";
                dgvProductos.Columns["CodigoBarras"].HeaderText = "Código barras";
                dgvProductos.Columns["Activo"].HeaderText = "Activo";

                // columnas que puedes ocultar
                if (dgvProductos.Columns["IdCategoria"] != null)
                    dgvProductos.Columns["IdCategoria"].Visible = false;

                dgvProductos.Columns["IdProducto"].Width = 50;
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
                Producto p = dgvProductos.CurrentRow.DataBoundItem as Producto;

                if (p != null)
                {
                    txtIdProducto.Text = p.IdProducto.ToString();
                    txtNombre.Text = p.Nombre;
                    txtDescripcion.Text = p.Descripcion;
                    txtPrecioCompra.Text = p.PrecioCompra.ToString("0.00");
                    txtPrecioVenta.Text = p.PrecioVenta.ToString("0.00");
                    txtStock.Text = p.Stock.ToString();
                    txtCodigoBarras.Text = p.CodigoBarras;
                    chkActivo.Checked = p.Activo;
                    cmbCategoria.SelectedValue = p.IdCategoria;
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

            int id = Convert.ToInt32(txtIdProducto.Text);

            try
            {
                bool ok = ProductoDAO.Eliminar(id);

                if (ok)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el producto:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void grpDatosProducto_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lblTituloProductos_Click(object sender, EventArgs e)
        {

        }

        private void lblBuscarProducto_Click(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
