using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using PelisPlusApp.Models;

namespace PelisPlusApp.Data
{
    public class PeliculasData
    {
        string connectionString = "Data Source=U20210476;Initial Catalog=PelisPlus;Integrated Security=True;Encrypt=False";

        public IEnumerable<PeliculasModel> GetAll()
        {
            List<PeliculasModel> peliculasList = new List<PeliculasModel>();
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using(var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "Select Id_pelicula, Titulo, Categoria, Sinopsis, Duracion, Director, Fecha_estreno From peliculas ";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PeliculasModel peliculasModel = new PeliculasModel();
                            peliculasModel.Id_pelicula = Convert.ToInt32(reader["Id_pelicula"]);
                            peliculasModel.Titulo = reader["Titulo"].ToString();
                            peliculasModel.Categoria = reader["Categoria"].ToString();
                            peliculasModel.Sinopsis = reader["Sinopsis"].ToString();
                            peliculasModel.Duracion = reader["Duracion"].ToString();
                            peliculasModel.Director = reader["Director"].ToString();
                            peliculasModel.Fecha_estreno = reader["Fecha_estreno"].ToString();

                            peliculasList.Add(peliculasModel);

                        }
                    }
                }
            }

            return peliculasList;
        }

        public void Insertar(PeliculasModel peliculas)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"Insert Into Peliculas
                                           Values(@Titulo, @Categoria, @Sinopsis, @Duracion, @Director, @Fecha_estreno)";

                    command.Parameters.AddWithValue("@Titulo", peliculas.Titulo);
                    command.Parameters.AddWithValue("@Categoria", peliculas.Categoria);
                    command.Parameters.AddWithValue("@Sinopsis", peliculas.Sinopsis);
                    command.Parameters.AddWithValue("@Duracion", peliculas.Duracion);
                    command.Parameters.AddWithValue("@Director", peliculas.Director);
                    command.Parameters.AddWithValue("@Fecha_estreno", peliculas.Fecha_estreno);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Editar(PeliculasModel peliculas)
        {
            using (var conncetion = new SqlConnection(connectionString))
            {
                conncetion.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conncetion;
                    command.CommandText = @"Update Peliculas 
                                            Set Titulo = @Titulo,
                                            Categoria = @Categoria,
                                            Sinopsis = @Sinopsis,
                                            Duracion = @Duracion,
                                            Director = @Director,
                                            Fecha_estreno = @Fecha_estreno
                                            Where Id_pelicula = @Id_pelicula";

                    command.Parameters.AddWithValue("@Titulo", peliculas.Titulo);
                    command.Parameters.AddWithValue("@Categoria", peliculas.Categoria);
                    command.Parameters.AddWithValue("@Sinopsis", peliculas.Sinopsis);
                    command.Parameters.AddWithValue("@Duracion", peliculas.Duracion);
                    command.Parameters.AddWithValue("@Director", peliculas.Director);
                    command.Parameters.AddWithValue("@Fecha_estreno", peliculas.Fecha_estreno);
                    command.Parameters.AddWithValue("@Id_pelicula", peliculas.Id_pelicula);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }                           
            }
        }

        public void Eliminar(int Id)
        {
            using (var conection  = new SqlConnection(connectionString))
            {
                conection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = conection;
                    command.CommandText = @"Delete From Peliculas
                                           Where Id_pelicula = @Id_pelicula";

                    command.Parameters.AddWithValue("@Id_pelicula", Id);
                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
 
    }
}
