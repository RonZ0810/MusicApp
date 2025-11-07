using MusicApp.Domain.Enums;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Users.Dtos;

public record UserDto(
    Guid Id,
    string Email,
    string DisplayName,
    string ProfileImageUrl,
    string PasswordHash,
    UserRole Role,
    string? SpotifyId,
    ICollection<Playlist> Playlists,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);
