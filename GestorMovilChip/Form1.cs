using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestorMovilChip
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
         
            // Ajusta estos valores a tu entorno
            string servidor = "localhost";
            string puerto = "3306";
            string bd = "tienda_moviles";
            string usuario = "root";
            string contraseña = "root";

            string cadenaConexion =
                "Server=" + servidor +
                ";Port=" + puerto +
                ";Database=" + bd +
                ";Uid=" + usuario +
                ";Pwd=" + contraseña + ";";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();
                    MessageBox.Show("Conexión correcta a la base de datos.", "OK",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
