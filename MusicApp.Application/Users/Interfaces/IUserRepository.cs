using MusicApp.Domain.Entities;
using MusicApp.Application.Interfaces;
namespace MusicApp.Application.Users.Interfaces;

public interface IUserRepository {
    IUnitOfWork UnitOfWork { get; }
    Task<User?> GetUserAsync(Guid id);
    Task<IEnumerable<User>> ListUsersAsync();
    void Add(User user);
    void Update(User user);
}
