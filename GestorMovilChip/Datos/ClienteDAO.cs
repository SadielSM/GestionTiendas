using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestorMovilChip.Clase;
using GestorMovilChip.Modelos;
using MySql.Data.MySqlClient;

namespace GestorMovilChip.Datos
{
    public static class ClienteDAO
    {
        public static List<Cliente> ObtenerTodos(string filtroNombre = "")
        {
            List<Cliente> lista = new List<Cliente>();
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_cliente, nombre, telefono, email, dni, direccion " +
                             "FROM clientes ";

                if (filtroNombre != "")
                    sql += " WHERE nombre LIKE @filtro";

                sql += " ORDER BY id_cliente,nombre asc";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                if (filtroNombre != "")
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente c = new Cliente();
                    c.IdCliente = reader.GetInt32("id_cliente");
                    c.Nombre = reader.GetString("nombre");
                    c.Telefono = reader["telefono"] == DBNull.Value ? "" : reader.GetString("telefono");
                    c.Email = reader["email"] == DBNull.Value ? "" : reader.GetString("email");
                    c.Dni = reader["dni"] == DBNull.Value ? "" : reader.GetString("dni");
                    c.Direccion = reader["direccion"] == DBNull.Value ? "" : reader.GetString("direccion");
                    lista.Add(c);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener clientes", ex);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public static bool Insertar(Cliente c)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "INSERT INTO clientes " +
                             "(nombre, telefono, email, dni, direccion) " +
                             "VALUES (@nombre, @telefono, @email, @dni, @direccion)";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@dni", c.Dni);
                cmd.Parameters.AddWithValue("@direccion", c.Direccion);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar cliente", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }

        public static bool Actualizar(Cliente c)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "UPDATE clientes SET " +
                             "nombre = @nombre, telefono = @telefono, " +
                             "email = @email, dni = @dni, direccion = @direccion " +
                             "WHERE id_cliente = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@email", c.Email);
                cmd.Parameters.AddWithValue("@dni", c.Dni);
                cmd.Parameters.AddWithValue("@direccion", c.Direccion);
                cmd.Parameters.AddWithValue("@id", c.IdCliente);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar cliente", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }

        public static bool Eliminar(int idCliente)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "DELETE FROM clientes WHERE id_cliente = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idCliente);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede eliminar el cliente (puede tener ventas).", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar cliente", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }
    }
}
