using OnlineStore.Models.RacketModels;
using OnlineStore.Models.RacketsModels;

namespace OnlineStore.Abstractions
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAll();
        Task<Guid> Add(Brand brand);

        public void Get(Guid id);
    }
}