namespace STEM24.Model.Dto;

/// <summary>
/// Add event model
/// </summary>
public class AddEventDto
{
    /// <summary>
    /// User identifier
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [Required]
    public string Name { get; set; } = default!;

    /// <summary>
    /// Description
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Affected brand
    /// </summary>
    [Required]
    public string AffectedBrand { get; set; } = default!;

    /// <summary>
    /// Malicious url
    /// </summary>
    [Required]
    public string MaliciousUrl { get; set; } = default!;

    /// <summary>
    /// Domain registration time
    /// </summary>
    [Required]
    public DateTime DomainRegistrationTime { get; set; }

    /// <summary>
    /// Keywords
    /// </summary>
    public List<string> Keywords { get; set; } = new List<string>();

    /// <summary>
    /// Dns records
    /// </summary>
    [Required]
    public List<AddDnsRecordDto> DnsRecords { get; set; } = default!;
}
