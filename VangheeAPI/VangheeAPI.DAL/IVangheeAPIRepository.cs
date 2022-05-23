using System.Collections.Generic;
using System.Threading.Tasks;
using VangheeAPI.Entities;

namespace VangheeAPI.DAL
{
    public interface IVangheeAPIRepository
    {
        Task<IEnumerable<DemoEntities>> Get();
        void Add(DemoEntities entity);
        void Update(DemoEntities entity);
        void Remove(int id);
    }
}
