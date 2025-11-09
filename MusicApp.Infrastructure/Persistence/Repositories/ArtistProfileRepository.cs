using Microsoft.EntityFrameworkCore;
using MusicApp.Application.ArtistProfiles.Interfaces;
using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Infrastructure.Persistence.Repositories;

public class ArtistProfileRepository(ApplicationDbContext context) : IArtistProfileRepository {
    public IUnitOfWork UnitOfWork => context;
    public async Task<ArtistProfile?> GetArtistProfileAsync(Guid id) => await context.ArtistProfiles.FindAsync(id);
    public async Task<IEnumerable<ArtistProfile>> ListArtistProfilesAsync() => await context.ArtistProfiles.AsNoTracking().ToListAsync();

    public void Add(ArtistProfile artistProfile) => context.ArtistProfiles.Add(artistProfile);

    public void Update(ArtistProfile artistProfile) => context.ArtistProfiles.Update(artistProfile);
}
