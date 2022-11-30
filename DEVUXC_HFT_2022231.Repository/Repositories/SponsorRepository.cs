using DEVUXC_HFT_2022231.Models;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Repositories
{
    public class SponsorRepository : Repository<Sponsor>, IRepository<Sponsor>

    {
        public SponsorRepository(F1DbContext ctx) : base(ctx)
        {
        }

        
    }
}
