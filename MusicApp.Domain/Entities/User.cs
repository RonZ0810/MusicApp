using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class User {
    public Guid Id { get; init; }
    public string Email { get; set; } = null!;
    public string DisplayName { get; set; } = null!;
    public string Password { get; set; } = null!;
    public UserRole Role { get; set; }

    // Spotify Integration
    public Spotify.UserInfo? UserInfo { get; set; }

}
