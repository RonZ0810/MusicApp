using MusicApp.Application.Songs.Dtos;
using MusicApp.Application.Songs.Extensions;
using MusicApp.Application.Songs.Interfaces;
using MusicApp.Application.Songs.Queries;
using MusicApp.Cqrs.Core;
using MusicApp.Cqrs.Interfaces;

namespace MusicApp.Application.Songs.Handlers;

public sealed class ListSongsHandler(ISongRepository songRepository) : IQueryHandler<ListSongsQuery, IEnumerable<SongDto>> {
    private readonly ISongRepository _songRepository = songRepository;
    public async Task<Result<IEnumerable<SongDto>>> Handle(ListSongsQuery request, CancellationToken cancellationToken) {
        var songs = await _songRepository.ListSongsAsync();
        var dtos = songs.Select(s => s.ToDto()).ToList();
        return dtos;
    }
}

