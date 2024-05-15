using STEM24.Model.Enum;

namespace STEM24.Model.Entity;

public class EventEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public DateTime CreationTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public string AffectedBrand { get; set; } = default!;

    public string MaliciousUrl { get; set; } = default!;

    public DateTime DomainRegistration { get; set; }

    public EventStatusEnum Status { get; set; }

    public string MatchingKeywords { get; set; } = default!;
}
