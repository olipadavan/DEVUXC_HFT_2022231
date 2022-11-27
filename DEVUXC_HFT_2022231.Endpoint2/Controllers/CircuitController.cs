using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.Endpoint2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CircuitController : Controller
    {
        ICircuitLogic cl;
        public CircuitController(ICircuitLogic cl)
        {
            this.cl = cl;
        }

        [HttpGet]
        public IEnumerable<Circuit> ReadAll()
        {
            return cl.ReadAll();
        }

        [HttpGet("{id}")]
        public Circuit Read(int id)
        {
            return cl.Read(id);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }

        [HttpPost]
        public void Post([FromBody] Circuit circuit)
        {
            cl.Create(circuit);
        }

        [HttpPut]
        public void Update([FromBody] Circuit circuit)
        {
            cl.Update(circuit);
        }
    }
}
