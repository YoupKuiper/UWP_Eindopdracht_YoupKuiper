using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Eindopdracht_YoupKuiper.Models
{
    [DataContract]
    class User
    {
        [DataMember]
        private string Username { get; set; }

        [DataMember]
        private string Password { get; set; }


        public User(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
