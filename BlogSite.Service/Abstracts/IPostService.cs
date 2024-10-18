
using BlogSite.DataAccess.Contexts;
using BlogSite.Models.Dtos.Posts.Requests;
using BlogSite.Models.Dtos.Posts.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IPostService
{
    ReturnModel<List<PostResponseDto>> GetAll();

    ReturnModel<PostResponseDto> GetById(Guid id);

    ReturnModel<Post> Add(CreatePostRequest create);

    ReturnModel<PostResponseDto> Update(UpdatePostRequest update);

    ReturnModel<PostResponseDto> Remove(Guid id);

    
}
