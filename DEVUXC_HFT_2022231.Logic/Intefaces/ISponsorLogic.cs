using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface ISponsorLogic
    {
        void Create(Sponsor item);
        void Delete(int item);
        IEnumerable<Sponsor> ReadAll();
        Sponsor Read(int id);
        void Update(Sponsor item);
        
    }
}
