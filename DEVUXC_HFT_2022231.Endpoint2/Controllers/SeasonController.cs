using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("api/[controller]")]
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

        [HttpGet("{id}")]
        public IEnumerable<Team> GetTeams(int SeasonId)
        {
            return sl.GetTeams(SeasonId);
        }

        [HttpGet("{id}")]
        public int MostMoney(int SeasonId)
        {
            return sl.MostMoney(SeasonId);

        }

        [HttpGet("{id}")]
        public IEnumerable<Driver> DriversInTeam(int SeasonId, int TeamId)
        {
            return sl.DriversInTeam(SeasonId, TeamId);

        }

        [HttpGet("{id}")]
        public IEnumerable<int> DriverNumbers(int SeasonId, int TeamId)
        {
            return sl.DriverNumbers(SeasonId, TeamId);

        }

        [HttpGet("{id}")]
        public IEnumerable<Sponsor> RichestSponsor(int SeasonId)
        {
            return sl.RichestSponsor(SeasonId);

        }
    }
}
