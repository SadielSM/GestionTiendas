using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GestorMovilChip.Clase
{
    public static class EstilosUI
    {
        // Colores base (ajústalos a tu gusto)
        public static Color ColorFondoFormulario = Color.FromArgb(235, 239, 244);
        public static Color ColorPanel = Color.FromArgb(30, 30, 40);
        public static Color ColorPrincipal = Color.FromArgb(52, 152, 219);   // azul
        public static Color ColorTextoClaro = Color.White;
        public static Color ColorTextoOscuro = Color.FromArgb(40, 40, 40);
        public static Color ColorCard = Color.FromArgb(248, 249, 252); // blanco-gris suave
                                                                       // Tema oscuro
        public static Color ColorFondoOscuro = Color.FromArgb(24, 26, 38);      // fondo general
        public static Color ColorZonaOscura = Color.FromArgb(33, 37, 53);      // paneles / cards
        public static Color ColorInputOscuro = Color.FromArgb(45, 49, 66);     // textbox, combos



        public static void AplicarEstiloFormulario(Form f)
        {
            f.BackColor = ColorFondoFormulario;
            f.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void AplicarEstiloBoton(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = ColorPrincipal;
            b.ForeColor = ColorTextoClaro;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        public static void AplicarEstiloBotonSecundario(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Color.FromArgb(100, 100, 120);
            b.ForeColor = ColorTextoClaro;
            b.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            b.Cursor = Cursors.Hand;
        }

        public static void AplicarEstiloDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPanel;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = ColorTextoClaro;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 30;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = ColorTextoOscuro;
            dgv.DefaultCellStyle.SelectionBackColor = ColorPrincipal;
            dgv.DefaultCellStyle.SelectionForeColor = ColorTextoClaro;
            dgv.RowHeadersVisible = false;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 235, 235);
        }

        public static void AplicarEstiloLabelTitulo(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lbl.ForeColor = ColorTextoOscuro;
        }

        public static void AplicarEstiloBotonMenu(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = ColorPrincipal;
            b.ForeColor = ColorTextoClaro;
            b.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Padding = new Padding(15, 0, 0, 0);

            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185); // un pelín más oscuro
            b.FlatAppearance.MouseDownBackColor = Color.FromArgb(31, 97, 141);
        }


        public static void AplicarEstiloCard(Panel p)
        {
            p.BackColor = ColorCard;
            p.BorderStyle = BorderStyle.FixedSingle;
            p.Padding = new Padding(15);
        }



        public static void AplicarEstiloGroupBox(GroupBox g)
        {
            g.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            g.ForeColor = ColorTextoOscuro;
        }

        public static void AplicarTituloSeccion(Label lbl)
        {
            lbl.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lbl.ForeColor = ColorTextoOscuro;
        }


        //MODO OSCURO
        public static void AplicarEstiloFormularioOscuro(Form f)
        {
            f.BackColor = ColorFondoOscuro;
            f.StartPosition = FormStartPosition.CenterScreen;
            f.ForeColor = ColorTextoClaro;   // textos en blanco por defecto
        }

        public static void AplicarContenedorOscuro(Control c)
        {
            c.BackColor = ColorZonaOscura;
            c.ForeColor = ColorTextoClaro;
        }

        public static void AplicarInputOscuro(TextBox t)
        {
            t.BackColor = ColorInputOscuro;
            t.ForeColor = ColorTextoClaro;
            t.BorderStyle = BorderStyle.FixedSingle;
        }

        public static void AplicarComboOscuro(ComboBox c)
        {
            c.BackColor = ColorInputOscuro;
            c.ForeColor = ColorTextoClaro;
            c.FlatStyle = FlatStyle.Flat;
        }


        // === PANTALLA CRUD: FONDO OSCURO + DETALLE DERECHO CLARO ===
        public static void AplicarPantallaCrudOscuroConDetalleClaro(
            Form form,
            string textoTitulo,
            DataGridView dgv,
            SplitContainer splitContainer,
            GroupBox grpDatos,
            Panel panelBusqueda,
            TableLayoutPanel tblCampos,
            Panel panelBotones,
            Label lblBuscar,
            CheckBox chkActivo,
            TextBox[] cajasTexto,
            ComboBox comboCategoria,
            Button btnNuevo,
            Button btnGuardar,
            Button btnEliminar,
            Button btnCancelar
        )
        {
            // 1) Fondo oscuro general
            AplicarEstiloFormularioOscuro(form);

            // 3) Grid izquierdo oscuro
            AplicarEstiloDataGridView(dgv);
            dgv.BackgroundColor = ColorFondoOscuro;
            splitContainer.Panel1.BackColor = ColorFondoOscuro;

            // 4) Panel derecho claro
            Color fondoClaro = Color.FromArgb(245, 245, 245);

            grpDatos.BackColor = fondoClaro;
            panelBusqueda.BackColor = fondoClaro;
            tblCampos.BackColor = fondoClaro;
            panelBotones.BackColor = fondoClaro;

            form.BackColor = ColorFondoOscuro; // resto sigue oscuro

            grpDatos.ForeColor = ColorTextoOscuro;
            lblBuscar.ForeColor = ColorTextoOscuro;
            chkActivo.ForeColor = ColorTextoOscuro;

            // 5) Fuentes de la parte derecha
            Font fuenteLabels = new Font("Segoe UI", 9F, FontStyle.Regular);
            Font fuenteInputs = new Font("Segoe UI", 9F, FontStyle.Regular);

            grpDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBuscar.Font = fuenteLabels;
            chkActivo.Font = fuenteLabels;

            foreach (Control c in tblCampos.Controls)
            {
                if (c is Label lbl)
                {
                    lbl.ForeColor = ColorTextoOscuro;
                    lbl.Font = fuenteLabels;
                }
                else if (c is TextBox txt)
                {
                    txt.Font = fuenteInputs;
                }
                else if (c is ComboBox cmb)
                {
                    cmb.Font = fuenteInputs;
                }
            }

            // 6) TextBox en blanco
            foreach (TextBox t in cajasTexto)
            {
                t.BackColor = Color.White;
                t.ForeColor = ColorTextoOscuro;
                t.BorderStyle = BorderStyle.FixedSingle;
                t.Font = fuenteInputs;
            }

            // 7) Combo en claro
            comboCategoria.BackColor = Color.White;
            comboCategoria.ForeColor = ColorTextoOscuro;
            comboCategoria.FlatStyle = FlatStyle.Standard;
            comboCategoria.Font = fuenteInputs;

            // 8) Botones
            AplicarEstiloBoton(btnNuevo);
            AplicarEstiloBoton(btnGuardar);
            AplicarEstiloBotonSecundario(btnEliminar);
            AplicarEstiloBotonSecundario(btnCancelar);


        }

        public static void AplicarBotonesCrud(params Button[] botones)
        {
            foreach (var b in botones)
            {
                b.AutoSize = false;           // importante para que respeten Width/Height
                b.Width = 120;
                b.Height = 38;
                b.Margin = new Padding(6);    // separación entre botones
            }
        }




    }
}
