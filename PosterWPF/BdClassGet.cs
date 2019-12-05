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

        public void GetAllFilms(List<int> Id = null, List<string> Name = null, List<string> DescriptionAndActors = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Country = null, List<string> Duration = null)
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
                        if (Id != null)
                            Id.Add(reader.GetInt32(0));
                        if (Name != null)
                            Name.Add(reader.GetString(1));
                        if (DescriptionAndActors != null)
                            DescriptionAndActors.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(3) as byte[]);
                        if (Genre != null)
                            Genre.Add(reader.GetString(4));
                        if (Country != null)
                            Country.Add(reader.GetString(5));
                        if (Duration != null)
                            Duration.Add(reader.GetString(6));
                    }
                }
                reader.Close();
            }
        }

        public void GetAllCinemas(List<int> Id = null, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SelectAllCinemas";
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
                        if (Name != null)
                            Name.Add(reader.GetString(1));
                        if (Address != null)
                            Address.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(3) as byte[]);
                    }
                }
                reader.Close();
            }
        }
        
        public void GetAllMIC(List<int> Id, List<DateTime> Date, List<string> FilmName, List<string> CinemaName, List<int> Price, List<string> Time, List<int> FreeSpaces, List<int> ReservedSpaces)
        {
            string sqlExpression = "SelectAllMIC";
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
                        Date.Add(reader.GetDateTime(1));
                        FilmName.Add(reader.GetString(2));
                        CinemaName.Add(reader.GetString(3));
                        Price.Add(reader.GetInt32(4));
                        Time.Add(reader.GetString(5));
                        FreeSpaces.Add(reader.GetInt32(6));
                        ReservedSpaces.Add(reader.GetInt32(7));
                    }
                }
                reader.Close();
            }
        }

        public void GetAllDates(List<int> Id, List<DateTime> Date)
        {
            string sqlExpression = "SelectAllDates";
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
                        Date.Add(reader.GetDateTime(1));
                    }
                }
                reader.Close();
            }
        }
    }
}
