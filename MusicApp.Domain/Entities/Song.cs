using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class Song {
    public Guid Id { get; init; }
    public string Title { get; init; } = null!;
    public string FileUrl { get; init; } = null!;
    public string? CoverImageUrl { get; init; }
    public Genre Genre { get; init; }
    // Spotify Integration
    public string? SpotifyId { get; set; }
    // Relationships
    public ArtistProfile ArtistProfile { get; init; } = null!;
    public Album? Album { get; set; }

}
