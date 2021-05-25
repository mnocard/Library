using System.Collections.Generic;

namespace Library.Wpf.Model
{
    public class PublishersWithGenres
    {
        public string Name { get; set; }
        public Dictionary<string, int> BooksByGenres { get; set; }
    }
}
