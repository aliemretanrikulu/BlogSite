

using BlogSite.Models.Dtos.Categories.Responses;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using Core.Responses;

namespace BlogSite.Service.Abstracts;

public interface IUserService
{
    ReturnModel<List<UserResponseDto>> Getall();

    ReturnModel<UserResponseDto> GetById(Guid id);

    ReturnModel<User> Add(UserResponseDto create);

    ReturnModel<UserResponseDto> Update(UserResponseDto update);

    ReturnModel<UserResponseDto> Remove(Guid id);
}
