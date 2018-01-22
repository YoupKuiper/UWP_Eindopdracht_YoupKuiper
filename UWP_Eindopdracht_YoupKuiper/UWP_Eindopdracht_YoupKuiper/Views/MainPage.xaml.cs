using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UWP_Eindopdracht_YoupKuiper.Models;
using Windows.UI.Popups;
using UWP_Eindopdracht_YoupKuiper.ViewModels;
using System.Threading.Tasks;
using UWP_Eindopdracht_YoupKuiper.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Eindopdracht_YoupKuiper.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private MainViewModel VM => MainViewModel.SingleInstance;

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                await VM.InitializeAsync();
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();
            }

            if (IsAuthTokenSet())
            {
                loginText.Text = "Uitloggen";
            }
            else
            {
                loginText.Text = "Inloggen";
            }
        }

        public bool IsAuthTokenSet()
        {
            return !String.IsNullOrEmpty(AuthToken.Instance.AuthenticationToken);
        }
        
        public void itemClicked(object sender, ItemClickEventArgs e)
        {
            Result item = (Result)e.ClickedItem;
            Frame.Navigate(typeof(ArticleDetailPage), item);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (IsAuthTokenSet())
            {
                VM.Logout();
                loginText.Text = "Inloggen";
            }
            else
            {
                Frame.Navigate(typeof(LoginPage));
            }
        }

        private async void likedButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await VM.GetAllLikedArticles();

            }
            catch (Exception)
            {
           }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }

        private async void CategoryButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            var id = button.Tag;
            try
            {
                await VM.GetArticlesForFeedAsync((int)id);

            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();

            }
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)e.OriginalSource;
            var id = checkBox.Tag;

            try
            {
                await VM.LikeArticle(Int32.Parse(id.ToString()));
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();

            }
        }

        private async void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)e.OriginalSource;
            var id = checkBox.Tag;

            try
            {
                await VM.NoLongerLikeArticle(Int32.Parse(id.ToString()));
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();
            }

        }
    }
}
