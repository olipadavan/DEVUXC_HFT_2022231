using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DEVUXC_HFT_2022231.Logic.Logics
{
    public class SeasonLogic : ISeasonLogic
    {
        ISeasonRepository seasonrepo;
        public SeasonLogic(ISeasonRepository seasonRepository) 
        { 
            seasonrepo = seasonRepository;
        }
        public void Create(Season season)
        {
            seasonrepo.Create(season);
        }

        public void Delete(int id)
        {
            seasonrepo.Delete(id);
        }

        public Season Read(int id)
        {
            return seasonrepo.Read(id) ?? throw new ArgumentException("Season with the specified id does not exists.");
        }

        public IEnumerable<Season> ReadAll()
        {
            return seasonrepo.ReadAll();
        }

        public void Update(Season car)
        {
            seasonrepo.Update(car);
        }
        public IEnumerable<Point> GetPoint(int SeasonId, int DriverNumber)
        {
            return seasonrepo.GetPoint(SeasonId, DriverNumber);
        }

        public IQueryable<Race> GetRaces(int SeasonId, int RaceId)
        {
            return seasonrepo.GetRaces(SeasonId, RaceId);
        }

        public IQueryable<Circuit> LongestCircuitInTheSeason(int SeasonId)
        {
            var longestcircuit = seasonrepo.Read(SeasonId).Races.OrderByDescending(r => r.Circuit.Length).First().Circuit;
            return longestcircuit;
        }
    }
}
