namespace STEM24.Model.Dto;

public class UserLoginRequestDto
{
    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    [Required, MinLength(8)]
    public string Password { get; set; } = default!;
}
