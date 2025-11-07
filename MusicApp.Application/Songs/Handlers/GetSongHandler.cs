using MusicApp.Application.Songs.Dtos;
using MusicApp.Application.Songs.Extensions;
using MusicApp.Application.Songs.Interfaces;
using MusicApp.Application.Songs.Queries;
using MusicApp.Cqrs.Interfaces;
using MusicApp.Cqrs.Core;

namespace MusicApp.Application.Songs.Handlers;

public class GetSongHandler(ISongRepository songRepository) : IQueryHandler<GetSongQuery, SongDto?> {
    private readonly ISongRepository _songRepository = songRepository;
    public async Task<Result<SongDto?>> Handle(GetSongQuery request, CancellationToken cancellationToken) {
        try {
            var song = await _songRepository.GetSongAsync(request.Id);
            if (song == null) {
                return Result.Failure<SongDto?>(Error.NotFound("Song.NotFound", $"Song not found with Id: {request.Id}"));
            }
            return Result.Success<SongDto?>(song.ToDto());
        }
        catch (Exception ex) {
            return Result.Failure<SongDto?>(Error.Failure("Song.Failure", ex.Message));
        }
    }
}

