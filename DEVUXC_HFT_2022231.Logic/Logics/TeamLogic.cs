using DEVUXC_HFT_2022231.Logic.Intefaces;
using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Models.Useless;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Logic.Logics
{
    public class TeamLogic : ITeamLogic
    {
        IRepository<Team> racerepo;
        public TeamLogic(IRepository<Team> racerepo)
        {
            this.racerepo = racerepo;
        }

        public void Create(Team item)
        {
            racerepo.Create(item);
        }

        public void Delete(int item)
        {
            racerepo.Delete(item);
        }

        public Team Read(int id)
        {
            return racerepo.Read(id) ?? throw new ArgumentException("Team with the specified id does not exists.");

        }

        public IEnumerable<Team> ReadAll()
        {
            return racerepo.ReadAll();
        }

        public void Update(Team item)
        {
            racerepo.Update(item);
        }
    }
}
