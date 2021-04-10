using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PosterWPF
{
    class BdClassGet
    {
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AfishaEvent;Integrated Security=True";


        public void GetAllUsers(List<string> Mail = null, List<string> Name = null, List<byte[]> Password = null, List<int> Id = null)
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
                            Password.Add(reader.GetValue(3) as byte[]);
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

        public void SearchFilms(string searchString, List<int> Id = null, List<string> Name = null, List<string> DescriptionAndActors = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Country = null, List<string> Duration = null)
        {
            string sqlExpression = "SearchFilms";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@searchString", searchString);
                command.Parameters.Add(SearchParameter);
                var result = command.ExecuteNonQuery();
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


        public void GetAllFilmsByDate(DateTime date, List<int>Id = null, List<string> Name = null, List<string> DescriptionAndActors = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Country = null, List<string> Duration = null)
        {
            string sqlExpression = "SelectAllFilmsByDate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
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
        public void GetAllCinemasByIdFilm(int Id, DateTime date, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null, List<int> Price = null, List<string> Time = null, List<int> FreeSpaces = null, List<int> ReservedSpaces = null, List<int> IdC = null)
        {
            string sqlExpression = "GetCinemasByFilmId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@FilmId", Id);
                command.Parameters.Add(SearchParameter);
                SqlParameter SeaParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(SeaParameter);
                var result = command.ExecuteNonQuery();
                
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Address != null)
                            Address.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(2) as byte[]);
                        if (Price != null)
                            Price.Add(reader.GetInt32(3));
                        if (Time != null)
                            Time.Add(reader.GetString(4));
                        if (ReservedSpaces != null)
                            ReservedSpaces.Add(reader.GetInt32(5));
                        if (FreeSpaces != null)
                            FreeSpaces.Add(reader.GetInt32(6));
                        if (IdC != null)
                            IdC.Add(reader.GetInt32(7));
                    }
                }
                reader.Close();
            }
        }
        public void GetAllConcertHallsByIdConcert(int Id, DateTime date, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null, List<int> Price = null, List<int> FreeSpaces = null, List<int> ReservedSpaces = null, List<int> IdC = null)
        {
            string sqlExpression = "GetConcertHallsByConcertId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@ConcertId", Id);
                command.Parameters.Add(SearchParameter);
                SqlParameter SeaParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(SeaParameter);
                var result = command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Address != null)
                            Address.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(2) as byte[]);
                        if (Price != null)
                            Price.Add(reader.GetInt32(3));
                        if (ReservedSpaces != null)
                            ReservedSpaces.Add(reader.GetInt32(4));
                        if (FreeSpaces != null)
                            FreeSpaces.Add(reader.GetInt32(5));
                        if (IdC != null)
                            IdC.Add(reader.GetInt32(6));
                    }
                }
                reader.Close();
            }
        }
        public void GetCinemasByFilmsId(int Id, DateTime date, List<string> Name = null, List<string> Genre = null, List<byte[]> Photo = null, List<int> Price = null, List<int> FreeSpaces = null, List<int> ReservedSpaces = null, List<int> IdC = null, List<string> NameFilm = null)
        {
            string sqlExpression = "GetFilmsByCinemaId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@CinemaId", Id);
                SqlParameter SeaParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(SearchParameter);
                command.Parameters.Add(SeaParameter);
                var result = command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Genre != null)
                            Genre.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(2) as byte[]);
                        if (Price != null)
                            Price.Add(reader.GetInt32(3));
                        if (ReservedSpaces != null)
                            ReservedSpaces.Add(reader.GetInt32(4));
                        if (FreeSpaces != null)
                            FreeSpaces.Add(reader.GetInt32(5));
                        if (IdC != null)
                            IdC.Add(reader.GetInt32(6));
                        if (NameFilm != null)
                            NameFilm.Add(reader.GetString(7));
                    }
                }
                reader.Close();
            }
        }
        public void GetConcertsByConcertHallsId(int Id, DateTime date, List<string> Name = null,List<string> Time = null, List<string> Genre = null, List<byte[]> Photo = null, List<int> Price = null, List<int> FreeSpaces = null, List<int> ReservedSpaces = null, List<int> IdC = null)
        {
            string sqlExpression = "GetConcertsByConcertHallsId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@ConcertHallsId", Id);
                command.Parameters.Add(SearchParameter);
                SqlParameter SeaParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(SeaParameter);
                var result = command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Genre != null)
                            Genre.Add(reader.GetString(1));
                        Time.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(3) as byte[]);
                        if (Price != null)
                            Price.Add(reader.GetInt32(4));
                        if (ReservedSpaces != null)
                            ReservedSpaces.Add(reader.GetInt32(5));
                        if (FreeSpaces != null)
                            FreeSpaces.Add(reader.GetInt32(6));
                        if (IdC != null)
                            IdC.Add(reader.GetInt32(7));
                    }
                }
                reader.Close();
            }
        }
        public void GetEByECId(int Id, DateTime date, List<string> Name = null, List<string> Time = null, List<string> Genre = null, List<byte[]> Photo = null, List<int> Price = null, List<int> FreeSpaces = null, List<int> ReservedSpaces = null, List<int> IdC = null)
        {
            string sqlExpression = "GetEByECId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@ECId", Id);
                command.Parameters.Add(SearchParameter);
                SqlParameter SeaParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(SeaParameter);
                var result = command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Genre != null)
                            Genre.Add(reader.GetString(1));
                        Time.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(3) as byte[]);
                        if (Price != null)
                            Price.Add(reader.GetInt32(4));
                        if (ReservedSpaces != null)
                            ReservedSpaces.Add(reader.GetInt32(5));
                        if (FreeSpaces != null)
                            FreeSpaces.Add(reader.GetInt32(6));
                        if (IdC != null)
                            IdC.Add(reader.GetInt32(7));
                    }
                }
                reader.Close();
            }
        }
       

        public void SearchCinemas(string searchString, List<int> Id = null, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SearchCinemas";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter SearchParameter = new SqlParameter("@searchString", searchString);
                command.Parameters.Add(SearchParameter);
                var result = command.ExecuteNonQuery();
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
        public void GetAllCinemasByDate(DateTime date,List<int> Id, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SelectAllCinemasByDate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Address != null)
                            Address.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(2) as byte[]);
                        Id.Add(reader.GetInt32(3));
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

        public void GetAllBK(List<int> Id, List<string> UserMail, List<string> Film, List<DateTime> Date)
        {
            string sqlExpression = "SelectAllBM";
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
                        UserMail.Add(reader.GetString(1));
                        Film.Add(reader.GetString(2));
                        Date.Add(reader.GetDateTime(3));
                    }
                }
                reader.Close();
            }
        }

        public void GetAllConcerts(List<int> Id = null, List<string> Name = null, List<string> Description = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Time = null)
        {
            string sqlExpression = "SelectAllConcerts";
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
                        if (Description != null)
                            Description.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(4) as byte[]);
                        if (Genre != null)
                            Genre.Add(reader.GetString(5));
                        if (Time != null)
                            Time.Add(reader.GetString(3));

                    }
                }
                reader.Close();
            }
        }
        public void GetAllConcertsByDate(DateTime date, List<int> Id, List<string> Name = null, List<string> Description = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Time = null)
        {
            string sqlExpression = "SelectAllConcertsByDate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Description != null)
                            Description.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(3) as byte[]);
                        if (Genre != null)
                            Genre.Add(reader.GetString(4));
                        if (Time != null)
                            Time.Add(reader.GetString(2));
                        Id.Add(reader.GetInt32(5));

                    }
                }
                reader.Close();
            }
        }
        public void SearchConcerts(string searchString, List<int> Id, List<string> Name = null, List<string> Description = null, List<byte[]> Photo = null, List<string> Genre = null, List<string> Time = null)
        {
            string sqlExpression = "SearchConcerts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@searchString", searchString);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Id.Add(reader.GetInt32(0));
                        if (Name != null)
                            Name.Add(reader.GetString(1));
                        if (Description != null)
                            Description.Add(reader.GetString(2));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(4) as byte[]);
                        if (Genre != null)
                            Genre.Add(reader.GetString(5));
                        if (Time != null)
                            Time.Add(reader.GetString(3));

                    }
                }
                reader.Close();
            }
        }

        public void GetAllConcertHalls(List<int> Id = null, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SelectAllConcertHalls";
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
        public void GetAllConcertHallsByDate(DateTime date,List<int> Id, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SelectAllConcertHallsByDate";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@currentDate", date);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (Name != null)
                            Name.Add(reader.GetString(0));
                        if (Address != null)
                            Address.Add(reader.GetString(1));
                        if (Photo != null)
                            Photo.Add(reader.GetValue(2) as byte[]);
                        Id.Add(reader.GetInt32(3));
                    }
                }
                reader.Close();
            }
        }
        public void SearchConcertHalls(string searchString,List<int> Id, List<string> Name = null, List<string> Address = null, List<byte[]> Photo = null)
        {
            string sqlExpression = "SearchConcertHalls";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter DateParameter = new SqlParameter("@searchString", searchString);
                command.Parameters.Add(DateParameter);
                var result = command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
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

        public void GetAllCICH(List<int> Id, List<DateTime> Date, List<string> ConcertsName, List<string> ConcertHallsName, List<int> Price, List<int> FreeSpaces, List<int> ReservedSpaces)
        {
            string sqlExpression = "SelectAllCICH";
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
                        ConcertsName.Add(reader.GetString(2));
                        ConcertHallsName.Add(reader.GetString(3));
                        Price.Add(reader.GetInt32(4));
                        FreeSpaces.Add(reader.GetInt32(5));
                        ReservedSpaces.Add(reader.GetInt32(6));
                    }
                }
                reader.Close();
            }
        }
       

        public void GetAllBC(List<int> Id, List<string> UserMail, List<string> Concerts, List<DateTime> Date)
        {
            string sqlExpression = "SelectAllBC";
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
                        UserMail.Add(reader.GetString(1));
                        Concerts.Add(reader.GetString(2));
                        Date.Add(reader.GetDateTime(3));
                    }
                }
                reader.Close();
            }
        }
      
        public bool auth(string Mail, string Password)
        {
            try
            {
                string sqlExpression = "auth";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter Pass = new SqlParameter("@Pass", Password);
                    SqlParameter mail = new SqlParameter("@Mail", Mail);
                    SqlParameter Boolpar = new SqlParameter
                    {
                        ParameterName = "@out",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output // параметр выходной
                    };

                    command.Parameters.Add(Pass);
                    command.Parameters.Add(mail);
                    command.Parameters.Add(Boolpar);

                    var result = command.ExecuteNonQuery();
                    if ((int)Boolpar.Value != 1)
                    {
                        return false;
                        throw new Exception("Invalid user or password");
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
