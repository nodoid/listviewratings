using System.Collections.Generic;

namespace listviewratings.Models
{
    public class ListviewModel 
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageIcon { get; set;}
        public string Category { get; set; }
        public int CurrentRating { get; set; }
        public List<string> StarRatings { get; set; }
    }
}
