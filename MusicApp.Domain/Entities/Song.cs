using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class Song {
    // ----- PROPERTIES ----- //
    public Guid Id { get; init; }
    public string Title { get; private set; } = null!;
    public string? Lyrics { get; private set; }
    public string? FileUrl { get; private set; }    // Local/hosted file (if not from Spotify)
    public string? CoverImageUrl { get; private set; }
    public Genre Genre { get; private set; }
    public TimeSpan? Duration { get; private set; }
    public DateTime? ReleaseDate { get; private set; }
    public string? SpotifyId { get; private set; }
    public ICollection<ArtistProfile> Artists { get; private set; } = new List<ArtistProfile>();
    public Album? Album { get; private set; }

    // ---- METHODS ---- //
    private Song() { }

    public static Song Create(string title, Genre genre, ICollection<ArtistProfile> artists, string? fileUrl = null, string? coverImageUrl = null, string? spotifyId = null, TimeSpan? duration = null, DateTime? releaseDate = null) {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Title is required");
        return new Song {
            Id = Guid.NewGuid(),
            Title = title,
            Genre = genre,
            FileUrl = fileUrl,
            CoverImageUrl = coverImageUrl,
            SpotifyId = spotifyId,
            Duration = duration,
            ReleaseDate = releaseDate,
            Artists = artists
        };
    }

    public void ChangeSpotifyReference(string spotifyId) {
        if (string.IsNullOrWhiteSpace(spotifyId))
            throw new ArgumentException("Spotify ID cannot be empty.");
        SpotifyId = spotifyId;
    }

}
