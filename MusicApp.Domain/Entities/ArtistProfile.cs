namespace MusicApp.Domain.Entities;

public class ArtistProfile {
    public Guid Id { get; init; }
    public User User { get; private set; } = null!;

    public string StageName { get; set; } = null!;
    public string? ProfileImageUrl { get; set; } = string.Empty;

    // Spotify Integration
    public string? SpotifyId { get; set; }

    // Relationships
    public ICollection<Song> Songs { get; private set; } = new List<Song>();
}
