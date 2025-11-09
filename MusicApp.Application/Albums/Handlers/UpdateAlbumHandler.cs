using MusicApp.Application.Albums.Commands;
using MusicApp.Application.Albums.Dtos;
using MusicApp.Application.Albums.Extensions;
using MusicApp.Application.Albums.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Handlers;

public class UpdateAlbumHandler(IAlbumRepository albumRepository) : ICommandHandler<UpdateAlbumCommand, AlbumDto> {
    private readonly IAlbumRepository _albumRepository = albumRepository;
    public async Task<Result<AlbumDto>> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.UpdateAlbumDto;
            var album = await _albumRepository.GetAlbumAsync(dto.Id);
            if (album == null) {
                return Result.Failure<AlbumDto>(Error.NotFound("Album.NotFound", $"Album not found with Id: {dto.Id}"));
            }
            var changed = false;
            if (!string.IsNullOrWhiteSpace(dto.SpotifyId) && dto.SpotifyId != album.SpotifyId) {
                album.ChangeSpotifyReference(dto.SpotifyId);
                changed = true;
            }
            if (changed) {
                _albumRepository.Update(album);
                await _albumRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Result.Success(album.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<AlbumDto>(Error.Failure("Album.Failure", ex.Message));
        }
    }
}

