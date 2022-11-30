using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Intefaces
{
    public interface ITeamLogic 
    {
        void Create(Team item);
        void Delete(int item);
        IEnumerable<Team> ReadAll();
        Team Read(int id);
        void Update(Team item);
    }
}
