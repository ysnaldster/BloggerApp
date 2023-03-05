using System.Text.RegularExpressions;
using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Repositories;
using BlogApplication.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BlogApplicationContext _context;

    public UserRepository(BlogApplicationContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetUser(Guid? id)
    {
        return await _context.Users.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<User> SaveUser(User? user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        user.Name = Regex.Replace(user.Name, @"\s+", " ").Trim();
        user.Password = Regex.Replace(user.Password, @"\s+", " ").Trim();
        user.Nickname = Regex.Replace(user.Nickname, @"\s+", " ").Trim();
        user.Email = Regex.Replace(user.Email, @"\s+", " ").Trim();
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(Guid? id, User? user)
    {
        if (user == null || id == null) throw new ArgumentNullException(nameof(user));
        user.Name = Regex.Replace(user.Name, @"\s+", " ").Trim();
        user.Password = Regex.Replace(user.Password, @"\s+", " ").Trim();
        user.Nickname = Regex.Replace(user.Nickname, @"\s+", " ").Trim();
        user.Email = Regex.Replace(user.Email, @"\s+", " ").Trim();
        var actualUser = await _context.Users.SingleOrDefaultAsync(p => p.Id == id);
        if (actualUser == null) return user;
        actualUser.Name = user.Name;
        actualUser.Password = user.Password;
        actualUser.Nickname = user.Nickname;
        actualUser.Email = user.Email;
        await _context.SaveChangesAsync();
        return actualUser;
    }

    public async Task<User?> DeleteUser(Guid id)
    {
        var userToDelete = await _context.Users
            .Where(s => s.Id == id)
            .SingleOrDefaultAsync();
        if (userToDelete == null) return userToDelete;
        _context.Remove(userToDelete!);
        await _context.SaveChangesAsync();
        return userToDelete;
    }
}