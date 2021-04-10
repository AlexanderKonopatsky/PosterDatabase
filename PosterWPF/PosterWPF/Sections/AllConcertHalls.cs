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
    partial class AllConcertHalls
    {
        public delegate void ClickGrid(GridConcertHalls gridConcertHalls);
        public event ClickGrid EventClickGrid;
        BdClassGet bdClassGet = new BdClassGet();
        List<int> Id = new List<int>();
        new List<string> Name = new List<string>();
        List<string> Address = new List<string>();
        List<byte[]> Photo = new List<byte[]>();

        public void OutputElements()
        {

            bdClassGet.GetAllConcertHallsByDate(User.Date,Id, Name, Address, Photo);
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
                grid.Height = 150;
                grid.MouseDown += Grid_MouseDown;

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
        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Grid grid = (Grid)sender;
            int id = Convert.ToInt32(grid.Name.Substring(3));
            for (int a = 0; a < Name.Count; a++)
            {
                if (Id[a] == id)
                {
                    EventClickGrid?.Invoke(new GridConcertHalls(Id[a],Name[a],Photo[a]));
                    EventClickGrid += MainWindow.EventClickGrid;
                }
            }  
        }
    }
}
