using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETDemo.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<string> Cast { get; set; }
    }
}
