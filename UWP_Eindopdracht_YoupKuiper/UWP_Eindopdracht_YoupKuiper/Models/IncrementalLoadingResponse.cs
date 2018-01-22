using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWP_Eindopdracht_YoupKuiper.Models
{
    public sealed class IncrementalLoadingResponse<T>
    {
        public int NextId { get; set; }
        public IEnumerable<T> Results { get; set; }

        public IncrementalLoadingResponse(int nextId, IEnumerable<T> results)
        {
            NextId = nextId;
            Results = results;
        }
    }
}
