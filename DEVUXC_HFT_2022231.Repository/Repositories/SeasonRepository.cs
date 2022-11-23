using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System.Collections.Immutable;

namespace DEVUXC_HFT_2022231.Repository.Repositories
{
    public class SeasonRepository : Repository<Season>, ISeasonRepository
    {
        public SeasonRepository(F1DbContext ctx) : base(ctx)
        {
        }

        public IEnumerable<Point> GetPoint(int SeasonId, int DriverNumber)
        {
            var resoult = ctx.Seasons.Where(season => season.Id == SeasonId).Select(season => season.Standing.FirstOrDefault(d => d.DriverNumber == DriverNumber));
            
            return resoult;
        }

        public IQueryable<Race> GetRaces(int SeasonId, int RaceId)
        {
            var resoult = ctx.Seasons.Where(s => s.Id == SeasonId).Select(s => s.Races.Where(r => r.Id == RaceId));
            return (IQueryable<Race>)resoult;
        }
    }
}
