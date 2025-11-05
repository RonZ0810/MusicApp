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

    private User() { }
    public static User Create(string email, string displayName, string passwordHash, string? spotifyId, UserRole role = UserRole.Listener) {
        return new User {
            Id = Guid.NewGuid(),
            DisplayName = displayName,
            Email = email,
            SpotifyId = spotifyId,
            Role = role,
            PasswordHash = passwordHash,
            ArtistProfile = new ArtistProfile()
        };
    }

    public void UpdateArtistProfile(ArtistProfile artistProfile) {
        ArtistProfile = artistProfile;
    }

    public void UpdateRole(UserRole role) {
        Role = role;
    }

    public void UpdateSpotifyId(string spotifyId) {
        SpotifyId = spotifyId;
    }

}
