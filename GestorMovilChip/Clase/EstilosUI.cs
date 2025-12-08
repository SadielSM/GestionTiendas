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
        public static Color ColorFondoFormulario = Color.FromArgb(245, 245, 245);
        public static Color ColorPanel = Color.FromArgb(30, 30, 40);
        public static Color ColorPrincipal = Color.FromArgb(52, 152, 219);   // azul
        public static Color ColorTextoClaro = Color.White;
        public static Color ColorTextoOscuro = Color.FromArgb(40, 40, 40);

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
    }
}
