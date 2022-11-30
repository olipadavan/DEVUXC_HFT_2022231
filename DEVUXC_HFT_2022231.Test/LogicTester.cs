using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Repository.Repositories;
using DEVUXC_HFT_2022231.Repository;
using System.Xml;
using Moq;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Logic.Logics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.ExceptionServices;
using DEVUXC_HFT_2022231.Models.Useless;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace DEVUXC_HFT_2022231.Test
{
    [TestFixture]
    public class SeasonLogicTester
    {
        SeasonLogic Sl;
        Mock<IRepository<Season>> MockSeasonRepo;
        List<Season> seasons = new List<Season>();
        List<Team> teams = new List<Team>();
        List<Sponsor> sponsors = new List<Sponsor>();


        [SetUp]
        public void Init()
        {

            Season s2022 = new Season() { Id = 1, SeasonYear = 2022 };
            
            Driver ver = new Driver() { Name = "Verstappen", DriverNumber = 1 };
            Driver per = new Driver() { Name = "Perez", DriverNumber = 11 };
            Driver sai = new Driver() { Name = "Sainz", DriverNumber = 55 };
            Driver lec = new Driver() { Name = "Leclerc", DriverNumber = 16 };
            Driver nor = new Driver() { Name = "Norris", DriverNumber = 4 };
            Driver ric = new Driver() { Name = "Riccardo", DriverNumber = 3 };
            Driver ham = new Driver() { Name = "Hamilton", DriverNumber = 44 };
            Driver rus = new Driver() { Name = "Russel", DriverNumber = 63 };

            Team Redbull = new Team() { Id = 1, Name = "Redbull", Drivers = { ver, per }, SeasonId = s2022.Id };
            Team Ferrari = new Team() { Id = 2, Name = "Ferrari", Drivers = { sai, nor }, SeasonId = s2022.Id };
            Team Mercedes = new Team() { Id = 3, Name = "Mercedes", Drivers = { ham, rus }, SeasonId = s2022.Id };
            Team Mclaren = new Team() { Id = 4, Name = "Mclaren", Drivers = { ric, nor }, SeasonId = s2022.Id };

            teams.Add(Redbull);
            teams.Add(Ferrari);
            teams.Add(Mercedes);
            teams.Add(Mclaren);

            Sponsor Shell = new Sponsor() { Id = 1, Name = "Shell", Money = 800, TeamId = Ferrari.Id };
            Sponsor Snapdragon = new Sponsor() { Id = 2, Name = "Snapdragon", Money = 950, TeamId = Ferrari.Id };
            Sponsor Petronas = new Sponsor() { Id = 3, Name = "Petronas", Money = 1900, TeamId = Mercedes.Id };
            Sponsor Teamviever = new Sponsor() { Id = 4, Name = "Team Viewer", Money = 600, TeamId = Mercedes.Id };
            Sponsor Honda = new Sponsor() { Id = 5, Name = "Honda", Money = 500, TeamId = Redbull.Id };
            Sponsor Oracle = new Sponsor() { Id = 6, Name = "Oracle", Money = 1700, TeamId = Redbull.Id };
            Sponsor Rolex = new Sponsor() { Id = 7, Name = "Rolex", Money = 1500, TeamId = Mclaren.Id };
            Sponsor vmware = new Sponsor() { Id = 8, Name = "WMware", Money = 1000, TeamId = Mclaren.Id };


            //sponsors.Add(Shell, Shell1, Snapdragon, Snapdragon1, Petronas, Petronas1,
            //    Teamviever, Teamviever1, Honda, Honda1, Oracle, Oracle1, Rolex, Rolex1, vmware, vmware1);

            sponsors.Add(Shell);
            sponsors.Add(Snapdragon);
            sponsors.Add(Petronas);
            sponsors.Add(Teamviever);
            sponsors.Add(Honda);
            sponsors.Add(Oracle);
            sponsors.Add(Rolex);
            sponsors.Add(vmware);

            seasons.Add(s2022);
            foreach (var team in s2022.Teams)
            {
                foreach (var sponsor in team.Sponsors)
                {
                    team.Sponsors.Add(sponsor);
                }
                s2022.Teams.Add(team);
            }

            seasons.Add(s2022);
            var q = seasons.AsQueryable();

            MockSeasonRepo = new Mock<IRepository<Season>>();
            MockSeasonRepo.Setup(s => s.ReadAll()).Returns(q);

            Sl = new SeasonLogic(MockSeasonRepo.Object);
        }

        //5 db non-crud, 3 db create és 2 szabadon választott egyéb teszt
        [Test]
        public void DeleteTest()
        {
            Sl.Delete(1);

            MockSeasonRepo
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
        [Test]
        public void CreateTest()
        {
            var s = new Season() { Id = 500, SeasonYear= 1 };
            Sl.Create(s);

            MockSeasonRepo.Verify();
        }

        [Test]
        public void GetTeamsTest()
        {
            int SeasonId = 1;

            var res = Sl.GetTeams(SeasonId);

            var exp = from s in seasons where s.Id == SeasonId select s.Teams;
            ;
            //Assert.That(res, Is.EqualTo(exp));
        }
        [Test]
        public void MostMoneyTest()
        {
            int SeasonId = 1;

            //var res = Sl.MostMoney(SeasonId);
            //var exp = teams.Where(t => t.SeasonId == SeasonId).Max(t => t.Sponsors.Sum(s => s.Money));
            //Assert.That(res, Is.EqualTo(exp));
        }
        

        [Test]
        public void GetSponsorTest()
        {
            //int SeasonId = 1;
            //int TeamId = 1;
            //var res = Sl.GetSponsors(SeasonId, TeamId);
            //var seasonarray = seasons.ToArray();
            //var teamarray = seasonarray[SeasonId].Teams.ToArray();
            //var exp = teamarray[TeamId].Sponsors;
            //;
            //Assert.That(res, Is.EqualTo(exp));

        }

        [Test]
        public void RichestSponsor()
        {
            int SeasonId = 1;
            //var res = Sl.RichestSponsor(SeasonId);
            //var exp = sponsors.Where(s=>s.Money == sponsors.Max(s => s.Money));
            //Assert.That(res, Is.EqualTo(exp));
        }
    }
    [TestFixture]
    public class TeamLogicTester
    {
        TeamLogic Tl;
        Mock<IRepository<Team>> MockSeasonRepo;
        List<Season> seasons = new List<Season>();
        List<Team> teams = new List<Team>();
        List<Sponsor> sponsors = new List<Sponsor>();


        [SetUp]
        public void Init()
        {

            Season s2022 = new Season() { Id = 1, SeasonYear = 2022 };

            Driver ver = new Driver() { Name = "Verstappen", DriverNumber = 1 };
            Driver per = new Driver() { Name = "Perez", DriverNumber = 11 };
            Driver sai = new Driver() { Name = "Sainz", DriverNumber = 55 };
            Driver lec = new Driver() { Name = "Leclerc", DriverNumber = 16 };
            Driver nor = new Driver() { Name = "Norris", DriverNumber = 4 };
            Driver ric = new Driver() { Name = "Riccardo", DriverNumber = 3 };
            Driver ham = new Driver() { Name = "Hamilton", DriverNumber = 44 };
            Driver rus = new Driver() { Name = "Russel", DriverNumber = 63 };

            Team Redbull = new Team() { Id = 1, Name = "Redbull", Drivers = { ver, per }, SeasonId = s2022.Id };
            Team Ferrari = new Team() { Id = 2, Name = "Ferrari", Drivers = { sai, nor }, SeasonId = s2022.Id };
            Team Mercedes = new Team() { Id = 3, Name = "Mercedes", Drivers = { ham, rus }, SeasonId = s2022.Id };
            Team Mclaren = new Team() { Id = 4, Name = "Mclaren", Drivers = { ric, nor }, SeasonId = s2022.Id };

            teams.Add(Redbull);
            teams.Add(Ferrari);
            teams.Add(Mercedes);
            teams.Add(Mclaren);

            Sponsor Shell = new Sponsor() { Id = 1, Name = "Shell", Money = 800, TeamId = Ferrari.Id };
            Sponsor Snapdragon = new Sponsor() { Id = 2, Name = "Snapdragon", Money = 950, TeamId = Ferrari.Id };
            Sponsor Petronas = new Sponsor() { Id = 3, Name = "Petronas", Money = 1900, TeamId = Mercedes.Id };
            Sponsor Teamviever = new Sponsor() { Id = 4, Name = "Team Viewer", Money = 600, TeamId = Mercedes.Id };
            Sponsor Honda = new Sponsor() { Id = 5, Name = "Honda", Money = 500, TeamId = Redbull.Id };
            Sponsor Oracle = new Sponsor() { Id = 6, Name = "Oracle", Money = 1700, TeamId = Redbull.Id };
            Sponsor Rolex = new Sponsor() { Id = 7, Name = "Rolex", Money = 1500, TeamId = Mclaren.Id };
            Sponsor vmware = new Sponsor() { Id = 8, Name = "WMware", Money = 1000, TeamId = Mclaren.Id };

            sponsors.Add(Shell);
            sponsors.Add(Snapdragon);
            sponsors.Add(Petronas);
            sponsors.Add(Teamviever);
            sponsors.Add(Honda);
            sponsors.Add(Oracle);
            sponsors.Add(Rolex);
            sponsors.Add(vmware);

            seasons.Add(s2022);

            var q = teams.AsQueryable();

            MockSeasonRepo = new Mock<IRepository<Team>>();
            MockSeasonRepo.Setup(s => s.ReadAll()).Returns(q);

            Tl = new TeamLogic(MockSeasonRepo.Object);
        }
        [Test]
        public void CreateTest()
        {
            var s = new Team() { Id = 500, Name = "asd" };
            Tl.Create(s);

            MockSeasonRepo.Verify();
        }
        [Test]
        public void DeleteTest()
        {
            Tl.Delete(1);

            MockSeasonRepo
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
    }


    [TestFixture]
    public class SponsorLogicTester
    {
        SponsorLogic Sl;
        Mock<IRepository<Sponsor>> MockSeasonRepo;
        List<Season> seasons = new List<Season>();
        List<Team> teams = new List<Team>();
        List<Sponsor> sponsors = new List<Sponsor>();


        [SetUp]
        public void Init()
        {

            Season s2022 = new Season() { Id = 1, SeasonYear = 2022 };

            Driver ver = new Driver() { Name = "Verstappen", DriverNumber = 1 };
            Driver per = new Driver() { Name = "Perez", DriverNumber = 11 };
            Driver sai = new Driver() { Name = "Sainz", DriverNumber = 55 };
            Driver lec = new Driver() { Name = "Leclerc", DriverNumber = 16 };
            Driver nor = new Driver() { Name = "Norris", DriverNumber = 4 };
            Driver ric = new Driver() { Name = "Riccardo", DriverNumber = 3 };
            Driver ham = new Driver() { Name = "Hamilton", DriverNumber = 44 };
            Driver rus = new Driver() { Name = "Russel", DriverNumber = 63 };

            Team Redbull = new Team() { Id = 1, Name = "Redbull", Drivers = { ver, per }, SeasonId = s2022.Id };
            Team Ferrari = new Team() { Id = 2, Name = "Ferrari", Drivers = { sai, nor }, SeasonId = s2022.Id };
            Team Mercedes = new Team() { Id = 3, Name = "Mercedes", Drivers = { ham, rus }, SeasonId = s2022.Id };
            Team Mclaren = new Team() { Id = 4, Name = "Mclaren", Drivers = { ric, nor }, SeasonId = s2022.Id };

            teams.Add(Redbull);
            teams.Add(Ferrari);
            teams.Add(Mercedes);
            teams.Add(Mclaren);

            Sponsor Shell = new Sponsor() { Id = 1, Name = "Shell", Money = 800, TeamId = Ferrari.Id };
            Sponsor Snapdragon = new Sponsor() { Id = 2, Name = "Snapdragon", Money = 950, TeamId = Ferrari.Id };
            Sponsor Petronas = new Sponsor() { Id = 3, Name = "Petronas", Money = 1900, TeamId = Mercedes.Id };
            Sponsor Teamviever = new Sponsor() { Id = 4, Name = "Team Viewer", Money = 600, TeamId = Mercedes.Id };
            Sponsor Honda = new Sponsor() { Id = 5, Name = "Honda", Money = 500, TeamId = Redbull.Id };
            Sponsor Oracle = new Sponsor() { Id = 6, Name = "Oracle", Money = 1700, TeamId = Redbull.Id };
            Sponsor Rolex = new Sponsor() { Id = 7, Name = "Rolex", Money = 1500, TeamId = Mclaren.Id };
            Sponsor vmware = new Sponsor() { Id = 8, Name = "WMware", Money = 1000, TeamId = Mclaren.Id };

            sponsors.Add(Shell);
            sponsors.Add(Snapdragon);
            sponsors.Add(Petronas);
            sponsors.Add(Teamviever);
            sponsors.Add(Honda);
            sponsors.Add(Oracle);
            sponsors.Add(Rolex);
            sponsors.Add(vmware);

            seasons.Add(s2022);

            var q = sponsors.AsQueryable();

            MockSeasonRepo = new Mock<IRepository<Sponsor>>();
            MockSeasonRepo.Setup(s => s.ReadAll()).Returns(q);

            Sl = new SponsorLogic(MockSeasonRepo.Object);
        }
        [Test]
        public void CreateTest()
        {
            var s = new Sponsor() { Id = 500, Name = "Asd", Money = 0, };
            Sl.Create(s);

            MockSeasonRepo.Verify();
        }
        [Test]
        public void DeleteTest()
        {
            Sl.Delete(1);

            MockSeasonRepo
                .Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
        }
    }

}
