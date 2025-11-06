using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class Song {
    public Guid Id { get; init; }
    public string Title { get; private set; } = null!;
    public string? Lyrics { get; private set; }

    // Media
    public string? FileUrl { get; private set; }    // Local/hosted file (if not from Spotify)
    public string? CoverImageUrl { get; private set; }

    // Metadata
    public Genre Genre { get; private set; }
    public TimeSpan? Duration { get; private set; }
    public DateTime? ReleaseDate { get; private set; }

    // Spotify Integration
    public string? SpotifyId { get; private set; }
    // Relationships
    public ICollection<Guid> ArtistIds { get; private set; } = new List<Guid>();
    public ICollection<ArtistProfile> Artists { get; private set; } = new List<ArtistProfile>();

    public Album? Album { get; private set; }

    // Constructors
    private Song() { }

    public static Song Create(string title, Genre genre, ICollection<Guid> artistIds, string? fileUrl = null, string? coverImageUrl = null, string? spotifyId = null, TimeSpan? duration = null, DateTime? releaseDate = null) {
        return new Song {
            Id = Guid.NewGuid(),
            Title = title,
            Genre = genre,
            ArtistIds = artistIds,
            FileUrl = fileUrl,
            CoverImageUrl = coverImageUrl,
            SpotifyId = spotifyId,
            Duration = duration,
            ReleaseDate = releaseDate
        };
    }



}
