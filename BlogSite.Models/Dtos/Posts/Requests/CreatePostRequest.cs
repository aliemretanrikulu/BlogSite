
namespace BlogSite.Models.Dtos.Posts.Requests;

public sealed record CreatePostRequest (string title, string content, int CategoryId);



