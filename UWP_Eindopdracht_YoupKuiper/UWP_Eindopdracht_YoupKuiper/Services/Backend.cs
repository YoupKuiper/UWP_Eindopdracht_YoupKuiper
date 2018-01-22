using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using UWP_Eindopdracht_YoupKuiper.Models;
using System.Net.Http.Headers;

namespace UWP_Eindopdracht_YoupKuiper.Services
{
    class Backend
    {
        public static async Task<RootObject> GetDataFromBackendAsync(int? startingArticleId, int? categoryFeed)
        {
            try
            {
                int numberOfArticlesToGet = 20;
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", AuthToken.Instance.AuthenticationToken);
                    var json = "";
                    if (startingArticleId != 0 && categoryFeed != null)
                    {
                        json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/Articles/" + startingArticleId + "?count=" + numberOfArticlesToGet + "&feeds=" + categoryFeed);

                    }
                    else if (startingArticleId != null)
                    {
                        json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/Articles/" + startingArticleId + "?count=" + numberOfArticlesToGet);
                    }
                    else
                    {
                        json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/Articles");
                    }

                    return JsonConvert.DeserializeObject<RootObject>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }

        }

        public static async Task LikeArticle(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", AuthToken.Instance.AuthenticationToken);
                await client.PutAsync("http://inhollandbackend.azurewebsites.net/api/Articles/" + id + "/like", new StringContent("ASD", Encoding.UTF8));
            }
        }

        public static async Task NoLongerLikeArticle(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", AuthToken.Instance.AuthenticationToken);
                await client.DeleteAsync("http://inhollandbackend.azurewebsites.net/api/Articles/" + id + "/like");
            }
        }

        public static async Task<List<Category>> getFeedsFromBackendAsync()
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/feeds");

                return JsonConvert.DeserializeObject<List<Category>>(json);
            }
        }

        public static async Task<RootObject> GetArticlesForFeedFromBackendAsync(int feedId)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", AuthToken.Instance.AuthenticationToken);
                var json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/Articles?feeds=" + feedId);

                return JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public static async Task<RootObject> GetAllLikedArticles()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.TryAddWithoutValidation("x-authtoken", AuthToken.Instance.AuthenticationToken);
                var json = await client.GetStringAsync("http://inhollandbackend.azurewebsites.net/api/Articles/liked");

                return JsonConvert.DeserializeObject<RootObject>(json);
            }
        }

        public static async Task<string> PostAsJsonAsync<T>(Uri uri, T item)
        {
            var itemAsJson = JsonConvert.SerializeObject(item);
            var content = new StringContent(itemAsJson);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (var client = new HttpClient())
            {

                var response = await client.PostAsJsonAsync(uri, item);

                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
