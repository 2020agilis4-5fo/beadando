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
    public abstract class RepositoryBase<T, TContext> : ICrudRepository<T>
        where T : class, IIdProvider
        where TContext : DbContext
    {
        public RepositoryBase(TContext context)
        {
            _context = context;
        }
        protected TContext _context;

        public async Task CreateAsync(T newEntry)
        {
            if (await EntryFinderAsync(newEntry.Id) != null)
            {
                throw new ApplicationException($"The element with the same ID is already in the database");
            }

            await _context.Set<T>().AddAsync(newEntry);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T deletee)
        {
            T element = await EntryFinderAsync(deletee.Id);
            if (element != null)
            {
                _context.Remove(deletee);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException($"There was an error during deleting the instance");
            }
        }

        public virtual async Task<T> GetElementAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetElementsAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T updatee)
        {
            T element = await EntryFinderAsync(updatee.Id);

            if (element != null)
            {
                _context.Entry(element).State = EntityState.Detached;
                //_context.Update(updatee);
                element = updatee;
                _context.Entry(element).State = EntityState.Modified;

                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ApplicationException($"An error occured during updating the instance");
            }
        }

        private async Task<T> EntryFinderAsync(int id)
        {
            return (T)await _context.Set<T>()
                //.AsNoTracking()
                .FirstOrDefaultAsync(en => en.Id == id);
        }
    }
}
