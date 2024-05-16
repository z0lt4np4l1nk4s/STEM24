namespace STEM24.Service;

/// <inheritdoc cref="IEventService" />
public class EventService : IEventService
{
    private readonly IGenericRepository<EventEntity> _repository;
    private readonly IMapper _mapper;

    public EventService(IGenericRepository<EventEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc cref="IEventService.AddAsync(AddEventDto)" />
    public async Task<ServiceResult> AddAsync(AddEventDto model)
    {
        try
        {
            var entity = _mapper.Map<EventEntity>(model);

            entity.CreationTime = entity.UpdateTime = DateTime.UtcNow;
            entity.Status = EventStatusEnum.Todo;

            var result = await _repository.AddAsync(entity);

            return result;
        }
        catch
        {
            return ServiceResult.Failure("Failed to add event.");
        }
    }

    /// <inheritdoc cref="IEventService.UpdateAsync(Guid, UpdateEventDto)" />
    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateEventDto model)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return ServiceResult.Failure("Event not found.");
            }

            if (entity.UserId != model.UserId)
            {
                return ServiceResult.Failure("No permission to edit this event.");
            }

            model.Adapt(entity);

            await _repository.SaveChangesAsync();

            return ServiceResult.Success();
        }
        catch
        {
            return ServiceResult.Failure("Failed to update event.");
        }
    }

    /// <inheritdoc cref="IEventService.GetPagedAsync(EventFilter)" />
    public async Task<PagedList<EventDto>> GetPagedAsync(EventFilter filter)
    {
        var eventQueryable = _repository.GetAll().Include(x => x.DnsRecords).AsNoTracking();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            var query = filter.Query.ToLower();
            eventQueryable = eventQueryable.Where(x => x.MaliciousUrl.ToLower().StartsWith(query) || x.Keywords.ToLower().StartsWith(query) || x.Name.ToLower().StartsWith(query));
        }

        if (!string.IsNullOrEmpty(filter.Name))
        {
            eventQueryable = eventQueryable.Where(x => x.Name.ToLower().StartsWith(filter.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.Keywords))
        {
            eventQueryable = eventQueryable.Where(x => x.Keywords.ToLower().StartsWith(filter.Keywords.ToLower()));
        }

        if (!string.IsNullOrEmpty(filter.MaliciousUrl))
        {
            eventQueryable = eventQueryable.Where(x => x.MaliciousUrl.ToLower().StartsWith(filter.MaliciousUrl.ToLower()));
        }

        if (filter.Date.HasValue)
        {
            eventQueryable = eventQueryable.Where(x => x.DomainRegistrationTime.Year == filter.Date.Value.Year && x.DomainRegistrationTime.Month == filter.Date.Value.Month && x.DomainRegistrationTime.Day == filter.Date.Value.Day);
        }

        if (filter.Status.HasValue)
        {
            eventQueryable = eventQueryable.Where(x => x.Status == filter.Status.Value);
        }

        var totalCount = await eventQueryable.CountAsync();

        var events = await eventQueryable.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToListAsync();

        var mappedEvents = _mapper.Map<List<EventDto>>(events);

        var pagedList = new PagedList<EventDto>
        {
            Items = mappedEvents,
            TotalCount = totalCount,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber,
            LastPage = (int)Math.Ceiling(1.0 * totalCount / filter.PageSize)
        };

        return pagedList;
    }

    /// <inheritdoc cref="IEventService.GetByIdAsync(Guid)" />
    public async Task<EventDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
        {
            return null;
        }

        var mapped = _mapper.Map<EventDto>(entity);

        return mapped;
    }

    /// <inheritdoc cref="IEventService.DeleteAsync(Guid)" />
    public async Task<ServiceResult> DeleteAsync(Guid id)
    {
        try
        {
            var entity = await _repository.GetByIdAsync(id);

            if (entity == null)
            {
                return ServiceResult.Failure("Event not found.");
            }

            await _repository.RemoveAsync(entity);

            return ServiceResult.Success();
        }
        catch
        {
            return ServiceResult.Failure("Failed to delete event.");
        }
    }

}
