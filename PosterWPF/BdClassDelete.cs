﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PosterWPF
{
    class BdClassDelete
    {
        private string connectionString = @"Data Source=.;Initial Catalog=Poster;Integrated Security=True";

        public void DeleteFilms(int Id)
        {
            try
            {
                string sqlExpression = "DeleteFilmsById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteCinema(int Id)
        {
            try
            {
                string sqlExpression = "DeleteCinemasById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteMIC(int Id)
        {
            try
            {
                string sqlExpression = "DeleteMICById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteDate(int Id)
        {
            try
            {
                string sqlExpression = "DeleteCalendarById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void DeleteUser(int Id)
        {
            try
            {
                string sqlExpression = "DeleteUserById";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@deleteId", Id);

                    command.Parameters.Add(IdParameter);


                    var result = command.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
