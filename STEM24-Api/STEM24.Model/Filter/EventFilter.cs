namespace STEM24.Model.Filter;

public class EventFilter : BaseFilter
{
    public string? Name { get; set; }

    public DateTime? Date { get; set; }

    public string? AffectedBrand { get; set; }

    public string? MaliciousUrl { get; set; }

    public string? Keywords { get; set; }

    public EventStatusEnum? Status { get; set; }
}
