using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using PosterWPF.Sections;

namespace PosterWPF
{
    partial class MainWindow
    {
        private FilmsPage filmsPage = new FilmsPage();
        private CalendarPage calendarPage = new CalendarPage(LinkToMainWindow);
        private UserControl BackToFilms;

        private void MoveMenu(double x1, double x2)
        {
            var animation = new ThicknessAnimation();
            animation.From = new Thickness(x1, 10.091, 0, 0);
            animation.To = new Thickness(x2, 10.091, 0, 0);
            animation.SpeedRatio = 2;
            Menu.BeginAnimation(MarginProperty, animation);
        }

        private void SetGridChildren(Grid grid, UIElement page)
        {
            grid.Children.Clear();
            grid.Children.Add(page);
        }

        private void RenameSection(Button button)
        {
            Section.Content = button.Content;
        }

        public static void EventClickGrid(UserControl userControl)
        {
            LinkToMainWindow.SetGridChildren(LinkToMainWindow.MainBody, userControl);
        }
        public static void BackSetting(UserControl userControl)
        {
            LinkToMainWindow.BackToFilms = userControl;
        }

        public static void OpenFilm(UserControl userControl)
        {
            LinkToMainWindow.BackToFilms = userControl;
        }

    }
}
