using DEVUXC_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEVUXC_HFT_2022231.Repository.Interfaces;
using System.Collections.Immutable;
using System.Xml;
using System.Threading;
using DEVUXC_HFT_2022231.Models.Useless;

namespace DEVUXC_HFT_2022231.Repository.Repositories
{
    public class SeasonRepository : Repository<Season>, IRepository<Season>
    {
        public SeasonRepository(F1DbContext ctx) : base(ctx)
        {
        }

        
    }
}
