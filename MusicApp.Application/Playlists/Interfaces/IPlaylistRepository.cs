using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Playlists.Interfaces;

public interface IPlaylistRepository {
    IUnitOfWork UnitOfWork { get; }
    Task<Playlist?> GetPlaylistAsync(Guid id);
    Task<IEnumerable<Playlist>> ListPlaylistsAsync();
    void Add(Playlist playlist);
    void Update(Playlist playlist);
    void Delete(Guid Id);
}

