namespace MusicApp.Domain.Entities;

public class Playlist {
    public Guid Id { get; init; }
    public User User { get; set; } = null!;
    public ICollection<Song> Songs { get; set; } = new List<Song>();
    public string? SpotifyId { get; set; }

}
