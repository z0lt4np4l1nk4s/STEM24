namespace STEM24.Model.Entity;

public class EventEntity
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public DateTime CreationTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string AffectedBrand { get; set; } = default!;

    public string MaliciousUrl { get; set; } = default!;

    public DateTime DomainRegistrationTime { get; set; }

    public EventStatusEnum Status { get; set; }

    public string Keywords { get; set; } = default!;

    public ICollection<DnsRecordEntity> DnsRecords { get; set; } = default!;
}
