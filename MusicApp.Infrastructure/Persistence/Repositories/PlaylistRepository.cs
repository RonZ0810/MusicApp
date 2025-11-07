using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Interfaces;

namespace MusicApp.Infrastructure.Persistence.Repositories;

public class PlaylistRepository(ApplicationDbContext context) : IPlaylistRepository {
    public IUnitOfWork UnitOfWork => context;
    public async Task<Playlist?> GetPlaylistAsync(Guid id) => await context.Playlists.FindAsync(id);
    public async Task<IEnumerable<Playlist>> ListPlaylistsAsync() => await context.Playlists.AsNoTracking().ToListAsync();
    public void Add(Playlist playlist) => context.Playlists.Add(playlist);
    public void Update(Playlist playlist) => context.Playlists.Update(playlist);
    public void Delete(Guid id) {
        var entity = context.Playlists.Find(id);
        if (entity != null)
            context.Playlists.Remove(entity);
    }
}
