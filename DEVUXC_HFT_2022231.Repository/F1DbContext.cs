using Castle.Core.Internal;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository
{
    public class F1DbContext : DbContext
    {
        
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Sponsor> Sponsors { get; set; }
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
                    .UseInMemoryDatabase("F1db")
                    .EnableSensitiveDataLogging()
                    .UseLazyLoadingProxies();
            }
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Season>(entity =>
            {
                entity.HasMany(season => season.Teams)
                    .WithOne(team => team.Season)
                    .HasForeignKey(team => team.SeasonId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasMany(team => team.Sponsors)
                    .WithOne(sponsor => sponsor.Team)
                    .HasForeignKey(sponsor => sponsor.TeamId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            Season s2022 = new Season() { Id = 1, SeasonYear = 2022 };
            Season s2021 = new Season() { Id = 2, SeasonYear = 2021 };
            Season s2020 = new Season() { Id = 3, SeasonYear = 2020 };

            Driver ver = new Driver() {Name = "Verstappen",DriverNumber = 1 };
            Driver per = new Driver() {Name = "Perez",DriverNumber = 11};
            Driver sai = new Driver() {Name = "Sainz", DriverNumber = 55};
            Driver lec = new Driver() {Name = "Leclerc",  DriverNumber = 16};
            Driver nor = new Driver() {Name = "Norris",  DriverNumber = 4 };
            Driver ric = new Driver() {Name = "Riccardo", DriverNumber = 3 };
            Driver ham = new Driver() {Name = "Hamilton",  DriverNumber = 44 };
            Driver rus = new Driver() {Name = "Russel", DriverNumber = 63 };
            

            Team Redbull = new Team() { Id = 1,Name = "Redbull", Drivers = { ver, per } , SeasonId = s2022.Id};
            Team Redbull1 = new Team() { Id = 2, Name = "Redbull1", Drivers = { ver, lec }, SeasonId = s2020.Id};
            Team Ferrari = new Team() { Id = 3, Name = "Ferrari", Drivers = { sai, nor }, SeasonId = s2020.Id};
            Team Ferrari1 = new Team() { Id = 4, Name = "Ferrari1", Drivers = { sai, lec }, SeasonId = s2021.Id};
            Team Mercedes = new Team() { Id = 5, Name = "Mercedes", Drivers = { ham, per }, SeasonId = s2022.Id};
            Team Mercedes1 = new Team() { Id = 6, Name = "Mercedes1", Drivers = { ham, rus }, SeasonId = s2020.Id};
            Team Mclaren = new Team() { Id = 7, Name = "Mclaren", Drivers = { ric, nor }, SeasonId = s2022.Id};
            Team Mclaren1 = new Team() { Id = 8, Name = "Mclaren", Drivers = { ric, rus }, SeasonId = s2021.Id};
            

            Sponsor Shell = new Sponsor() { Id= 1, Name = "Shell", Money = 800,  TeamId = Ferrari.Id};
            Sponsor Shell1 = new Sponsor() { Id= 2, Name = "Shell", Money = 1000, TeamId = Ferrari1.Id};
            Sponsor Snapdragon = new Sponsor() { Id= 3, Name = "Snapdragon", Money = 950, TeamId = Ferrari.Id};
            Sponsor Snapdragon1 = new Sponsor() { Id= 4, Name = "Snapdragon", Money = 800, TeamId = Ferrari1.Id};
            Sponsor Petronas = new Sponsor() { Id= 5, Name = "Petronas", Money = 1900,  TeamId = Mercedes.Id};
            Sponsor Petronas1 = new Sponsor() { Id= 6, Name = "Petronas", Money = 2000, TeamId = Mercedes1.Id};
            Sponsor Teamviever = new Sponsor() { Id= 7, Name = "Team Viewer", Money = 600, TeamId = Mercedes.Id};
            Sponsor Teamviever1 = new Sponsor() { Id= 8, Name = "Team Viewer", Money = 1300, TeamId = Mercedes1.Id};
            Sponsor Honda = new Sponsor() { Id= 9, Name = "Honda", Money = 500, TeamId = Redbull1.Id};
            Sponsor Honda1 = new Sponsor() { Id= 10, Name = "Honda", Money = 900, TeamId = Redbull.Id};
            Sponsor Oracle = new Sponsor() { Id= 11, Name = "Oracle", Money = 1700, TeamId = Redbull1.Id};
            Sponsor Oracle1 = new Sponsor() { Id= 12, Name = "Oracle", Money = 1500, TeamId = Redbull.Id};
            Sponsor Rolex = new Sponsor() { Id= 13, Name = "Rolex", Money = 1500, TeamId = Mclaren1.Id};
            Sponsor Rolex1 = new Sponsor() { Id= 14, Name = "Rolex", Money = 1800, TeamId = Mclaren.Id};
            Sponsor vmware = new Sponsor() { Id= 15, Name = "WMware", Money = 1000,  TeamId = Mclaren1.Id};
            Sponsor vmware1 = new Sponsor() { Id= 16, Name = "WMware", Money = 1200, TeamId = Mclaren.Id};

            

            
            modelBuilder.Entity<Season>().HasData(s2021, s2020, s2022);
            modelBuilder.Entity<Team>().HasData(Redbull, Redbull1, Ferrari, Ferrari1, Mercedes, Mercedes1, Mclaren, Mclaren1);
            modelBuilder.Entity<Sponsor>().HasData(Shell, Petronas, Snapdragon, Teamviever, Honda, Oracle, Rolex, vmware, Shell1, Petronas1, Snapdragon1, Teamviever1, Honda1, Oracle1, Rolex1, vmware1);

        }
    }
}
