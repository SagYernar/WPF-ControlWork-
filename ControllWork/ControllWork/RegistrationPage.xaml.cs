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
using Model;

namespace ControllWork
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        UserService userService;
        User currentUser;
        public RegistrationPage()
        {
            InitializeComponent();
            userService = new UserService();
            currentUser = new User();
        }

        private void RegistrateButton_Click(object sender, RoutedEventArgs e)
        {
            if (long.TryParse(loginTextBox.Text, out long result))
            {
                if (userService.CheckLogin(long.Parse(loginTextBox.Text)))
                {
                    currentUser.Login = long.Parse(loginTextBox.Text);
                    currentUser.Password = GetPass();
                    yourPasswordTextBox.Text = currentUser.Password;
                    userService.AddUser(currentUser);
                }
                else
                {
                    notFreeIIN.Visibility = Visibility.Visible;
                    incorrectIIN.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                incorrectIIN.Visibility = Visibility.Visible;
                notFreeIIN.Visibility = Visibility.Hidden;
            }
        }

        public string GetPass()
        {
            int[] arr = new int[16];
            Random rnd = new Random();
            string Password = "";

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(33, 125);
                Password += (char)arr[i];
            }
            return Password;
        }
    }
}
