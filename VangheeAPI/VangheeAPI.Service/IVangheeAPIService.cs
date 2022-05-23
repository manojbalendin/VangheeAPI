using System.Collections.Generic;
using System.Threading.Tasks;
using VangheeAPI.Entities;

namespace VangheeAPI.Service
{
    public interface IVangheeAPIService
    {
        Task<IEnumerable<DemoEntities>> Get();
    }
}