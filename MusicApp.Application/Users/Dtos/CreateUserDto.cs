namespace MusicApp.Application.Users.Dtos;

public record CreateUserDto(
    string Email,
    string DisplayName,
    string PasswordHash,
    string PasswordSalt,
    string? SpotifyId
);
