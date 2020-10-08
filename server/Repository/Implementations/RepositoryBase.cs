using Data;
using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    /// <summary>
    /// Base class for repositories.
    /// </summary>
    /// <typeparam name="T">The entity type</typeparam>
    public abstract class RepositoryBase<T> : ICrudRepository<T>
        where T : class, IIdProvider
    {
        public RepositoryBase(DbContext context)
        {
            _context = context;
        }
        private DbContext _context;

        public async Task CreateAsync(T newEntry)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(T deletee)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetElementAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetElementsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(T updatee)
        {
            throw new NotImplementedException();
        }
    }
}
