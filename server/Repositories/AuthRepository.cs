using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;
using server.Repositories.interfaces;

namespace server.Repositories;


public class UserRepository : IAuthRepository {
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context) {
        _context = context;
    }

    public async Task<User> CreateUser(User user) {
        await _context.Users.AddAsync(user);        
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserById(int id) {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmail(string email) {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<bool> IsEmailExist (string email) {
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
}