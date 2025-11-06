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

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
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
            Role = role
        };
    }

    // ----- METHODS ----- //
    public void Update(string? email, string? displayName, string? spotifyId, UserRole? role) {
        if (!string.IsNullOrWhiteSpace(email)) Email = email;
        if (!string.IsNullOrWhiteSpace(displayName)) DisplayName = displayName;
        if (!string.IsNullOrWhiteSpace(spotifyId)) SpotifyId = spotifyId;
        if (role.HasValue) Role = role.Value;

        UpdatedAt = DateTime.UtcNow;
    }

    public void LinkSpotifyAccount(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
        UpdatedAt = DateTime.UtcNow;
    }
}
