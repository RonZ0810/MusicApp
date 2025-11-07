namespace MusicApp.Application.Users.Dtos;

public record CreateUserDto(
    string Email,
    string DisplayName,
    string PasswordHash,
    string? SpotifyId
);
