using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Eindopdracht_YoupKuiper.Models
{
    class NewsItem
    {
        public string title { get; set; }
        public string content { get; set; }

        public NewsItem(string title, string content)
        {
            this.title = title;
            this.content = content;
        }
    }
}
