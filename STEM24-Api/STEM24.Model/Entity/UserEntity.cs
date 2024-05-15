namespace STEM24.Model.Entity;

public class UserEntity : IdentityUser<Guid>
{
    public string Name { get; set; } = default!;

    public string Surname { get; set; } = default!;
}
