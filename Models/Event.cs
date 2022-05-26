using System;
using System.Collections.Generic;

namespace TicketsShop.Models
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Type { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime EventTime { get; set; }
        public decimal Price { get; set; } = 200;
        public string PlaceSymbol { get; set; } = "N";
        public DateTime CreationTime { get; set; }
        public string ImagePath { get; set; }
        public string PlaceName { get; set; } = "PGE Narodowy";
        public int TicketsNumber { get; set; } = 20;
        //public List<Ticket>? Tickets { get; set; } = new List<Ticket>();
    }
}
