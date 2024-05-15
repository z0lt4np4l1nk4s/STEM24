using STEM24.Model.Entity;

namespace STEM24.Service;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {


    }

    public DbSet<UserEntity> Users { get; set; } = default!;
}
