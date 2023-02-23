using BlogApplication.Domain.Entities;
using BlogApplication.Domain.Repositories;
using BlogApplication.Domain.Services;

namespace BlogApplication.Application.Services;

public class UserService : IUserService
{
    
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<IEnumerable<User>> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }

    public Task<User?> GetUser(Guid id)
    {
        return _userRepository.GetUser(id);
    }

    public Task<User> SaveUser(User user)
    {
        return _userRepository.SaveUser(user);
    }

    public Task<User> UpdateUser(Guid? id, User? user)
    {
        return _userRepository.UpdateUser(id, user);
    }

    public Task<User?> DeleteUser(Guid id)
    {
        return _userRepository.DeleteUser(id);
    }
}