

using Core.Entitites;

namespace BlogSite.Models.Entities;

public class User : Entity<long>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public List<Post> Posts { get; set; }
}
