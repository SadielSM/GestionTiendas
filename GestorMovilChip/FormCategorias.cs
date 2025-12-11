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
    public partial class FormCategorias : Form
    {
        public FormCategorias()
        {
            InitializeComponent();

            EstilosUI.AplicarEstiloFormularioOscuro(this);

            EstilosUI.AplicarEstiloDataGridView(dgvCategorias);
            dgvCategorias.BackgroundColor = EstilosUI.ColorFondoOscuro;
            splitCategorias.Panel1.BackColor = EstilosUI.ColorFondoOscuro;

            Color fondoClaro = Color.FromArgb(245, 245, 245);

            grpDatosCategoria.BackColor = fondoClaro;
            tblDatosCategoria.BackColor = fondoClaro;
            panelBotonesCat.BackColor = fondoClaro;

            Font fuenteLabels = new Font("Segoe UI", 9F, FontStyle.Regular);
            Font fuenteInputs = new Font("Segoe UI", 9F, FontStyle.Regular);

            Label[] labels =
            {
             lblID,
             lblNombre,
             lblDescripcion
             };

            foreach (Label lbl in labels)
            {
                lbl.ForeColor = EstilosUI.ColorTextoOscuro;
                lbl.Font = fuenteLabels;
            }

            grpDatosCategoria.ForeColor = EstilosUI.ColorTextoOscuro;
            grpDatosCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            TextBox[] cajas =
            {
              txtId,
             txtNombre,
             txtDescripcion
             };

            foreach (TextBox t in cajas)
            {
                t.BackColor = Color.White;
                t.ForeColor = EstilosUI.ColorTextoOscuro;
                t.BorderStyle = BorderStyle.FixedSingle;
                t.Font = fuenteInputs;
            }

            EstilosUI.AplicarEstiloBoton(btnNuevo);
            EstilosUI.AplicarEstiloBoton(btnGuardar);
            EstilosUI.AplicarEstiloBotonSecundario(btnEliminar);
            EstilosUI.AplicarEstiloBotonSecundario(btnCancelar);

            foreach (Control c in tableLayoutPanel1.Controls)
            {
                c.Margin = new Padding(5, 5, 5, 5);
                c.Width = 95;   
                c.Height = 32;
            }

            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
                dgvCategorias.Columns["IdCategoria"].HeaderText = "ID";
                dgvCategorias.Columns["Nombre"].HeaderText = "Nombre";
                dgvCategorias.Columns["Descripcion"].HeaderText = "Descripción";

                dgvCategorias.Columns["IdCategoria"].Width = 60;
            }
        }


        private void CargarCategorias()
        {
            try
            {
                List<Categoria> lista = CategoriaDAO.ObtenerTodas();

                dgvCategorias.DataSource = null;
                dgvCategorias.DataSource = lista;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar categorías:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                Categoria cat = dgvCategorias.CurrentRow.DataBoundItem as Categoria;

                if (cat != null)
                {
                    txtId.Text = cat.IdCategoria.ToString();
                    txtNombre.Text = cat.Nombre;
                    txtDescripcion.Text = cat.Descripcion;
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

            if (nombre == "")
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Categoria cat = new Categoria();
            cat.Nombre = nombre;
            cat.Descripcion = descripcion;

            bool ok = false;

            try
            {
                if (txtId.Text == "")
                {
                    // INSERT
                    ok = CategoriaDAO.Insertar(cat);
                }
                else
                {
                    // UPDATE
                    cat.IdCategoria = Convert.ToInt32(txtId.Text);
                    ok = CategoriaDAO.Actualizar(cat);
                }

                if (ok)
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

            int id = Convert.ToInt32(txtId.Text);

            try
            {
                bool ok = CategoriaDAO.Eliminar(id);

                if (ok)
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
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la categoría:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
    

}
}
