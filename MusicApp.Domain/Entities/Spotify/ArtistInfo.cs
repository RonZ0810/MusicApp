namespace MusicApp.Domain.Entities.Spotify;

public class ArtistInfo {
    public string? ArtistId { get; set; } // e.g., "1Xyo4u8uXC1ZmMpatF05PJ"
    public int? Followers { get; set; }
    public string? ProfileUrl { get; set; }
    public string? Genres { get; set; } // comma-separated list
    public string? ImageUrl { get; set; } // high-res Spotify image
}
