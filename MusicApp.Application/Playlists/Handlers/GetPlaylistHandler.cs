using MusicApp.Application.Playlists.Dtos;
using MusicApp.Application.Playlists.Extensions;
using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Application.Playlists.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Handlers;

public class GetPlaylistHandler(IPlaylistRepository playlistRepository) : IQueryHandler<GetPlaylistQuery, PlaylistDto?> {
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    public async Task<Result<PlaylistDto?>> Handle(GetPlaylistQuery request, CancellationToken cancellationToken) {
        try {
            var playlist = await _playlistRepository.GetPlaylistAsync(request.Id);
            if (playlist == null) {
                return Result.Failure<PlaylistDto?>(Error.NotFound("Playlist.NotFound", $"Playlist not found with Id: {request.Id}"));
            }
            return Result.Success<PlaylistDto?>(playlist.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<PlaylistDto?>(Error.Failure("Playlist.Failure", ex.Message));
        }
    }
}

