using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Eindopdracht_YoupKuiper.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Result
    {
        public int Id { get; set; }
        public int Feed { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public DateTime PublishDate { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public List<object> Related { get; set; }
        public List<Category> Categories { get; set; }
        public bool? IsLiked { get; set; }
    }

    public class RootObject
    {
        public List<Result> Results { get; set; }
        public int NextId { get; set; }
    }
}
