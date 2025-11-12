using MusicApp.Application.Users.Dtos;

namespace MusicApp.Web.Services;

public interface IUserService {
    Task<string> GetUserRoleAsync();
    Task<UserDto?> GetCurrentUserAsync();
}
