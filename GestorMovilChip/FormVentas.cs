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
            try
            {
                List<Cliente> lista = ClienteDAO.ObtenerTodos(); // sin filtro

                cmbCliente.DataSource = null;
                cmbCliente.DataSource = lista;
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "IdCliente";
                cmbCliente.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarProductosCombo()
        {
            try
            {
                List<Producto> lista = ProductoDAO.ObtenerActivosParaVenta();

                cmbProducto.DataSource = null;
                cmbProducto.DataSource = lista;
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "IdProducto";
                cmbProducto.SelectedIndex = -1;

                txtPrecioUnitario.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            Producto p = cmbProducto.SelectedItem as Producto;

            if (p != null)
            {
                txtPrecioUnitario.Text = p.PrecioVenta.ToString("0.00");
            }
        }


        private void btnAgregarLinea_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un producto.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ahora el combo trabaja con objetos Producto, no con DataRowView
            Producto p = cmbProducto.SelectedItem as Producto;

            if (p == null)
            {
                MessageBox.Show("Error al obtener el producto seleccionado.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int idProducto = p.IdProducto;
            string nombreProducto = p.Nombre;

            decimal precioUnitario;
            if (!decimal.TryParse(txtPrecioUnitario.Text.Trim(), out precioUnitario))
            {
                MessageBox.Show("Precio unitario no válido.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad = (int)nudCantidad.Value;
            decimal subtotal = precioUnitario * cantidad;

            // Añadir fila al grid
            dgvLineas.Rows.Add(
                idProducto,
                nombreProducto,
                cantidad,
                precioUnitario.ToString("0.00"),
                subtotal.ToString("0.00")
            );

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

            // Construimos el objeto Venta
            Venta v = new Venta();
            v.Fecha = DateTime.Now;
            v.IdUsuario = idUsuario;
            v.Total = total;

            if (cmbCliente.SelectedValue != null)
                v.IdCliente = Convert.ToInt32(cmbCliente.SelectedValue);
            else
                v.IdCliente = null;

            // Construimos la lista de detalles desde el grid
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            foreach (DataGridViewRow fila in dgvLineas.Rows)
            {
                if (fila.IsNewRow) continue;

                DetalleVenta d = new DetalleVenta();
                d.IdProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                d.Cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value);
                d.PrecioUnitario = Convert.ToDecimal(fila.Cells["precio_unitario"].Value);
                d.Subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value);

                detalles.Add(d);
            }

            try
            {
                int idVentaNueva = VentaDAO.InsertarVentaConDetalles(v, detalles);

                MessageBox.Show("Venta guardada correctamente. ID: " + idVentaNueva,
                    "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarVenta();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la venta:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
