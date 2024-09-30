using DemoZagirov.DataBase;
using DemoZagirov.Windows;
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
    /// Логика взаимодействия для ServiceForAdmin.xaml
    /// </summary>
    public partial class ServiceForAdmin : Page
    {
        public ServiceForAdmin()
        {
            InitializeComponent();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Service service)
            {
                Service selectedService = service;

                EditServiceWindow editServiceWindow = new EditServiceWindow(selectedService);
                editServiceWindow.ShowDialog();

            }
        }
    }
}
