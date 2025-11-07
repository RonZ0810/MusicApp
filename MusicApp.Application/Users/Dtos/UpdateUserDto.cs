using MusicApp.Domain.Enums;

namespace MusicApp.Application.Users.Dtos;

public record UpdateUserDto(
    Guid Id,
    string? Email,
    string? DisplayName,
    string? ProfileImageUrl,
    UserRole? Role,
    string? SpotifyId
);
