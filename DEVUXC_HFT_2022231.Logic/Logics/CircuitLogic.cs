using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using DEVUXC_HFT_2022231.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Logics
{
    public class CircuitLogic : ICircuitLogic
    {
        ICircuitRepository cirrepo;
        public CircuitLogic(ICircuitRepository cirrepo)
        {
            this.cirrepo = cirrepo;
        }

        public void Create(Circuit item)
        {
            cirrepo.Create(item);
        }

        public void Delete(int item)
        {
            cirrepo.Delete(item);
        }

        public IQueryable<double> GetTrackLenght(int circuitId)
        {
            return cirrepo.GetTrackLenght(circuitId) ?? throw new ArgumentException("Circuit with the specified id does not exists.");
        }

        public Circuit Read(int id)
        {
            return cirrepo.Read(id) ?? throw new ArgumentException("Circuit with the specified id does not exists.");
        }

        public IEnumerable<Circuit> ReadAll()
        {
            return cirrepo.ReadAll();
        }

        public void trackChange(int CircuitId, double newLength)
        {
            cirrepo.trackChange(CircuitId, newLength);
        }

        public void Update(Circuit item)
        {
            cirrepo.Update(item);
        }
    }
}
