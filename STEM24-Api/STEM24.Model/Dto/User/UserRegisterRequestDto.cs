namespace STEM24.Model.Dto;

/// <summary>
/// User register request model
/// </summary>
public class UserRegisterRequestDto
{
    /// <summary>
    /// Name
    /// </summary>
    [Required]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Surname
    /// </summary>
    [Required]
    public string Surname { get; set; } = default!;

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
