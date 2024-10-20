

namespace BlogSite.Models.Dtos.Users.Responses;

public sealed record UserResponseDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string EMail { get; set; }
}
