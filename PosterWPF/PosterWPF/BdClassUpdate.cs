using System;
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
        private string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AfishaEvent;Integrated Security=True";

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
                string sqlExpression = "ChangeMIC";
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

        public void UpdateBK(int Id, string UserMail, string Film, DateTime Date)
        {
            try
            {
                string sqlExpression = "ChangeBM";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmParameter = new SqlParameter("@newFilmsName", Film);
                    SqlParameter UserMailParameter = new SqlParameter("@newUserMail", UserMail);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmParameter);
                    command.Parameters.Add(UserMailParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateConcerts(int Id, string Name, string Description, string Time, byte[] Photo, string Genre)
        {
            try
            {
                string sqlExpression = "ChangeConcerts";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter NameParameter = new SqlParameter("@newName", Name);
                    SqlParameter DescriptionParameter = new SqlParameter("@newDescription", Description);
                    SqlParameter PhotoParameter = new SqlParameter("@newPhoto", Photo);
                    SqlParameter GenreParameter = new SqlParameter("@newGenre", Genre);
                    SqlParameter TimeParameter = new SqlParameter("@newTime", Time);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(DescriptionParameter);
                    command.Parameters.Add(PhotoParameter);
                    command.Parameters.Add(GenreParameter);
                    command.Parameters.Add(TimeParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateConcertHalls(int Id, string Name, string Address, byte[] Photo)
        {
            try
            {
                string sqlExpression = "ChangeConcertHalls";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateCICH(int Id, DateTime Date, string FilmName, string CinemaName, int Price, int FreeSpaces, int ReservedSpaces)
        {
            try
            {
                string sqlExpression = "ChangeCICH";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmNameParameter = new SqlParameter("@newConcertsName", FilmName);
                    SqlParameter CinemaNameParameter = new SqlParameter("@newConcertHallsName", CinemaName);
                    SqlParameter PriceParameter = new SqlParameter("@newPrice", Price);
                    SqlParameter FreeSpacesParameter = new SqlParameter("@newFreeSpaces", FreeSpaces);
                    SqlParameter ReservedSpacesParameter = new SqlParameter("@newReservedSpaces", ReservedSpaces);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmNameParameter);
                    command.Parameters.Add(CinemaNameParameter);
                    command.Parameters.Add(PriceParameter);
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
        public void UpdateEIEC(int Id, DateTime Date, string Exhibitions, string ExhibitionCenters, int Price, int FreeSpaces, int ReservedSpaces)
        {
            try
            {
                string sqlExpression = "ChangeEIEC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmNameParameter = new SqlParameter("@newExhibitionsName", Exhibitions);
                    SqlParameter CinemaNameParameter = new SqlParameter("@newExhibitionCentersName", ExhibitionCenters);
                    SqlParameter PriceParameter = new SqlParameter("@newPrice", Price);
                    SqlParameter FreeSpacesParameter = new SqlParameter("@newFreeSpaces", FreeSpaces);
                    SqlParameter ReservedSpacesParameter = new SqlParameter("@newReservedSpaces", ReservedSpaces);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmNameParameter);
                    command.Parameters.Add(CinemaNameParameter);
                    command.Parameters.Add(PriceParameter);
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
        public void UpdateBC(int Id, string UserMail, string Concerts, DateTime Date)
        {
            try
            {
                string sqlExpression = "ChangeBC";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmParameter = new SqlParameter("@newConcertsName", Concerts);
                    SqlParameter UserMailParameter = new SqlParameter("@newUserMail", UserMail);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmParameter);
                    command.Parameters.Add(UserMailParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateBE(int Id, string UserMail, string Exhibitions, DateTime Date)
        {
            try
            {
                string sqlExpression = "ChangeBE";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter DateParameter = new SqlParameter("@newDate", Date);
                    SqlParameter FilmParameter = new SqlParameter("@newExhibitionName", Exhibitions);
                    SqlParameter UserMailParameter = new SqlParameter("@newUserMail", UserMail);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(DateParameter);
                    command.Parameters.Add(FilmParameter);
                    command.Parameters.Add(UserMailParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateExhibitions(int Id, string Name, string Description, string Time, byte[] Photo, string Genre)
        {
            try
            {
                string sqlExpression = "ChangeExhibitions";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter IdParameter = new SqlParameter("@Id", Id);
                    SqlParameter NameParameter = new SqlParameter("@newName", Name);
                    SqlParameter DescriptionParameter = new SqlParameter("@newDescription", Description);
                    SqlParameter PhotoParameter = new SqlParameter("@newPhoto", Photo);
                    SqlParameter GenreParameter = new SqlParameter("@newGenre", Genre);
                    SqlParameter TimeParameter = new SqlParameter("@newTime", Time);


                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(DescriptionParameter);
                    command.Parameters.Add(PhotoParameter);
                    command.Parameters.Add(GenreParameter);
                    command.Parameters.Add(TimeParameter);

                    var result = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void UpdateExhibitionCenters(int Id, string Name, string Address, byte[] Photo)
        {
            try
            {
                string sqlExpression = "ChangeExhibitionCenters";
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyFilm(int id, int count, string user, DateTime date)
        {
            try
            {
                string sqlExpression = "BuyFilms";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //MessageBox.Show(id.ToString());

                    SqlParameter IdParameter = new SqlParameter("@Id", id);
                    SqlParameter NameParameter = new SqlParameter("@count", count);
                    SqlParameter AddressParameter = new SqlParameter("@User", user);
                    SqlParameter PhotoParameter = new SqlParameter("@Date", date);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(AddressParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PhotoParameter);

                    var result = command.ExecuteNonQuery();
                    MessageBox.Show("Request sent!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyConcerts(int id, int count, string user, DateTime date)
        {
            try
            {
                string sqlExpression = "BuyConcerts";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter IdParameter = new SqlParameter("@Id", id);
                    SqlParameter NameParameter = new SqlParameter("@count", count);
                    SqlParameter AddressParameter = new SqlParameter("@User", user);
                    SqlParameter PhotoParameter = new SqlParameter("@Date", date);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(AddressParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PhotoParameter);

                    var result = command.ExecuteNonQuery();

                    MessageBox.Show("Request sent!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BuyExhibitions(int id, int count, string user, DateTime date)
        {
            try
            {
                string sqlExpression = "BuyExhibitions";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    SqlParameter IdParameter = new SqlParameter("@Id", id);
                    SqlParameter NameParameter = new SqlParameter("@count", count);
                    SqlParameter AddressParameter = new SqlParameter("@User", user);
                    SqlParameter PhotoParameter = new SqlParameter("@Date", date);

                    command.Parameters.Add(IdParameter);
                    command.Parameters.Add(AddressParameter);
                    command.Parameters.Add(NameParameter);
                    command.Parameters.Add(PhotoParameter);

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
