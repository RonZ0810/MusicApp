using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.Albums.Interfaces;

public interface IAlbumRepository {
    IUnitOfWork UnitOfWork { get; }
    Task<Album?> GetAlbumAsync(Guid id);
    Task<IEnumerable<Album>> ListAlbumsAsync();
    void Add(Album album);
    void Update(Album album);
}

