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
    public partial class FormListadoVentas : Form
    {
        public FormListadoVentas()
        {
            InitializeComponent();
        }

        private void FormListadoVentas_Load(object sender, EventArgs e)
        {
            CargarVentas();
            ConfigurarGridVentas();
            ConfigurarGridDetalle();
            lblTotalVenta.Text = "0.00";
        }

        private void CargarVentas()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT v.id_venta, v.fecha, " +
                             "IFNULL(c.nombre, '(Sin cliente)') AS cliente, " +
                             "u.nombre AS usuario, v.total " +
                             "FROM ventas v " +
                             "LEFT JOIN clientes c ON v.id_cliente = c.id_cliente " +
                             "INNER JOIN usuarios u ON v.id_usuario = u.id_usuario " +
                             "ORDER BY v.fecha DESC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, conexion);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvVentas.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void ConfigurarGridVentas()
        {
            if (dgvVentas.Columns.Count > 0)
            {
                dgvVentas.Columns["id_venta"].HeaderText = "ID";
                dgvVentas.Columns["fecha"].HeaderText = "Fecha";
                dgvVentas.Columns["cliente"].HeaderText = "Cliente";
                dgvVentas.Columns["usuario"].HeaderText = "Usuario";
                dgvVentas.Columns["total"].HeaderText = "Total";

                dgvVentas.Columns["id_venta"].Width = 60;
                dgvVentas.Columns["total"].Width = 80;
            }
        }

        private void ConfigurarGridDetalle()
        {
            dgvDetalle.Columns.Clear();

            dgvDetalle.Columns.Add("id_detalle", "ID Detalle");
            dgvDetalle.Columns.Add("id_producto", "ID Producto");
            dgvDetalle.Columns.Add("nombre_producto", "Producto");
            dgvDetalle.Columns.Add("cantidad", "Cantidad");
            dgvDetalle.Columns.Add("precio_unitario", "Precio");
            dgvDetalle.Columns.Add("subtotal", "Subtotal");

            dgvDetalle.Columns["id_detalle"].Width = 80;
            dgvDetalle.Columns["id_producto"].Width = 80;
            dgvDetalle.Columns["cantidad"].Width = 80;
            dgvDetalle.Columns["precio_unitario"].Width = 100;
            dgvDetalle.Columns["subtotal"].Width = 100;
        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvVentas.CurrentRow != null)
            {
                int idVenta = Convert.ToInt32(dgvVentas.CurrentRow.Cells["id_venta"].Value);
                lblTotalVenta.Text = dgvVentas.CurrentRow.Cells["total"].Value.ToString();

                CargarDetalleVenta(idVenta);
            }
        }

        private void CargarDetalleVenta(int idVenta)
        {
            dgvDetalle.Rows.Clear();

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT dv.id_detalle, dv.id_producto, p.nombre, " +
                             "dv.cantidad, dv.precio_unitario, dv.subtotal " +
                             "FROM detalle_venta dv " +
                             "INNER JOIN productos p ON dv.id_producto = p.id_producto " +
                             "WHERE dv.id_venta = @id_venta";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id_venta", idVenta);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idDetalle = reader.GetInt32("id_detalle");
                    int idProducto = reader.GetInt32("id_producto");
                    string nombreProducto = reader.GetString("nombre");
                    int cantidad = reader.GetInt32("cantidad");
                    decimal precioUnitario = reader.GetDecimal("precio_unitario");
                    decimal subtotal = reader.GetDecimal("subtotal");

                    dgvDetalle.Rows.Add(
                        idDetalle,
                        idProducto,
                        nombreProducto,
                        cantidad,
                        precioUnitario.ToString("0.00"),
                        subtotal.ToString("0.00")
                    );
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarVentas();
            dgvDetalle.Rows.Clear();
            lblTotalVenta.Text = "0.00";
        }

    }
}
