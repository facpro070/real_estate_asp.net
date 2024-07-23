using ListingsMicroservice.Data.Repository;
using RealEstate.Shared.Data.Cache;
using RealEstate.Shared.Data.Context;

namespace RealEstate.Shared.Data.Repository
{
    public class ListingsDbRepository : Repository, IListingsDbRepository
    {
        public ListingsDbRepository(CombinedDBContext context, ICacheService cacheService)
        {
            Context = context; 
            _cacheService = cacheService;
        }
    }
}
