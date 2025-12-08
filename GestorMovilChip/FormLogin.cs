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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
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


    }
}
