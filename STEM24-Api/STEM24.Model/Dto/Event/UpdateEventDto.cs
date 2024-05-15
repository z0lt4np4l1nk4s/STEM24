namespace STEM24.Model.Dto;

/// <summary>
/// Update event model
/// </summary>
public class UpdateEventDto
{
    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Affected brand
    /// </summary>
    public string AffectedBrand { get; set; } = default!;

    /// <summary>
    /// Malicious url
    /// </summary>
    public string MaliciousUrl { get; set; } = default!;

    /// <summary>
    /// Domain registration time
    /// </summary>
    public DateTime DomainRegistrationTime { get; set; }

    /// <summary>
    /// Keywords
    /// </summary>
    public List<string> Keywords { get; set; } = new List<string>();
}
