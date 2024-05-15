namespace STEM24.Model.Dto;

public class UserLoginResponseDto
{
    public string Token { get; set; } = default!;

    public DateTime Expiration { get; set; }
}
