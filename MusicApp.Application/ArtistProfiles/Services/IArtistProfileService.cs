using MusicApp.Domain.Entities;

namespace MusicApp.Application.ArtistProfiles.Services;

public interface IArtistProfileService {
    Task<ArtistProfile?> GetArtistProfileAsync(Guid Id);
}

