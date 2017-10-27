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
using Model;
using Services;

namespace ControllWork
{
    /// <summary>
    /// Логика взаимодействия для RequestPage.xaml
    /// </summary>
    public partial class RequestPage : Page
    {
        Request request;
        User currentUser;
        UserService userService;
        RequestService requestService;
        public RequestPage()
        {
            InitializeComponent();
            request = new Request();
            currentUser = new User();
            userService = new UserService();
            requestService = new RequestService();
        }
        

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(regionTextBox.Text) &&
                !string.IsNullOrEmpty(nameTextBox.Text) &&
                !string.IsNullOrEmpty(surnameTextBox.Text) &&
                !string.IsNullOrEmpty(telephoneTextBox.Text))
            {
                currentUser = userService.GetActiveUser();
                request.UserIIN = currentUser.Login;

                request.IIN = IINTextBox.Text;
                request.Name = nameTextBox.Text;
                request.Surname = surnameTextBox.Text;
                request.Region = regionTextBox.Text;
                request.TelephoneNumber = telephoneTextBox.Text;

                requestService.AddRequest(request);

            }
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (cheker.IsChecked == true)
            {
                sendButton.IsEnabled = true;
            }
            else
            {
                sendButton.IsEnabled = false;
            }
        }
    }
}
