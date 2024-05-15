namespace STEM24.Model.Entity;

public class UserEntity : IdentityUser
{
    public string Name { get; set; } = default!;

    public string Surname { get; set; } = default!;
}
