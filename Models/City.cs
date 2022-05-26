using System.Collections.Generic;

namespace TicketsShop.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Event>? Events { get; set; } = new List<Event>();
    }
}