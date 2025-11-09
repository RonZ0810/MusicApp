using MusicApp.Application.ArtistProfiles.Commands;
using MusicApp.Application.ArtistProfiles.Dtos;
using MusicApp.Application.ArtistProfiles.Extensions;
using MusicApp.Application.ArtistProfiles.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Domain.Entities;

namespace MusicApp.Application.ArtistProfiles.Handlers;

public class CreateArtistProfileHandler(IArtistProfileRepository artistRepository) : ICommandHandler<CreateArtistProfileCommand, ArtistProfileDto> {
    private readonly IArtistProfileRepository _artistRepository = artistRepository;
    public async Task<Result<ArtistProfileDto>> Handle(CreateArtistProfileCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.CreateArtistProfileDto;
            if (string.IsNullOrWhiteSpace(dto.StageName)) {
                return Result.Failure<ArtistProfileDto>(Error.Validation("Artist.Validation", "StageName is required."));
            }
            var artist = ArtistProfile.Create(null, dto.StageName, new List<Song>(), new List<Album>());
            if (!string.IsNullOrWhiteSpace(dto.SpotifyId)) {
                artist.ChangeSpotifyReference(dto.SpotifyId);
            }
            _artistRepository.Add(artist);
            await _artistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success(artist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<ArtistProfileDto>(Error.Failure("Artist.Failure", ex.Message));
        }
    }
}

