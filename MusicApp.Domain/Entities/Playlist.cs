using System.Net;

namespace MusicApp.Domain.Entities;

public class Playlist {
    // ----- PROPERTIES -----
    public Guid Id { get; init; }
    public string Name { get; private set; } = null!;
    public User User { get; init; } = null!;
    public ICollection<Song> Songs { get; private set; } = new List<Song>();
    public string? SpotifyId { get; private set; }

    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    // ----- METHODS ----- //
    private Playlist() { }
    public static Playlist Create(string name, User user, string? spotifyId) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Playlist name is required");
        return new Playlist {
            Id = Guid.NewGuid(),
            Name = name,
            User = user,
            Songs = new List<Song>(),
            SpotifyId = spotifyId,
            CreatedAt = DateTime.UtcNow
        };
    }
    public void Update(string? name) {
        bool updated = false;
        if (!string.IsNullOrWhiteSpace(name) && Name != name) {
            Name = name;
            updated = true;
        }
        if (updated)
            UpdatedAt = DateTime.UtcNow;
    }

    public void AddSong(Song song) {
        if (!Songs.Any(s => s.Id == song.Id)) {
            Songs.Add(song);
        }
    }

    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }

}
