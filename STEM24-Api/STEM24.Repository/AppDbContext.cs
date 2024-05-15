using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using STEM24.Model.Entity;

namespace STEM24.Repository;

public class AppDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<CommentEntity> Comments { get; set; } = default!;
    public DbSet<EventEntity> Events { get; set; } = default!;
    public DbSet<DnsRecordEntity> DnsRecords { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
