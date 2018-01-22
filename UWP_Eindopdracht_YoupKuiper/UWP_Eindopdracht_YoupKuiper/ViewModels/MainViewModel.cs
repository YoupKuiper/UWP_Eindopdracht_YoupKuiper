using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UWP_Eindopdracht_YoupKuiper.Helpers;
using UWP_Eindopdracht_YoupKuiper.Models;
using UWP_Eindopdracht_YoupKuiper.Services;
using Windows.UI.Popups;

namespace UWP_Eindopdracht_YoupKuiper.ViewModels
{
    class MainViewModel
    {
        public static MainViewModel SingleInstance { get; } = new MainViewModel();
        public int NextId { get; set; }
        public ObservableIncrementalLoadingCollection<Result> NewsItems { get; set; }
        public ObservableCollection<Category> Categories { get; }
        public int CategoryFeed { get; set; }

        private MainViewModel()
        {
            Categories = new ObservableCollection<Category>();
            NewsItems = new ObservableIncrementalLoadingCollection<Result>();
            bool isInternetConnected = NetworkInterface.GetIsNetworkAvailable();
            if (isInternetConnected)
            {
                NewsItems.LoadMoreItemsAsyncEvent += ListArticlesOnLoadMoreItems;

            }
        }

        public async Task InitializeAsync()
        {
            if (Categories.Count == 0)
            {
                var feeds = await Backend.getFeedsFromBackendAsync();

                foreach (var item in feeds)
                {
                    Categories.Add(item);
                }
            }
        }

        public async Task<IncrementalLoadingResponse<Result>> ListArticlesOnLoadMoreItems(int nextId)
        {
            
            try
            {
                RootObject rootObject = new RootObject();

                if (NewsItems.Count == 0)
                {
                    rootObject = await Backend.GetDataFromBackendAsync(null, null);
                }
                else if (CategoryFeed > 0 )
                {
                    rootObject = await Backend.GetDataFromBackendAsync(NextId, CategoryFeed);
                }
                else
                {
                    rootObject = await Backend.GetDataFromBackendAsync(NextId, null);
                }

                if(rootObject == null)
                {
                    var dialog = new MessageDialog("Er is iets fout gegaan bij het ophalen van de gegevens. ");
                    await dialog.ShowAsync();
                    return null;
                }
                var results = new List<Result>();

                foreach (var item in rootObject.Results)
                {
                    results.Add(item);
                }

                NextId = rootObject.NextId;

                var response = new IncrementalLoadingResponse<Result>(rootObject.NextId, results);
                return response;
            }
            catch (Exception exception)
            {
                var dialog = new MessageDialog("Er is iets fout gegaan: " + exception.Message);
                await dialog.ShowAsync();
                return null;
            }

            
        }

        public async Task LikeArticle(int id)
        {
            await Backend.LikeArticle(id);
        }

        public async Task NoLongerLikeArticle(int id)
        {
            await Backend.NoLongerLikeArticle(id);
        }

        public async Task GetAllLikedArticles()
        {
            var list = await Backend.GetAllLikedArticles();

            NewsItems.Clear();

            foreach (var item in list.Results)
            {
                NewsItems.Add(item);
            }
        }

        public void Logout()
        {
            AuthToken.Instance.AuthenticationToken = "";
        }

        public async Task GetArticlesForFeedAsync(int feedId)
        {
            CategoryFeed = feedId;
            var list = await Backend.GetArticlesForFeedFromBackendAsync(feedId);

            NewsItems.Clear();

            foreach (var item in list.Results)
            {
                NewsItems.Add(item);
            }
            NextId = list.NextId;

        }
    }
}
