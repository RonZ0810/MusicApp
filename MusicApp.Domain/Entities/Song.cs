using MusicApp.Domain.Enums;

namespace MusicApp.Domain.Entities;

public class Song {
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string? CoverImageUrl { get; set; }

    public Genre Genre { get; set; }
    public DateTime UploadedAt { get; set; }

    // Spotify Integration
    public Spotify.SongInfo? SongInfo { get; set; }


    // Relationships
    public ArtistProfile ArtistProfile { get; set; } = null!;

}
