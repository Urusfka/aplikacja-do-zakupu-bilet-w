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
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=events.db");
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

            var deanLewis = new Event
            {
                Name = "Dean Lewis",
                CityId = lublin.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(1)),
                Description = "Dean Lewis, autor multiplatynowego hitu „Be Alright”, wystąpi jesienią w Progresji!Złote dziecko australijskiego popu, Dean Lewis to prawdziwy kolekcjoner imponujących osiągnięć - 5, 6 miliarda streamów i ponad 1, 3 sprzedanych wydawnictw, milion obserwujących na Youtube i 830 tysięcy followersów na Tik Toku.Artysta wystąpi w warszawskiej Progresji 1 października.Jego najnowszy singiel, “Falling Up” do tej pory zaliczył ponad 45 milionów streamów na całym świecie, zyskując w Australii status Złotej Płyty. W 2019 roku Lewis został ogłoszony przez Apple jako “Up Next Artist”, wyprzedając tournee w Australii i USA. Niedługo później ukazał się jego debiutancki album „A Place We Knew”, który przyniósł takie hity jak „Waves”, „Be Alright”, „7 Minutes” i „Stay Awake”. Płyta ma status platyny w Australii, złota w USA, srebra w UK oraz platyny w ponad ośmiu innych krajach. „Be Alright”, które okazało się przełomem w karierze artysty, ma niemal 5 miliardów streamów na całym świecie(status platyny w ponad 23 krajach - w samej Australii 11 - stokrotną!).",
                EventTime = DateTime.Parse("01 11 2022 20:00"),
                Type = koncert,
                ImagePath = "/Images/05.png",
                Price = 110,
                PlaceName = "Progresja"
            };

            var alibi = new Event
            {
                Name = "Alibi Od Zaraz",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "Przyłapany na zdradzie mąż potrafi wznieść się na wyżyny kreatywności! Sztuka Jeana Poireta “Alibi od zaraz” jest tego niezbitym dowodem. Michel, zaprasza do domu piękną młodą dziewczynę.Gdy powoli wciela w życie swoje marzenia o romansie, w drzwiach staje jego żona Sophie!Zdezorientowany i przerażony wizją rozwodu z dobrze sytuowaną małżonką, potrzebuje porządnego alibi. Na poczekaniu wymyśla niedorzeczną historię i wciąga niedoszłą kochankę do wspólnego odgrywania absolutnie nieprzemyślanej farsy…Jakie alibi będzie najbardziej wiarygodne? W co uwierzy żona? Scenariusza komicznej intrygi nie zna nikt! Nawet sam autor!",
                EventTime = DateTime.Parse("03 06 2022 19:30"),
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
                Description = "Kiedy kota nie ma... istnieje szansa, że pojawi się w najmniej oczekiwanym momencie! A wtedy bieg komicznych wydarzeń w tej znakomitej brytyjskiej komedii sytuacyjnej, może nabrać zawrotnego tempa, a rozbawienie Widzów całkowicie wymknąć się spod kontroli. Podróż poślubna do Saint Tropez? Tak! Ale w dwudziestą rocznicę ślubu??? Jak poradzą sobie z wzajemnymi uszczypliwościami dwa zabawne angielskie małżeństwa z 20-letnim stażem? Jak rozbudzić dziką namiętność w mężu fajtłapie? Jak ów próbuje dotrzymać kroku szwagrowi seksoholikowi? Jak zaimponować zmanierowanej zamożnej siostrze i nie zabić jej wędzonym łososiem? Oraz czy szczotka sedesowa z wizerunkiem pary królewskiej może pomóc w samobójstwie pięknej 20-latce? - odpowiedzi mogą być abstrakcyjnie zaskakujące! Jedyne przewidywalne tego wieczoru, to ponad 2 godziny dobrego dowcipu, humoru i śmiechu do łez!",
                EventTime = DateTime.Parse("10 09 2022 19:00"),
                Type = teatr,
                ImagePath = "/Images/03.png",
                Price = 131,
                PlaceName = "Teatr Capitol"
            };

            var pentatonix = new Event
            {
                Name = "Pentatonix",
                CityId = warszawa.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description = "Pentatonix, czyli bez wątpienia najsłynniejszy na świecie zespół acapella, słusznie owiany legendarną sławą zmuszony został do ponownego przeniesienia swojej światowej trasy koncertowej. Tym samym przesunięty został również termin polskiego występu grupy, która według nowego kalendarza zagra w warszawskiej hali Torwar 15 maja 2023 roku.Chociaż fani Pentatonix muszą wykazać się nie lada cierpliwością,to w tym wypadku bez wątpienia jest na co czekać.Pentatonix to prawdziwe wokalne mistrzostwo świata.Piątka artystów tworzących muzykę łączącą niemal wszystkie gatunki świata rozkochała w sobie setki tysięcy ludzi za sprawą swoich nietuzinkowych głosów.Poza tworzeniem oryginalnych utworów, Pentatonix słyną z aranżacji popowych przebojów i popularnych piosenek świątecznych, które każdego roku biją rekordy popularności. Amerykanie zdobyli już 3 nagrody Grammy, a ich albumy stale goszczą na liście Billboard(dziesięć płyt sięgnęło TOP10 tego zestawienia, w tym dwa zdobyły pierwsze miejsce) i wielokrotnie pokrywały się multi - platyną, platyną i złotem.Ich kanał na YouTube subskrybuje ponad 17 milionów osób, a ich filmy zostały obejrzane już ponad 4 miliardy razy.Te liczby mówią same za siebie – Pentatonix to potężna marka, a ich występ na żywo będzie wydarzeniem, które na lata pozostanie w pamięci słuchaczy.",
                EventTime = DateTime.Parse("15 05 2023 19:00"),
                Type = koncert,
                ImagePath = "/Images/04.png",
                Price = 225,
                PlaceName = "COS Torwar"
            };
            var kochanePien = new Event
            {
                Name = "Kochane pieniążki",
                CityId = poznan.Id,
                CreationTime = DateTime.Now.Add(TimeSpan.FromDays(2)),
                Description =
                    "Co byś zrobił, gdybyś przez pomyłkę wszedł w posiadanie teczki z gigantyczną sumą pieniędzy? Szukałbyś właściciela czy szalejąc ze szczęścia zatrzymałbyś ją dla siebie? Trudny wybór… Bo przecież pieniądze nie spadają z nieba i taka szansa nie zdarza się co dzień. Henry, bohater kryminalnej farsy „Kochane pieniążki” podejmuje więc szybką decyzję. W końcu właśnie w jego urodziny otrzymuje ten wyjątkowy prezent od losu i żal z niego nie skorzystać. Pędzi do domu ile tchu, ściskając go w rękach. Czas to pieniądz, więc od razu wciela w życie swój misterny plan!Żona patrzy na niego z przerażeniem,próbując odwieść go od szalonego pomysłu… Gdy małżonkowie starają się dojść do porozumienia, niespodziewani goście tylko komplikują sytuację.Żądni sensacji i chciwi przyjaciele, skorumpowany glina, niezbyt rozgarnięty inspektor, bezczelny taksówkarz, a wszystkim po piętach depcze ktoś z kim lepiej nie zadzierać… I wtedy zaczyna się prawdziwa akcja… Zawrotne tempo, niespodziewane wydarzenia, komiczne sytuacje i przezabawne dialogi.",
                EventTime = DateTime.Parse("25 09 2022 18:00"),
                Type = teatr,
                ImagePath = "/Images/06.png",
                Price = 142,
                PlaceName = "Teatr Capitol"
            };
            var imagineDragons1 = new Event
            {
                Name = imagineDragons.Name,
                CityId = poznan.Id,
                CreationTime = DateTime.Now,
                Description = imagineDragons.Description,
                EventTime = DateTime.Parse("12 09 2022 18:00:00"),
                Type = koncert,
                ImagePath = "/Images/01.png",
                Price = 219,
                PlaceName = "Progresja"
            };
            var imagineDragons2 = new Event
            {
                Name = imagineDragons.Name,
                CityId = lublin.Id,
                CreationTime = DateTime.Now,
                Description = imagineDragons.Description,
                EventTime = DateTime.Parse("12 08 2022 17:00:00"),
                Type = koncert,
                ImagePath = "/Images/01.png",
                Price = 229,
                PlaceName = "Progresja"
            };

            modelBuilder.Entity<Event>()
                .HasData(imagineDragons, deanLewis, alibi, kota, pentatonix, imagineDragons1, imagineDragons2);

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
