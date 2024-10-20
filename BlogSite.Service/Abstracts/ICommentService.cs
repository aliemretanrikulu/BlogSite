

using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAll();

    ReturnModel<CommentResponseDto> GetById(Guid id);

    ReturnModel<Comment> Add(CommentResponseDto create);

    ReturnModel<CommentResponseDto> Update(CommentResponseDto update);

    ReturnModel<CommentResponseDto> Remove(Guid id);



}
