using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface ICircuitLogic
    {
        void Create(Circuit item);
        void Delete(int item);
        IEnumerable<Circuit> ReadAll();
        Circuit Read(int id);
        void Update(Circuit item);
        void trackChange(int CircuitId, double newLength);
        IQueryable<double> GetTrackLenght(int circuitId);
    }
}
