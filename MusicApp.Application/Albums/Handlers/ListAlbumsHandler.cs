using MusicApp.Application.Albums.Dtos;
using MusicApp.Application.Albums.Extensions;
using MusicApp.Application.Albums.Interfaces;
using MusicApp.Application.Albums.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Albums.Handlers;

public sealed class ListAlbumsHandler(IAlbumRepository albumRepository) : IQueryHandler<ListAlbumsQuery, IEnumerable<AlbumDto>> {
    private readonly IAlbumRepository _albumRepository = albumRepository;
    public async Task<Result<IEnumerable<AlbumDto>>> Handle(ListAlbumsQuery request, CancellationToken cancellationToken) {
        var albums = await _albumRepository.ListAlbumsAsync();
        var dtos = albums.Select(a => a.ToDto()).ToList();
        return dtos;
    }
}

