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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();

            // Form fijo como el resto
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //  FONDO OSCURO GENERAL 
            EstilosUI.AplicarEstiloFormularioOscuro(this);

            //  GRID IZQUIERDO 
            EstilosUI.AplicarEstiloDataGridView(dgvClientes);
            dgvClientes.BackgroundColor = EstilosUI.ColorFondoOscuro;
            splitContainer1.Panel1.BackColor = EstilosUI.ColorFondoOscuro;

            //  ZONA DERECHA CLARITA (FICHA CLIENTE) 
            Color fondoClaro = EstilosUI.ColorFondoFormulario;

            splitContainer1.Panel2.BackColor = fondoClaro;
            grpDatosCliente.BackColor = fondoClaro;
            tblDatosCliente.BackColor = fondoClaro;
            tableLayoutPanel1.BackColor = fondoClaro;  // panel botones arriba 
            tableLayoutPanel2.BackColor = fondoClaro;  // panel botones abajo 

            grpDatosCliente.ForeColor = EstilosUI.ColorTextoOscuro;
            grpDatosCliente.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            //  FUENTES Y COLORES DE LABELS 
            Font fuenteLabels = new Font("Segoe UI", 9F, FontStyle.Regular);
            Font fuenteInputs = new Font("Segoe UI", 9F, FontStyle.Regular);

            foreach (Control c in tblDatosCliente.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = EstilosUI.ColorTextoOscuro;
                    lbl.Font = fuenteLabels;
                }
                else if (c is TextBox txt)
                {
                    txt.Font = fuenteInputs;
                    txt.BackColor = Color.White;
                    txt.ForeColor = EstilosUI.ColorTextoOscuro;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // Por si el label de Buscar está fuera del foreach
            lblBuscarCli.Font = fuenteLabels;
            lblBuscarCli.ForeColor = EstilosUI.ColorTextoOscuro;

            //  BOTONES 
            // 1-Primarios
            EstilosUI.AplicarEstiloBoton(btnNuevo);
            EstilosUI.AplicarEstiloBoton(btnGuardar);

            // 2-Secundarios
            EstilosUI.AplicarEstiloBotonSecundario(btnEliminar);
            EstilosUI.AplicarEstiloBotonSecundario(btnCancelar);

            // Todos con el mismo tamaño / margen
            EstilosUI.AplicarBotonesCrud(btnNuevo, btnGuardar, btnEliminar, btnCancelar);

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
                dgvClientes.Columns["IdCliente"].HeaderText = "ID";
                dgvClientes.Columns["Nombre"].HeaderText = "Nombre";
                dgvClientes.Columns["Telefono"].HeaderText = "Teléfono";
                dgvClientes.Columns["Email"].HeaderText = "Email";
                dgvClientes.Columns["Dni"].HeaderText = "DNI";
                dgvClientes.Columns["Direccion"].HeaderText = "Dirección";

                dgvClientes.Columns["IdCliente"].Width = 60;
            }
        }


        private void CargarClientes(string filtroNombre = "")
        {
            try
            {
                List<Cliente> lista = ClienteDAO.ObtenerTodos(filtroNombre);

                dgvClientes.DataSource = null;
                dgvClientes.DataSource = lista;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Cliente c = dgvClientes.CurrentRow.DataBoundItem as Cliente;

                if (c != null)
                {
                    txtIdCliente.Text = c.IdCliente.ToString();
                    txtNombre.Text = c.Nombre;
                    txtTelefono.Text = c.Telefono;
                    txtEmail.Text = c.Email;
                    txtDni.Text = c.Dni;
                    txtDireccion.Text = c.Direccion;
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

            Cliente c = new Cliente();
            c.Nombre = nombre;
            c.Telefono = telefono;
            c.Email = email;
            c.Dni = dni;
            c.Direccion = direccion;

            bool ok = false;

            try
            {
                if (txtIdCliente.Text == "")
                {
                    ok = ClienteDAO.Insertar(c);
                }
                else
                {
                    c.IdCliente = Convert.ToInt32(txtIdCliente.Text);
                    ok = ClienteDAO.Actualizar(c);
                }

                if (ok)
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

            int id = Convert.ToInt32(txtIdCliente.Text);

            try
            {
                bool ok = ClienteDAO.Eliminar(id);

                if (ok)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar el cliente:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
