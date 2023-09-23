using AutoMapper;
using ServerApp.Dtos;
using ServerApp.Helpers.Interfaces;
using ServerApp.Models;
using ServerApp.Repositories.Interfaces;
using ServerApp.Services.Interfaces;

namespace ServerApp.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository userRepository;
    private readonly ITokenService tokenService;
    private readonly IRefreshTokenRepository refreshTokenRepository;
    private readonly IHttpContextHelper httpContextHelper;
    private readonly IMapper mapper;

    public AuthService(
        IUserRepository userRepository,
        ITokenService tokenService,
        IRefreshTokenRepository refreshTokenRepository,
        IHttpContextHelper httpContextHelper,
        IMapper mapper)
    {
        this.userRepository = userRepository;
        this.tokenService = tokenService;
        this.refreshTokenRepository = refreshTokenRepository;
        this.httpContextHelper = httpContextHelper;
        this.mapper = mapper;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto request)
    {
        User user = await userRepository.Get(request.Username, request.Password);
        if (user == null)
            throw new Exception("Invalid username or password");

        RefreshToken refreshToken = new()
        {
            UserId = user.Id,
            Token = await tokenService.GenerateRefreshToken(),
            ExpiryDate = tokenService.RefreshTokenExpiryDate
        };
        await refreshTokenRepository.Insert(refreshToken);
        httpContextHelper.SetRefreshTokenCookie(refreshToken.Token, refreshToken.ExpiryDate);

        string accessToken = tokenService.GenerateAccessToken(user);
        return new LoginResponseDto()
        {
            Username = user.Username,
            Token = accessToken
        };
    }

    public async Task<LoginResponseDto> Signup(SignupRequestDto signupRequest)
    {
        if (await userRepository.IsUsernameExist(signupRequest.Username))
            throw new Exception("Username already exist. Please try another one.");


        User user = mapper.Map<User>(signupRequest);
        user.Id = await userRepository.Insert(user);

        string accessToken = tokenService.GenerateAccessToken(user);
        return new LoginResponseDto()
        {
            Username = user.Username,
            Token = accessToken
        };
    }
}
