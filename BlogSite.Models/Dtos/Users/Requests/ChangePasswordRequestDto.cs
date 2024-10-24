
namespace BlogSite.Models.Dtos.Users.Requests;

public sealed record ChangePasswordRequestDto(string currentPassword, string newPassword, string newPasswordAgain);


