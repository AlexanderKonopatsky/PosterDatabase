using Microsoft.Extensions.DependencyInjection;
using PosterWPF.Properties;
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
    /// Логика взаимодействия для SignInForm.xaml
    /// </summary>
    public partial class SignInForm : UserControl
    {
        public delegate void ClickGrid(SettingsPage settingsPage);
        public event ClickGrid EventOpenSettings;

      

        public SignInForm()
        {
            InitializeComponent();
        }

        private void MainSignInForm_Loaded(object sender, RoutedEventArgs e)
        {
            EventOpenSettings?.Invoke(new SettingsPage());
            EventOpenSettings += MainWindow.OpenFilm;
            EventOpenSettings(new SettingsPage());
        }

        private void LoginOrEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Email.Text == "")
            {
                Email.Foreground = Brushes.Gainsboro;
                Email.Text = "E-mail";
            }      
        }

        private void LoginOrEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            Email.Text = "";
            Email.Foreground = Brushes.Black;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            BdClassGet bdClass = new BdClassGet();

            if(bdClass.auth(Email.Text, UserPassword.Password))
            {
                User.Name = Email.Text;
                EventOpenSettings?.Invoke(new SettingsPage());
                EventOpenSettings += MainWindow.EventClickGrid;
                EventOpenSettings(new SettingsPage());
            }
        }

        //private void Vk_Click(object sender, RoutedEventArgs e)
        //{
        //    var VkLogin = new VkLogin();
        //    VkLogin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        //    VkLogin.ShowDialog();
        //}

        private void ForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your password has been sent to your email");
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            var signUp = new SignUp();
            signUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            signUp.ShowDialog();
        }
    }
}
