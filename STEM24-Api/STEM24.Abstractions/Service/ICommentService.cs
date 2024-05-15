namespace STEM24.Abstractions.Service;

/// <summary>
/// Comment service
/// </summary>
public interface ICommentService
{
    /// <summary>
    /// Add comment asynchronously
    /// </summary>
    /// <param name="model">Model</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> AddAsync(AddCommentDto model);

    /// <summary>
    /// Get comments paged asynchronously
    /// </summary>
    /// <param name="filter">Filter</param>
    /// <returns>Paged list</returns>
    Task<PagedList<CommentDto>> GetPagedAsync(CommentFilter filter);

    /// <summary>
    /// Update event asynchronously
    /// </summary>
    /// <param name="id">Identifier</param>
    /// <param name="model">Model</param>
    /// <returns>Service result</returns>
    Task<ServiceResult> UpdateAsync(Guid id, UpdateCommentDto model);
}