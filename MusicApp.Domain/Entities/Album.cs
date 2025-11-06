namespace MusicApp.Domain.Entities;

public class Album {

    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string? CoverImageUrl { get; init; }
    public DateTime ReleaseDate { get; init; }

    // Spotify Integration
    public string? SpotifyId { get; private set; }

    public ICollection<ArtistProfile> Artists { get; init; } = new List<ArtistProfile>();
    public ICollection<Song>? Songs { get; private set; } = new List<Song>();

    // ----- METHODS ----- //
    public Album() { }
    public static Album Create(string title, string? imageUrl, DateTime releaseDate, string? spotifyId, ICollection<ArtistProfile> artists, ICollection<Song>? songs) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");
        return new Album {
            Id = Guid.NewGuid(),
            Title = title,
            CoverImageUrl = imageUrl,
            ReleaseDate = releaseDate,
            Artists = artists,
            Songs = songs ?? new List<Song>(),
            SpotifyId = spotifyId
        };
    }

    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }

}
