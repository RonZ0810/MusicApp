using MusicApp.Application.Playlists.Commands;
using MusicApp.Application.Playlists.Dtos;
using MusicApp.Application.Playlists.Extensions;
using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Application.Playlists.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Handlers;


public class DeletePlaylistHandler(IPlaylistRepository playlistRepository) : ICommandHandler<DeletePlaylistCommand, bool> {
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    public async Task<Result<bool>> Handle(DeletePlaylistCommand request, CancellationToken cancellationToken) {

        var playlist = await _playlistRepository.GetPlaylistAsync(request.Id);

        if (playlist == null)
            throw new KeyNotFoundException($"Playlist {request.Id} was not found");

        _playlistRepository.Delete(request.Id);

        var success = await _playlistRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return success != 0;
    }
}
