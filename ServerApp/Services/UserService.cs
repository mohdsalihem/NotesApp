using ServerApp.Dtos;
using ServerApp.Models;
using ServerApp.Services.Interfaces;
using ServerApp.Repositories.Interfaces;
using AutoMapper;
using ServerApp.Helpers.Interfaces;

namespace ServerApp.Services;

public class UserService : IUserService
{
    private readonly IUserRepository userRepository;
    private readonly IJwtUtility jwtUtility;
    private readonly IMapper mapper;

    public UserService(IUserRepository userRepository, IMapper mapper, IJwtUtility jwtUtility)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.jwtUtility = jwtUtility;
    }

    public async Task<LoginResponseDto> Login(LoginRequestDto request)
    {
        User user =  await userRepository.Get(request.Username, request.Password);
        if (user == null)
            throw new Exception("Username or password incorrect");

        var token = jwtUtility.GenerateToken(user);
        
        return new LoginResponseDto()
        {
            Username = user.Username,
            Token = token
        };
    }

    public async Task<LoginResponseDto> Signup(SignupRequestDto signupRequest)
    {
        if (await IsUsernameExist(signupRequest.Username))
            throw new Exception("Username already exist. Please try another one.");


        User user = mapper.Map<User>(signupRequest);
        user.Id = await userRepository.Insert(user);

        var token = jwtUtility.GenerateToken(user);

        return new LoginResponseDto()
        {
            Username = user.Username,
            Token = token
        };
    }

    public async Task<bool> IsUsernameExist(string username)
    {
        return await userRepository.IsUsernameExist(username);
    }
}