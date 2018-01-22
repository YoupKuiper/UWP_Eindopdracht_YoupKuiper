using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Eindopdracht_YoupKuiper.Models
{
    class AuthToken
    {
        static readonly AuthToken _instance = new AuthToken();
        public string AuthenticationToken;
        public static AuthToken Instance
        {
            get
            {
                return _instance;
            }
        }
        AuthToken()
        {
            
        }
    }
}
