using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для SearchPage.xaml
    /// </summary>
    public partial class SearchPage : UserControl
    {
        public delegate void ClickGridFilm(GridFilm gridFilm);
        public event ClickGridFilm EventClickGridFilm;

        public delegate void ClickGridCinemas(GridCinema gridCinema);
        public event ClickGridCinemas EventClickGridCinemas;

        public delegate void ClickGridConcerts(GridConcerts gridCinema);
        public event ClickGridConcerts EventClickGridConcerts;

        public delegate void ClickGridConcertHalls(GridConcertHalls gridCinema);
        public event ClickGridConcertHalls EventClickGridConcertHalls;

        BdClassGet get = new BdClassGet();
        public SearchPage()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainStack.Children.Clear();
                film();
                Cinemas();
                Concerts();
                ConcertHalls();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        void film()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> DescriptionAndActors = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Country = new List<string>();
            List<string> Duration = new List<string>();
            get.SearchFilms(SearchString.Text, Id, Name, DescriptionAndActors, Photo, Genre, Country, Duration);
            if (Id.Count > 0)
            {
                Border border = new Border();
                border.Height = 30;
                border.Background = Brushes.WhiteSmoke;

                Label label = new Label();
                label.FontSize = 15;
                label.Content = "Films";

                border.Child = label;

                MainStack.Children.Add(border);
            }

            for (int iterator = 0; iterator < Id.Count; iterator++)
            {
                Grid grid = new Grid();
                grid.Name = "grid1"; // имя потом брать из названия фильма
                grid.Height = 178;
                grid.MouseDown += Grid_MouseDownFilm;

                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                MainStack.Children.Add(grid);
                MainStack.Children.Add(border);

                Image image = new Image();
                image.Height = 158;
                image.Width = 134;
                image.Margin = new Thickness(10, 10, 0, 0);
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = HorizontalAlignment.Left;

                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new MemoryStream(Photo[iterator]);
                img.EndInit();

                image.Source = img;
                grid.Children.Add(image);

                Label name = new Label();
                name.Content = Name[iterator]; // имя взять из бд
                name.Margin = new Thickness(170, 10, 0, 0);
                name.FontFamily = new FontFamily("Times New Roman");
                name.FontSize = 24;
                name.Width = 314;
                name.FontWeight = FontWeights.Bold;
                name.VerticalAlignment = VerticalAlignment.Top;
                name.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(name);


                Label genre = new Label();
                genre.Content = Genre[iterator]; // имя взять из бд
                genre.Margin = new Thickness(170, 50, 0, 0);
                genre.FontFamily = new FontFamily("Times New Roman");
                genre.FontSize = 18;
                genre.Width = 314;
                genre.VerticalAlignment = VerticalAlignment.Top;
                genre.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(genre);


                Label country = new Label();
                country.Content = Country[iterator]; // имя взять из бд
                country.Margin = new Thickness(170, 80, 0, 0);
                country.FontFamily = new FontFamily("Times New Roman");
                country.FontSize = 18;
                country.Width = 314;
                country.VerticalAlignment = VerticalAlignment.Top;
                country.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(country);
            }
        }
        void Grid_MouseDownFilm(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> DescriptionAndActors = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Country = new List<string>();
            List<string> Duration = new List<string>();
            get.SearchFilms(SearchString.Text, Id, Name, DescriptionAndActors, Photo, Genre, Country, Duration);
            Grid grid = (Grid)sender;
            for (int a = 0; a < Name.Count; a++)
            {
                if (Name[a] == grid.Name)
                {
                    EventClickGridFilm?.Invoke(new GridFilm( Id[a], Name[a], DescriptionAndActors[a], Photo[a], Genre[a], Country[a], Duration[a], ""));
                    EventClickGridFilm += MainWindow.EventClickGrid;
                }
            }
               
        }

        void Cinemas()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            get.SearchCinemas(SearchString.Text, Id, Name, Address, Photo);
            if (Id.Count > 0)
            {
                Border border = new Border();
                border.Height = 30;
                border.Background = Brushes.WhiteSmoke;

                Label label = new Label();
                label.FontSize = 15;
                label.Content = "Cinemas";

                border.Child = label;

                MainStack.Children.Add(border);
            }

            for (int iterator = 0; iterator < Name.Count; iterator++)
            {
                Grid grid = new Grid();
                grid.Name = "grid1"; // имя потом брать из названия фильма
                grid.Height = 150;
                grid.MouseDown += Grid_MouseDownCinemas;

                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                MainStack.Children.Add(grid);
                MainStack.Children.Add(border);

                Image image = new Image();
                image.Height = 120;
                image.Width = 134;
                image.Margin = new Thickness(328, 15, 0, 0);
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new MemoryStream(Photo[iterator]);
                img.EndInit();
                image.Source = img;
                grid.Children.Add(image);

                Label name = new Label();
                name.Content = Name[iterator]; // имя взять из бд
                name.Margin = new Thickness(10, 15, 0, 0);
                name.FontFamily = new FontFamily("Times New Roman");
                name.FontSize = 28;
                name.Width = 288;
                name.FontWeight = FontWeights.Bold;
                name.VerticalAlignment = VerticalAlignment.Top;
                name.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(name);


                Label address = new Label();
                address.Content = Address[iterator]; // имя взять из бд
                address.Margin = new Thickness(10, 65, 0, 0);
                address.FontFamily = new FontFamily("Times New Roman");
                address.FontSize = 18;
                address.Width = 288;
                address.VerticalAlignment = VerticalAlignment.Top;
                address.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(address);
            }
        }
        private void Grid_MouseDownCinemas(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            get.SearchCinemas(SearchString.Text, Id, Name, Address, Photo);
            Grid grid = (Grid)sender;
            for (int a = 0; a < Name.Count; a++)
            {
                if (Name[a] == grid.Name)
                {
                    EventClickGridCinemas?.Invoke(new GridCinema(Id[a],Name[a],Photo[a],""));
                    EventClickGridCinemas += MainWindow.EventClickGrid;
                }
            }   
        }
        void Concerts()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Description = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Time = new List<string>();
            get.SearchConcerts(SearchString.Text,Id, Name, Description, Photo, Genre, Time);
            if (Name.Count > 0)
            {
                Border border = new Border();
                border.Height = 30;
                border.Background = Brushes.WhiteSmoke;

                Label label = new Label();
                label.FontSize = 15;
                label.Content = "Concerts";

                border.Child = label;

                MainStack.Children.Add(border);
            }

            for (int iterator = 0; iterator < Name.Count; iterator++)
            {
                Grid grid = new Grid();
                grid.Name = "grid1"; // имя потом брать из названия фильма
                grid.Height = 178;
                grid.MouseDown += Grid_MouseDownConcerts;

                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                MainStack.Children.Add(grid);
                MainStack.Children.Add(border);

                Image image = new Image();
                image.Height = 158;
                image.Width = 134;
                image.Margin = new Thickness(10, 10, 0, 0);
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new MemoryStream(Photo[iterator]);
                img.EndInit();
                image.Source = img;
                grid.Children.Add(image);

                Label name = new Label();
                name.Content = Name[iterator]; // имя взять из бд
                name.Margin = new Thickness(170, 10, 0, 0);
                name.FontFamily = new FontFamily("Times New Roman");
                name.FontSize = 24;
                name.Width = 314;
                name.FontWeight = FontWeights.Bold;
                name.VerticalAlignment = VerticalAlignment.Top;
                name.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(name);


                Label genre = new Label();
                genre.Content = Genre[iterator]; // имя взять из бд
                genre.Margin = new Thickness(170, 50, 0, 0);
                genre.FontFamily = new FontFamily("Times New Roman");
                genre.FontSize = 18;
                genre.Width = 314;
                genre.VerticalAlignment = VerticalAlignment.Top;
                genre.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(genre);


                Label country = new Label();
                country.Content = Time[iterator]; // имя взять из бд
                country.Margin = new Thickness(170, 80, 0, 0);
                country.FontFamily = new FontFamily("Times New Roman");
                country.FontSize = 18;
                country.Width = 314;
                country.VerticalAlignment = VerticalAlignment.Top;
                country.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(country);
            }
        }
        private void Grid_MouseDownConcerts(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Description = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            List<string> Genre = new List<string>();
            List<string> Time = new List<string>();
            get.SearchConcerts(SearchString.Text,Id, Name, Description, Photo, Genre, Time);
            Grid grid = (Grid)sender;
            for (int a = 0; a < Name.Count; a++)
            {
                if (Name[a] == grid.Name)
                {
                    EventClickGridConcerts?.Invoke(new GridConcerts(Id[a],Name[a],Genre[a],Description[a],Photo[a],""));
                    EventClickGridConcerts += MainWindow.EventClickGrid;
                }
            }
                    
        }
        void ConcertHalls()
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            get.SearchConcertHalls(SearchString.Text,Id, Name, Address, Photo);
            if (Name.Count > 0)
            {
                Border border = new Border();
                border.Height = 30;
                border.Background = Brushes.WhiteSmoke;

                Label label = new Label();
                label.FontSize = 15;
                label.Content = "ConcertHalls";

                border.Child = label;

                MainStack.Children.Add(border);
            }
            for (int iterator = 0; iterator < Name.Count; iterator++)
            {
                Grid grid = new Grid();
                grid.Name = "grid1"; // имя потом брать из названия фильма
                grid.Height = 150;
                grid.MouseDown += Grid_MouseDownConcertHalls;

                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                MainStack.Children.Add(grid);
                MainStack.Children.Add(border);

                Image image = new Image();
                image.Height = 120;
                image.Width = 134;
                image.Margin = new Thickness(328, 15, 0, 0);
                image.VerticalAlignment = VerticalAlignment.Top;
                image.HorizontalAlignment = HorizontalAlignment.Left;
                BitmapImage img = new BitmapImage();
                img.BeginInit();
                img.StreamSource = new MemoryStream(Photo[iterator]);
                img.EndInit();
                image.Source = img;
                grid.Children.Add(image);

                Label name = new Label();
                name.Content = Name[iterator]; // имя взять из бд
                name.Margin = new Thickness(10, 15, 0, 0);
                name.FontFamily = new FontFamily("Times New Roman");
                name.FontSize = 28;
                name.Width = 288;
                name.FontWeight = FontWeights.Bold;
                name.VerticalAlignment = VerticalAlignment.Top;
                name.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(name);


                Label address = new Label();
                address.Content = Address[iterator]; // имя взять из бд
                address.Margin = new Thickness(10, 65, 0, 0);
                address.FontFamily = new FontFamily("Times New Roman");
                address.FontSize = 18;
                address.Width = 288;
                address.VerticalAlignment = VerticalAlignment.Top;
                address.HorizontalAlignment = HorizontalAlignment.Left;
                grid.Children.Add(address);
            }
        }
        private void Grid_MouseDownConcertHalls(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            List<int> Id = new List<int>();
            List<string> Name = new List<string>();
            List<string> Address = new List<string>();
            List<byte[]> Photo = new List<byte[]>();
            get.SearchConcertHalls(SearchString.Text,Id, Name, Address, Photo);
            Grid grid = (Grid)sender;
            for (int a = 0; a < Name.Count; a++)
            {
                if (Name[a] == grid.Name)
                {
                    EventClickGridConcertHalls?.Invoke(new GridConcertHalls(Id[a],Name[a],Photo[a],""));
                    EventClickGridConcertHalls += MainWindow.EventClickGrid;
                }
            }
                    
        }
       
        
    }
}
