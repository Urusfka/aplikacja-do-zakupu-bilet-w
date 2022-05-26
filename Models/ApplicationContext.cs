using Microsoft.EntityFrameworkCore;
using System;

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
            var poznan = new City { Id = 2, Name = "Poznan" };
            var lublin = new City { Id = 3, Name = "Lublin" };

            modelBuilder.Entity<City>()
                .HasData(warszawa, poznan, lublin);

            var koncert = "Koncert";
            var teatr = "Teatr";

            var imagineDragons = new Event
            {
                Name = "Ed Sheeran: +-=÷x Tour",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now,
                Description = "Ed Sheeran ogłasza swoja najnowsza trasę ‘+ - = ÷ x Tour’ (wymawiane ‘The Mathematics Tour’/’Trasa Matematyczna’), która odbędzie się na stadionach w roku 2022. Tournée rozpocznie się w kwietniu przyszłego roku, a Ed zagra w UK, Irlandii, Środkowej Europie i Skandynawii, jak również powróci na londyński stadion Wembley, aby zagrać trzy koncerty w czerwcu/lipcu. Ogólna sprzedaż biletów na wszystkie kraje rozpocznie się w sobotę 25 września (dokładny czas w sprzedaży dla poszczególnych państw zamieszczony powyżej). Najbliższa trasa Eda ‘+ - = ÷ x Tour’ odbędzie się na stadionach po raz pierwszy od przełomowej ‘Divide Tour’ z lat 2017 – 2019. Była to oficjalnie najpopularniejsza trasa, która przyniosła najwyższe zyski jeszcze przed jej zakończeniem. Podczas przyszłorocznego tournée, fani będą mieli okazje zobaczyć Eda wykonującego po raz pierwszy na żywo wybór utworów z najnowszego albumu ‘=’. Będą mogli również doświadczyć wyjątkowej produkcji, z okrągłą sceną na środku stadionu, na której Ed wystąpi w każdym kraju otoczony publicznością. Wyczekiwany album Eda ‘=’ ukaże się 29 października nakładem Asylum/Atlantic. Oczekuje się, że nowy singiel artysty zajmie miejsce jego poprzedniego hitu na oficjalnej lisice singli w UK, utwór ‘Shivers’ – Ed wykonał go po raz pierwszy w poprzedni weekend na MTV VMA’s. Jest to kolejny szlagier po ogromnym sukcesie, ‘Bad Habits’, i powrocie Eda na listy, gdzie jak do tej pory, pozostawał w czołówce przez kolejne 11 tygodni. Po raz kolejny Ed i jego współpracownicy zdecydowanie przeciwstawiają się wtórnej sprzedaży biletów przez strony nieoficjalne, starając się uchronić fanów przez wyzyskiem w trakcie kupna. Koncerty na najnowszej trasie będą używać specjalnie zaprojektowanej biletowej technologii cyfrowej z zabezpieczeniami, aby mieć pewność, że tylko prawdziwi fani kupują autentyczne bilety. Ma to na celu zablokowanie wtórnej sprzedaży na stronach nieoficjalnych po wygórowanych cenach, co stanowi oszustwo wobec fanów. Aby usprawnić sprzedaż legalnych biletów, zachęcamy fanów do zarejestrowania się z wyprzedzeniem na konto oficjalnego sprzedawcy. Fani, którzy nie będą w stanie dotrzeć na koncert, będą mogli odsprzedać bilet innym fanom po cenie, za którą go nabyli + oficjalną opłatę rezerwacyjną poprzez oficjalną platformę do nominalnej odsprzedaży pomiędzy fanami, w miejscu, w którym bilet został nabyty.",
                EventTime = DateTime.Parse("26 08 2022 18:00:00"),
                Type = koncert,
                ImagePath = "/Images/01.png",
                Price = 249
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
                Description = "Przyłapany na zdradzie mąż potrafi wznieść się na wyżyny kreatywności! Sztuka Jeana Poireta “Alibi od zaraz” jest tego niezbitym dowodem. Michel, zaprasza do domu piękną młodą dziewczynę.Gdy powoli wciela w życie swoje marzenia o romansie, w drzwiach staje jego żona Sophie!Zdezorientowany i przerażony wizją rozwodu z dobrze sytuowaną małżonką, potrzebuje porządnego alibi. Na poczekaniu wymyśla niedorzeczną historię i wciąga niedoszłą kochankę do wspólnego odgrywania absolutnie nieprzemyślanej farsy…Jakie alibi będzie najbardziej wiarygodne? W co uwierzy żona? Scenariusza komicznej intrygi nie zna nikt! Nawet sam autor!",
                EventTime = DateTime.Parse("TimeSpan.FromDays(2)"),
                Type = teatr,
                ImagePath = "/Images/02.png",
                Price = 142,
                PlaceName = "Teatr Capitol"
            };


            var kota = new Event
            {
                Name = "Kiedy Kota Niema",
                CityId = poznan.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "None",
                EventTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Type = teatr,
                ImagePath = "/Images/1.jpg"
            };

            var psa = new Event
            {
                Name = "Kiedy Psa Niema",
                CityId = poznan.Id,
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
