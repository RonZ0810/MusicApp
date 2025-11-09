using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Albums.Interfaces;
using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Repositories;

public class AlbumRepository(ApplicationDbContext context) : IAlbumRepository {
    public IUnitOfWork UnitOfWork => context;
    public async Task<Album?> GetAlbumAsync(Guid id) => await context.Albums.FindAsync(id);
    public async Task<IEnumerable<Album>> ListAlbumsAsync() => await context.Albums.AsNoTracking().ToListAsync();
    public void Add(Album album) => context.Albums.Add(album);
    public void Update(Album album) => context.Albums.Update(album);
}
