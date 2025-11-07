using MusicApp.Domain.Entities;

namespace MusicApp.Application.Albums.Services;

public interface IAlbumService {
    Task<Album?> GetAlbumAsync(Guid Id);
}

