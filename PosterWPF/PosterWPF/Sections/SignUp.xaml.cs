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
using System.Windows.Shapes;

namespace PosterWPF.Sections
{
    /// <summary>
    /// Логика взаимодействия для SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public delegate void ClickGrid(SettingsPage settingsPage);
        public event ClickGrid EventOpenSettings;

        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            BdClassGet bdClassGet = new BdClassGet();
            BdClassAdd bdClassAdd = new BdClassAdd();

            List<string> EMail = new List<string>();

            bdClassGet.GetAllUsers(EMail);

            bool coincidences = EMail.Any(n => n == Mail.Text);
            if (coincidences)
            {
                MessageBox.Show("Such a user exists");
                Mail.Text = "";
                Name.Text = "";
                Pass.Password = "";
            }
            else
            {
                bdClassAdd.AddUser(EMail.Count + 1, Mail.Text, Name.Text, Pass.Password);
                MessageBox.Show("Registration was successful");
                User.Name = Name.Text;
                EventOpenSettings?.Invoke(new SettingsPage());
                EventOpenSettings += MainWindow.EventClickGrid;
                EventOpenSettings(new SettingsPage());
                Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Mail_GotFocus(object sender, RoutedEventArgs e)
        {
            Mail.Text = "";
            Mail.Foreground = Brushes.Black;
        }

        private void Mail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Mail.Text == "")
            {
                Mail.Foreground = Brushes.Gainsboro;
                Mail.Text = "E-mail";
            }
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
            Name.Foreground = Brushes.Black;
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Foreground = Brushes.Gainsboro;
                Name.Text = "E-mail";
            }
        }
    }
}
