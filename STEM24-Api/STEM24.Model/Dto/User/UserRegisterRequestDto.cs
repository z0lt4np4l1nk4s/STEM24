namespace STEM24.Model.Dto;

public class UserRegisterRequestDto
{
    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public string Surname { get; set; } = default!;

    [Required, EmailAddress]
    public string Email { get; set; } = default!;

    [Required, MinLength(8)]
    public string Password { get; set; } = default!;
}
