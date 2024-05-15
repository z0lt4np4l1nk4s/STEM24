namespace STEM24.Abstractions.Repository;

/// <summary>
/// Generic repository
/// </summary>
/// <typeparam name="T">Type</typeparam>
public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// Add asynchronously
    /// </summary>
    /// <param name="entity">Entity</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> AddAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Add range asynchronously
    /// </summary>
    /// <param name="entities">Entities</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get by identifier asynchronously
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Entity</returns>
    Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get all
    /// </summary>
    /// <returns>Queryable</returns>
    IQueryable<T> GetAll();

    /// <summary>
    /// Removes an entity
    /// </summary>
    /// <param name="entity">Entity to remove</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> RemoveAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove range
    /// </summary>
    /// <param name="entities">Entities to remove</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

    /// <summary>
    /// Save changes asynchronously
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Number of affected rows</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
