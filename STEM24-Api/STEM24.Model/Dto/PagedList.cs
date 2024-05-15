namespace STEM24.Model.Dto;

/// <summary>
/// Paged list
/// </summary>
/// <typeparam name="T">Type</typeparam>
public class PagedList<T>
{
    /// <summary>
    /// Page number
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Page size
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Result
    /// </summary>
    public IEnumerable<T>? Items { get; set; }

    /// <summary>
    /// Total count
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// LastPage
    /// </summary>
    public int LastPage { get; set; }
}
