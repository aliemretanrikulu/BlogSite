using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Models.Entities;
using BlogSite.Service.Abstracts;
using Core.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace BlogSite.Service.Concretes;

public sealed class UserService(UserManager<User> _userManager) : IUserService
{
    public async Task<User> ChangePaswordAsync(ChangePasswordRequestDto requestDto, string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundExcepiton("Kullanıcı bulunamadı");
        }

        if (requestDto.newPassword.Equals(requestDto.newPasswordAgain) is false) 
        {
            throw new BusinessExcepiton("Parolalar uyuşmuyor!");
        }

        var result = await _userManager.ChangePasswordAsync(user, requestDto.currentPassword, requestDto.newPassword);

        if (result.Succeeded is false)
        {
            {
                throw new BusinessExcepiton(result.Errors.ToList().First().Description);
            }
        }

        return user;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundExcepiton("Kullanıcı bulunamadı");
        }

        var result = await _userManager.DeleteAsync(user);

        if (!result.Succeeded)
        {
            throw new BusinessExcepiton(result.Errors.ToList().First().Description);
        }
        return "Kullanıcı silindi!";
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
        {
            throw new Exception("Kullanıcı bulunamadı");
        }
        return user;
    }


    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(dto.Email);

        if (user is null)
        {
            throw new NotFoundExcepiton("Kullanıcı bulunamadı");
        }

        bool checkPassword = await _userManager.CheckPasswordAsync(user, dto.Password);

        if (checkPassword is false)
        {
            new BusinessExcepiton("Parolanız yanlış!");
        }

        return user;
    }


    public async Task<User> RegisterAsync(RegisterRequestDto dto)
    {
        User user = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            City = dto.City,
            UserName = dto.Username,

        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            throw new(result.Errors.ToList().First().Description);
        }

        var addRole = await _userManager.AddToRoleAsync(user, "User");
        CheckIdentityResult(addRole);

        return user;
    }

    public async Task<User> UpdateAsync(string id, UserUpdateRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        if (user is null)
        {
            throw new NotFoundExcepiton("Kullanıcı bulunamadı");
        }

        user.UserName = dto.Username;
        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.City = dto.City;

        var result = await _userManager.UpdateAsync(user);
        CheckIdentityResult(result);

        return user;
    }

    private void CheckIdentityResult(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessExcepiton(result.Errors.ToList().First().Description);
        }
    }
}
