namespace STEM24.Controllers;

[Route("api/event")]
[ApiController]
public class EventController : AuthBaseController
{
    private readonly IEventService _eventService;

    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddEventDto model)
    {
        model.UserId = UserId;
        var result = await _eventService.AddAsync(model);

        return result.ToActionResult();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateEventDto model)
    {
        var result = await _eventService.UpdateAsync(id, model);

        return result.ToActionResult();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await _eventService.DeleteAsync(id);

        return result.ToActionResult();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _eventService.GetByIdAsync(id);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetPagedAsync([System.Web.Http.FromUri] EventFilter filter)
    {
        var result = await _eventService.GetPagedAsync(filter);

        return Ok(result);
    }
}
