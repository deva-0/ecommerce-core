using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    /// <summary>
    /// Generic repository for simplification.   
    /// </summary>
    /// <typeparam name="T">Entity type used inside repository.</typeparam>
    public interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Retrieves entity with matching id. 
        /// </summary>
        /// <param name="id">ID of entity to search for.</param>
        /// <returns>Entity with matching ID</returns>
        Task<T> GetByIdAsync(int id);
        /// <summary>
        /// Retrieves all entities.  
        /// </summary>
        /// <returns>Readonly list of all entities</returns>
        Task<IReadOnlyList<T>> ListAllAsync();
        /// <summary>
        /// Retrieves entity matching specification. 
        /// </summary>
        /// <param name="spec">Initialized object with specification.</param>
        /// <returns>Entity which matches specification</returns>
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        /// <summary>
        /// Retrieves all entities matching specification. 
        /// </summary>
        /// <param name="spec">Initialized object with specification.</param>
        /// <returns>All entities matching specification</returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);

    }
}