namespace MusicApp.Domain.Entities;

public class Album {
    public Guid Id { get; init; }
    public required string Title { get; set; }
    public string? CoverImageUrl { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Spotify Integration
    public string? SpotifyId { get; set; }

    public ArtistProfile ArtistProfile { get; set; } = null!;
    public ICollection<Song> Songs { get; set; } = [];
}
