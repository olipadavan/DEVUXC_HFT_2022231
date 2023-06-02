using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
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
        IRepository<Season> seasonrepo;
        public SeasonLogic(IRepository<Season> seasonRepository)
        {
            seasonrepo = seasonRepository;
        }

        public void Create(Season item)
        {
            seasonrepo.Create(item);
        }

        public void Delete(int item)
        {
            seasonrepo.Delete(item);
        }

        public IEnumerable<Driver> DriversInTeam(int SeasonId, int TeamId)
        {
            var a = seasonrepo.ReadAll().Where(s => s.Id == SeasonId).Select(s => s.Teams.Where(t=>t.Id == TeamId)).First();
            var b = a.Select(d => d.Drivers).First();
            return b;
        }

        public IEnumerable<Team> GetTeams(int SeasonId)
        {
            var a = (from s in seasonrepo.ReadAll()
                     where s.Id == SeasonId select s.Teams).FirstOrDefault();
            var b = seasonrepo.ReadAll().FirstOrDefault(s=> s.Id == SeasonId).Teams;

            return b;
        }

        public Team MostMoney(int SeasonId)
        {
            var a = seasonrepo.ReadAll().Where(s => s.Id == SeasonId).Max(s => s.Teams.OrderByDescending(t => t.Sponsors.Sum(s => s.Money))).FirstOrDefault();
            return a;
        }

        public IEnumerable<Sponsor> GetSponsors(int SeasonId, int TeamId)
        {
            var a = seasonrepo.ReadAll().Where(s => s.Id == SeasonId).Select(s => s.Teams.Where(t => t.Id == TeamId)).First();
            var b = a.Select(d => d.Sponsors).First();
            return b;
        }

        public Season Read(int id)
        {
            return seasonrepo.Read(id);       
        }

        public IEnumerable<Season> ReadAll()
        {
            return seasonrepo.ReadAll();
        }

        public Sponsor RichestSponsor(int SeasonId)
        {
            var a = seasonrepo.ReadAll().SelectMany(season => season.Teams).SelectMany(t => t.Sponsors).OrderByDescending(s => s.Money).First();
            return a;
        }

        public void Update(Season item)
        {
            seasonrepo.Update(item);
        }
    }
}
