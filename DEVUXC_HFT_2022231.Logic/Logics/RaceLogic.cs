using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Logics
{
    public class RaceLogic : IRaceLogic
    {
        IRaceRepository racerepo;
        public RaceLogic(IRaceRepository racerepo)
        {
            this.racerepo = racerepo;
        }

        public void Create(Race item)
        {
            racerepo.Create(item);
        }

        public void Delete(int item)
        {
            racerepo.Delete(item);
        }

        public IQueryable<Driver> GetAllDrivers(int RaceId)
        {
            return racerepo.GetAllDrivers(RaceId) ?? throw new ArgumentException("Race with the specified id does not exists. So it has no Drivers either.");
        }

        public Race Read(int id)
        {
            return racerepo.Read(id) ?? throw new ArgumentException("Race with the specified id does not exists.");

        }

        public IEnumerable<Race> ReadAll()
        {
            return racerepo.ReadAll();
        }

        public void Update(Race item)
        {
            racerepo.Update(item);
        }
    }
}
