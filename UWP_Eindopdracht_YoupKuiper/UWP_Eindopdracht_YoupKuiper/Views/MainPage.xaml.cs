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
            ObservableCollection<NewsItem> newsItems = new ObservableCollection<NewsItem>();

            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));
            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));
            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));
            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));
            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));
            newsItems.Add(new NewsItem("Test Titel", "lorem ipsum doru soahe ska dhahe oaie ajsie arum aospis alarmii ajseas amvlansal sjajen ane"));


            MyList.ItemsSource = newsItems;
        }
    }
}
