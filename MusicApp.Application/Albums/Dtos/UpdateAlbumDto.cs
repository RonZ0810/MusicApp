namespace MusicApp.Application.Albums.Dtos;

public record UpdateAlbumDto(
    Guid Id,
    string? SpotifyId
);

