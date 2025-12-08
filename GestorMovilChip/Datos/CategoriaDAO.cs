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
        public static class CategoriaDAO
        {
            public static List<Categoria> ObtenerTodas(string filtroNombre = "")
            {
                List<Categoria> lista = new List<Categoria>();

                MySqlConnection conexion = ConexionBD.ObtenerConexion();

                try
                {
                    conexion.Open();

                    string sql = "SELECT id_categoria, nombre, descripcion " +
                                 "FROM categorias";

                    if (filtroNombre != "")
                    {
                        sql += " WHERE nombre LIKE @filtro";
                    }

                    sql += " ORDER BY id_categoria";

                    MySqlCommand cmd = new MySqlCommand(sql, conexion);

                    if (filtroNombre != "")
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");
                    }

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Categoria c = new Categoria();
                        c.IdCategoria = reader.GetInt32("id_categoria");
                        c.Nombre = reader.GetString("nombre");
                        c.Descripcion = reader["descripcion"] == DBNull.Value
                            ? ""
                            : reader.GetString("descripcion");

                        lista.Add(c);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Aquí solo relanzamos; el form mostrará el mensaje
                    throw new Exception("Error al obtener categorías", ex);
                }
                finally
                {
                    conexion.Close();
                }

                return lista;
            }

            public static bool Insertar(Categoria categoria)
            {
                bool ok = false;

                MySqlConnection conexion = ConexionBD.ObtenerConexion();

                try
                {
                    conexion.Open();

                    string sql = "INSERT INTO categorias (nombre, descripcion) " +
                                 "VALUES (@nombre, @descripcion)";

                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        ok = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar categoría", ex);
                }
                finally
                {
                    conexion.Close();
                }

                return ok;
            }

            public static bool Actualizar(Categoria categoria)
            {
                bool ok = false;

                MySqlConnection conexion = ConexionBD.ObtenerConexion();

                try
                {
                    conexion.Open();

                    string sql = "UPDATE categorias SET " +
                                 "nombre = @nombre, descripcion = @descripcion " +
                                 "WHERE id_categoria = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@nombre", categoria.Nombre);
                    cmd.Parameters.AddWithValue("@descripcion", categoria.Descripcion);
                    cmd.Parameters.AddWithValue("@id", categoria.IdCategoria);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        ok = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar categoría", ex);
                }
                finally
                {
                    conexion.Close();
                }

                return ok;
            }

            public static bool Eliminar(int idCategoria)
            {
                bool ok = false;

                MySqlConnection conexion = ConexionBD.ObtenerConexion();

                try
                {
                    conexion.Open();

                    string sql = "DELETE FROM categorias WHERE id_categoria = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conexion);
                    cmd.Parameters.AddWithValue("@id", idCategoria);

                    int filas = cmd.ExecuteNonQuery();

                    if (filas > 0)
                    {
                        ok = true;
                    }
                }
                catch (MySqlException ex)
                {
                    // Por si tiene productos asociados, lanzamos la excepción
                    throw new Exception("No se puede eliminar la categoría (posibles productos asociados).", ex);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al eliminar categoría", ex);
                }
                finally
                {
                    conexion.Close();
                }

                return ok;
            }
        }
    }
