

namespace BlogSite.Models.Dtos.Comments.Requests;

public sealed record CreateCommentRequest(Guid PostId, long UserId, string Text );
