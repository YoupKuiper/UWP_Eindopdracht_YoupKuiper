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
    class RegisterViewModel
    {
        public static RegisterViewModel SingleInstance { get; } = new RegisterViewModel();

        private RegisterViewModel()
        {

        }

        public async Task<string> RegisterAsync(Uri uri, User user)
        {
            var response = await Backend.PostAsJsonAsync(uri, user);
            dynamic res = JsonConvert.DeserializeObject<dynamic>(response);
            return res.Message;
        }
    }
}
