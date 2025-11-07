using MusicApp.Application.Songs.Dtos;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Songs.Extensions;

public static class SongMappingExtensions {
    public static SongDto ToDto(this Song song) {
        return new SongDto(
            song.Id,
            song.Title,
            song.Lyrics,
            song.FileUrl,
            song.CoverImageUrl,
            song.Genre,
            song.Duration,
            song.ReleaseDate,
            song.SpotifyId,
            song.Artists.Select(a => a.Id),
            song.Album?.Id
        );
    }
}

