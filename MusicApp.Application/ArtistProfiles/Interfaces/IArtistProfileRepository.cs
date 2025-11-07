using MusicApp.Application.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.ArtistProfiles.Interfaces;

public interface IArtistProfileRepository {
    IUnitOfWork UnitOfWork { get; }
    Task<ArtistProfile?> GetArtistProfileAsync(Guid id);
    Task<IEnumerable<ArtistProfile>> ListArtistProfilesAsync();
    void Add(ArtistProfile artistProfile);
    void Update(ArtistProfile artistProfile);
}

