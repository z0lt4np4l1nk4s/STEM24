namespace STEM24.Model.Dto;

/// <summary>
/// User reset password model
/// </summary>
public class UserResetPasswordDto
{
    /// <summary>
    /// Email
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    /// <summary>
    /// Code
    /// </summary>
    [Required]
    public string Code { get; set; } = default!;

    /// <summary>
    /// Password
    /// </summary>
    [Required, MinLength(8)]
    public string Password { get; set; } = default!;
}
