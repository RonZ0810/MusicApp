namespace MusicApp.Domain.Entities;

public class ArtistProfile {
    public User User { get; set; } = null!;

    public string DisplayName { get; set; } = null!;
    public string? Bio { get; set; } = string.Empty;
    public string? ProfileImageUrl { get; set; } = string.Empty;
    public string? BannerUrl { get; set; }

    // Spotify Integration
    public Spotify.ArtistInfo? ArtistInfo { get; set; }

    public ICollection<Song> Songs { get; set; } = new List<Song>();
    public ICollection<Album> Albums { get; set; } = new List<Album>();
}
