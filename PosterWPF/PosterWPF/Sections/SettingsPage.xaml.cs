using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (User.Name != null)
            {
                if (User.Name == "Admin")
                {
                    Button ApplicationManagement = new Button();
                    ApplicationManagement.Content = "Application management";
                    ApplicationManagement.Background = Brushes.White;
                    ApplicationManagement.Height = 50;
                    ApplicationManagement.Width = 494;
                    ApplicationManagement.BorderThickness = new Thickness(0, 0, 0, 2);
                    ApplicationManagement.FontSize = 24;
                    ApplicationManagement.Click += ApplicationManagement_Click;
                    MainStack.Children.Add(ApplicationManagement);

                    Button ExportToXML = new Button();
                    ExportToXML.Content = "Export to XML";
                    ExportToXML.Background = Brushes.White;
                    ExportToXML.Height = 50;
                    ExportToXML.Width = 494;
                    ExportToXML.BorderThickness = new Thickness(0, 0, 0, 2);
                    ExportToXML.FontSize = 24;
                    ExportToXML.Click += ExportToXML_Click;
                    MainStack.Children.Add(ExportToXML);

                    Button ImportFromXML = new Button();
                    ImportFromXML.Content = "Import from XML";
                    ImportFromXML.Background = Brushes.White;
                    //ImportFromXML.Style = (Style)ApplicationManagement.FindResource("ButtonsStyle1");
                    ImportFromXML.Height = 50;
                    ImportFromXML.Width = 494;
                    ImportFromXML.BorderThickness = new Thickness(0, 0, 0, 2);
                    ImportFromXML.FontSize = 24;
                    ImportFromXML.Click += ImportFromXML_Click;
                    MainStack.Children.Add(ImportFromXML);
                }


                Button LogOut = new Button();
                LogOut.Content = "Log out";
                LogOut.Background = Brushes.White;
                LogOut.Height = 50;
                LogOut.Width = 494;
                LogOut.BorderThickness = new Thickness(0, 0, 0, 2);
                LogOut.FontSize = 24;
                LogOut.Click += LogOut_Click;

                MainStack.Children.Add(LogOut);
            }
            else
            {
                Button SignIn = new Button();
                SignIn.Content = "Sign In";
                SignIn.Background = Brushes.White;
                SignIn.Height = 50;
                SignIn.Width = 494;
                SignIn.BorderThickness = new Thickness(0, 0, 0, 2);
                SignIn.FontSize = 24;
                SignIn.Click += SignIn_Click;

                MainStack.Children.Add(SignIn);
            }
        }

        private void ImportFromXML_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AfishaEvent;Integrated Security=True";
            try
            {
                string sqlExpression = "ImportFromXML";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    var result = command.ExecuteScalar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportToXML_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=AfishaEvent;Integrated Security=True";
            try
            {
                string sqlExpression = "ExportToXML";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter PathParameter = new SqlParameter("@path", @"D:\XMLAfishaEvent\");

                    command.Parameters.Add(PathParameter);

                    var result = command.ExecuteScalar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplicationManagement_Click(object sender, RoutedEventArgs e)
        {
            var appM = new AppManagement();
            appM.Show();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage1.Children.Clear();
            SettingsPage1.Children.Add(new SignInForm());
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            User.Name = null;
            MainStack.Children.Clear();
            Button SignIn = new Button();
            SignIn.Content = "Sign In";
            SignIn.Background = Brushes.White;
            //SignIn.Style = (Style)SignIn.FindResource("ButtonsStyle1");
            SignIn.Height = 50;
            SignIn.Width = 494;
            SignIn.BorderThickness = new Thickness(0, 0, 0, 2);
            SignIn.FontSize = 24;
            SignIn.Click += SignIn_Click;
            MainStack.Children.Add(SignIn);

            FileInfo fileInf = new FileInfo("CurrentUser.dat");
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }

    }
}
