using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PosterWPF.Sections
{
    partial class AllConcerts
    {
        public delegate void ClickGrid(GridConcerts gridConcerts);
        public event ClickGrid EventClickGrid;
        private BdClassGet bdClassGet = new BdClassGet();
        List<int> Id = new List<int>();
        new List<string> Name = new List<string>();
        List<string> Description = new List<string>();
        List<byte[]> Photo = new List<byte[]>();
        List<string> Genre = new List<string>();
        List<string> Time = new List<string>();
        public void OutputElements()
        {
            

            bdClassGet.GetAllConcertsByDate(User.Date, Id, Name, Description, Photo, Genre, Time);
            MainStack.Children.Clear();
            if (Name.Count == 0)
            {
                Label err = new Label();
                err.Content = "The list of films is empty"; // имя взять из бд
                err.FontFamily = new FontFamily("Times New Roman");
                err.FontSize = 24;
                err.Width = 314;
                err.FontWeight = FontWeights.Bold;
                err.VerticalAlignment = VerticalAlignment.Top;
                err.HorizontalAlignment = HorizontalAlignment.Left;
                MainStack.Children.Add(err);
            }
            for (int iterator = 0; iterator < Name.Count; iterator++)
            {
                Grid grid = new Grid();
                grid.Name = "Id_" + Id[iterator]; // имя потом брать из названия фильма
                grid.Height = 178;
                grid.MouseDown += Grid_MouseDown;

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

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            int id = Convert.ToInt32(grid.Name.Substring(3));
            for (int a = 0; a < Name.Count; a++)
            {
                if (Id[a] == id)
                {
                    EventClickGrid?.Invoke(new GridConcerts(Id[a], Name[a], Genre[a], Description[a], Photo[a]));
                    EventClickGrid += MainWindow.EventClickGrid;
                }
            }
                
        }
    }
}
