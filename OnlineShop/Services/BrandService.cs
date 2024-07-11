using OnlineStore.Abstractions;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;

namespace OnlineStore.Services
{
    public class BrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Task<List<Brand>> GetAll()
        {
            return _brandRepository.GetAll();
        }

        public async Task<Guid> AddRacket(Brand brand)
        {
            return await _brandRepository.Add(brand);
        }

        public void Get(Guid id)
        {
            _brandRepository.Get(id);
        }
    }
}
