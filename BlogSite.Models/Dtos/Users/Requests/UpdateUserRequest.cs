

namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record UpdateUserRequest(long Id, string FirstName, string LastName, string UserName, string EMail);
