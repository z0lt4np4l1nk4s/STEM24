namespace STEM24.Model.Dto;

/// <summary>
/// User login request model
/// </summary>
public class UserLoginRequestDto
{
    /// <summary>
    /// Email
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    [Required, MinLength(8)]
    public string Password { get; set; } = default!;
}
