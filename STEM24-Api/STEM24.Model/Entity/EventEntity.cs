namespace STEM24.Model.Entity;

/// <summary>
/// Event entity
/// </summary>
[Table("Events")]
public class EventEntity
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
    /// Description
    /// </summary>
    public string Description { get; set; } = default!;

    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Update time
    /// </summary>
    public DateTime UpdateTime { get; set; }

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
    /// Keywords
    /// </summary>
    public string Keywords { get; set; } = default!;

    /// <summary>
    /// Dns records
    /// </summary>
    public ICollection<DnsRecordEntity> DnsRecords { get; set; } = default!;
}
