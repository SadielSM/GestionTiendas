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
    public partial class FormVentas : Form
    {
        private int idUsuario;
        private string nombreUsuario;
        public FormVentas(int idUsuario, string nombreUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = nombreUsuario;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            lblTotal.Text = "0.00";

            CargarClientes();
            CargarProductosCombo();
            ConfigurarGridLineas();

            nudCantidad.Minimum = 1;
            nudCantidad.Value = 1;
        }

        private void CargarClientes()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_cliente, nombre FROM clientes ORDER BY nombre";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbCliente.DataSource = dt;
                cmbCliente.DisplayMember = "nombre";
                cmbCliente.ValueMember = "id_cliente";
                cmbCliente.SelectedIndex = -1; // cliente opcional
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

        private void CargarProductosCombo()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_producto, nombre, precio_venta " +
                             "FROM productos " +
                             "WHERE activo = 1 " +
                             "ORDER BY nombre";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbProducto.DataSource = dt;
                cmbProducto.DisplayMember = "nombre";
                cmbProducto.ValueMember = "id_producto";
                cmbProducto.SelectedIndex = -1;

                txtPrecioUnitario.Text = "";
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

        private void ConfigurarGridLineas()
        {
            dgvLineas.Columns.Clear();

            dgvLineas.Columns.Add("id_producto", "ID Producto");
            dgvLineas.Columns.Add("nombre_producto", "Producto");
            dgvLineas.Columns.Add("cantidad", "Cantidad");
            dgvLineas.Columns.Add("precio_unitario", "Precio");
            dgvLineas.Columns.Add("subtotal", "Subtotal");

            dgvLineas.Columns["id_producto"].Width = 80;
            dgvLineas.Columns["cantidad"].Width = 80;
            dgvLineas.Columns["precio_unitario"].Width = 100;
            dgvLineas.Columns["subtotal"].Width = 100;
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem != null)
            {
                DataRowView fila = cmbProducto.SelectedItem as DataRowView;
                if (fila != null)
                {
                    decimal precio = 0;

                    if (fila["precio_venta"] != DBNull.Value)
                    {
                        precio = Convert.ToDecimal(fila["precio_venta"]);
                    }

                    txtPrecioUnitario.Text = precio.ToString("0.00");
                }
            }
        }

        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idProducto = Convert.ToInt32(cmbProducto.SelectedValue);
            string nombreProducto = ((DataRowView)cmbProducto.SelectedItem)["nombre"].ToString();

            decimal precioUnitario;
            if (!decimal.TryParse(txtPrecioUnitario.Text.Trim(), out precioUnitario))
            {
                MessageBox.Show("Precio unitario no válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = Convert.ToInt32(nudCantidad.Value);
            decimal subtotal = precioUnitario * cantidad;

            // Añadir fila al grid
            dgvLineas.Rows.Add(idProducto, nombreProducto, cantidad,
                               precioUnitario.ToString("0.00"),
                               subtotal.ToString("0.00"));

            CalcularTotal();
        }

        private void btnQuitarLinea_Click(object sender, EventArgs e)
        {
            if (dgvLineas.CurrentRow != null && dgvLineas.CurrentRow.Index >= 0)
            {
                dgvLineas.Rows.RemoveAt(dgvLineas.CurrentRow.Index);
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Selecciona una línea para quitar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;

            foreach (DataGridViewRow fila in dgvLineas.Rows)
            {
                if (fila.Cells["subtotal"].Value != null)
                {
                    decimal valor;
                    if (decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out valor))
                    {
                        total += valor;
                    }
                }
            }

            lblTotal.Text = total.ToString("0.00");
        }

        private void LimpiarVenta()
        {
            cmbCliente.SelectedIndex = -1;
            cmbProducto.SelectedIndex = -1;
            txtPrecioUnitario.Text = "";
            nudCantidad.Value = 1;
            dgvLineas.Rows.Clear();
            lblTotal.Text = "0.00";
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarVenta();
        }

        private void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (dgvLineas.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos una línea de producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total;
            if (!decimal.TryParse(lblTotal.Text, out total))
            {
                MessageBox.Show("Total no válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlConnection conexion = ConexionBD.ObtenerConexion();
            MySqlTransaction transaccion = null;

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                // 1) Insertar en ventas
                string sqlVenta = "INSERT INTO ventas (fecha, id_cliente, id_usuario, total) " +
                                  "VALUES (@fecha, @id_cliente, @id_usuario, @total)";

                MySqlCommand cmdVenta = new MySqlCommand(sqlVenta, conexion, transaccion);
                cmdVenta.Parameters.AddWithValue("@fecha", DateTime.Now);

                object idCliente = DBNull.Value;
                if (cmbCliente.SelectedValue != null)
                {
                    idCliente = cmbCliente.SelectedValue;
                }
                cmdVenta.Parameters.AddWithValue("@id_cliente", idCliente);

                cmdVenta.Parameters.AddWithValue("@id_usuario", idUsuario);
                cmdVenta.Parameters.AddWithValue("@total", total);

                cmdVenta.ExecuteNonQuery();
                long idVenta = cmdVenta.LastInsertedId;

                // 2) Insertar detalle_venta + actualizar stock
                foreach (DataGridViewRow fila in dgvLineas.Rows)
                {
                    int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);
                    decimal precioUnitario = Convert.ToDecimal(fila.Cells["precio_unitario"].Value);
                    decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);

                    // detalle_venta
                    string sqlDetalle = "INSERT INTO detalle_venta " +
                                        "(id_venta, id_producto, cantidad, precio_unitario, subtotal) " +
                                        "VALUES (@id_venta, @id_producto, @cantidad, @precio_unitario, @subtotal)";

                    MySqlCommand cmdDetalle = new MySqlCommand(sqlDetalle, conexion, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@id_venta", idVenta);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", idProducto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio_unitario", precioUnitario);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    // actualizar stock
                    string sqlStock = "UPDATE productos " +
                                      "SET stock = stock - @cantidad " +
                                      "WHERE id_producto = @id_producto";

                    MySqlCommand cmdStock = new MySqlCommand(sqlStock, conexion, transaccion);
                    cmdStock.Parameters.AddWithValue("@cantidad", cantidad);
                    cmdStock.Parameters.AddWithValue("@id_producto", idProducto);
                    cmdStock.ExecuteNonQuery();
                }

                // 3) Confirmar transacción
                transaccion.Commit();

                MessageBox.Show("Venta guardada correctamente.",
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarVenta();
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                {
                    transaccion.Rollback();
                }

                MessageBox.Show("Error al guardar la venta:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

    }
}
