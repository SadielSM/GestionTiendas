using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestorMovilChip.Clase;
using MySql.Data.MySqlClient;

namespace GestorMovilChip
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();

            /*
            EstilosUI.AplicarEstiloFormulario(this);
            this.BackColor = EstilosUI.ColorPrincipal; // fondo azul
            */
            // EstilosUI.AplicarEstiloBoton(btnLogin);

            this.DoubleBuffered = true;               // para que no parpadee
            this.Paint += FormLogin_Paint;            // manejamos el evento Paint del formulario
           
        }

        //Método para el degradado 
        private void FormLogin_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = this.ClientRectangle;

            // Colores del degradado (puedes ajustarlos)
            Color colorArriba = Color.FromArgb(120, 180, 235);  // azul más claro
            Color colorAbajo = Color.FromArgb(40, 90, 160);    // azul más oscuro

            using (LinearGradientBrush brush = new LinearGradientBrush(
                       rect,
                       colorArriba,
                       colorAbajo,
                       LinearGradientMode.Vertical))            // vertical, de arriba a abajo
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (usuario == "" || contraseña == "")
            {
                lblMensaje.Text = "Introduce usuario y contraseña.";
                return;
            }

            // Calculamos el hash de la contraseña introducida
            string hashContraseña = Seguridad.CalcularHash(contraseña);

            MySqlConnection conexion = ConexionBD.ObtenerConexion();
            try
            {
                conexion.Open();

                string sql = "SELECT id_usuario, nombre, rol " +
                             "FROM usuarios " +
                             "WHERE usuario = @usuario AND contraseña = @contraseña " +
                             "LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contraseña", hashContraseña);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    int idUsuario = reader.GetInt32("id_usuario");
                    string nombre = reader.GetString("nombre");
                    string rol = reader.GetString("rol");

                    FormMenuPrincipal menu = new FormMenuPrincipal(idUsuario, nombre, rol);
                    menu.Show();
                    this.Hide();
                }
                else
                {
                    lblMensaje.Text = "Usuario o contraseña incorrectos.";
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexion.Close();
            }

        }

        private void linkOlvido_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Si has olvidado la contraseña, ponte en contacto con el administrador de la tienda para que te la restablezca.",
                "Contraseña olvidada",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }


        private void CentrarPanel()
        {
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            CentrarPanel();
        }

        private void FormLogin_Resize(object sender, EventArgs e)
        {
            CentrarPanel();
        }
    }
}
