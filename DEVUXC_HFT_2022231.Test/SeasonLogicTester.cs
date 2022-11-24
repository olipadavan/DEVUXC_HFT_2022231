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

namespace DEVUXC_HFT_2022231.Test
{
    [TestFixture]
    public class SeasonLogicTester
    {
        SeasonLogic Sl;
        Mock<ISeasonRepository> MockSeasonRepo;
        [SetUp]
        public void Init()
        {
            Season sFake = new Season(2049) { Id = 1 };
            var Drivers = new List<Driver>();
            
                Drivers.Add(new Driver() { Id = 1, Name = "Verstappen", Points = 0, DriverNumber = 1, Country = "ned", Birth = Driver.ToDatetime(1997, 09, 30), WorldChampTitles = 2 });
                Drivers.Add(new Driver() { Id = 2, Name = "Perez", Points = 0, DriverNumber = 11, Country = "mex", Birth = Driver.ToDatetime(1990, 01, 26) });
                Drivers.Add(new Driver() { Id = 3, Name = "Sainz", Points = 0, DriverNumber = 55, Country = "esp", Birth = Driver.ToDatetime(1994, 09, 01) });
                Drivers.Add(new Driver() { Id = 4, Name = "Leclerc", Points = 0, DriverNumber = 16, Country = "mon", Birth = Driver.ToDatetime(1997, 10, 16) });


            Race italy = new Race() { Id = 1, Drivers = new List<Driver>(), Country = "Italy", RaceDate = Race.ToDatetime(2022, 04, 24), SeasonId = sFake.Id, Season = sFake };
            Race monaco = new Race() { Id = 2, Drivers = new List<Driver>(), Country = "Monaco", RaceDate = Race.ToDatetime(2022, 05, 29), SeasonId = sFake.Id, Season = sFake };
            Race canada = new Race() { Id = 3, Drivers = new List<Driver>(), Country = "Canada", RaceDate = Race.ToDatetime(2022, 06, 19), SeasonId = sFake.Id, Season = sFake };
            Race hungary = new Race() { Id = 4, Drivers = new List<Driver>(), Country = "Hungary", RaceDate = Race.ToDatetime(2022, 07, 31), SeasonId = sFake.Id, Season = sFake };
            Race grBritain = new Race() { Id = 5, Drivers = new List<Driver>(), Country = "Great Britain", RaceDate = Race.ToDatetime(2022, 07, 03), SeasonId = sFake.Id, Season = sFake };

            List<Race> r = new List<Race>();

            r.Add(canada);
            r.Add(hungary);
            r.Add(grBritain);
            r.Add(italy);
            r.Add(monaco);

            Circuit cirItaly = new Circuit() { Id = 1, Name = "Autodromo Enzo e Dino Ferrari", Length = 4.909, Laps = 63, Race = italy, RaceId = italy.Id };
            Circuit cirMonaco = new Circuit() { Id = 2, Name = "Circuit de Monaco", Length = 3.337, Laps = 78, Race = monaco, RaceId = monaco.Id };
            Circuit cirCanada = new Circuit() { Id = 3, Name = "Circuit Gilles-Villeneuve", Length = 4.361, Laps = 70, Race = canada, RaceId = canada.Id };
            Circuit cirHungary = new Circuit() { Id = 4, Name = "Hungaroring", Length = 4.381, Laps = 70, Race = hungary, RaceId = hungary.Id };
            Circuit cirGrB = new Circuit() { Id = 5, Name = "Silverstone Circuit", Length = 5.891, Laps = 52, Race = grBritain, RaceId = grBritain.Id };

            italy.Circuit = cirItaly;
            italy.CircuitId = cirItaly.Id;
            monaco.Circuit = cirMonaco;
            monaco.CircuitId = cirMonaco.Id;
            canada.Circuit = cirCanada;
            canada.CircuitId = cirCanada.Id;
            hungary.Circuit = cirHungary;
            hungary.CircuitId = cirHungary.Id;
            grBritain.Circuit = cirGrB;
            grBritain.CircuitId = cirGrB.Id;

            
        }

    }
}
