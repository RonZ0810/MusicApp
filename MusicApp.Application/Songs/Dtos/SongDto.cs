using MusicApp.Domain.Enums;

namespace MusicApp.Application.Songs.Dtos;

public record SongDto(
    Guid Id,
    string Title,
    string? Lyrics,
    string? FileUrl,
    string? CoverImageUrl,
    Genre Genre,
    TimeSpan? Duration,
    DateTime? ReleaseDate,
    string? SpotifyId,
    IEnumerable<Guid> ArtistIds,
    Guid? AlbumId
);

