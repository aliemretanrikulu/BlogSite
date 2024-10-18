﻿namespace BlogSite.Models.Dtos.Posts.Responses;

public sealed record PostResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreateDate { get; set; }
    public string AuthorUserName { get; set; }
    public string CategoryName { get; set; }
}
