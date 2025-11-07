namespace MusicApp.Application.Playlists.Dtos;

public record CreatePlaylistDto(
    string Name,
    Guid UserId,
    string? SpotifyId
);

