using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ContractsDbRepository : Repository, IContractsDbRepository
    {
        public ContractsDbRepository(CombinedDBContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
