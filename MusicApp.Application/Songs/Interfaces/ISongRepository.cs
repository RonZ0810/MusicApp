using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Songs.Interfaces;

public interface ISongRepository {
    IUnitOfWork UnitOfWork { get; }
    Task<Song?> GetSongAsync(Guid id);
    Task<IEnumerable<Song>> ListSongsAsync();
    void Add(Song song);
    void Update(Song song);
}

