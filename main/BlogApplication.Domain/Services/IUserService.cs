using BlogApplication.Domain.Entities;

namespace BlogApplication.Domain.Services;

public interface IUserService
{
    public Task<IEnumerable<User>> GetAllUsers();

    public Task<User?> GetUser(Guid id);

    public Task<User> SaveUser(User user);

    public Task<User> UpdateUser(Guid? id, User? user);

    public Task<User?> DeleteUser(Guid id);

}