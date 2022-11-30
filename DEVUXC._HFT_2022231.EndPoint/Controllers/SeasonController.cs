using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        ISeasonLogic sl;
        public SeasonController(ISeasonLogic sl)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Season> ReadAll()
        {
            return sl.ReadAll();
        }

        [HttpGet("{id}")]
        public Season Read(int id)
        {
            return sl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            sl.Delete(id);
        }

        [HttpPost]
        public void Post([FromBody] Season season)
        {
            sl.Create(season);
        }

        [HttpPut]
        public void Update([FromBody] Season season)
        {
            sl.Update(season);
        }

        [HttpGet("{SeasonId}")]
        public IEnumerable<Team> GetTeams(int SeasonId)
        {
            return sl.GetTeams(SeasonId);
        }

        [HttpGet("{SeasonId}")]
        public IEnumerable<Team> MostMoney(int SeasonId)
        {
            return sl.MostMoney(SeasonId);

        }

        [HttpGet("{SeasonId},{TeamId}")]
        public IEnumerable<Driver> DriversInTeam(int SeasonId, int TeamId)
        {
            return sl.DriversInTeam(SeasonId, TeamId);

        }

        [HttpGet("{SeasonId},{TeamId}")]
        public IEnumerable<Sponsor> GetSponsors(int SeasonId, int TeamId)
        {
            return sl.GetSponsors(SeasonId, TeamId);

        }

        [HttpGet("{SeasonId}")]
        public IEnumerable<Sponsor> RichestSponsor(int SeasonId)
        {
            return sl.RichestSponsor(SeasonId);

        }
    }
}
