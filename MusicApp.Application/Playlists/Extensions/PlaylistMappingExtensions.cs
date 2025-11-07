using MusicApp.Application.Playlists.Dtos;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Playlists.Extensions;

public static class PlaylistMappingExtensions {
    public static PlaylistDto ToDto(this Playlist playlist) {
        return new PlaylistDto(
            playlist.Id,
            playlist.Name,
            playlist.User.Id,
            playlist.Songs.Select(s => s.Id),
            playlist.SpotifyId,
            playlist.CreatedAt,
            playlist.UpdatedAt
        );
    }
}

