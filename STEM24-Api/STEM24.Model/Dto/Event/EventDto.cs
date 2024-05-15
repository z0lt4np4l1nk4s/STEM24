namespace STEM24.Model.Dto;

/// <summary>
/// Event model
/// </summary>
public class EventDto
{
    /// <summary>
    /// Identifier
    /// </summary>
    public Guid Id { get; set; }

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
    /// Status
    /// </summary>
    public EventStatusEnum Status { get; set; }

    /// <summary>
    /// Dns records
    /// </summary>
    public List<DnsRecordDto> DnsRecords { get; set; } = default!;

    /// <summary>
    /// Keywords
    /// </summary>
    public List<string> Keywords { get; set; } = default!;

    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime CreationTime { get; set; }
}
