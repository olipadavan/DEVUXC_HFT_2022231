using DEVUXC_HFT_2022231.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
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

            Season s2022 = new Season(2022);

            #region driver declaration
            Driver ver = new Driver() { Id = 1 , Name = "Verstappen", Points=0, DriverNumber= 1, Country= "ned", Birth= Driver.ToDatetime(1997, 09, 30), WorldChampTitles = 2};
            Driver per = new Driver() { Id = 2 , Name = "Perez", Points=0, DriverNumber= 11, Country= "mex", Birth= Driver.ToDatetime(1990, 01, 26)};
            Driver sai = new Driver() { Id = 3 , Name = "Sainz", Points=0, DriverNumber= 55, Country= "esp", Birth= Driver.ToDatetime(1994, 09, 01)};
            Driver lec = new Driver() { Id = 4 , Name = "Leclerc", Points=0, DriverNumber= 16, Country= "mon", Birth= Driver.ToDatetime(1997,10,16)};
            Driver nor = new Driver() { Id = 5 , Name = "Norris", Points=0, DriverNumber= 4, Country= "gbr", Birth= Driver.ToDatetime(1999, 11, 13)};
            Driver ric = new Driver() { Id = 6 , Name = "Riccardo", Points=0, DriverNumber= 3, Country= "aus", Birth= Driver.ToDatetime(1989, 07, 01)};
            Driver ham = new Driver() { Id = 7 , Name = "Hamilton", Points=0, DriverNumber= 44, Country= "gbr", Birth= Driver.ToDatetime(1985, 01, 07), WorldChampTitles = 7};
            Driver rus = new Driver() { Id = 8 , Name = "Russel", Points=0, DriverNumber= 63, Country= "gbr", Birth= Driver.ToDatetime(1998, 02, 15)};
            Driver oco = new Driver() { Id = 9 , Name = "Ocon", Points=0, DriverNumber= 31, Country= "fra", Birth= Driver.ToDatetime(1996, 09, 17)};
            Driver alo= new Driver() { Id = 10, Name = "Alonzo", Points=0, DriverNumber= 14, Country= "esp", Birth= Driver.ToDatetime(1981, 09, 29), WorldChampTitles = 2};
            Driver vet= new Driver() { Id = 11, Name = "Vettel", Points=0, DriverNumber= 5, Country= "ger", Birth= Driver.ToDatetime(1987, 07, 03), WorldChampTitles = 4};
            Driver str= new Driver() { Id = 12, Name = "Stroll", Points=0, DriverNumber= 18, Country= "can", Birth= Driver.ToDatetime(1998, 10, 29)};
            Driver mag= new Driver() { Id = 13, Name = "Magnussen", Points=0, DriverNumber= 20, Country= "den", Birth= Driver.ToDatetime(1992, 10, 05)};
            Driver sch= new Driver() { Id = 14, Name = "Schumacher", Points=0, DriverNumber= 47, Country= "ger", Birth= Driver.ToDatetime(1999, 03, 22)};
            Driver gas= new Driver() { Id = 15, Name = "Gasly", Points=0, DriverNumber= 10, Country= "fra", Birth= Driver.ToDatetime(1996, 02, 07)};
            Driver tsu= new Driver() { Id = 16, Name = "Tsunoda", Points=0, DriverNumber= 22, Country= "jpn", Birth= Driver.ToDatetime(2000, 05, 11)};
            Driver zho= new Driver() { Id = 17, Name = "Zhou", Points=0, DriverNumber= 24, Country= "chn", Birth= Driver.ToDatetime(1999, 05, 30)};
            Driver bot= new Driver() { Id = 18, Name = "Bottas", Points=0, DriverNumber= 77, Country= "fin", Birth= Driver.ToDatetime(1989, 08, 28)};
            Driver alb= new Driver() { Id = 19, Name = "Albon", Points=0, DriverNumber= 23, Country= "tha", Birth= Driver.ToDatetime(1996, 03,23)};
            Driver lat= new Driver() { Id = 20, Name = "Latifi", Points=0, DriverNumber= 6, Country= "can", Birth= Driver.ToDatetime(1995, 06, 29)};
            Driver dev= new Driver() { Id = 21, Name = "De Vires", Points=0, DriverNumber= 19, Country= "ned", Birth= Driver.ToDatetime(1995, 02, 06)};
            Driver hul= new Driver() { Id = 22, Name = "Hulkenberg", Points=0, DriverNumber= 27, Country= "ger", Birth= Driver.ToDatetime(1987, 08, 19)};

            #endregion

            Race italy = new Race() { Id = 1, Drivers = new List<Driver>(), Country = "Italy", RaceDate = Race.ToDatetime(2022, 04, 24), SeasonId = s2022.Id, Season = s2022};
            Race monaco = new Race() { Id = 2, Drivers = new List<Driver>(), Country = "Monaco", RaceDate = Race.ToDatetime(2022, 05, 29), SeasonId = s2022.Id, Season = s2022};
            Race canada = new Race() { Id = 3, Drivers = new List<Driver>(), Country = "Canada", RaceDate = Race.ToDatetime(2022, 06, 19), SeasonId = s2022.Id, Season = s2022};
            Race hungary = new Race() { Id = 4, Drivers = new List<Driver>(), Country = "Hungary", RaceDate = Race.ToDatetime(2022, 07, 31), SeasonId = s2022.Id, Season = s2022};
            Race grBritain = new Race() { Id = 5, Drivers = new List<Driver>(), Country = "Great Britain", RaceDate = Race.ToDatetime(2022, 07, 03), SeasonId = s2022.Id, Season = s2022};

            List<Race> r = new List<Race>();

            r.Add(canada);
            r.Add(hungary);
            r.Add(grBritain);
            r.Add(italy);
            r.Add(monaco);


            modelBuilder.Entity<Driver>().HasData(ver, per, sai, lec, nor, ric, ham, rus, oco, alo,
                vet, str, mag, sch, gas, tsu, bot, zho, lat, hul, alb, dev);
            modelBuilder.Entity<Race>().HasData(italy, monaco, canada, hungary, grBritain);
            modelBuilder.Entity<Season>().HasData(s2022);

        }
    }
}
