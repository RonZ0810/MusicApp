namespace MusicApp.Domain.Entities;

public class Album {
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public Guid ArtistProfileId { get; set; }
    public string? CoverImageUrl { get; set; }
    public DateTime ReleaseDate { get; set; }

    // Spotify Integration
    public Spotify.AlbumInfo? AlbumInfo { get; set; }

    public ArtistProfile ArtistProfile { get; set; } = null!;
    public ICollection<Song> Songs { get; set; } = new List<Song>();
}
