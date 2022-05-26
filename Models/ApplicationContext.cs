using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TicketsShop.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        //public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Ticket> Cities { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=auction.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Ticket>()
            //    .HasOne(item => item.Event)
            //    .WithMany(user => user.Tickets)
            //    .HasForeignKey(item => item.EventId);

            modelBuilder.Entity<Event>()
                .HasOne(item => item.City)
                .WithMany(city => city.Events)
                .HasForeignKey(item => item.CityId);

            var warszawa = new City { Id = 1, Name = "Warszawa" };
            var katowice = new City { Id = 2, Name = "Katowice" };
            var lublin = new City { Id = 3, Name = "Lublin" };

            modelBuilder.Entity<City>()
                .HasData(warszawa, katowice, lublin);

            var koncert = "Koncert";
            var teatr = "Teatr";

            var imagineDragons = new Event
            {
                Name = "Imagine Dragons",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now,
                Description = "None",
                EventTime = DateTime.Now,
                Type = koncert,
                ImagePath = "/Images/1.jpg"
            };

            var arcticMonkeys = new Event
            {
                Name = "Arctic Monkeys",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Description = "None",
                EventTime = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Type = koncert,
                ImagePath = "/Images/1.jpg"
            };

            var alibi = new Event
            {
                Name = "Alibi Od Zaraz",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "None",
                EventTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Type = koncert,
                ImagePath = "/Images/1.jpg"
            };

            var kota = new Event
            {
                Name = "Kiedy Kota Niema",
                CityId = katowice.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "None",
                EventTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Type = teatr,
                ImagePath = "/Images/1.jpg"
            };

            var psa = new Event
            {
                Name = "Kiedy Psa Niema",
                CityId = katowice.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "None",
                EventTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Type = teatr,
                ImagePath = "/Images/1.jpg",
            };

            modelBuilder.Entity<Event>()
                .HasData(imagineDragons, arcticMonkeys, alibi, kota, psa);

            //var tickets_ID = new List<Ticket>();
            //for (int i = 0; i < 20; i++)
            //{
            //    modelBuilder.Entity<Ticket>()
            //        .HasData(new Ticket { EventId = imagineDragons.Id });
            //}
            //var tickets_AM = new List<Ticket>();
            //for (int i = 0; i < 20; i++)
            //{
            //    modelBuilder.Entity<Ticket>()
            //        .HasData(new Ticket { EventId = arcticMonkeys.Id });
            //}
            //var tickets_A = new List<Ticket>();
            //for (int i = 0; i < 20; i++)
            //{
            //    modelBuilder.Entity<Ticket>()
            //        .HasData(new Ticket { EventId = alibi.Id });
            //}
            //var tickets_K = new List<Ticket>();
            //for (int i = 0; i < 20; i++)
            //{
            //    modelBuilder.Entity<Ticket>()
            //        .HasData(new Ticket { EventId = kota.Id });
            //}
            //var tickets_P = new List<Ticket>();
            //for (int i = 0; i < 20; i++)
            //{
            //    modelBuilder.Entity<Ticket>()
            //        .HasData(new Ticket { EventId = psa.Id });
            //}

            //modelBuilder.Entity<Ticket>()
            //    .HasData(tickets_ID, tickets_AM, tickets_A, tickets_K, tickets_P);
        }
    }
}
