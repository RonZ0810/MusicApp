using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.ArtistProfiles.Extensions;

public static class ArtistProfileMappingExtensions {
    public static ArtistProfileDto ToDto(this ArtistProfile artist) {
        return new ArtistProfileDto(
            artist.Id,
            artist.StageName,
            artist.User?.Id,
            artist.SpotifyId,
            artist.Songs.Select(s => s.Id),
            artist.Albums.Select(a => a.Id)
        );
    }
}

