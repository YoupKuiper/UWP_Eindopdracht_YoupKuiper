using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWP_Eindopdracht_YoupKuiper.Models;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_Eindopdracht_YoupKuiper.Services;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Windows.UI.Popups;
using UWP_Eindopdracht_YoupKuiper.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UWP_Eindopdracht_YoupKuiper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            this.InitializeComponent();
        }

        private string Username { get; set; }
        private string Password { get; set; }

        private async void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Username = UsernameBox.Text;
            Password = PasswordBox.Password;

            User user = new User(Username, Password);

            var uri = new Uri(@"http://inhollandbackend.azurewebsites.net/api/Users/register");

            try
            {
                var response = await RegisterViewModel.SingleInstance.RegisterAsync(uri, user);
                var dialog = new MessageDialog(
                response);

                var result = await dialog.ShowAsync();
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();
            }
        }
    }
}
