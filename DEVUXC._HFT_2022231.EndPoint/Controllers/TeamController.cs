using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        ITeamLogic tl;
        IHubContext<SignalRHub> hub;
        public TeamController(ITeamLogic tl, IHubContext<SignalRHub> hub)
        {
            this.tl = tl;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Team> ReadAll()
        {
            return tl.ReadAll();
        }

        [HttpGet("{id}")]
        public Team Read(int id)
        {
            return tl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ToDelete = tl.Read(id);
            tl.Delete(id);
            this.hub.Clients.All.SendAsync("TeamDeleted", ToDelete);
        }

        [HttpPost]
        public void Post([FromBody] Team team)
        {
            tl.Create(team);
            this.hub.Clients.All.SendAsync("TeamCreated", team);
        }

        [HttpPut]
        public void Update([FromBody] Team team)
        {
            tl.Update(team);
            this.hub.Clients.All.SendAsync("TeamCreated", team);

        }
    }
}
