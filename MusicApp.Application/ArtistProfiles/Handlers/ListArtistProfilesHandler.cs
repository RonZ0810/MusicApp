using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Application.ArtistProfiles.Extensions;
using MusicApp.Application.ArtistProfiles.Interfaces;
using MusicApp.Application.ArtistProfiles.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.ArtistProfiles.Handlers;

public sealed class ListArtistProfilesHandler(IArtistProfileRepository artistRepository) : IQueryHandler<ListArtistProfilesQuery, IEnumerable<ArtistProfileDto>> {
    private readonly IArtistProfileRepository _artistRepository = artistRepository;
    public async Task<Result<IEnumerable<ArtistProfileDto>>> Handle(ListArtistProfilesQuery request, CancellationToken cancellationToken) {
        var artists = await _artistRepository.ListArtistProfilesAsync();
        var dtos = artists.Select(a => a.ToDto()).ToList();
        return dtos;
    }
}

