using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class User {
    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public string Email { get; private set; } = null!;
    public string DisplayName { get; private set; } = null!;
    public string ProfileImageUrl { get; private set; } = null!;
    public string PasswordHash { get; private set; } = null!;
    public string PasswordSalt { get; private set; } = null!;
    public UserRole Role { get; private set; }
    public string? SpotifyId { get; private set; }

    public ICollection<Playlist> Playlists { get; private set; } = new List<Playlist>();

    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    // ----- METHODS ----- //
    private User() { }
    public static User Create(string email, string displayName, string passwordHash, string passwordSalt, string? spotifyId, UserRole role = UserRole.Listener) {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email is required");
        if (string.IsNullOrWhiteSpace(displayName))
            throw new ArgumentException("Display name is required");
        if (string.IsNullOrWhiteSpace(passwordHash))
            throw new ArgumentException("Password Hash cannot be empty");
        if (string.IsNullOrWhiteSpace(passwordSalt))
            throw new ArgumentException("Password Salt cannot be empty");
        return new User {
            Id = Guid.NewGuid(),
            Email = email,
            DisplayName = displayName,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            SpotifyId = spotifyId ?? string.Empty,
            Role = role,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }
    public void ChangePassword(string passwordHash, string passwordSalt) {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
    public void Update(string? email, string? displayName) {
        if (!string.IsNullOrWhiteSpace(email))
            Email = email;
        if (!string.IsNullOrWhiteSpace(displayName))
            DisplayName = displayName;
    }
    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }
    public void ChangeRole(UserRole role) => Role = role;
    public void AddPlaylist(Playlist playlist) => Playlists.Add(playlist);
    public void RemovePlaylist(Guid id) {
        var playlist = Playlists.FirstOrDefault(p => p.Id == id);
        if (playlist != null)
            Playlists.Remove(playlist);
    }
    public void UpdateProfileImageUrl(string newURL) => ProfileImageUrl = newURL;
    public void UpdatedAtTimestamp() => UpdatedAt = DateTime.UtcNow;
}
