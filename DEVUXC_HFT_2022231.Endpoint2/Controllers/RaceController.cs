using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.Endpoint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RaceController : Controller
    {
        IRaceLogic rl;
        public RaceController(IRaceLogic rl)
        {
            this.rl = rl;
        }

        [HttpGet]
        public IEnumerable<Race> ReadAll()
        {
            return rl.ReadAll();
        }

        [HttpGet("{id}")]
        public Race Read(int id)
        {
            return rl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            rl.Delete(id);
        }

        [HttpPost]
        public void Post([FromBody] Race race)
        {
            rl.Create(race);
        }

        [HttpPut]
        public void Update([FromBody] Race race)
        {
            rl.Update(race);
        }
    }
}
