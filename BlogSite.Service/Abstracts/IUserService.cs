

using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    ReturnModel<List<UserResponseDto>> GetAll();

    ReturnModel<UserResponseDto> GetById(long id);

    ReturnModel<UserResponseDto> Add(CreateUserRequest create);

    ReturnModel<UserResponseDto> Update(UpdateUserRequest update);

    ReturnModel<UserResponseDto> Remove(long id);
}
