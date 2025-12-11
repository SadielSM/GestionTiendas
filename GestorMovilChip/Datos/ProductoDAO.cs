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
    public static class ProductoDAO
    {
        public static List<Producto> ObtenerTodos(string filtroNombre = "")
        {
            List<Producto> lista = new List<Producto>();

            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT p.id_producto, p.nombre, p.descripcion, " +
                             "p.id_categoria, c.nombre AS categoria, " +
                             "p.precio_compra, p.precio_venta, p.stock, " +
                             "p.codigo_barras, p.activo " +
                             "FROM productos p " +
                             "INNER JOIN categorias c ON p.id_categoria = c.id_categoria";

                if (filtroNombre != "")
                {
                    sql += " WHERE p.nombre LIKE @filtro";
                }

                sql += " ORDER BY p.id_producto";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);

                if (filtroNombre != "")
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();
                    p.IdProducto = reader.GetInt32("id_producto");
                    p.Nombre = reader.GetString("nombre");
                    p.Descripcion = reader["descripcion"] == DBNull.Value ? "" : reader.GetString("descripcion");
                    p.IdCategoria = reader.GetInt32("id_categoria");
                    p.NombreCategoria = reader.GetString("categoria");
                    p.PrecioCompra = reader.GetDecimal("precio_compra");
                    p.PrecioVenta = reader.GetDecimal("precio_venta");
                    p.Stock = reader.GetInt32("stock");
                    p.CodigoBarras = reader["codigo_barras"] == DBNull.Value ? "" : reader.GetString("codigo_barras");
                    p.Activo = reader.GetInt32("activo") == 1;

                    lista.Add(p);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos", ex);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        public static bool Insertar(Producto p)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "INSERT INTO productos " +
                             "(nombre, descripcion, id_categoria, precio_compra, precio_venta, stock, codigo_barras, activo) " +
                             "VALUES (@nombre, @descripcion, @id_categoria, @precio_compra, @precio_venta, @stock, @codigo_barras, @activo)";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@id_categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@precio_compra", p.PrecioCompra);
                cmd.Parameters.AddWithValue("@precio_venta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@codigo_barras", p.CodigoBarras);
                cmd.Parameters.AddWithValue("@activo", p.Activo ? 1 : 0);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar producto", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }

        public static bool Actualizar(Producto p)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "UPDATE productos SET " +
                             "nombre = @nombre, descripcion = @descripcion, " +
                             "id_categoria = @id_categoria, precio_compra = @precio_compra, " +
                             "precio_venta = @precio_venta, stock = @stock, " +
                             "codigo_barras = @codigo_barras, activo = @activo " +
                             "WHERE id_producto = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@descripcion", p.Descripcion);
                cmd.Parameters.AddWithValue("@id_categoria", p.IdCategoria);
                cmd.Parameters.AddWithValue("@precio_compra", p.PrecioCompra);
                cmd.Parameters.AddWithValue("@precio_venta", p.PrecioVenta);
                cmd.Parameters.AddWithValue("@stock", p.Stock);
                cmd.Parameters.AddWithValue("@codigo_barras", p.CodigoBarras);
                cmd.Parameters.AddWithValue("@activo", p.Activo ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", p.IdProducto);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar producto", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }

        public static bool Eliminar(int idProducto)
        {
            bool ok = false;
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "DELETE FROM productos WHERE id_producto = @id";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id", idProducto);

                int filas = cmd.ExecuteNonQuery();
                if (filas > 0) ok = true;
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se puede eliminar el producto (puede estar en ventas).", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar producto", ex);
            }
            finally
            {
                conexion.Close();
            }

            return ok;
        }

        // Para ventas (productos activos)
        public static List<Producto> ObtenerActivosParaVenta()
        {
            List<Producto> lista = new List<Producto>();
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT id_producto, nombre, precio_venta, stock " +
                             "FROM productos " +
                             "WHERE activo = 1 " +
                             "ORDER BY nombre";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto p = new Producto();
                    p.IdProducto = reader.GetInt32("id_producto");
                    p.Nombre = reader.GetString("nombre");
                    p.PrecioVenta = reader.GetDecimal("precio_venta");
                    p.Stock = reader.GetInt32("stock"); 

                    lista.Add(p);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos activos para venta", ex);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

    }
}
