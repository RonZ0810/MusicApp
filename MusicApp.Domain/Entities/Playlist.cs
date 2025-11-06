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

    // ----- CONSTRUCTOR ----- //
    private Playlist() { }

    // ----- FACTORY ----- //
    public static Playlist Create(string name, User user, string? spotifyId) {
        return new Playlist {
            Id = Guid.NewGuid(),
            Name = name,
            User = user,
            Songs = new List<Song>(),
            SpotifyId = spotifyId,
            CreatedAt = DateTime.UtcNow
        };
    }

    public void Update(string? name, ICollection<Song>? songs) {
        bool updated = false;
        if (!string.IsNullOrWhiteSpace(name) && Name != name) {
            Name = name;
            updated = true;
        }
        if (songs != null && !songs.Select(s => s.Id).ToHashSet().SetEquals(Songs.Select(s => s.Id))) {
            Songs = songs;
            updated = true;
        }
        if (updated)
            UpdatedAt = DateTime.UtcNow;
    }

}
