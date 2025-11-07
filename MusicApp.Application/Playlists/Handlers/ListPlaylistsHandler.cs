using MusicApp.Application.Playlists.Dtos;
using MusicApp.Application.Playlists.Extensions;
using MusicApp.Application.Playlists.Interfaces;
using MusicApp.Application.Playlists.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Playlists.Handlers;

public sealed class ListPlaylistsHandler(IPlaylistRepository playlistRepository) : IQueryHandler<ListPlaylistsQuery, IEnumerable<PlaylistDto>> {
    private readonly IPlaylistRepository _playlistRepository = playlistRepository;
    public async Task<Result<IEnumerable<PlaylistDto>>> Handle(ListPlaylistsQuery request, CancellationToken cancellationToken) {
        var playlists = await _playlistRepository.ListPlaylistsAsync();
        var dtos = playlists.Select(p => p.ToDto()).ToList();
        return dtos;
    }
}

