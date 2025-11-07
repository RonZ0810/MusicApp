using MusicApp.Domain.Enums;

namespace MusicApp.Application.Users.Dtos;

public record UserDto(
    Guid Id,
    string Email,
    string DisplayName,
    string? ProfileImageUrl,
    UserRole Role,
    string? SpotifyId,
    DateTime CreatedAt,
    DateTime UpdatedAt
);
