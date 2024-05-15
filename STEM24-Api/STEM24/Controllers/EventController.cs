namespace STEM24.Controllers;

/// <summary>
/// Event controller
/// </summary>
[Route("api/event")]
[ApiController]
public class EventController : AuthBaseController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    /// <summary>
    /// Add event
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync(AddEventDto model)
    {
        model.UserId = UserId;
        var result = await _eventService.AddAsync(model);

        return result.ToActionResult();
    }

    /// <summary>
    /// Update event
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateEventDto model)
    {
        var result = await _eventService.UpdateAsync(id, model);

        return result.ToActionResult();
    }

    /// <summary>
    /// Delete event
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Action result</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _eventService.DeleteAsync(id);

        return result.ToActionResult();
    }

    /// <summary>
    /// Get event by identifier
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <returns>Action result</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EventDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(EventDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _eventService.GetByIdAsync(id);

        return Ok(result);
    }

    /// <summary>
    /// Get events paged
    /// </summary>
    /// <param name="filter">Filter</param>
    /// <returns>Action result</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<EventDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PagedList<EventDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPagedAsync([FromQuery] EventFilter filter)
    {
        var result = await _eventService.GetPagedAsync(filter);

        return Ok(result);
    }
}
