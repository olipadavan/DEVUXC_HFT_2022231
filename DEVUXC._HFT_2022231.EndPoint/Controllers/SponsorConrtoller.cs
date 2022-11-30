using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SponsorController : Controller
    {
        ISponsorLogic sl;
        public SponsorController(ISponsorLogic sl)
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
            sl.Delete(id);
        }

        [HttpPost]
        public void Post([FromBody] Sponsor circuit)
        {
            sl.Create(circuit);
        }

        [HttpPut]
        public void Update([FromBody] Sponsor circuit)
        {
            sl.Update(circuit);
        }
    }
}

