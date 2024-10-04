using server.Models;

namespace server.Repositories.interfaces;


public interface IUserRepository {
    Task<User> CreateUser(User user);

    Task<User?> GetUserById(int id);

    Task<User?> GetUserByEmail(string email);

    Task<bool> IsEmailExist (string email);

}