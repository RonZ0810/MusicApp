using MusicApp.Application.ArtistProfiles.Commands;
using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Application.ArtistProfiles.Extensions;
using MusicApp.Application.ArtistProfiles.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.ArtistProfiles.Handlers;

public class UpdateArtistProfileHandler(IArtistProfileRepository artistRepository) : ICommandHandler<UpdateArtistProfileCommand, ArtistProfileDto> {
    private readonly IArtistProfileRepository _artistRepository = artistRepository;
    public async Task<Result<ArtistProfileDto>> Handle(UpdateArtistProfileCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.UpdateArtistProfileDto;
            var artist = await _artistRepository.GetArtistProfileAsync(dto.Id);
            if (artist == null) {
                return Result.Failure<ArtistProfileDto>(Error.NotFound("Artist.NotFound", $"ArtistProfile not found with Id: {dto.Id}"));
            }
            var changed = false;
            if (!string.IsNullOrWhiteSpace(dto.SpotifyId) && dto.SpotifyId != artist.SpotifyId) {
                artist.ChangeSpotifyReference(dto.SpotifyId);
                changed = true;
            }
            if (changed) {
                _artistRepository.Update(artist);
                await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Result.Success(artist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<ArtistProfileDto>(Error.Failure("Artist.Failure", ex.Message));
        }
    }
}

