namespace STEM24.Abstractions.Service;

/// <summary>
/// Comment service
/// </summary>
public interface ICommentService
{
    Task<ServiceResult> AddAsync(AddCommentDto model);
    Task<PagedList<CommentDto>> GetPagedAsync(CommentFilter filter);
    Task<ServiceResult> UpdateAsync(Guid id, UpdateCommentDto model);
}