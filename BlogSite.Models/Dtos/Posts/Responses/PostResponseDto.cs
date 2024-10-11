namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto(
    Guid Id,
    string Title,
    string Content,
    DateTime CreateDate
    );