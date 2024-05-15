namespace STEM24.Controllers;

/// <summary>
/// Comment controller
/// </summary>
[Route("api/comment")]
[ApiController]
public class CommentController : AuthBaseController
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    /// <summary>
    /// Add comment
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddAsync(AddCommentDto model)
    {
        model.UserId = UserId;
        var result = await _commentService.AddAsync(model);

        return result.ToActionResult();
    }

    /// <summary>
    /// Update comment
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCommentDto model)
    {
        model.UserId = UserId;
        var result = await _commentService.UpdateAsync(id, model);

        return result.ToActionResult();
    }

    /// <summary>
    /// Get comments paged
    /// </summary>
    /// <param name="filter">Filter</param>
    /// <returns>Action result</returns>
    [HttpGet]
    [ProducesResponseType(typeof(PagedList<CommentDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(PagedList<CommentDto>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetPagedAsync([FromQuery] CommentFilter filter)
    {
        var result = await _commentService.GetPagedAsync(filter);

        return Ok(result);
    }
}
