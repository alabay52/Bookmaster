using Bookmaster.View.Pages;
using Bookmaster.View.Windows;
using System.Windows;

namespace Bookmaster
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LogoutMi.Visibility = Visibility.Collapsed;

            LibraryMi.Visibility = Visibility.Collapsed;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            //Для реализации оконной навигации нужно: 
            // 1) создать экземпляр окна, которое требуется открыть
            LoginWindow loginWindow = new LoginWindow();
            // 2) у экземпляра вызываем метод Show() или ShowDialog();
            loginWindow.ShowDialog();

        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CloseMi_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BrowseCatalogMi_Click(object sender, RoutedEventArgs e)
        {
            // для реализации страничной навигации нужно:
            // 1) обратиться к элементу Frame по имени и вызываем метод Navigate()
            // 2) в качестве аргумента передаем в метод экземпляр страницы, которую нужно открыть.
            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void ManageCustomersMi_Click_1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }
    }
}
