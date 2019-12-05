﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PosterWPF
{
    class BdClassUpdate
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Poster;Integrated Security=True";

        public void UpdateFilm(int Id, string Name, string DescriptionsAndActors, byte[] Photo, string Genre, string Country, string Duration)
        {
            try
            {
                string sqlExpression = "ChangeFilm";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
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

        public void UpdateCinemas(int Id, string Name, string Address, byte[] Photo)
        {
            try
            {
                string sqlExpression = "ChangeCinema";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateMIC(int Id, DateTime Date, string FilmName, string CinemaName, int Price, string Time, int FreeSpaces, int ReservedSpaces)
        {
            try
            {
                string sqlExpression = "AddMIC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmNameParameter = new SqlParameter("@newFilmsName", FilmName);
                    SqlParameter CinemaNameParameter = new SqlParameter("@newCinemasName", CinemaName);
                    SqlParameter PriceParameter = new SqlParameter("@newPrice", Price);
                    SqlParameter TimeParameter = new SqlParameter("@newTime", Time);
                    SqlParameter FreeSpacesParameter = new SqlParameter("@newFreeSpaces", FreeSpaces);
                    SqlParameter ReservedSpacesParameter = new SqlParameter("@newReservedSpaces", ReservedSpaces);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmNameParameter);
                    command.Parameters.Add(CinemaNameParameter);
                    command.Parameters.Add(PriceParameter);
                    command.Parameters.Add(TimeParameter);
                    command.Parameters.Add(FreeSpacesParameter);
                    command.Parameters.Add(ReservedSpacesParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateDate(int Id, DateTime Date)
        {
            try
            {
                string sqlExpression = "ChangeCalendar";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateUser(int Id, string Mail, string Name, string Password)
        {
            try
            {
                string sqlExpression = "ChangeUser";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newMail", Mail);
                    SqlParameter NameParameter = new SqlParameter("@newName", Name);
                    SqlParameter PasswordParameter = new SqlParameter("@newPassword", Password);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PasswordParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
