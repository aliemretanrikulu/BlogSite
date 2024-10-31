using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Dtos.Users.Requests;
using BlogSite.Service.Abstracts;
using BlogSite.Service.Abstratcts;
using Core.Responses;

namespace BlogSite.Service.Concretes;

public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
{
    public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequestDto dto)
    {
        var user = await _userService.LoginAsync(dto);
        var tokenResponse = _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = tokenResponse,
            Message = "Giriş başarılı",
            StatusCode = 200,
            Success = true
        };

    }

    public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequestDto dto)
    {
        var user = await _userService.RegisterAsync(dto);
        var registerResponse = _jwtService.CreateJwtTokenAsync(user);

        return new ReturnModel<TokenResponseDto>
        {
            Data = registerResponse,
            Message = "Kayıt işlemi başarılı",
            StatusCode = 200,
            Success = true
        };
    }
}
