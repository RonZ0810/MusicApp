using MusicApp.Application.Playlists.Commands;
using MusicApp.Application.Playlists.Dtos;
using MusicApp.Application.Playlists.Extensions;
using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Handlers;

public class UpdatePlaylistHandler(IPlaylistRepository playlistRepository) : ICommandHandler<UpdatePlaylistCommand, PlaylistDto> {
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    public async Task<Result<PlaylistDto>> Handle(UpdatePlaylistCommand request, CancellationToken cancellationToken) {
        try {
            var dto = request.UpdatePlaylistDto;
            var playlist = await _playlistRepository.GetPlaylistAsync(dto.Id);
            if (playlist == null) {
                return Result.Failure<PlaylistDto>(Error.NotFound("Playlist.NotFound", $"Playlist not found with Id: {dto.Id}"));
            }
            var changed = false;
            if (!string.IsNullOrWhiteSpace(dto.Name) && dto.Name != playlist.Name) {
                playlist.Update(dto.Name);
                changed = true;
            }
            if (!string.IsNullOrWhiteSpace(dto.SpotifyId) && dto.SpotifyId != playlist.SpotifyId) {
                playlist.ChangeSpotifyReference(dto.SpotifyId);
                changed = true;
            }
            if (changed) {
                _playlistRepository.Update(playlist);
                await _playlistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            }
            return Result.Success(playlist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<PlaylistDto>(Error.Failure("Playlist.Failure", ex.Message));
        }
    }
}

