using DEVUXC_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository
{
    public class F1DbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Race> Races { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public F1DbContext()
        {
            this.Database.EnsureCreated();
        }
        public F1DbContext(DbContextOptions<F1DbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseInMemoryDatabase("carshopdb")
                    .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasMany(season => season.Races)
                    .WithOne(races => races.Season)
                    .HasForeignKey(race => race.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            //Season thisyear = new Season() { Id = 2022 };
        }
    }
}
