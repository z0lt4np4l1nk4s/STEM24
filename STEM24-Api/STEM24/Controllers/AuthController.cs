namespace STEM24.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _configuration;

    public AuthController(UserManager<UserEntity> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtTokenOptions:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtTokenOptions:Issuer"],
                audience: _configuration["JwtTokenOptions:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return Ok(new UserLoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo
            });
        }

        return Unauthorized();
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] UserRegisterRequestDto model)
    {
        if (ModelState.IsValid)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                return ServiceResult.Failure("User already exists.").ToActionResult();
            }

            UserEntity user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return ServiceResult.Success().ToActionResult();
            }

            return ServiceResult.Failure(result.Errors.Select(x => x.Description).ToList()).ToActionResult();
        }

        return ServiceResult.Failure("User registration failed! Please check user details and try again.").ToActionResult();
    }

}
