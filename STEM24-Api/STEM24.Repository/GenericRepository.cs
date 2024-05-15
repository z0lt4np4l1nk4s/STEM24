using Microsoft.EntityFrameworkCore;
using STEM24.Abstractions.Repository;
using STEM24.Model.Dto;

namespace STEM24.Repository;

/// <inheritdoc cref="IGenericRepository{T}" />
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private DbSet<T>? _entities;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc cref="IGenericRepository{T}.AddAsync(T, CancellationToken)" />
    public async Task<ServiceResult> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Entities.AddAsync(entity, cancellationToken);
        var result = await SaveChangesAsync(cancellationToken);
        return result > 0
            ? ServiceResult.Success()
            : ServiceResult.Failure();
    }

    /// <inheritdoc cref="IGenericRepository{T}.AddRangeAsync(List{T}, CancellationToken)" />
    public async Task<ServiceResult> AddRangeAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        await Entities.AddRangeAsync(entities, cancellationToken);
        var result = await SaveChangesAsync(cancellationToken);
        return result > 0
            ? ServiceResult.Success()
            : ServiceResult.Failure();
    }

    /// <inheritdoc cref="IGenericRepository{T}.GetByIdAsync(object, CancellationToken)" />
    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await Entities.FindAsync(new object?[] { id }, cancellationToken: cancellationToken);
    }

    /// <inheritdoc cref="IGenericRepository{T}.GetAll()" />
    public IQueryable<T> GetAll() => Entities;

    /// <inheritdoc cref="IGenericRepository{T}.RemoveAsync(T, CancellationToken)" />
    public async Task<ServiceResult> RemoveAsync(T entity, CancellationToken cancellationToken = default)
    {
        Entities.Remove(entity);
        var result = await SaveChangesAsync(cancellationToken);
        return result > 0
            ? ServiceResult.Success()
            : ServiceResult.Failure();
    }

    /// <inheritdoc cref="IGenericRepository{T}.RemoveRangeAsync(IEnumerable{T}, CancellationToken)" />
    public async Task<ServiceResult> RemoveRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
    {
        Entities.RemoveRange(entities);
        var result = await SaveChangesAsync(cancellationToken);
        return result > 0
            ? ServiceResult.Success()
            : ServiceResult.Failure();
    }

    /// <inheritdoc cref="IGenericRepository{T}.SaveChangesAsync(CancellationToken)" />
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => _context.SaveChangesAsync(cancellationToken);

    private DbSet<T> Entities
    {
        get
        {
            _entities ??= _context.Set<T>();
            return _entities;
        }
    }
}
