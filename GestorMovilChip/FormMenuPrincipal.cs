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
using GestorMovilChip.Datos;
using MySql.Data.MySqlClient;


namespace GestorMovilChip
{
    public partial class FormMenuPrincipal : Form
    {
        private int idUsuario;
        private string nombreUsuario;
        private string rolUsuario;

        public FormMenuPrincipal(int idUsuario, string nombreUsuario, string rolUsuario)
        {
            InitializeComponent();

            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.rolUsuario = rolUsuario;

            EstilosUI.AplicarEstiloFormulario(this);

            panelTop.BackColor = EstilosUI.ColorPanel;
            panelLeft.BackColor = Color.FromArgb(25, 25, 40);

            EstilosUI.AplicarEstiloLabelTitulo(lblTituloApp);
            lblTituloApp.ForeColor = EstilosUI.ColorTextoClaro;
            lblUsuarioLogueado.ForeColor = EstilosUI.ColorTextoClaro;

            EstilosUI.AplicarEstiloBotonMenu(btnCategorias);
            EstilosUI.AplicarEstiloBotonMenu(btnProductos);
            EstilosUI.AplicarEstiloBotonMenu(btnVentas);
            EstilosUI.AplicarEstiloBotonMenu(btnListadoVentas);
            EstilosUI.AplicarEstiloBotonMenu(btnClientes);

            EstilosUI.AplicarEstiloCard(panelCardHoy);
            EstilosUI.AplicarEstiloCard(panelCardMes);
            EstilosUI.AplicarEstiloCard(panelCardStock);
            EstilosUI.AplicarEstiloDataGridView(dgvUltimasVentas);
            EstilosUI.AplicarEstiloBotonSecundario(btnRefrescarDashboard);
            EstilosUI.AplicarEstiloGroupBox(grpUltimasVentas);



        }


        private void FormMenuPrincipal_Load(object sender, EventArgs e)
        {
            // Puedes poner el nombre del usuario en el título
            this.Text = "Gestor Tienda - " + nombreUsuario + " (" + rolUsuario + ")";

            // Si tienes un label de bienvenida:
            lblUsuarioLogueado.Text = "Bienvenido, " + nombreUsuario;

            CargarResumenDashboard();
            AplicarPermisosPorRol();
        }

        private void FormMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Si cierra el menú principal → cerramos toda la app
            Application.Exit();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FormCategorias form = new FormCategorias();
            form.ShowDialog(); // modal
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FormProductos form = new FormProductos();
            form.ShowDialog();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            // Ya tenemos idUsuario y nombreUsuario en este form
            FormVentas form = new FormVentas(idUsuario, nombreUsuario);
            form.ShowDialog();
        }

        private void btnListadoVentas_Click(object sender, EventArgs e)
        {
            FormListadoVentas form = new FormListadoVentas();
            form.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes form = new FormClientes();
            form.ShowDialog();
        }

        //CÓDIGO DEL DASHBOARD
        private void CargarResumenDashboard()
        {
            CargarVentasHoy();
            CargarVentasMes();
            CargarProductosStockBajo();
            CargarUltimasVentas();
        }

        private void CargarVentasHoy()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT IFNULL(SUM(total), 0) AS total_hoy " +
                             "FROM ventas " +
                             "WHERE DATE(fecha) = CURDATE()";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                object resultado = cmd.ExecuteScalar();

                decimal totalHoy = 0;

                if (resultado != null && resultado != DBNull.Value)
                {
                    totalHoy = Convert.ToDecimal(resultado);
                }

                lblVentasHoy.Text = totalHoy.ToString("0.00") + " €";
            }
            catch (Exception ex)
            {
                lblVentasHoy.Text = "--";
                MessageBox.Show("Error al cargar ventas de hoy:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void CargarVentasMes()
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT IFNULL(SUM(total), 0) AS total_mes " +
                             "FROM ventas " +
                             "WHERE YEAR(fecha) = YEAR(CURDATE()) " +
                             "AND MONTH(fecha) = MONTH(CURDATE())";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                object resultado = cmd.ExecuteScalar();

                decimal totalMes = 0;

                if (resultado != null && resultado != DBNull.Value)
                {
                    totalMes = Convert.ToDecimal(resultado);
                }

                lblVentasMes.Text = totalMes.ToString("0.00") + " €";
            }
            catch (Exception ex)
            {
                lblVentasMes.Text = "--";
                MessageBox.Show("Error al cargar ventas del mes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void CargarProductosStockBajo(int umbral = 5)
        {
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT COUNT(*) FROM productos " +
                             "WHERE stock < @umbral AND activo = 1";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@umbral", umbral);

                object resultado = cmd.ExecuteScalar();

                int cantidad = 0;

                if (resultado != null && resultado != DBNull.Value)
                {
                    cantidad = Convert.ToInt32(resultado);
                }

                lblStockBajo.Text = cantidad.ToString();
            }
            catch (Exception ex)
            {
                lblStockBajo.Text = "--";
                MessageBox.Show("Error al cargar productos con stock bajo:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void FormMenuPrincipal_Activated(object sender, EventArgs e)
        {
            CargarResumenDashboard();
        }

        private void btnRefrescarDashboard_Click(object sender, EventArgs e)
        {
            CargarResumenDashboard();
        }

        private bool EsAdmin
        {
            get { return rolUsuario != null && rolUsuario.ToLower() == "admin"; }
        }

        private void AplicarPermisosPorRol()
        {
            if (!EsAdmin)
            {
                // un empleado NO puede ver el listado global de ventas
                btnListadoVentas.Enabled = false;
                // Lo podemos ocultar si queremos: 
                // btnListadoVentas.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Calcular Hash
            Console.Write(Seguridad.CalcularHash("1234"));
             MessageBox.Show(Seguridad.CalcularHash("1234"));
        }

        private void CargarUltimasVentas(int maxFilas = 10)
        {
            try
            {
                var lista = VentaDAO.ObtenerVentas(); // ya la tenemos hecha

                // Si quieres solo las 10 primeras:
                if (lista.Count > maxFilas)
                {
                    lista = lista.GetRange(0, maxFilas);
                }

                dgvUltimasVentas.DataSource = null;
                dgvUltimasVentas.DataSource = lista;

                ConfigurarGridUltimasVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar últimas ventas:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGridUltimasVentas()
        {
            if (dgvUltimasVentas.Columns.Count > 0)
            {
                dgvUltimasVentas.Columns["IdVenta"].HeaderText = "ID";
                dgvUltimasVentas.Columns["Fecha"].HeaderText = "Fecha";
                dgvUltimasVentas.Columns["NombreCliente"].HeaderText = "Cliente";
                dgvUltimasVentas.Columns["NombreUsuario"].HeaderText = "Usuario";
                dgvUltimasVentas.Columns["Total"].HeaderText = "Total";

                // ocultamos lo que no haga falta
                if (dgvUltimasVentas.Columns["IdCliente"] != null)
                    dgvUltimasVentas.Columns["IdCliente"].Visible = false;
                if (dgvUltimasVentas.Columns["IdUsuario"] != null)
                    dgvUltimasVentas.Columns["IdUsuario"].Visible = false;

                dgvUltimasVentas.Columns["IdVenta"].Width = 60;
                dgvUltimasVentas.Columns["Total"].Width = 80;
            }
        }

    }
}
