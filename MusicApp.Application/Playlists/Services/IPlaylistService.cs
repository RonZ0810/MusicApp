using MusicApp.Domain.Entities;

namespace MusicApp.Application.Playlists.Services;

public interface IPlaylistService {
    Task<Playlist?> GetPlaylistAsync(Guid Id);
}

