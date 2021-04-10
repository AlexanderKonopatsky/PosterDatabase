using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ConcertsPage.xaml
    /// </summary>
    public partial class ConcertsPage : UserControl
    {
        public ConcertsPage()
        {
            InitializeComponent();
        }
        private void Concerts_Click(object sender, RoutedEventArgs e)
        {
            Concerts.BorderThickness = new Thickness(0, 0, 1, 3);
            ConcertHalls.BorderThickness = new Thickness(1, 0, 0, 0);
            Output.Children.Clear();
            User.allConcerts = new AllConcerts();
            User.currentPage = "AllConcerts";
            Output.Children.Add(User.allConcerts);
        }

        private void ConcertHalls_Click(object sender, RoutedEventArgs e)
        {
            Concerts.BorderThickness = new Thickness(0, 0, 1, 0);
            ConcertHalls.BorderThickness = new Thickness(1, 0, 0, 3);
            Output.Children.Clear();
            User.allConcertHalls = new AllConcertHalls();
            User.currentPage = "AllConcertHalls";
            Output.Children.Add(new AllConcertHalls());
        }


        private void MainConcertsPage_Loaded(object sender, RoutedEventArgs e)
        {
            Date.Content = DateTime.Today;
            User.allConcerts = new AllConcerts();
            User.currentPage = "AllConcerts";
            Output.Children.Add(User.allConcerts);
        }
    }
}
