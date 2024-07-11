using Microsoft.EntityFrameworkCore;
using OnlineStore.Abstractions;
using OnlineStore.Models.DbModels;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;
using OnlineStore.SQL;

namespace OnlineStore.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private OnlineStoreContext _context;

        public BrandRepository(OnlineStoreContext context)
        {
            _context = context;
        }

        public async Task<List<Brand>> GetAll()
        {
            List<Brand> list = await _context.Brands.ToListAsync();
            return list;
        }

        public async Task<Guid> Add(Brand brand)
        {
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return brand.BId;
        }

        public void Get(Guid id)
        {
            Console.WriteLine(SQLQueries.getBrand(id));
        }


        
    }
}
