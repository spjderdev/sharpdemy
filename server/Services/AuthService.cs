using server.DTOs;
using server.Models;
using server.Repositories.interfaces;
using server.Services.interfaces;

namespace server.Services;



public class UserService : IAuthService {
    private readonly IAuthRepository _userRepository;
    private readonly TokenService _tokenService;

    public UserService(IAuthRepository userRepository, TokenService tokenService) {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<User> Register (UserRegisterDTO userDTO) {
        if(await _userRepository.IsEmailExist(userDTO.Email)) {
            throw new Exception("Email already exists");
        }
        var user = new User {
            Name = userDTO.Name,
            Email = userDTO.Email,
            Password = userDTO.Password,
        };

        return await _userRepository.CreateUser(user);
    }

    public async Task<LoginResponseDTO> Login (UserLoginDTO loginDTO) {

        var user = await _userRepository.GetUserByEmail(loginDTO.Email);
        if(user == null) {
            throw new Exception("Email already exists");
        }

        if(user.Password != loginDTO.Password) {
            throw new Exception ("Invalid password");
        }
        var token = _tokenService.GenerateJwtToken(user.Email, user.Name);

        var userResponse = new LoginResponseDTO {
            Name = user.Name,
            Email = user.Email,
            Role = user.Role,
            Token = token
        };

        return userResponse;
    }
}