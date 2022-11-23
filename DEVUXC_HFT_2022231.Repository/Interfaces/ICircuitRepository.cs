using DEVUXC_HFT_2022231.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Interfaces
{
    public interface ICircuitRepository : IRepository<Circuit>
    {
        void trackChange(int CircuitId, double newLength);
        IQueryable<double> GetTrackLenght(int circuitId);
    }
}
