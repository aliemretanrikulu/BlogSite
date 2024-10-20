

namespace BlogSite.Models.Dtos.Comments.Responses;

public sealed record CommentResponseDto
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public string UserName { get; set; }
    public Guid PostId { get; set; }
}
