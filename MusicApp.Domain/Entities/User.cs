using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class User {
    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public string Email { get; private set; } = null!;
    public string DisplayName { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public string? SpotifyId { get; private set; }

    public ICollection<Playlist> Playlists { get; private set; } = new List<Playlist>();

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // ----- CONSTRUCTOR ----- //
    private User() { }

    // ----- FACTORY ----- //
    public static User Create(string email, string displayName, string passwordHash, string? spotifyId, UserRole role = UserRole.Listener) {
        return new User {
            Id = Guid.NewGuid(),
            Email = email,
            DisplayName = displayName,
            PasswordHash = passwordHash,
            SpotifyId = spotifyId,
            Role = role,
            UpdatedAt = DateTime.UtcNow
        };
    }

    // ----- METHODS ----- //
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
        if (!string.IsNullOrWhiteSpace(spotifyId) && spotifyId != SpotifyId) {
            SpotifyId = spotifyId;
            updated = true;
        }
        if (role.HasValue && role.Value != Role) {
            Role = role.Value;
            updated = true;
        }
        if (playlists != null && !playlists.Select(p => p.Id).ToHashSet().SetEquals(Playlists.Select(p => p.Id))) {
            Playlists = playlists;
            updated = true;
        }
        if (updated)
            UpdatedAt = DateTime.UtcNow;
    }

    public void LinkSpotifyAccount(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
        UpdatedAt = DateTime.UtcNow;
    }
}
