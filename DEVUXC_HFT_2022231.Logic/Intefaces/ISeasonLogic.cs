using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface ISeasonLogic
    {
        void Create(Season item);
        void Delete(int item);
        IEnumerable<Season> ReadAll();
        Season Read(int id);
        void Update(Season item);
        //all teams from certain season
        IEnumerable<Team> GetTeams(int SeasonId);
        //the team with the most combined sponsor money ---works---
        Team MostMoney(int SeasonId);
        //drivers from a crertain season and team
        IEnumerable<Driver> DriversInTeam(int SeasonId, int TeamId);
        //Number of sponsors from a crertain season and team
        IEnumerable<Sponsor> GetSponsors(int SeasonId, int TeamId);
        //the sponsor with the most money
        Sponsor RichestSponsor(int SeasonId);
    }
}
