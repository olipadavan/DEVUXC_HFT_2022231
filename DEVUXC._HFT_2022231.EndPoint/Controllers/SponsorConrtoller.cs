using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Globalization;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SponsorController : Controller
    {
        ISponsorLogic sl;
        IHubContext<SignalRHub> hub;
        public SponsorController(ISponsorLogic sl, IHubContext<SignalRHub> hub)
        {
            this.sl = sl;
        }

        [HttpGet]
        public IEnumerable<Sponsor> ReadAll()
        {
            return sl.ReadAll();
        }

        [HttpGet("{id}")]
        public Sponsor Read(int id)
        {
            return sl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ToDelete = this.sl.Read(id);
            this.sl.Delete(id);
            this.hub.Clients.All.SendAsync("SponsorDeleted", ToDelete);
        }

        [HttpPost]
        public void Post([FromBody] Sponsor sponsor)
        {
            sl.Create(sponsor);
            this.hub.Clients.All.SendAsync("SponsorCreated", sponsor);

        }

        [HttpPut]
        public void Update([FromBody] Sponsor sponsor)
        {
            sl.Update(sponsor);
            this.hub.Clients.All.SendAsync("SponsorUpdated", sponsor);
        }
    }
}

