namespace MusicApp.Application.ArtistProfiles.Dtos;

public record UpdateArtistProfileDto(
    Guid Id,
    string? SpotifyId
);

