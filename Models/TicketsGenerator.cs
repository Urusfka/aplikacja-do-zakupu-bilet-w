using System;
using System.Collections.Generic;

namespace TicketsShop.Models
{
    public class TicketsGenerator
    {
        public List<Ticket> GenerateTickets(int number, Guid eventId)
        {
            var tickets = new List<Ticket>();

            for (int i = 0; i < number; i++)
            {
                tickets.Add(new Ticket { Id = Guid.NewGuid(), EventId = eventId});
            }

            return tickets;
        }
    }
}
