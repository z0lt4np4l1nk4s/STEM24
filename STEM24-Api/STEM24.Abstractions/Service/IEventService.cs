namespace STEM24.Abstractions.Service;

/// <summary>
/// Event service
/// </summary>
public interface IEventService
{
    Task<ServiceResult> AddAsync(AddEventDto model);
    Task<ServiceResult> DeleteAsync(Guid id);
    Task<PagedList<EventDto>> GetPagedAsync(EventFilter filter);
    Task<EventDto?> GetByIdAsync(Guid id);
    Task<ServiceResult> UpdateAsync(Guid id, UpdateEventDto model);
}