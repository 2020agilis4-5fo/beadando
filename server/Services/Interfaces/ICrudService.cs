using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services.Interfaces
{
    /// <summary>
    /// A base interface for CRUD operations
    /// </summary>
    /// <typeparam name="T">The type of the entity</typeparam>
    public interface ICrudService<T>
        where T:class
    {
        /// <summary>
        /// Creating the element asynchronously.
        /// </summary>
        /// <param name="newEntry">The entity to be created</param>
        /// <returns>A <see cref="Task"> representing the async operation.</returns>
        Task CreateAsync(T newEntry);

        /// <summary>
        /// Updating the entity asynchronously.
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
        Task<IEnumerable<T>> GetElementsAsync();

        /// <summary>
        /// Deletes the entity asynchronously.
        /// </summary>
        /// <param name="deletee">The entity to be deleted.</param>
        /// <returns>A <see cref="Task"> representing the async operation.</returns>
        Task DeleteAsync(T deletee);
    }
}
