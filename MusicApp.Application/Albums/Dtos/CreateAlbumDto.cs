namespace MusicApp.Application.Albums.Dtos;

public record CreateAlbumDto(
    string Title,
    string? CoverImageUrl,
    DateTime ReleaseDate,
    string? SpotifyId
);

