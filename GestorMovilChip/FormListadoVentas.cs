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
using GestorMovilChip.Datos;
using GestorMovilChip.Modelos;

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
            try
            {
                List<Venta> lista = VentaDAO.ObtenerVentas();

                dgvVentas.DataSource = null;
                dgvVentas.DataSource = lista;

                ConfigurarGridVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ConfigurarGridVentas()
        {
            if (dgvVentas.Columns.Count > 0)
            {
                dgvVentas.Columns["IdVenta"].HeaderText = "ID";
                dgvVentas.Columns["Fecha"].HeaderText = "Fecha";
                dgvVentas.Columns["NombreCliente"].HeaderText = "Cliente";
                dgvVentas.Columns["NombreUsuario"].HeaderText = "Usuario";
                dgvVentas.Columns["Total"].HeaderText = "Total";

                dgvVentas.Columns["IdCliente"].Visible = false;
                dgvVentas.Columns["IdUsuario"].Visible = false;

                dgvVentas.Columns["IdVenta"].Width = 60;
                dgvVentas.Columns["Total"].Width = 80;
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
                Venta v = dgvVentas.CurrentRow.DataBoundItem as Venta;

                if (v != null)
                {
                    lblTotalVenta.Text = v.Total.ToString("0.00");
                    CargarDetalleVenta(v.IdVenta);
                }
            }
        }


        private void CargarDetalleVenta(int idVenta)
        {
            dgvDetalle.Rows.Clear();

            try
            {
                List<DetalleVenta> lista = VentaDAO.ObtenerDetalleVenta(idVenta);

                foreach (DetalleVenta d in lista)
                {
                    dgvDetalle.Rows.Add(
                        d.IdDetalle,
                        d.IdProducto,
                        d.NombreProducto,
                        d.Cantidad,
                        d.PrecioUnitario.ToString("0.00"),
                        d.Subtotal.ToString("0.00")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la venta:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
