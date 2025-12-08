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
    public static class VentaDAO
    {
        // Inserta la venta + detalles y actualiza stock en UNA transacción
        public static int InsertarVentaConDetalles(Venta venta, List<DetalleVenta> detalles)
        {
            if (detalles == null || detalles.Count == 0)
                throw new Exception("La venta debe tener al menos un detalle.");

            int idVentaGenerada = 0;

            MySqlConnection conexion = ConexionBD.ObtenerConexion();
            MySqlTransaction transaccion = null;

            try
            {
                conexion.Open();
                transaccion = conexion.BeginTransaction();

                // 1) Insertar en ventas
                string sqlVenta = "INSERT INTO ventas (fecha, id_cliente, id_usuario, total) " +
                                  "VALUES (@fecha, @id_cliente, @id_usuario, @total)";

                MySqlCommand cmdVenta = new MySqlCommand(sqlVenta, conexion, transaccion);
                cmdVenta.Parameters.AddWithValue("@fecha", venta.Fecha);

                object idCliente = DBNull.Value;
                if (venta.IdCliente.HasValue)
                    idCliente = venta.IdCliente.Value;

                cmdVenta.Parameters.AddWithValue("@id_cliente", idCliente);
                cmdVenta.Parameters.AddWithValue("@id_usuario", venta.IdUsuario);
                cmdVenta.Parameters.AddWithValue("@total", venta.Total);

                cmdVenta.ExecuteNonQuery();
                idVentaGenerada = (int)cmdVenta.LastInsertedId;

                // 2) Insertar detalles + actualizar stock
                foreach (DetalleVenta d in detalles)
                {
                    // detalle_venta
                    string sqlDetalle = "INSERT INTO detalle_venta " +
                                        "(id_venta, id_producto, cantidad, precio_unitario, subtotal) " +
                                        "VALUES (@id_venta, @id_producto, @cantidad, @precio_unitario, @subtotal)";

                    MySqlCommand cmdDetalle = new MySqlCommand(sqlDetalle, conexion, transaccion);
                    cmdDetalle.Parameters.AddWithValue("@id_venta", idVentaGenerada);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", d.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio_unitario", d.PrecioUnitario);
                    cmdDetalle.Parameters.AddWithValue("@subtotal", d.Subtotal);
                    cmdDetalle.ExecuteNonQuery();

                    // actualizar stock
                    string sqlStock = "UPDATE productos " +
                                      "SET stock = stock - @cantidad " +
                                      "WHERE id_producto = @id_producto";

                    MySqlCommand cmdStock = new MySqlCommand(sqlStock, conexion, transaccion);
                    cmdStock.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    cmdStock.Parameters.AddWithValue("@id_producto", d.IdProducto);
                    cmdStock.ExecuteNonQuery();
                }

                // 3) Confirmar
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                if (transaccion != null)
                    transaccion.Rollback();

                throw new Exception("Error al guardar la venta completa", ex);
            }
            finally
            {
                conexion.Close();
            }

            return idVentaGenerada;
        }

        // Listado de ventas (para FormListadoVentas)
        public static List<Venta> ObtenerVentas()
        {
            List<Venta> lista = new List<Venta>();
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT v.id_venta, v.fecha, " +
                             "IFNULL(c.nombre, '(Sin cliente)') AS cliente, " +
                             "u.nombre AS usuario, v.total " +
                             "FROM ventas v " +
                             "LEFT JOIN clientes c ON v.id_cliente = c.id_cliente " +
                             "INNER JOIN usuarios u ON v.id_usuario = u.id_usuario " +
                             "ORDER BY v.fecha DESC";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Venta v = new Venta();
                    v.IdVenta = reader.GetInt32("id_venta");
                    v.Fecha = reader.GetDateTime("fecha");
                    v.NombreCliente = reader.GetString("cliente");
                    v.NombreUsuario = reader.GetString("usuario");
                    v.Total = reader.GetDecimal("total");

                    lista.Add(v);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener ventas", ex);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }

        // Detalle de una venta
        public static List<DetalleVenta> ObtenerDetalleVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            MySqlConnection conexion = ConexionBD.ObtenerConexion();

            try
            {
                conexion.Open();

                string sql = "SELECT dv.id_detalle, dv.id_producto, p.nombre, " +
                             "dv.cantidad, dv.precio_unitario, dv.subtotal " +
                             "FROM detalle_venta dv " +
                             "INNER JOIN productos p ON dv.id_producto = p.id_producto " +
                             "WHERE dv.id_venta = @id_venta";

                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@id_venta", idVenta);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DetalleVenta d = new DetalleVenta();
                    d.IdDetalle = reader.GetInt32("id_detalle");
                    d.IdVenta = idVenta;
                    d.IdProducto = reader.GetInt32("id_producto");
                    d.NombreProducto = reader.GetString("nombre");
                    d.Cantidad = reader.GetInt32("cantidad");
                    d.PrecioUnitario = reader.GetDecimal("precio_unitario");
                    d.Subtotal = reader.GetDecimal("subtotal");

                    lista.Add(d);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener detalle de venta", ex);
            }
            finally
            {
                conexion.Close();
            }

            return lista;
        }
    }
}
