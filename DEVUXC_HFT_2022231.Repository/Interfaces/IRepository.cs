using DEVUXC_HFT_2022231.Models.Useless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVUXC_HFT_2022231.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IQueryable<T> ReadAll();
        T Read(int id);
    }
}
