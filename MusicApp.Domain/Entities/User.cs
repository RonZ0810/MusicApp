using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class User {
    public Guid Id { get; init; }
    public required string Email { get; set; }
    public required string DisplayName { get; set; }
    public required string PasswordHash { get; init; }
    public UserRole Role { get; set; }

    // Spotify Integration
    public string? SpotifyId { get; set; }
    public ArtistProfile? ArtistProfile { get; set; }

}
