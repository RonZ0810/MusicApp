namespace MusicApp.Domain.Entities.Spotify;

public class SongInfo {
    public string? TrackId { get; set; } // e.g., "3n3Ppam7vgaVa1iaRUc9Lp"
    public string? PreviewUrl { get; set; } // 30s preview link
    public string? ExternalUrl { get; set; } // link to open on Spotify
    public string? AlbumId { get; set; }
    public string? ArtistId { get; set; }
}
