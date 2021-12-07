using System.Collections.Generic;

namespace AppShopping.Models
{
    public class Film
    {
        public string Cover { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SessionGroup> SessionGroups { get; set; }
    }
}
