using MusicApp.Application.Users.Dtos;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Users.Extensions;

public static class UserMappingExtensions {
    public static UserDto ToDto(this User user) {
            return new UserDto(
                user.Id,
                user.Email,
                user.DisplayName,
                user.ProfileImageUrl,
                user.Role,
                user.SpotifyId,
                user.CreatedAt,
                user.UpdatedAt
            );
        }
}
