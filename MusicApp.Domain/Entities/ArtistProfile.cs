namespace MusicApp.Domain.Entities;

public class ArtistProfile {
    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public User? User { get; private set; }

    public string StageName { get; private set; } = null!;
    // Spotify Integration
    public string? SpotifyId { get; private set; }

    // Relationships
    public ICollection<Song> Songs { get; private set; } = new List<Song>();
    public ICollection<Album> Albums { get; private set; } = new List<Album>();
    // ----- METHODS ----- //
    private ArtistProfile() { }
    public static ArtistProfile Create(User? user, string name, ICollection<Song>? songs, ICollection<Album>? albums) {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Artist Name is required");
        return new ArtistProfile {
            Id = Guid.NewGuid(),
            User = user,
            StageName = name,
            Songs = songs ?? new List<Song>(),
            Albums = albums ?? new List<Album>()
        };
    }
    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }

}
