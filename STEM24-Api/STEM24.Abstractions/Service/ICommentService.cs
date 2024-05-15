namespace STEM24.Service;

/// <summary>
/// Comment service
/// </summary>
public interface ICommentService
{
    Task<ServiceResult> AddAsync(AddCommentDto model);
    Task<List<CommentDto>> GetPagedAsync(CommentFilter filter);
    Task<ServiceResult> UpdateAsync(Guid id, UpdateCommentDto model);
}