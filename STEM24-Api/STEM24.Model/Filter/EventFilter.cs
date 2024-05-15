namespace STEM24.Model.Filter;

/// <summary>
/// Event filter
/// </summary>
public class EventFilter : BaseFilter
{
    /// <summary>
    /// Name
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Date
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Affected brand
    /// </summary>
    public string? AffectedBrand { get; set; }

    /// <summary>
    /// Malicious url
    /// </summary>
    public string? MaliciousUrl { get; set; }

    /// <summary>
    /// Keywords
    /// </summary>
    public string? Keywords { get; set; }

    /// <summary>
    /// Status
    /// </summary>
    public EventStatusEnum? Status { get; set; }
}
