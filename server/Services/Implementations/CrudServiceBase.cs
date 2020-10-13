using Data;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
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

        public Task UpdateAsync(T updatee)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetElementAsync(int id)
        {
            return await _repo.GetElementAsync(id);
        }

        public async Task<IEnumerable<T>> GetElementsAsync()
        {
            return await _repo.GetElementsAsync();
        }

        public Task DeleteAsync(T deletee)
        {
            throw new NotImplementedException();
        }
    }
}
