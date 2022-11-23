using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface ISeasonLogic
    {
        void Create(Season item);
        void Delete(int item);
        IEnumerable<Season> ReadAll();
        Season Read(int id);
        void Update(Season item);
        IEnumerable<Point> GetPoint(int SeasonId, int DriverNumber);
        IQueryable<Race> GetRaces(int SeasonId, int RaceId);
        IQueryable<Circuit> LongestCircuitInTheSeason(int SeasonId);
    }
}
