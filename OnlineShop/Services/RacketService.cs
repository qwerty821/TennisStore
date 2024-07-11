using OnlineShop.Models;
using OnlineStore.Abstractions;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;

namespace OnlineStore.Services
{
    public class RacketService
    {
        private readonly IRacketRepository _racketRepository;

        public RacketService(IRacketRepository racketRepository)
        {
            _racketRepository = racketRepository;
        }

        public Task<List<Racket>> GetAll()
        {
            return _racketRepository.GetAll();
        }

        public Task<List<Racket>> GetAll(FilterOptions filterOptions)
        {
            return _racketRepository.GetAll(filterOptions);
        }
        public async Task<Guid> AddRacket(Racket racket)
        {
            return await _racketRepository.Add(racket);
        }

    }
}
