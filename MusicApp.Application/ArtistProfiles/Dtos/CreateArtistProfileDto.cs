namespace MusicApp.Application.ArtistProfiles.Dtos;

public record CreateArtistProfileDto(
    string StageName,
    string? SpotifyId
);

