namespace STEM24.Controllers;

[Route("api/comment")]
[ApiController]
public class CommentController : AuthBaseController
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(AddCommentDto model)
    {
        model.UserId = UserId;
        var result = await _commentService.AddAsync(model);

        return result.ToActionResult();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCommentDto model)
    {
        model.UserId = UserId;
        var result = await _commentService.UpdateAsync(id, model);

        return result.ToActionResult();
    }

    [HttpGet]
    public async Task<IActionResult> GetPagedAsync([System.Web.Http.FromUri] CommentFilter filter)
    {
        var result = await _commentService.GetPagedAsync(filter);

        return Ok(result);
    }
}
