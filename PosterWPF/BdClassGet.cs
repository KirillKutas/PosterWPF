using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosterWPF
{
    class BdClassGet
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Poster;Integrated Security=True";


        public void GetAllUsers(List<string> Mail = null, List<string> Name = null, List<string> Password = null, List<int> Id = null)
        {
            string sqlExpression = "SelectAllUsers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    while (reader.Read())
                    {
                        if (Id != null)
                            Id.Add(reader.GetInt32(0));
                        if (Mail != null)
                            Mail.Add(reader.GetString(1));
                        if (Name != null)
                            Name.Add(reader.GetString(2));
                        if (Password != null)
                            Password.Add(reader.GetString(3));
                    }
                }
                reader.Close();
            }
        }

        public void GetAllFilms(List<int> Id, List<string> Name, List<string> DescriptionAndActors, List<byte[]> Photo, List<string> Genre, List<string> Country, List<string> Duration)
        {
            string sqlExpression = "SelectAllFilms";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Id.Add(reader.GetInt32(0));
                        Name.Add(reader.GetString(1));
                        DescriptionAndActors.Add(reader.GetString(2));
                        Photo.Add(reader.GetValue(3) as byte[]);
                        Genre.Add(reader.GetString(4));
                        Country.Add(reader.GetString(5));
                        Duration.Add(reader.GetString(6));
                    }
                }
                reader.Close();
            }
        }
    }
}
