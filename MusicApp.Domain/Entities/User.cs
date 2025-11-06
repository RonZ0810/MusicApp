using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class User {
    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public string Email { get; private set; } = null!;
    public string DisplayName { get; private set; } = null!;
    public string ProfileImageUrl { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public string? SpotifyId { get; private set; }

    public ICollection<Playlist> Playlists { get; private set; } = new List<Playlist>();

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // ----- METHODS ----- //
    private User() { }
    public static User Create(string email, string displayName, string passwordHash, string? spotifyId, UserRole role = UserRole.Listener) {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");
        if (string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentException("Display name is required");
        return new User {
            Id = Guid.NewGuid(),
            Email = email,
            DisplayName = displayName,
            PasswordHash = passwordHash,
            SpotifyId = spotifyId,
            Role = role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    public void Update(string? email, string? displayName, string? spotifyId, UserRole? role, ICollection<Playlist>? playlists) {
        bool updated = false;
        if (!string.IsNullOrWhiteSpace(email) && email != Email) {
            Email = email;
            updated = true;
        }
        if (!string.IsNullOrWhiteSpace(displayName) && displayName != DisplayName) {
            DisplayName = displayName;
            updated = true;
        }
        if (playlists != null && !playlists.Select(p => p.Id).ToHashSet().SetEquals(Playlists.Select(p => p.Id))) {
            Playlists = playlists;
            updated = true;
        }
        if (updated)
            UpdatedAt = DateTime.UtcNow;
    }
    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }
    public void ChangeRole(UserRole role) {
        Role = role;
    }
}
