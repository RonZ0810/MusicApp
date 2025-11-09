using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Application.ArtistProfiles.Extensions;
using MusicApp.Application.ArtistProfiles.Interfaces;
using MusicApp.Application.ArtistProfiles.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.ArtistProfiles.Handlers;

public class GetArtistProfileHandler(IArtistProfileRepository artistRepository) : IQueryHandler<GetArtistProfileQuery, ArtistProfileDto?> {
    private readonly IArtistProfileRepository _artistRepository = artistRepository;
    public async Task<Result<ArtistProfileDto?>> Handle(GetArtistProfileQuery request, CancellationToken cancellationToken) {
        try {
            var artist = await _artistRepository.GetArtistProfileAsync(request.Id);
            if (artist == null) {
                return Result.Failure<ArtistProfileDto?>(Error.NotFound("Artist.NotFound", $"ArtistProfile not found with Id: {request.Id}"));
            }
            return Result.Success<ArtistProfileDto?>(artist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<ArtistProfileDto?>(Error.Failure("Artist.Failure", ex.Message));
        }
    }
}

