using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Repositories
{
    public class RaceRepository : Repository<Race>, IRaceRepository
    {
        public RaceRepository(F1DbContext ctx) : base(ctx)
        {
        }

        public IQueryable<Driver> GetAllDrivers(int RaceId)
        {
            return (IQueryable<Driver>)ctx.Races.Where(r => r.Id == RaceId).Select(d => d.Drivers);
        }
    }
}
