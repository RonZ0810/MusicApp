namespace MusicApp.Domain.Entities.Spotify;

public class UserInfo {
    public User User { get; set; } = null!;

    public string SpotifyUserId { get; set; } = null!;
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }


}
