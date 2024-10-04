using server.DTOs;
using server.Models;

namespace server.Services.interfaces;


public interface IAuthService {
    Task<User> Register (UserRegisterDTO userDTO);
    Task<LoginResponseDTO> Login (UserLoginDTO loginDTO);
}