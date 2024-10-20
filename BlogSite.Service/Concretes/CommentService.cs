

using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.Models.Dtos.Comments.Requests;
using BlogSite.Models.Dtos.Comments.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public ReturnModel<CommentResponseDto> Add(CreateCommentRequest create)
    {
        Comment createdComment = _mapper.Map<Comment>(create);
        createdComment.PostId = Guid.NewGuid();
        _commentRepository.Add(createdComment);

        CommentResponseDto response = _mapper.Map<CommentResponseDto>(createdComment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment Eklendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<CommentResponseDto>> GetAll()
    {
        List<Comment> comments = _commentRepository.GetAll();
        List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);

        return new ReturnModel<List<CommentResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> GetById(Guid id)
    {
        var comment = _commentRepository.GetById(id);
        var response = _mapper.Map<CommentResponseDto>(comment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Remove(Guid id)
    {
        Comment comment = _commentRepository.GetById(id);
        Comment deletedComment = _mapper.Map<Comment>(comment);

        CommentResponseDto response = _mapper.Map<CommentResponseDto>(deletedComment);

        return new ReturnModel<CommentResponseDto>
        {
            Data = response,
            Message = "Comment Silindi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<CommentResponseDto> Update(UpdateCommentRequest updateComment)
    {
        Comment comment = _commentRepository.GetById(updateComment.Id);
        Comment update = new Comment
        {
            UserId = comment.User.Id,
            Text = comment.Text,
            CreatedDate = comment.CreatedDate
        };

        Comment updatedComment = _commentRepository.Update(update);

        CommentResponseDto dto = _mapper.Map<CommentResponseDto>(updatedComment);
        return new ReturnModel<CommentResponseDto>
        {
            Data = dto,
            Message = "Comment Güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}
