namespace STEM24.Model.Dto;

/// <summary>
/// User password reset model
/// </summary>
public class UserForgotPasswordDto
{
    /// <summary>
    /// Email
    /// </summary>
    [Required, EmailAddress]
    public string Email { get; set; } = default!;
}
