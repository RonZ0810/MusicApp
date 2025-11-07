using MusicApp.Domain.Entities;

namespace MusicApp.Application.Songs.Services;

public interface ISongService {
    Task<Song?> GetSongAsync(Guid Id);
}

