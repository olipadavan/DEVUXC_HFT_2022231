using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace DEVUXC_HFT_2022231.EndPoint.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        IDriverLogic dl;
        public DriverController(IDriverLogic dl)
        {
            this.dl = dl;
        }
        [HttpGet]
        public IEnumerable<Driver> ReadAll()
        {
            return dl.ReadAll();
        }
        [HttpGet]
        public void Create(Driver d)
        {
            dl.Create(d);
        }
        [HttpDelete]
        public void Delete(int id)
        {
            dl.Delete(id);
        }
        [HttpGet]
        public void Update(Driver d)
        {
            dl.Update(d);
        }
        [HttpGet("{id}")]
        public Driver Read(int id)
        {
            return dl.Read(id);
        }
    }
}