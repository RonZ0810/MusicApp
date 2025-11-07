namespace MusicApp.Application.ArtistProfiles.Dtos;

public record ArtistProfileDto(
    Guid Id,
    string StageName,
    Guid? UserId,
    string? SpotifyId,
    IEnumerable<Guid> SongIds,
    IEnumerable<Guid> AlbumIds
);

