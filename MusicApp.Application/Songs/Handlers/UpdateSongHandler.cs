using MusicApp.Application.Songs.Commands;
using MusicApp.Application.Songs.Dtos;
using MusicApp.Application.Songs.Extensions;
using MusicApp.Application.Songs.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Songs.Handlers;

public class UpdateSongHandler(ISongRepository songRepository) : ICommandHandler<UpdateSongCommand, SongDto> {
    private readonly ISongRepository _songRepository = songRepository;
    public async Task<Result<SongDto>> Handle(UpdateSongCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.UpdateSongDto;
            var song = await _songRepository.GetSongAsync(dto.Id);
            if (song == null) {
                return Result.Failure<SongDto>(Error.NotFound("Song.NotFound", $"Song not found with Id: {dto.Id}"));
            }
            var changed = false;
            if (!string.IsNullOrWhiteSpace(dto.SpotifyId) && dto.SpotifyId != song.SpotifyId) {
                song.ChangeSpotifyReference(dto.SpotifyId);
                changed = true;
            }
            if (changed) {
                _songRepository.Update(song);
                await _songRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Result.Success(song.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<SongDto>(Error.Failure("Song.Failure", ex.Message));
        }
    }
}

