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
    /// Логика взаимодействия для GridConcerts.xaml
    /// </summary>
    public partial class GridConcerts : UserControl
    {
        public delegate void ClickGrid(UserControl concertsPage);
        public event ClickGrid EventOpenFilm;
        BdClassGet get = new BdClassGet();
        BdClassUpdate classUpdate = new BdClassUpdate();
        string a;
        int rf = 1;
        List<int> IdC = new List<int>();
        List<string> NameC = new List<string>();
        List<string> AddressC = new List<string>();
        List<byte[]> PhotoC = new List<byte[]>();
        List<int> PriceC = new List<int>();
        List<int> FreeSpaces = new List<int>();
        List<int> ReservedSpaces = new List<int>();
        public GridConcerts()
        {
            InitializeComponent();
        }
        public GridConcerts(int Id, string Name, string Genre, string Description, byte[] Photo, string a = null)
        {
            InitializeComponent();
            this.a = a;
            ConcertName.Content = Name;
            this.Genre.Content = Genre;
            if (File.Exists(Description))
                ActorsAndDescriptions.Text = File.ReadAllText(Description);
            else
                ActorsAndDescriptions.Text = "Missing description file";
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.StreamSource = new MemoryStream(Photo);
            image.EndInit();

            FilmImage.Source = image;
            get.GetAllConcertHallsByIdConcert(Id, User.Date, NameC, AddressC, PhotoC, PriceC, FreeSpaces, ReservedSpaces, IdC);
        }

        private void MainGridConcert_Loaded(object sender, RoutedEventArgs e)
        {
            for (int a = 0; a < NameC.Count; a++)
            {
                Border border = new Border();
                border.Background = Brushes.WhiteSmoke;
                border.BorderThickness = new Thickness(1);
                border.Height = 4;

                Grid grid = new Grid();
                grid.Name = "Id_"; // имя потом брать из названия фильма
                grid.Height = 120;

                ConcertHall.Children.Add(border);
                ConcertHall.Children.Add(grid);

                Label CinemaName = new Label();
                CinemaName.Content = "ConcertHall: " + NameC[a]; // из бд
                CinemaName.Margin = new Thickness(28, 15, 0, 0);
                CinemaName.FontFamily = new FontFamily("Times New Roman");
                CinemaName.FontSize = 21;
                CinemaName.FontWeight = FontWeights.Bold;
                CinemaName.HorizontalAlignment = HorizontalAlignment.Left;
                CinemaName.VerticalAlignment = VerticalAlignment.Top;
                CinemaName.Width = 250;

                Label Address = new Label();
                Address.Content = "Address: " + AddressC[a]; // из бд
                Address.Margin = new Thickness(28, 45, 0, 0);
                Address.FontFamily = new FontFamily("Times New Roman");
                Address.FontSize = 16;
                Address.HorizontalAlignment = HorizontalAlignment.Left;
                Address.VerticalAlignment = VerticalAlignment.Top;
                Address.Width = 250;

                if (User.Name != null)
                {
                    Button Buy = new Button();
                    Buy.Name = "Id_" + IdC[a];
                    Buy.Margin = new Thickness(300, 0, 0, 0);
                    Buy.Height = 35;
                    Buy.Width = 80;
                    Buy.Style = (Style)Buy.FindResource("BuyButtonStyle");
                    Buy.Click += Buy_Click;

                    Label FR = new Label();
                    FR.Margin = new Thickness(360, 40, 0, 0);
                    FR.Content = FreeSpaces[a].ToString() + "/" + ReservedSpaces[a].ToString();
                    FR.Height = 25;

                    TextBox textBlock = new TextBox();
                    textBlock.Margin = new Thickness(180, 5, 0, 0);
                    textBlock.Height = 20;
                    textBlock.Width = 20;
                    textBlock.Text = rf.ToString();
                    textBlock.LostFocus += TextBlock_LostFocus;
                    grid.Children.Add(Buy);
                    grid.Children.Add(FR);
                    grid.Children.Add(textBlock);
                }

                

                grid.Children.Add(CinemaName);
                grid.Children.Add(Address);

            }

            if (a != null)
            {
                EventOpenFilm?.Invoke(new SearchPage());
                EventOpenFilm += MainWindow.OpenFilm;
                EventOpenFilm(new SearchPage());
            }
            else
            {
                EventOpenFilm?.Invoke(new ConcertsPage());
                EventOpenFilm += MainWindow.OpenFilm;
                EventOpenFilm(new ConcertsPage());
            }
            
        }
        private void TextBlock_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox textBlock = (TextBox)sender;
                rf = Convert.ToInt32(textBlock.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Convert.ToInt32(button.Name.Substring(3));
            classUpdate.BuyConcerts(id, rf, User.Name, User.Date);
        }
    }
}
