namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record UpdatePostRequest(Guid id, string title, string content);



