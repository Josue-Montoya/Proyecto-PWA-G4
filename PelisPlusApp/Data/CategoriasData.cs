using System.Data.SqlClient;
using System.Data;
using PelisPlusApp.Models;

namespace PelisPlusApp.Data
{
    public class CategoriasData
    {
        string connectionString = "Data Source=DESKTOP-FUJM22V\\U20210157;Initial Catalog=PelisPlus;Integrated Security=True;Encrypt=False;";

        public IEnumerable<CategoriasModel> GetAllsCategorias()
        {
            List<CategoriasModel> categoriaList = new List<CategoriasModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Categorias";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CategoriasModel categoriaModel = new CategoriasModel();
                            categoriaModel.Id_categoria = Convert.ToInt32(reader["id_categoria"]);
                            categoriaModel.Nombre_categoria = reader["nombre_categoria"].ToString();
                            categoriaModel.Descripcion_categoria = reader["descripcion_categoria"].ToString();
                            categoriaModel.Restriccion_edad_categoria = reader["restriccion_edad_categoria"].ToString();
                            categoriaModel.Nota_categoria = reader["nota_categoria"].ToString();

                            categoriaList.Add(categoriaModel);
                        }
                    }
                }
            }

            return categoriaList;
        }

        public void Añadir_Categorias(CategoriasModel categoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Categorias 
                                            VALUES (@nombre, @descripcion, @restriccion, @nota)";

                    command.Parameters.AddWithValue("@nombre", categoria.Nombre_categoria);
                    command.Parameters.AddWithValue("@descripcion", categoria.Descripcion_categoria);
                    command.Parameters.AddWithValue("@restriccion", categoria.Restriccion_edad_categoria);
                    command.Parameters.AddWithValue("@nota", categoria.Nota_categoria);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Editar_Categorias(CategoriasModel categoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Categorias
                                            SET 	nombre_categoria = @nombre,
	                                                descripcion_categoria = @descripcion,
	                                                restriccion_edad_categoria = @restriccion,
	                                                nota_categoria = @nota
                                                    WHERE id_categoria = @id";

                    command.Parameters.AddWithValue("@nombre", categoria.Nombre_categoria);
                    command.Parameters.AddWithValue("@descripcion", categoria.Descripcion_categoria);
                    command.Parameters.AddWithValue("@restriccion", categoria.Restriccion_edad_categoria);
                    command.Parameters.AddWithValue("@nota", categoria.Nota_categoria);
                    command.Parameters.AddWithValue("@id", categoria.Id_categoria);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Eliminar_Categorias(CategoriasModel categoria)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Categorias WHERE id_categoria = @id";

                    command.Parameters.AddWithValue("@id", categoria.Id_categoria);

                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
