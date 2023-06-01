using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SeasonController : ControllerBase
    {
        ISeasonLogic sl;
        IHubContext<SignalRHub> hub;
        public SeasonController(ISeasonLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
            this.hub = hub;
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
            var ToDelete = sl.Read(id);
            sl.Delete(id);
            this.hub.Clients.All.SendAsync("SeasonDeleted", ToDelete);
        }

        [HttpPost]
        public void Post([FromBody] Season season)
        {
            sl.Create(season);
            this.hub.Clients.All.SendAsync("SeasonCreated", season);
        }

        [HttpPut]
        public void Update([FromBody] Season season)
        {
            sl.Update(season);
            this.hub.Clients.All.SendAsync("SeasonUpdated", season);
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
