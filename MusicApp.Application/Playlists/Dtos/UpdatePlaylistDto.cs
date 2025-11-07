namespace MusicApp.Application.Playlists.Dtos;

public record UpdatePlaylistDto(
    Guid Id,
    string? Name,
    string? SpotifyId
);

