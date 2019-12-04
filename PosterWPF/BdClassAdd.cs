using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PosterWPF
{
    class BdClassAdd
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Poster;Integrated Security=True";

        public bool AddUser(int Id, string Mail, string Name, string Password)
        {
            try
            {
                string sqlExpression = "AddUser";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@newId", Id);
                    SqlParameter MailParameter = new SqlParameter("@newMail", Mail);
                    SqlParameter NameParameter = new SqlParameter("@newName", Name);
                    SqlParameter PasswordParameter = new SqlParameter("@newPassword", Password);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(MailParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PasswordParameter);

                    var result = command.ExecuteScalar();
                   
                }
                return true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
           
        }

        public void AddFilm(int Id, string Name, string DescriptionsAndActors, byte[] Photo, string Genre, string Country, string Duration)
        {
            try
            {
                string sqlExpression = "AddFilm";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@newId", Id);
                    SqlParameter NameParameter = new SqlParameter("@newName", Name);
                    SqlParameter DescriptionsAndActorsParameter = new SqlParameter("@newDescriptionAndActors", DescriptionsAndActors);
                    SqlParameter PhotoParameter = new SqlParameter("@newPhoto", Photo);
                    SqlParameter GenreParameter = new SqlParameter("@newGenre", Genre);
                    SqlParameter CountryParameter = new SqlParameter("@newCountry", Country);
                    SqlParameter DurationParameter = new SqlParameter("@newDuration", Duration);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DescriptionsAndActorsParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PhotoParameter);
                    command.Parameters.Add(GenreParameter);
                    command.Parameters.Add(CountryParameter);
                    command.Parameters.Add(DurationParameter);

                    var result = command.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void AddCinema(int Id, string Name, string Address, byte[] Photo)
        {
            string sqlExpression = "AddCinema";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter IdParameter = new SqlParameter("@newId", Id);
                SqlParameter NameParameter = new SqlParameter("@newName", Name);
                SqlParameter AddressParameter = new SqlParameter("@newAddress", Address);
                SqlParameter PhotoParameter = new SqlParameter("@newPhoto", Photo);

                command.Parameters.Add(IdParameter);
                command.Parameters.Add(AddressParameter);
                command.Parameters.Add(NameParameter);
                command.Parameters.Add(PhotoParameter);

                var result = command.ExecuteNonQuery();
            }
        }
    }
}
