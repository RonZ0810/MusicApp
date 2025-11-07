namespace MusicApp.Application.Albums.Dtos;

public record AlbumDto(
    Guid Id,
    string Title,
    string? CoverImageUrl,
    DateTime ReleaseDate,
    string? SpotifyId,
    IEnumerable<Guid> ArtistIds,
    IEnumerable<Guid> SongIds
);

