using MusicApp.Domain.Entities;

namespace MusicApp.Application.Users.Services;

public interface IUserService {
    Task<User?> GetUserAsync(Guid Id);
}
