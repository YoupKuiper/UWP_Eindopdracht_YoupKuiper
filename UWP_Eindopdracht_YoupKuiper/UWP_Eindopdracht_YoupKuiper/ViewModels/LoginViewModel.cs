using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_Eindopdracht_YoupKuiper.Models;
using UWP_Eindopdracht_YoupKuiper.Services;

namespace UWP_Eindopdracht_YoupKuiper.ViewModels
{
    class LoginViewModel
    {
        public static LoginViewModel SingleInstance { get; } = new LoginViewModel();

        private LoginViewModel()
        {

        }

        public async Task<string> LoginAsync(User user, Uri uri)
        {
            var response = await Backend.PostAsJsonAsync(uri, user);

            if(response != null)
            {
                var res = JsonConvert.DeserializeObject<dynamic>(response);
                AuthToken.Instance.AuthenticationToken = res.AuthToken;
            }

            return response;
        }
    }
}
