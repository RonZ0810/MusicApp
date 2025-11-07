namespace MusicApp.Application.Songs.Dtos;

public record UpdateSongDto(
    Guid Id,
    string? SpotifyId
);

