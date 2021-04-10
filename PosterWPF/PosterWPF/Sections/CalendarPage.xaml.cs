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
    /// Логика взаимодействия для CalendarPage.xaml
    /// </summary>
    public partial class CalendarPage : UserControl
    {
        public DateTime? selectedDate;
        private MainWindow Main;
        public CalendarPage(MainWindow mainWindow)
        {
            InitializeComponent();
            Main = mainWindow;
        }

        private void CalendarPage2_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ChangeDate_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = ChangeDate.SelectedDate;
            ChangeDate.SelectedDate = selectedDate.Value.Date;
            User.Date = selectedDate.Value.Date;
            //switch (User.currentPage)
            //{
            //    //case "AllFilms":
            //    //    {
            //    //        //User.allFilms.ClearElements();
            //    //        User.allFilms.OutputElements();
            //    //        break;
            //    //    }
            //    //case "AllCinemas":
            //    //    {
            //    //        User.allCinemas.OutputElements();
            //    //        break;
            //    //    }
            //    //case "AllConcerts":
            //    //    {
            //    //        User.allConcerts.OutputElements();
            //    //        break;
            //    //    }
            //    //case "AllConcertHalls":
            //    //    {
            //    //        User.allConcertHalls.OutputElements();
            //    //        break;
            //    //    }
            //}
            
        }
    }
}
