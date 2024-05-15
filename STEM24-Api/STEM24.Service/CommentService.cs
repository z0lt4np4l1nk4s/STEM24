namespace STEM24.Service;

/// <inheritdoc cref="ICommentService" />
public class CommentService : ICommentService
{
    private readonly IGenericRepository<CommentEntity> _repository;
    private readonly IMapper _mapper;

    public CommentService(IGenericRepository<CommentEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <inheritdoc cref="ICommentService.AddAsync(AddCommentDto)" />
    public async Task<ServiceResult> AddAsync(AddCommentDto model)
    {
        var entity = _mapper.Map<CommentEntity>(model);

        entity.UpdateTime = entity.CreationTime = DateTime.UtcNow;

        var result = await _repository.AddAsync(entity);

        return result;
    }

    /// <inheritdoc cref="ICommentService.UpdateAsync(Guid, UpdateCommentDto)" />
    public async Task<ServiceResult> UpdateAsync(Guid id, UpdateCommentDto model)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
        {
            return ServiceResult.Failure("Comment does not exist.");
        }

        if (entity.UserId != model.UserId)
        {
            return ServiceResult.Failure("No permission to edit this comment.");
        }

        entity.Text = model.Text;
        entity.UpdateTime = DateTime.UtcNow;

        await _repository.SaveChangesAsync();

        return ServiceResult.Success();
    }

    /// <inheritdoc cref="ICommentService.GetPagedAsync(CommentFilter)" />
    public async Task<PagedList<CommentDto>> GetPagedAsync(CommentFilter filter)
    {
        var commentsQueryable = _repository.GetAll().Where(x => x.EventId == filter.EventId).OrderByDescending(x => x.CreationTime).AsNoTracking();

        var totalCount = await commentsQueryable.CountAsync();

        var comments = commentsQueryable.Skip((filter.PageNumber - 1) * filter.PageSize).Take(filter.PageSize).ToList();

        var mappedComments = _mapper.Map<List<CommentDto>>(comments);

        var pagedList = new PagedList<CommentDto>
        {
            Items = mappedComments,
            TotalCount = totalCount,
            PageSize = filter.PageSize,
            PageNumber = filter.PageNumber,
            LastPage = (int)Math.Ceiling(1.0 * totalCount / filter.PageSize)
        };

        return pagedList;
    }
}
