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
    /// Логика взаимодействия для AllConcerts.xaml
    /// </summary>
    public partial class AllConcerts : UserControl
    {
        public AllConcerts()
        {
            InitializeComponent();
        }

        private void AllConcerts1_Loaded(object sender, RoutedEventArgs e)
        {
            OutputElements();
        }
    }
}
