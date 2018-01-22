using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWP_Eindopdracht_YoupKuiper.Models;
using UWP_Eindopdracht_YoupKuiper.Services;
using UWP_Eindopdracht_YoupKuiper.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Credentials;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Eindopdracht_YoupKuiper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private string Username { get; set; }
        private string Password { get; set; }

        private async void LoginButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            Username = UsernameBox.Text;
            Password = PasswordBox.Password;

            User user = new User(Username, Password);

            var uri = new Uri(@"http://inhollandbackend.azurewebsites.net/api/Users/login");

            try
            {
                var response = await LoginViewModel.SingleInstance.LoginAsync(user, uri);

                string message;

                if (response != null)
                {
                    message = "Successfully logged in";
                }
                else
                {
                    message = "Login failed: username or password incorrect";
                }
                var dialog = new MessageDialog(
                message);

                var result = await dialog.ShowAsync();

                if (response != null)
                {
                    Frame.Navigate(typeof(MainPage));
                }
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();
            }


        }
    }
}
