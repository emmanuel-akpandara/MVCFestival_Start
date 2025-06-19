namespace MVCFestival.DAL.Data
{
    using Microsoft.EntityFrameworkCore;
    using MVCFestival.DAL.Models;
    public class FestivalDbContext : DbContext
    {
        // DO NOT TOUCH! This empty constructor is needed for scaffolding!
        public FestivalDbContext()
        {

        }

        public FestivalDbContext(DbContextOptions<FestivalDbContext> options) : base(options)
        {
        }


        public DbSet<Festival> Festivals { get; set; }
        public DbSet<FestivalPerformance> FestivalPerformances { get; set; }
        public DbSet<FestivalStage> FestivalStages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Festival>().ToTable("Festival");
            modelBuilder.Entity<FestivalStage>().ToTable("FestivalStage");
            modelBuilder.Entity<FestivalPerformance>().ToTable("FestivalPerformance");
        }

        // DO NOT TOUCH! This code is needed for scaffolding!
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FestivalAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}



