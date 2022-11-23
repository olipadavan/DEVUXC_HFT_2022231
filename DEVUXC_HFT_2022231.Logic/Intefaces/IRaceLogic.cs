using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface IRaceLogic 
    {
        void Create(Race item);
        void Delete(int item);
        IEnumerable<Race> ReadAll();
        Race Read(int id);
        void Update(Race item);
        IQueryable<Driver> GetAllDrivers(int RaceId);
    }
}
