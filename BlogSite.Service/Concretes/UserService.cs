

using AutoMapper;
using BlogSite.DataAccess.Abstracts;
using BlogSite.DataAccess.Concretes;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Dtos.Users.Responses;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public ReturnModel<UserResponseDto> Add(CreateUserRequest create)
    {
        User createdUser = _mapper.Map<User>(create);
        createdUser.Username = createdUser.Username;

        _userRepository.Add(createdUser);
        UserResponseDto response = _mapper.Map<UserResponseDto>(createdUser);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = "User Eklendi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<List<UserResponseDto>> GetAll()
    {
        List<User> users = _userRepository.GetAll();
        List<UserResponseDto> responses = _mapper.Map<List<UserResponseDto>>(users);

        return new ReturnModel<List<UserResponseDto>>
        {
            Data = responses,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> GetById(long id)
    {
        var user = _userRepository.GetById(id);
        var response = _mapper.Map<UserResponseDto>(user);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = string.Empty,
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> Remove(long id)
    {
        User user = _userRepository.GetById(id);
        User deletedUser = _userRepository.Remove(user);

        UserResponseDto response = _mapper.Map<UserResponseDto>(deletedUser);

        return new ReturnModel<UserResponseDto>
        {
            Data = response,
            Message = "User silindi",
            StatusCode = 200,
            Success = true
        };
    }

    public ReturnModel<UserResponseDto> Update(UpdateUserRequest updateUser)
    {
        User user = _userRepository.GetById(updateUser.Id);

        User update = new User
        {
            Id = user.Id,
            Username = updateUser.UserName,
            LastName = user.LastName,
            Email = updateUser.EMail,
            FirstName = updateUser.FirstName,
            CreatedDate = user.CreatedDate
        };

        User updatedUser = _userRepository.Update(update);

        UserResponseDto dto = _mapper.Map<UserResponseDto>(updatedUser);
        return new ReturnModel<UserResponseDto>
        {
            Data = dto,
            Message = "User Güncellendi",
            StatusCode = 200,
            Success = true
        };
    }
}