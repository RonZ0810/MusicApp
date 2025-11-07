using MusicApp.Application.Albums.Dtos;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Albums.Extensions;

public static class AlbumMappingExtensions {
    public static AlbumDto ToDto(this Album album) {
        return new AlbumDto(
            album.Id,
            album.Title,
            album.CoverImageUrl,
            album.ReleaseDate,
            album.SpotifyId,
            album.Artists.Select(a => a.Id),
            (album.Songs ?? new List<Song>()).Select(s => s.Id)
        );
    }
}
