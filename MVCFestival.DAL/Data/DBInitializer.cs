namespace MVCFestival.DAL.Data
{
    using MVCFestival.DAL.Models;
    public class DBInitializer
    {
        public static void Initialize(FestivalDbContext context)
        {
            context.Database.EnsureCreated();

            // Seed the Festivals table with some dummy data
            if (!context.Festivals.Any())
            {
                var festivals = new Festival[]
                {
                new Festival { Name = "Coachella", Date = DateTime.Parse("2023-06-14"), Location = "Indio, California", Price = 399.99M, TicketsAvailable = 100000 },
                new Festival { Name = "Lollapalooza", Date = DateTime.Parse("2023-07-03"), Location = "Grant Park, Chicago", Price = 349.99M, TicketsAvailable = 80000 },
                new Festival { Name = "Bonnaroo", Date = DateTime.Parse("2023-08-08"), Location = "Manchester, Tennessee", Price = 319.99M, TicketsAvailable = 70000 }
                };

                foreach (Festival f in festivals)
                {
                    context.Festivals.Add(f);
                }

                context.SaveChanges();


                var stages = new FestivalStage[]
            {
                new FestivalStage { Name = "Coachella Beach", Capacity = 20000, FestivalId = 1 },
                new FestivalStage { Name = "Sahara Tent", Capacity = 15000, FestivalId = 1 },
                new FestivalStage { Name = "Grand Park Stage", Capacity = 18000, FestivalId = 2 },
                new FestivalStage { Name = "Main Stage", Capacity = 12000, FestivalId = 2 },
                new FestivalStage { Name = "Trolls Stage", Capacity = 25000, FestivalId = 3 },
                new FestivalStage { Name = "Whitches Stage", Capacity = 15000, FestivalId = 3 }
            };

                foreach (FestivalStage s in stages)
                {
                    context.FestivalStages.Add(s);
                }


                context.SaveChanges();


                // Seed the FestivalPerformances table with some dummy data
                if (!context.FestivalPerformances.Any())
                {
                    var performances = new FestivalPerformance[]
                    {

                        new FestivalPerformance { Performer = "Rage Against the Machine", StartTime = DateTime.Parse("2023-06-14 18:00:00"), EndTime = DateTime.Parse("2023-06-14 20:00:00"), StageId = 1 },
                        new FestivalPerformance { Performer = "Billie Eilish", StartTime = DateTime.Parse("2023-06-14 20:00:00"), EndTime = DateTime.Parse("2023-04-14 21:30:00"), StageId = 1 },
                        new FestivalPerformance { Performer = "The Weeknd", StartTime = DateTime.Parse("2023-04-14 22:00:00"), EndTime = DateTime.Parse("2023-04-14 23:30:00"), StageId = 1 },
                        new FestivalPerformance { Performer = "Foo Fighters", StartTime = DateTime.Parse("2023-06-14 20:00:00"), EndTime = DateTime.Parse("2023-04-14 21:30:00"), StageId = 2 },
                        new FestivalPerformance { Performer = "Kendrick Lamar", StartTime = DateTime.Parse("2023-04-14 22:00:00"), EndTime = DateTime.Parse("2023-04-14 23:30:00"), StageId = 2 },
                        new FestivalPerformance { Performer = "Lizzo", StartTime = DateTime.Parse("2023-07-03 18:00:00"), EndTime = DateTime.Parse("2023-07-03 19:30:00"), StageId = 3 },
                        new FestivalPerformance { Performer = "Post Malone", StartTime = DateTime.Parse("2023-07-03 20:00:00"), EndTime = DateTime.Parse("2023-07-03 22:00:00"), StageId = 3 },
                        new FestivalPerformance { Performer = "Dua Lipa", StartTime = DateTime.Parse("2023-07-03 20:00:00"), EndTime = DateTime.Parse("2023-07-03 22:00:00"), StageId = 4 },
                        new FestivalPerformance { Performer = "J. Cole", StartTime = DateTime.Parse("2023-07-03 22:00:00"), EndTime = DateTime.Parse("2023-07-03 23:45:00"), StageId = 4 },
                        new FestivalPerformance { Performer = "Harry Styles", StartTime = DateTime.Parse("2023-08-08 18:00:00"), EndTime = DateTime.Parse("2023-08-08 20:00:00"), StageId = 5 },
                        new FestivalPerformance { Performer = "Lana Del Rey", StartTime = DateTime.Parse("2023-08-08 21:00:00"), EndTime = DateTime.Parse("2023-08-08 23:00:00"), StageId = 5 },
                        new FestivalPerformance { Performer = "Coldplay", StartTime = DateTime.Parse("2023-08-08 18:30:00"), EndTime = DateTime.Parse("2023-08-08 20:30:00"), StageId = 6 },
                        new FestivalPerformance { Performer = "Drake", StartTime = DateTime.Parse("2023-08-08 20:30:00"), EndTime = DateTime.Parse("2023-08-08 22:00:00"), StageId = 6 },
                        new FestivalPerformance { Performer = "Rihanna", StartTime = DateTime.Parse("2023-08-08 20:30:00"), EndTime = DateTime.Parse("2023-08-08 23:00:00"), StageId = 6 }

                    };
                    foreach (FestivalPerformance p in performances)
                    {
                        context.FestivalPerformances.Add(p);
                    }


                    context.SaveChanges();
                }
            }
        }
    }
}

  