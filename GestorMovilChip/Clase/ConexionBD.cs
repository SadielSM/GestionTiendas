using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GestorMovilChip.Clase
{
    internal class ConexionBD
    {
        //Clase de conexion a la base de datos
        private static string servidor = "localhost";
        private static string puerto = "3306";
        private static string baseDatos = "tienda_moviles";
        private static string usuario = "root";
        private static string contraseña = "root";

        private static string cadenaConexion =
            "Server=" + servidor +
            ";Port=" + puerto +
            ";Database=" + baseDatos +
            ";Uid=" + usuario +
            ";Pwd=" + contraseña + ";";

        // Método que devuelve una conexión lista para usar
        public static MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
