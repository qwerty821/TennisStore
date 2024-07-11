using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;
using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;

namespace OnlineStore.Abstractions
{
    public interface IRacketRepository
    {
        Task<List<Racket>> GetAll();
        Task<List<Racket>> GetAll(FilterOptions filterOptions);
        Task<Guid> Add(Racket racket);

        Task<Racket> Get(Guid id);
    }
}
