using MapsterMapper;
using STEM24.Abstractions.Repository;
using STEM24.Model.Entity;

namespace STEM24.Service;

public class CommentService
{
    private readonly IGenericRepository<CommentEntity> _repository;
    private readonly IMapper _mapper;

    public CommentService(IMapper mapper, IGenericRepository<CommentEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
}
