namespace STEM24.Model.Option;

/// <summary>
/// Jwt token options
/// </summary>
public class JwtTokenOptions
{
    /// <summary>
    /// Issuer
    /// </summary>
    public string? Issuer { get; set; }

    /// <summary>
    /// Audience
    /// </summary>
    public string? Audience { get; set; }

    /// <summary>
    /// Key
    /// </summary>
    public string? Key { get; set; }
}
