namespace STEM24.Model.Filter;

/// <summary>
/// Base filter
/// </summary>
public class BaseFilter
{
    /// <summary>
    /// Query
    /// </summary>
    public string? Query { get; set; }

    /// <summary>
    /// Page number
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; set; }
}
