using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.Endpoint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        ITeamLogic tl;
        public TeamController(ITeamLogic tl)
        {
            this.tl = tl;
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
            tl.Delete(id);
        }

        [HttpPost]
        public void Post([FromBody] Team race)
        {
            tl.Create(race);
        }

        [HttpPut]
        public void Update([FromBody] Team race)
        {
            tl.Update(race);
        }
    }
}
