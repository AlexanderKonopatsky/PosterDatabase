using PosterWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PosterWPF.Sections
{
    public partial class AppManagement : Window
    {
        private string ImageSource { get; set; }
        private byte[] imageByte { get; set; }

        void ChangeGrid(Grid grid)
        {
            for (int i = 1; i < MainGrid.Children.Count; i++)
            {
                MainGrid.Children[i].Visibility = Visibility.Hidden;
            }
            grid.Visibility = Visibility.Visible;
        }

        void refreshFilmsBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> DescriptionAndActors = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Country = new List<string>();
            List<string> Duration = new List<string>();

            bdClassGet.GetAllFilms(Id, Name, DescriptionAndActors, Photo, Genre, Country, Duration);

            List<FilmsClass> filmsClasses = new List<FilmsClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                filmsClasses.Add(new FilmsClass(Id[iterator], Name[iterator], DescriptionAndActors[iterator], Photo[iterator], Genre[iterator], Country[iterator], Duration[iterator]));
            }

            FilmsBdFrid.ItemsSource = filmsClasses;
        }
        void refreshCinemasBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();

            bdClassGet.GetAllCinemas(Id, Name, Address, Photo);

            List<CinemasClass> cinemasClasses = new List<CinemasClass>();
            for(int iterator = 0; iterator < Id.Count; iterator++)
            {
                cinemasClasses.Add(new CinemasClass(Id[iterator], Name[iterator], Address[iterator], Photo[iterator]));
            }

            CinemasBdFrid.ItemsSource = cinemasClasses;
        }

        void refreshMICBdGrid()
        {
            List<int> Id = new List<int>();
            List<DateTime> Date = new List<DateTime>();
            List<string> FilmName = new List<string>();
            List<string> CinemaName = new List<string>();
            List<int> Price = new List<int>();
            List<string> Time = new List<string>();
            List<int> FreeSpaces = new List<int>();
            List<int> ReservedSpaces = new List<int>();

            bdClassGet.GetAllMIC(Id, Date, FilmName, CinemaName, Price, Time, FreeSpaces, ReservedSpaces);

            List<MICClass> mICClasses = new List<MICClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                mICClasses.Add(new MICClass(Id[iterator], Date[iterator], FilmName[iterator], CinemaName[iterator], Price[iterator], Time[iterator], FreeSpaces[iterator], ReservedSpaces[iterator]));
            }

            MICBdFrid.ItemsSource = mICClasses;

            List<string> filmIdName = new List<string>();
            List<string> cinemaIdName = new List<string>();
            bdClassGet.GetAllFilms(Name: filmIdName);
            bdClassGet.GetAllCinemas(Name: cinemaIdName);

            FilmIdName.Items.Clear();
            CinemaIdName.Items.Clear();
            foreach(var item in filmIdName)
            {
                FilmIdName.Items.Add(item);
            }
            foreach(var item in cinemaIdName)
            {
                CinemaIdName.Items.Add(item);
            }
        }

        void refreshCalendarBdGrid()
        {
            List<int> Id = new List<int>();
            List<DateTime> Date = new List<DateTime>();

            bdClassGet.GetAllDates(Id, Date);

            List<CalendarClass> caledarClasses = new List<CalendarClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                caledarClasses.Add(new CalendarClass(Id[iterator], Date[iterator]));
            }

            CalendarBdFrid.ItemsSource = caledarClasses;
        }

        void refreshUsersBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Mail = new List<string>();
            List<string> Name = new List<string>();
            List<byte[]> Password = new List<byte[]>();

            bdClassGet.GetAllUsers(Mail, Name, Password, Id);

            List<UsersClass> usersClasses = new List<UsersClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                usersClasses.Add(new UsersClass(Id[iterator], Mail[iterator], Name[iterator], Password[iterator].ToString()));
            }

            UsersBdGrid.ItemsSource = usersClasses;
        }
        void refreshBKBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> UserMail = new List<string>();
            List<string> Film = new List<string>();
            List<DateTime> Date = new List<DateTime>();

            bdClassGet.GetAllBK(Id, UserMail, Film, Date);
            List<BMClass> bKClasses = new List<BMClass>();
            for(int iterator = 0; iterator<Id.Count; iterator++)
            {
                bKClasses.Add(new BMClass(Id[iterator], UserMail[iterator], Film[iterator], Date[iterator]));
            }
            BookedMoviesBdGrid.ItemsSource = bKClasses;

            List<string> Films = new List<string>();
            List<string> UsersMail = new List<string>();
            bdClassGet.GetAllFilms(Name: Films);
            bdClassGet.GetAllUsers(Mail: UsersMail);

            BMIdName.Items.Clear();
            BMUserIdName.Items.Clear();
            foreach (var item in Films)
            {
                BMIdName.Items.Add(item);
            }
            foreach (var item in UsersMail)
            {
                BMUserIdName.Items.Add(item);
            }
        }
        void refreshConcertsBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Description = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Time = new List<string>();

            bdClassGet.GetAllConcerts(Id, Name, Description, Photo, Genre, Time);

            List<ConcertsClass> concertsClasses = new List<ConcertsClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                concertsClasses.Add(new ConcertsClass(Id[iterator], Name[iterator], Description[iterator], Time[iterator], Photo[iterator], Genre[iterator]));
            }

            ConcertsBdGrid.ItemsSource = concertsClasses;
        }

        void refreshConcertHallsBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();

            bdClassGet.GetAllConcertHalls(Id, Name, Address, Photo);

            List<ConcertHallsClass> concertHallsClasses = new List<ConcertHallsClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                concertHallsClasses.Add(new ConcertHallsClass(Id[iterator], Name[iterator], Address[iterator], Photo[iterator]));
            }

            ConcertHallsBdGrid.ItemsSource = concertHallsClasses;
        }

        void refreshCICHBdGrid()
        {
            List<int> Id = new List<int>();
            List<DateTime> Date = new List<DateTime>();
            List<string> ConcertsName = new List<string>();
            List<string> ConcertHallsName = new List<string>();
            List<int> Price = new List<int>();
            List<int> FreeSpaces = new List<int>();
            List<int> ReservedSpaces = new List<int>();

            bdClassGet.GetAllCICH(Id, Date, ConcertsName, ConcertHallsName, Price, FreeSpaces, ReservedSpaces);

            List<CICHClass> cICHClasses = new List<CICHClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                cICHClasses.Add(new CICHClass(Id[iterator], Date[iterator], ConcertsName[iterator], ConcertHallsName[iterator], Price[iterator], FreeSpaces[iterator], ReservedSpaces[iterator]));
            }

            CICHBdGrid.ItemsSource = cICHClasses;

            List<string> concertsIdName = new List<string>();
            List<string> concertHallsIdName = new List<string>();
            bdClassGet.GetAllConcerts(Name: concertsIdName);
            bdClassGet.GetAllConcertHalls(Name: concertHallsIdName);

            ConcertsIdName.Items.Clear();
            ConcertHallsIdName.Items.Clear();
            foreach (var item in concertsIdName)
            {
                ConcertsIdName.Items.Add(item);
            }
            foreach (var item in concertHallsIdName)
            {
                ConcertHallsIdName.Items.Add(item);
            }
        }

        
        void refreshBCBdGrid()
        {
            List<int> Id = new List<int>();
            List<string> UserMail = new List<string>();
            List<string> Concert = new List<string>();
            List<DateTime> Date = new List<DateTime>();

            bdClassGet.GetAllBC(Id, UserMail, Concert, Date);
            List<BCClass> bCClasses = new List<BCClass>();
            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                bCClasses.Add(new BCClass(Id[iterator], UserMail[iterator], Concert[iterator], Date[iterator]));
            }
            BCBdGrid.ItemsSource = bCClasses;

            List<string> Concerts = new List<string>();
            List<string> UsersMail = new List<string>();
            bdClassGet.GetAllConcerts(Name: Concerts);
            bdClassGet.GetAllUsers(Mail: UsersMail);

            BCIdName.Items.Clear();
            BCUserIdName.Items.Clear();
            foreach (var item in Concerts)
            {
                BCIdName.Items.Add(item);
            }
            foreach (var item in UsersMail)
            {
                BCUserIdName.Items.Add(item);
            }
        }

        void ImageToBD(ref byte[] imagecode)
        {
            FileStream fs = new FileStream(ImageSource, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imagecode = br.ReadBytes((Int32)fs.Length);
        }
    }
}
