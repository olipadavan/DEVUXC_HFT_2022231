using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Logic.Logics;
using DEVUXC_HFT_2022231.Models;
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
    }
}
