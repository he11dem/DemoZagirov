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
using DemoZagirov.Pages;
using DemoZagirov.Windows;

namespace DemoZagirov.Pages
{
    /// <summary>
    /// Логика взаимодействия для AllServicesPage.xaml
    /// </summary>
    public partial class AllServicesPage : Page
    {
        public static List<Service> services { get; set; }
        public static Client loggedClient;
        public AllServicesPage()
        {
            InitializeComponent();
            ProductLV.DataContextChanged += MyListView_DataContextChanged;

            loggedClient = DBConnection.loginedClient;

            services = new List<Service>(DBConnection.zaigirov.Service.ToList());
            ProductLV.ItemsSource = services;
            this.DataContext = this;

            FiltrCb.Items.Add("По умолчанию");
            FiltrCb.Items.Add("По убыванию");
            FiltrCb.Items.Add("По возрастанию");

            FiltrSaleCb.Items.Add("от 0 до 5%");
            FiltrSaleCb.Items.Add("от 5% до 15%");
            FiltrSaleCb.Items.Add("от 15% до 30%");
            FiltrSaleCb.Items.Add("от 30% до 70%");
            FiltrSaleCb.Items.Add("от 70% до 100%");
            FiltrSaleCb.Items.Add("Все");
        }
        private void Refresh()
        {
            List<Service> services = new List<Service>(DBConnection.zaigirov.Service.ToList());

            {
                services = services.Where(i => i.Title.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())
                   || i.Description.ToLower().StartsWith(SearchTbx.Text.Trim().ToLower())).ToList();
            }

            ProductLV.ItemsSource = services;

            if (FiltrCb.SelectedIndex == 0)
            {
                ProductLV.ItemsSource = services;
            }
            if (FiltrCb.SelectedIndex == 1)
            {
                ProductLV.ItemsSource = services.OrderByDescending(x => x.Cost).ToList();
            }
            if (FiltrCb.SelectedIndex == 2)
            {
                ProductLV.ItemsSource = services.OrderBy(x => x.Cost).ToList();
            }


            if (FiltrSaleCb.SelectedIndex == 0)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 0 && x.Discount < 5).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 1)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 5 && x.Discount < 15).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 2)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 15 && x.Discount < 30).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 3)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 30 && x.Discount < 70).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 4)
            {
                ProductLV.ItemsSource = services.Where(x => x.Discount >= 70 && x.Discount < 100).ToList();
            }
            if (FiltrSaleCb.SelectedIndex == 5)
            {
                ProductLV.ItemsSource = services;
            }
        }

       


        private void HideButtons(ListBoxItem listBoxItem)
        {
            // Получаем две кнопки из ListBoxItem
            Button EditBtn = listBoxItem.FindName("EditBtn") as Button;
            Button DeleteBtn = listBoxItem.FindName("DeleteBtn") as Button;

            // Проверяем условие loggedCClient == null
            if (loggedClient != null)
            {
                EditBtn.Visibility = Visibility.Collapsed;
                DeleteBtn.Visibility = Visibility.Collapsed;
            }
        }

        // Обработчик события DataContextChanged для ListView
        private void MyListView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Получаем элемент ListView
            ListView listView = sender as ListView;

            // Проверяем, не пустой ли ListView
            if (listView != null)
            {
                // Перебираем все элементы ListView
                foreach (var item in listView.Items)
                {
                    // Проверяем, является ли элемент ListBoxItem
                    if (item is ListBoxItem listBoxItem)
                    {
                        // Скрываем кнопки, если loggedCClient == null
                        HideButtons(listBoxItem);
                    }
                }
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Service service)
            {
                Service selectedService = service;

                EditServiceWindow editServiceWindow = new EditServiceWindow(selectedService);
                editServiceWindow.ShowDialog();

                Refresh();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Service service)
            {
                DBConnection.zaigirov.Service.Remove(service);
                DBConnection.zaigirov.SaveChanges();

                Refresh();
            }
        }
    }
}
