namespace STEM24.Model.Dto;

/// <summary>
/// User login response model
/// </summary>
public class UserLoginResponseDto
{
    /// <summary>
    /// Token
    /// </summary>
    public string Token { get; set; } = default!;

    /// <summary>
    /// Expiration
    /// </summary>
    public DateTime Expiration { get; set; }

    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }
}
