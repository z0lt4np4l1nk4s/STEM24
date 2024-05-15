namespace STEM24.Abstractions.Service;

/// <summary>
/// Event service
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Add event asynchronously
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> AddAsync(AddEventDto model);

    /// <summary>
    /// Delete event asynchronously
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> DeleteAsync(Guid id);

    /// <summary>
    /// Get events paged asynchronously
    /// </summary>
    /// <param name="filter">Filter</param>
    /// <returns>Paged list</returns>
    Task<PagedList<EventDto>> GetPagedAsync(EventFilter filter);

    /// <summary>
    /// Get event by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Event model or null</returns>
    Task<EventDto?> GetByIdAsync(Guid id);

    /// <summary>
    /// Update event asynchronously
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="model">Model</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> UpdateAsync(Guid id, UpdateEventDto model);
}