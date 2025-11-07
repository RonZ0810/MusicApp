using MusicApp.Domain.Enums;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Users.Dtos;

public record UpdateUserDto(
    Guid Id,
    string Email,
    string DisplayName,
    string PasswordHash,
    string? SpotifyId
);
