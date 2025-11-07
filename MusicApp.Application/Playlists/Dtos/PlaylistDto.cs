namespace MusicApp.Application.Playlists.Dtos;

public record PlaylistDto(
    Guid Id,
    string Name,
    Guid UserId,
    IEnumerable<Guid> SongIds,
    string? SpotifyId,
    DateTime CreatedAt,
    DateTime? UpdatedAt
);

