using Microsoft.AspNetCore.Authorization;

namespace STEM24.Controllers;

[ApiController]
[Authorize]
public class AuthBaseController : ControllerBase
{
    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId
    {
        get
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var guid = Guid.Parse(userId);
            return guid;
        }
    }


}
