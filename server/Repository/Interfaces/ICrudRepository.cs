using Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    /// <summary>
    /// Generic repository interface for CRUD operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICrudRepository<T>
         where T : class, IIdProvider
    {
        /// <summary>
        /// Creating the data entity asynchronously.
        /// </summary>
        /// <param name="newEntry">The entity to be created</param>
        /// <returns>A <see cref="Task"> representing the async operation.</returns>
        Task CreateAsync(T newEntry);

        /// <summary>
        /// Updating the data entity asynchronously.
        /// </summary>
        /// <param name="updatee">The entity holding the information.</param>
        /// <returns>A <see cref="Task"> representing the async operation.</returns>
        Task UpdateAsync(T updatee);

        /// <summary>
        /// Gets the id of an element asynchronously.
        /// </summary>
        /// <param name="id">The id of the element to search for.</param>
        /// <returns>A <see cref="Task"> representing the async operation with the element wrapped if found, null otherwise.</returns>
        Task<T> GetElementAsync(int id);

        /// <summary>
        /// Returns the elements asynchronously.
        /// </summary>
        /// <param name="ownerId">The ID of the corresponding user.</param>
        /// <returns>A <see cref="Task"> representing the async operation with the elements wrapped if found, empty enumerable otherwise.</returns>
        IQueryable<T> GetElementsAsync();

        /// <summary>
        /// Deletes the entity asynchronously.
        /// </summary>
        /// <param name="deletee">The entity to be deleted.</param>
        /// <returns>A <see cref="Task"> representing the async operation.</returns>
        Task DeleteAsync(T deletee);
    }
}
