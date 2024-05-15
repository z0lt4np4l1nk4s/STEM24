namespace STEM24.Model.Dto;

public class UpdateEventDto
{
    public string Name { get; set; } = default!;

    public string AffectedBrand { get; set; } = default!;

    public string MaliciousUrl { get; set; } = default!;

    public DateTime DomainRegistration { get; set; }

    public List<string> MatchingKeywords { get; set; } = new List<string>();
}
