using Data;
using Repository.Interfaces;
using Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public abstract class CrudServiceBase<T> : ICrudService<T>
        where T:class, IIdProvider
    {
        public CrudServiceBase(ICrudRepository<T> repository)
        {
            _repo = repository;
        }

        protected ICrudRepository<T> _repo;

        public async Task CreateAsync(T newEntry)
        {
            await _repo.CreateAsync(newEntry);
        }

        public async Task UpdateAsync(T updatee)
        {
            await _repo.UpdateAsync(updatee);
        }

        public async Task<T> GetElementAsync(int id)
        {
            return await _repo.GetElementAsync(id);
        }

        public IQueryable<T> GetElementsAsync()
        {
            return _repo.GetElementsAsync();
        }

        public async Task DeleteAsync(T deletee)
        {
            await _repo.DeleteAsync(deletee);
        }
    }
}
