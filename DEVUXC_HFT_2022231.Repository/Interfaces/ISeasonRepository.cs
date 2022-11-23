using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Models;


namespace DEVUXC_HFT_2022231.Repository.Interfaces
{
    public interface ISeasonRepository : IRepository<Season>
    {
        IEnumerable<Point> GetPoint(int SeasonId, int DriverNumber);
        IQueryable<Race> GetRaces(int SeasonId, int RaceId);
    }
}
