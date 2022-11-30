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
    public class SponsorLogic : ISponsorLogic
    {
        IRepository<Sponsor> cirrepo;
        public SponsorLogic(IRepository<Sponsor> cirrepo)
        {
            this.cirrepo = cirrepo;
        }

        public void Create(Sponsor item)
        {
            cirrepo.Create(item);
        }

        public void Delete(int item)
        {
            cirrepo.Delete(item);
        }

        public Sponsor Read(int id)
        {
            return cirrepo.Read(id) ?? throw new ArgumentException("Circuit with the specified id does not exists.");
        }

        public IEnumerable<Sponsor> ReadAll()
        {
            return cirrepo.ReadAll();
        }

        

        public void Update(Sponsor item)
        {
            cirrepo.Update(item);
        }
    }
}
