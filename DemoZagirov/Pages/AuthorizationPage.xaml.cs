using DemoZagirov.DataBase;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Client> clients { get; set; }
        public static Client loggedClient;
        public AuthorizationPage()
        {
            InitializeComponent();
            loggedClient = DBConnection.loginedClient;
        }

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = loginTb.Text.Trim();

                clients = new List<Client>(DBConnection.zaigirov.Client.ToList());
                var currentClient = clients.FirstOrDefault(i => i.Email.Trim() == email);
                DBConnection.loginedClient = currentClient;

                if (currentClient != null)
                {
                    NavigationService.Navigate(new AllServicesPage());
                }

                else if (email == "0000")
                {
                    MessageBox.Show("Добро пожаловать, Администратор!");
                    NavigationService.Navigate(new AllServicesPage());
                }

                else
                {
                    MessageBox.Show("Неверный логин или пароль! Попробуйте снова. ");
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка подключения. ");
            }
        }
    }
}
