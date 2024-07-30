using Microsoft.EntityFrameworkCore;

using OnlineStore.Abstractions;
using OnlineStore.Models.DbModels;
using OnlineStore.Models.RacketsModels;
using OnlineStore.Models.RacketsModels;
using OnlineStore.SQL;

namespace OnlineStore.Repositories
{
    public class RacketRepository : IRacketRepository
    {
        private OnlineStoreContext _context;

        public RacketRepository(OnlineStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Racket>> GetAll()
        {
            List<Racket> list = await _context.Rackets.ToListAsync();
            return list;
        }

        public async Task<List<Racket>> GetAll(FilterOptions filterOptions)
        {
            return await SQLQueries.getAll(filterOptions);
        }

        public async Task<Guid> Add(AddRacketModel racket)
        {
            //await _context.Rackets.AddAsync(racket); 
            //await _context.SaveChangesAsync();

           return await SQLQueries.addRacket(racket);

        }

        public async Task<Racket> Get(Guid id)
        {
            var r = await SQLQueries.get(id);
            return r;
        }
    }
}
