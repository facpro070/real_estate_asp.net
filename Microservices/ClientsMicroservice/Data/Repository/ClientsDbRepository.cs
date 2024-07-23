using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ClientsDbRepository : Repository, IClientsDbRepository
    {
        public ClientsDbRepository(CombinedDBContext context, ICacheService cacheService)
        {
            Context = context;
            _cacheService = cacheService;
        }
    }
}
