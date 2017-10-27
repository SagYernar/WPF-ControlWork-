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
using Services;
using DataBase;

namespace ControllWork
{
    /// <summary>
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        UserService userService;
        UserDataBase dataBase;
        public AutorizationPage()
        {
            InitializeComponent();
        }
        private void RegistrateButton_Click(object sender, RoutedEventArgs e)
        {
            (this.Parent as MainWindow).NavigationService.Navigate(new RegistrationPage());
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(loginTextBox.Text, out long result))
            {
                if (userService.CheckAutorization(long.Parse(loginTextBox.Text), passwordTextBox.Text))
                {
                    noEnterTextBlock.Visibility = Visibility.Hidden;
                    userService.GetUser(long.Parse(loginTextBox.Text));
                    (this.Parent as MainWindow).NavigationService.Navigate(new RequestPage());
                }
                else
                {
                    noEnterTextBlock.Visibility = Visibility.Visible;
                }
            }
        }

        private void DButton_Click(object sender, RoutedEventArgs e)
        {
            this.Background = Brushes.Gray;
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(@"C:\Users\СагадиевЕ\Documents\Visual Studio 2017\Projects\ControllWork\ControllWork\DarkThemeDictionary.xaml")
            });
        }

        private void RButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(@"C:\Users\СагадиевЕ\Documents\Visual Studio 2017\Projects\ControllWork\ControllWork\RedThemeDictionary.xaml")
            });
        }

        private void GButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(@"C:\Users\СагадиевЕ\Documents\Visual Studio 2017\Projects\ControllWork\ControllWork\GreenThemeDictionary.xaml")
            });
        }

        private void BButton_Click(object sender, RoutedEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri(@"C:\Users\СагадиевЕ\Documents\Visual Studio 2017\Projects\ControllWork\ControllWork\BlueThemeDictionary.xaml")
            });
        }
    }
}
