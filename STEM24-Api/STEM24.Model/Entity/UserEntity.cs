namespace STEM24.Model.Entity;

/// <summary>
/// User entity
/// </summary>
public class UserEntity : IdentityUser<Guid>
{
    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Surname
    /// </summary>
    public string Surname { get; set; } = default!;
}
