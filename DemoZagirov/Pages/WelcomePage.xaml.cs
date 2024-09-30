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

namespace DemoZagirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AllServicesPage());
        }

        private void logadmbtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

       
    }
}
