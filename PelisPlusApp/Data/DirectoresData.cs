using PelisPlusApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace PelisPlusApp.Data
{
    public class DirectoresData
    {
        string connectionString = "Data Source=DESKTOP-FUJM22V\\U20210157;Initial Catalog=PelisPlus;Integrated Security=True;Encrypt=False;";

        public IEnumerable<DirectoresModel> GetAllDirectores()
        {
            List<DirectoresModel> directoresList = new List<DirectoresModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT Id, Nombre, Apellido, Nacionalidad, Premios FROM Directores;";
                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DirectoresModel directoresModel = new DirectoresModel();
                            directoresModel.Id = Convert.ToInt32(reader["Id"]);
                            directoresModel.Nombre = reader["Nombre"].ToString();
                            directoresModel.Apellido = reader["Apellido"].ToString();
                            directoresModel.Nacionalidad = reader["Nacionalidad"].ToString();
                            directoresModel.Premios = Convert.ToInt32(reader["Premios"]);


                            directoresList.Add(directoresModel);
                        }
                    }
                }
            }

            return directoresList;
        }

        public DirectoresModel? GetById(int id)
        {
            DirectoresModel directoresModel = new DirectoresModel();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"SELECT Id, Nombre, Apellido, Nacionalidad, Premios FROM Directores
                                            WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            directoresModel.Id = Convert.ToInt32(reader["Id"]);
                            directoresModel.Nombre = reader["Nombre"].ToString();
                            directoresModel.Apellido = reader["Apellido"].ToString();
                            directoresModel.Nacionalidad = reader["Nacionalidad"].ToString();
                            directoresModel.Premios = Convert.ToInt32(reader["Premios"]);

                        }
                    }
                }
            }

            return directoresModel;
        }

        public void Add(DirectoresModel directores)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Directores 
                                           VALUES(@Nombre, @Apellido, @Nacionalidad, @Premios)";

                    command.Parameters.AddWithValue("@Nombre", directores.Nombre);
                    command.Parameters.AddWithValue("@Apellido", directores.Apellido);
                    command.Parameters.AddWithValue("@Nacionalidad", directores.Nacionalidad);
                    command.Parameters.AddWithValue("@Premios", directores.Premios);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Edit(DirectoresModel directores)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Directores 
                                           SET  Nombre = @Nombre,
                                           Apellido = @Apellido,
                                           Nacionalidad = @Nacionalidad,
                                           Premios = @Premios
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Nombre", directores.Nombre);
                    command.Parameters.AddWithValue("@Apellido", directores.Apellido);
                    command.Parameters.AddWithValue("@Nacionalidad", directores.Nacionalidad);
                    command.Parameters.AddWithValue("@Premios", directores.Premios);
                    command.Parameters.AddWithValue("@Id", directores.Id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Directores
                                           WHERE Id = @Id";

                    command.Parameters.AddWithValue("@Id", id);

                    command.CommandType = CommandType.Text;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
