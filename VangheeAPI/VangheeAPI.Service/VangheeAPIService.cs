using System.Collections.Generic;
using System.Threading.Tasks;
using VangheeAPI.DAL;
using VangheeAPI.Entities;

namespace VangheeAPI.Service
{
    internal class VangheeAPIService : IVangheeAPIService
    {
        private readonly IVangheeAPIRepository _repository;

        public VangheeAPIService(IVangheeAPIRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<DemoEntities>> Get()
        {
            return _repository.Get();
        }
    }
}
