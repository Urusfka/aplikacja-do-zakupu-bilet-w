using System;

namespace TicketsShop.Models
{
    public class Ticket
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int IsBought { get; set; } = 0;
        public Event Event { get; set; }
        public Guid EventId { get; set; }
    }
}
