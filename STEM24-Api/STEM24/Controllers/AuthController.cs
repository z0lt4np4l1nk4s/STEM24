using Microsoft.Extensions.Options;

namespace STEM24.Controllers;

/// <summary>
/// Auth controller
/// </summary>
[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<UserEntity> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ISmtpService _smtpService;
    private readonly JwtTokenOptions _jwtTokenOptions;

    public AuthController(UserManager<UserEntity> userManager, IConfiguration configuration, ISmtpService smtpService, IOptions<JwtTokenOptions> jwtTokenOptionsAccessor)
    {
        _userManager = userManager;
        _configuration = configuration;
        _smtpService = smtpService;
        _jwtTokenOptions = jwtTokenOptionsAccessor.Value;
    }

    /// <summary>
    /// Login
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPost("login")]
    [ProducesResponseType(typeof(UserLoginResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(UserLoginResponseDto), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] UserLoginRequestDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtTokenOptions.Key ?? ""));

            var token = new JwtSecurityToken(
                issuer: _jwtTokenOptions.Issuer,
                audience: _jwtTokenOptions.Audience,
                expires: DateTime.Now.AddHours(24),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

            return Ok(new UserLoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                UserId = user.Id
            });
        }

        return Unauthorized();
    }

    /// <summary>
    /// Register 
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPost("register")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
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
                Surname = model.Surname,
                EmailConfirmed = true,
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

    /// <summary>
    /// Send forgot password email
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Action result</returns>
    [HttpPost]
    [Route("forgot-password")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ForgotPassword([FromBody] UserForgotPasswordDto model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                return ServiceResult.Failure("Invalid request").ToActionResult();
            }

            var code = await _userManager.GeneratePasswordResetTokenAsync(user);

            var result = await _smtpService.SendAsync(model.Email, "Reset Password", $"Here is your password reset code \n\n{code}");

            return result.ToActionResult();
        }

        return ServiceResult.Failure("Invalid request").ToActionResult();
    }

    /// <summary>
    /// Reset password
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("reset-password")]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceResult), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetPassword([FromBody] UserResetPasswordDto model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return ServiceResult.Failure("Invalid request").ToActionResult();
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Code, model.Password);
            if (result.Succeeded)
            {
                return ServiceResult.Success().ToActionResult();
            }

            return ServiceResult.Failure("Error resetting password.").ToActionResult();
        }

        return ServiceResult.Failure("Invalid request").ToActionResult();
    }

}
