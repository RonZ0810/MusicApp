using Microsoft.EntityFrameworkCore;
using MusicApp.Application.Interfaces;
using MusicApp.Application.Songs.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Repositories;

public class SongRepository(ApplicationDbContext context) : ISongRepository {
    public IUnitOfWork UnitOfWork => context;

    public async Task<Song?> GetSongAsync(Guid id) => await context.Songs.FindAsync(id);

    public async Task<IEnumerable<Song>> ListSongsAsync() => await context.Songs.AsNoTracking().ToListAsync();

    public void Add(Song song) => context.Songs.Add(song);

    public void Update(Song song) => context.Songs.Update(song);
}
