using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Repositories
{
    public class CircuitRepository : Repository<Circuit>, ICircuitRepository
    {
        public CircuitRepository(F1DbContext ctx) : base(ctx)
        {
        }

        public IQueryable<double> GetTrackLenght(int circuitId)
        {
            return ctx.Races.Where(r => r.Circuit.Id == circuitId).Select(r=>r.Circuit.Length);
        }

        public void trackChange(int CircuitId, double newLength)
        {
            var old = Read(CircuitId);
            old.Length = newLength;
            ctx.SaveChanges();
        }
    }
}
