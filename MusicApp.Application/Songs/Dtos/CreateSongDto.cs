using MusicApp.Domain.Enums;

namespace MusicApp.Application.Songs.Dtos;

public record CreateSongDto(
    string Title,
    Genre Genre,
    string? Lyrics,
    string? FileUrl,
    string? CoverImageUrl,
    string? SpotifyId,
    TimeSpan? Duration,
    DateTime? ReleaseDate
);

